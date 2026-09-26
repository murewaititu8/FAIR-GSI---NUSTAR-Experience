21 Sep 26
: Named number of nuclei as nuclei_no for simplicity

: np.random.seed() is being used as a barrier of confusion when making changes and debugging between python and unity later in the project.

: log(2) assigned to ln2

: timesofDecay basically does 1000 independent random generations of numbers with no real reference to limits of what it could be.
: Producers a pattern in many results, comparable to popcorn idea where 1000 random pops happen but histogram would show a predictable shape every time

Sources:
Half life:
  Wikipedia, "Half-life" — https://en.wikipedia.org/wiki/Half-life
    Good general-audience explanation of the half-life/mean-lifetime relationship and why decay is random per-nucleus but predictable in bulk.

  Two State Radioactive Decay simulation, Open Source Physics @ Singapore — https://sg.iwant2study.org/ospsg/index.php/interactive-resources/physics/06-modern-physics/02-nuclear/315-decaychangenwee
    Shows the same half-life/decay-constant relationship (T½ = ln2/λ) used in an existing teaching simulation.


24 Sep 26
: Changed np.random.seed(42) to rng and rng.exponential() because first option would not work with a big file. Second option gives the opportunity for the seed to be changed very easily without looking at the code too closely

: Half life check is = median of decay times (the moment half the nuclei is dead.) Second check = count of survivors at t = half_life (expecting about half)

: exponential because real nuclei have no memory. This means nucleus decay times follow an exponential distribution. Histogram is the tallest at the start and falls smoothly. Shown in half life test runs (more nuclei results in clearer exponential distribution.)
No memory = a nucleus that's survived 5s is just as likely to decay in the next second as a new one - why one formula covers every isotope, just with a different half-life.

: Requirements.txt was invalid because of numpy as np so I changed it to just numpy

: Data source shortlist so far: IAEA LiveChart CSV API (easy for pandas and data group needed is ground_states.)

: Ran half_life.py at 1000 and again at 10,000,000 nuclei to check simulation against theory at different scales.

At 1000, the nuclei on the histogram wobbled slightly above and below theory curve. This shows randomness in this test.

At 10,000,000, nuclei bars sat almost exactly on the curve. No visible wobbles were present confirming that the more nuclei that are simulated, the more visible the predictable exponential pattern is.
Core idea behind Chapter 4 - individually random, collectively predictable.


26 Sep 26
: Isotope export is working well - 3386 rows of data in isotopes.json which is matching the download from IAEA

: Real IAEA data has three states, not two - "STABLE" (text), a real half-life number, or blank/NaN (unmeasured, not stable). Kept -1 for both stable and unknown for now since decay_mode (which would tell them apart) isn't needed until later chapters.

: Dropped decay_mode from Python export and Unity Isotope class - not needed for any minimum-version chapter, only later ones (Ch1 colour toggle, Ch5).

: Fixed index = "False" bug in export_isotopes.py - had written the string "False" not the boolean False. Non-empty strings are truthy in Python, so pandas kept writing the index column anyway.

: .gitignore was at repo root with root-relative patterns (e.g. /[Ll]ibrary/), so it never matched Unity's cache folders one level down at Unity/NUSTAR Project/Library/. 35k generated files were about to get tracked. Moved .gitignore into Unity/NUSTAR Project/, confirmed via git status that Library, Temp, Logs, UserSettings are now ignored.

: Found .DS_Store (macOS junk file) had been tracked. Removed it, added to root .gitignore.

: Consolidated python scripts into one raw_data/ folder instead of splitting across repo root and a separate python/ folder.

: Created the Unity project using Universal 3D template (URP), inside a Unity/ subfolder of the repo.

: Wrote DataLoader.cs - loads isotopes.json from StreamingAssets at scene start (Awake()). Used JsonUtility to convert JSON into Isotope/IsotopeDatabase objects, field names matching the Python export exactly.

: First attempt printed nothing to console - script wasn't attached to a GameObject, so Awake() never ran. Created a DataManager GameObject, attached DataLoader, replayed - console printed "Loaded 3386 isotopes", matching Python's count.
Confirms full data pipeline end to end: IAEA -> Python -> Unity, counts matching at every step.
