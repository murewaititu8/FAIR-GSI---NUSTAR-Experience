import pandas as pd

df = pd.read_csv("iaea_ground_states.csv")

print("total rows:", len(df))
print("rows marked STABLE:", (df["half_life"] == "STABLE").sum())
print("rows with an empty half_life:", df["half_life"].isna().sum())

# half_life holds numbers AND words. Show any words (other than numbers).
as_number = pd.to_numeric(df["half_life"], errors="coerce")
words = df.loc[as_number.isna() & df["half_life"].notna(), "half_life"]
print("\nword values in half_life:")
print(words.value_counts())

# Rows that are not STABLE but have no value in seconds
not_stable = df["half_life"] != "STABLE"
no_seconds = df["half_life_sec"].isna()
print("\nnot stable AND no seconds value:", (not_stable & no_seconds).sum())

# Is decay_1 really the biggest share? Count rows where decay_2 beats it.
bigger = (df["decay_2_%"] > df["decay_1_%"]).sum()
print("rows where decay_2 % is bigger than decay_1 %:", bigger)

# The most common decay_1 codes
print("\ncommon decay_1 values:")
print(df["decay_1"].value_counts().head(12))
