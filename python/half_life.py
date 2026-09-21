import numpy as np

half_life = 10.0
nuclei_no = 1000

np.random.seed(42)
# Using this to confirm if the script still works after edits and to reduce chances of confusion when debugging.

ln2 = np.log(2)
#assigning logarithm of 2 into variable

scale = half_life / ln2
# Converting the half life into an average lifetime

timesofDecay = np.random.exponential(scale, size = nuclei_no)
# Generating 1000 random lifetimes following decay pattern
