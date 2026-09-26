import pandas as pd

import urllib.request

url = "https://nds.iaea.org/relnsd/v1/data?fields=ground_states&nuclides=all"
# IAEA data website

request = urllib.request.Request(url, headers = {"User-Agent": "Mozilla/5.0"})
# Avoiding errors when requesting

data = pd.read_csv(urllib.request.urlopen(request))
# Putting the response in a pandas table

data.to_csv("iaea_ground_states.csv", index = False)
# Saving local copy

print("Rows (isotopes) downloaded:", len(data))

print("Column names:", list(data.columns))

print(data[["z", "n", "symbol", "half_life", "half_life_sec"]].head(10 ))
