using UnityEngine;
using TMPro;

public class InfoCard : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI answerText;

    // Seconds the pop takes
    public float popDuration = 0.25f;
    // The card starts a bit small then grows to normal size
    public float startScale = 0.85f;

    private Isotope currentIsotope;
    private float popTimer;

    void Start()
    {
        popTimer = popDuration;
        ShowWelcome();
    }

    void Update()
    {
        if (popTimer < popDuration)
        {
            popTimer += Time.deltaTime;

            float t = Mathf.Clamp(popTimer / popDuration, 0f, 1f);

            float eased = 1f - (1f - t) * (1f - t);

            // Lerp slides smoothly between two numbers.
            float scale = Mathf.Lerp(startScale, 1f, eased);
            transform.localScale = new Vector3(scale, scale, 1f);
        }
    }

    public void ShowIsotope(Isotope isotope)
    {
        currentIsotope = isotope;

        nameText.text = isotope.isotopeName;
        questionText.text = "How long do you think it takes for half of these atoms to disappear?";
        answerText.text = "";

        // Starting the pop animation
        popTimer = 0f;
    }

    public void Reveal()
    {
        if (currentIsotope == null) return;

        answerText.text = currentIsotope.Line() + "\n" + currentIsotope.isotopePrint;

        if (currentIsotope.Band() > 0)
        {
            answerText.text += "\nPhysicists call this the half-life.";
        }
    }

    private void ShowWelcome()
    {
        currentIsotope = null;
        nameText.text = "Tap an isotope";
        questionText.text = "";
        answerText.text = "";
    }
}
