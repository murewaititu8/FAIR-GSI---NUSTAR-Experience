using UnityEngine;

public class IsotopeDatabase : MonoBehaviour{
    // Isotopes Array
    public Isotope[] isotopes;

    void Start(){
        Debug.Log("The IsotopeDatabase holds " + isotopes.Length + " isotopes");

        foreach (Isotope iso in isotopes){
            Debug.Log(iso.isotopeName + " / Print" + iso.Line());
        }
    }
}
