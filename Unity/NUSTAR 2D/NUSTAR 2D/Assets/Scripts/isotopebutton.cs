using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IsotopeButton : MonoBehaviour{
    private Isotope isotope;
    private InfoCard infocard;

    public void Setup(Isotope isotopeToShow, InfoCard card, Color bandsColor)
    {
        isotope = isotopeToShow;
        infocard = card;

        // Writes the name of the isotope into the Text.
        GetComponentInChildren<TextMeshProUGUI>().text = isotope.isotopeName;

        // Decides the color of the button based on its band
        GetComponent<Image>().color = bandsColor;

        // Reads the click
        GetComponent<Button>().onClick.AddListener(OnClicked);
    }

    public void OnClicked(){
        infocard.ShowIsotope(isotope);
    }
}
