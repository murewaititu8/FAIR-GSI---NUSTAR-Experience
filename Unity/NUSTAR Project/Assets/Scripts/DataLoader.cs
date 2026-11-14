using System.IO;
using UnityEngine;

// One isotope's info. The field names must match the keys in isotopes.json.
[System.Serializable]
public class Isotope
{
    public int z;              // protons
    public int n;              // neutrons
    public string symbol;
    public double half_life_s; // -1 means stable or unknown
    public bool is_stable;     // true for stable isotopes
    public string decay_mode;  // main decay type, empty if none
}

// The JSON is one object holding a list, so we mirror that shape.
[System.Serializable]
public class IsotopeDatabase
{
    public Isotope[] isotopes;
}

public class DataLoader : MonoBehaviour
{
    // static means any other script can read it as DataLoader.Database
    public static IsotopeDatabase Database;

    void Awake()
    {
        // Build the path to the JSON file inside the StreamingAssets folder.
        string path = Path.Combine(Application.streamingAssetsPath, "isotopes.json");

        // Read the whole file as text, then turn that text into C# objects.
        Database = JsonUtility.FromJson<IsotopeDatabase>(File.ReadAllText(path));
        Debug.Log("Loaded " + Database.isotopes.Length + " isotopes");

        // Test: iron-56 has 26 protons and 30 neutrons. It should be stable.
        foreach (Isotope iso in Database.isotopes)
        {
            if (iso.z == 26 && iso.n == 30)
            {
                Debug.Log(iso.symbol + " stable? " + iso.is_stable);
            }
        }
    }
}
