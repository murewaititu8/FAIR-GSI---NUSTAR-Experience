using UnityEngine;

// Making a UI text float using sine wave
public class TextBounce : MonoBehaviour
{
    // Amount of pixels it can move between up and down
    public float height = 15;
    public float speed = 2;

    public RectTransform rect;
    public Vector2 startPosition;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        // Noting where it was placed
        startPosition = rect.anchoredPosition;
    }

    void Update()
    {
        // Mathf.Sin makes a wave as the number grows it swings up and down between -1 and 1.
        // Time.time keeps growing so the wave never stops.
        // Multiply by height to set the size.
        float offset = Mathf.Sin(Time.time * speed) * height;
        rect.anchoredPosition = startPosition + new Vector2(0f, offset);
    }
}
