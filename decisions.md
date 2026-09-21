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
