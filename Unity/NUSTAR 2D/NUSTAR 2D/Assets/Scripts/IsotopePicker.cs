using UnityEngine;

// One button per Isotope

public class IsotopePicker : MonoBehaviour{
    // Uses button in prefab folder
    public IsotopeButton buttonPrefab;
    // Buttongrid object that has grid layout group component
    public Transform buttonGrid;
    // Filled in isotopes in systems object
    public IsotopeDatabase database;
    public InfoCard card;
    // Colors based on index 0 coldest 7 warmest.
    public Color[] bandColors;

    void Start(){
        foreach (Isotope isotope in database.isotopes){
            if (isotope.Band() < 0 || isotope.Band() >= bandColors.Length)
            {
                Debug.Log("Band out of range for" + isotope.isotopeName);
                // Continues foreach.
                continue;
            }

            // Gives copy of the prefab with button grid
            IsotopeButton newButton = Instantiate(buttonPrefab, buttonGrid);

            // Gives it its color card and specific name
            newButton.Setup(isotope, card, bandColors[isotope.Band()]);
        }
    }


}
