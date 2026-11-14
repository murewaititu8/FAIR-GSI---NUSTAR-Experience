import json
import pandas as pd

df = pd.read_csv("iaea_ground_states.csv")

# Turn the seconds column into a plain number; empty cells become NaN.
seconds = pd.to_numeric(df["half_life_sec"], errors="coerce")

isotopes = []
for i in range(len(df)):
    row = df.iloc[i]

    # True only when the table says the word STABLE.
    is_stable = (row["half_life"] == "STABLE")

    # -1 means "no half-life number" (stable or unknown), as before.
    half_life_s = -1.0 if pd.isna(seconds.iloc[i]) else float(seconds.iloc[i])

    # Main decay mode, or an empty string if the cell is empty.
    decay_mode = "" if pd.isna(row["decay_1"]) else str(row["decay_1"])

    isotopes.append({
        "z": int(row["z"]),
        "n": int(row["n"]),
        "symbol": str(row["symbol"]),
        "half_life_s": half_life_s,
        "is_stable": bool(is_stable),
        "decay_mode": decay_mode,
    })

# Unity's JsonUtility needs one object that holds the list.
with open("isotopes_new.json", "w") as f:
    json.dump({"isotopes": isotopes}, f)

# Quick self-check
print("exported:", len(isotopes))
print("stable:", sum(1 for iso in isotopes if iso["is_stable"]))
print("iron-56:", [iso for iso in isotopes if iso["z"] == 26 and iso["n"] == 30])
