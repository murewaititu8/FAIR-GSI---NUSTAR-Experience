import numpy as np
#Random number generator
import matplotlib.pyplot as plt
#Histogram drawer

# Settings

half_life = 10.0
# Time in seconds for half life
nuclei_no = 1000
# How many nuclei are being simulated
seed = 42
# Fixed seed for reproducability when debugging

# Random number generator

rng = np.random.default_rng(seed)
# Generator that remembers place in random sequence

# Simulating decays

ln2 = np.log(2)
#assigning logarithm of 2 into variable

mean_lifetime = half_life / ln2
# Converting the half life into an average lifetime

decay_times = rng.exponential(mean_lifetime, size = nuclei_no)
# Generating 1000 random lifetimes following decay pattern

# Checking for median (the moment half of the nuclei are gone)

measured_half_life = np.median(decay_times)
percent_off = abs(measured_half_life - half_life) / half_life * 100
# abs() removes + or - sign
# Dividing by half_life turns gap into fraction. * 100 turns into percentage

print("Nuclei simulated: ", nuclei_no)
print("Half life asked for: ", half_life, "s")
print("Half-life that was measured: ", round(measured_half_life, 2), "s")
print("The difference: ", round(percent_off, 1), "%")


# Counting remaining nuclei after one round

survivors = 0
for t in decay_times:
    if t > half_life:
        survivors = survivors + 1
# Checks each nucleus. If it survived it is counted in survivors.

print("Still not gone at", half_life, "s:", survivors, "of ", nuclei_no, "(expecting about ", nuclei_no // 2, ")")


# Histogram

bin_width = 2.0
last_time = 60.0
bin_edges = np.arange(0, last_time + bin_width, bin_width)
# Each bar consists of how many nuclei were gone within a 2 second window.

plt.hist(decay_times, bins = bin_edges, color = "orange", edgecolor = "white", label = "Simulated deaths")


curve_x = []

curve_y = []

for i in range(len(bin_edges) - 1):
    start = bin_edges[i]
    end = bin_edges[i + 1]
    expected = nuclei_no * (np.exp(-start / mean_lifetime) - np.exp(-end / mean_lifetime))
    curve_x.append((start + end) / 2)
    # Middle of the slide
    curve_y.append(expected)

plt.plot(curve_x, curve_y, color = "Black", linewidth = 2, label = "What the theory predicts")

plt.xlabel("Time until pop (s)")

plt.ylabel("Number of nuclei dead in each 2.0s window")

plt.title("Example of popcorn physics: " + str(nuclei_no) + " nuclei, half-life " + str(half_life) + " s")

plt.legend()

plt.show()
