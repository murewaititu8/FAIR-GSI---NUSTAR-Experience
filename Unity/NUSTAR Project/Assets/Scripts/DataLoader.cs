using UnityEngine;
using System.IO;

[System.Serializable]
/* System.Serializable means it can be turned into a JSON string and vice versa. */

public class Isotope
{
    public int z; // Proton Count
    public int n; // Neutron Count
    public string symbol; // Symbol

    public double half_life_s; // Decimal number for half-life in seconds
}

[System.Serializable]
public class IsotopeDatabase
{
    public Isotope[] isotopes;
}
public class DataLoader : MonoBehaviour
{
    public static IsotopeDatabase Database;

    void Awake()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "isotopes.json");
        Database = JsonUtility.FromJson<IsotopeDatabase>(File.ReadAllText(path));
        Debug.Log("Loaded " + Database.isotopes.Length + " isotopes");
    }
}
