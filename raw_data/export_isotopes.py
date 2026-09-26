import pandas as pd
import json
import os

data = pd.read_csv("iaea_ground_states.csv")

isotopes = []

for row in data.itertuples():
    if row.half_life == "STABLE":
        half_life_s = -1

    elif pd.isna(row.half_life_sec):
        half_life_s = -1

    else:
        half_life_s = float(row.half_life_sec)

    isotopes.append({
    "z": int(row.z),
    "n": int(row.n),
    "symbol": row.symbol,
    "half_life_s": half_life_s
    })


output = {"isotopes": isotopes}

with open("isotopes.json", "w") as f:
    json.dump(output, f, indent = 2)

print("Isotopes written:", len(isotopes))
print("Example entry:", isotopes[0])
print("Saved to:", os.path.abspath("isotopes.json"))
