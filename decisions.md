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

: Requirements.txt was invalid because of numpy as np so I changed it to just numpy

: Data source shortlist so far: IAEA LiveChart CSV API (easy for pandas and data group needed is ground_states.)
