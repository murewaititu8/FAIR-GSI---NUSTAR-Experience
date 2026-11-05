# Job: turn the raw IAEA table into the small JSON file that Unity reads.

import json
from pathlib import Path

import pandas as pd

RAW_CSV = Path("iaea_ground_states.csv")
OUT_JSON = Path("../Unity/Assets/StreamingAssets/isotopes.json")  # adjust to your layout

# Change this if your printed column list shows a different name.
# Set it to None to skip decay modes for now.
DECAY_COLUMN = "decay_1"


def clean_half_life(row):
    """Return (is_stable, half_life_seconds). Seconds is -1 when not applicable."""
    if row.half_life == "STABLE":
        return True, -1.0                 # stable: no half-life exists
    if pd.isna(row.half_life_sec):
        return False, -1.0                # unknown: not stable, just not measured
    return False, float(row.half_life_sec)


def clean_text(value):
    """Empty cells arrive as NaN (a 'not a number' marker). Turn them into ''."""
    return "" if pd.isna(value) else str(value)


def main():
    data = pd.read_csv(RAW_CSV)
    isotopes = []

    for row in data.itertuples():
        is_stable, half_life_s = clean_half_life(row)
        isotopes.append({
            "z": int(row.z),                   # protons
            "n": int(row.n),                   # neutrons
            "symbol": clean_text(row.symbol),
            "is_stable": is_stable,
            "half_life_s": half_life_s,        # -1 = stable or unknown, use is_stable to tell
            "decay_mode": clean_text(getattr(row, DECAY_COLUMN)) if DECAY_COLUMN else "",
        })

    OUT_JSON.parent.mkdir(parents=True, exist_ok=True)
    with open(OUT_JSON, "w", encoding="utf-8") as f:
        json.dump({"isotopes": isotopes}, f, indent=1)

    # --- Sanity checks: read these numbers, don't just skim them ---
    stable = sum(i["is_stable"] for i in isotopes)
    unknown = sum((not i["is_stable"]) and i["half_life_s"] < 0 for i in isotopes)
    print("Total isotopes:", len(isotopes))
    print("Stable:", stable, "| Unknown half-life:", unknown)
    print("Written to:", OUT_JSON.resolve())
    for z, n in [(26, 30), (6, 8)]:            # iron-56 and carbon-14
        print([i for i in isotopes if i["z"] == z and i["n"] == n])


main()
