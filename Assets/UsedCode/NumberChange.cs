using UnityEngine;
using TMPro;

public class NumberChange : MonoBehaviour
{
    public float holdDuration = 3f; // Duration in seconds for holding to change text
    public TMP_Text textComponent; // Reference to the TextMeshPro text component
    private bool isHolding = false; // Flag to track if the GameObject is being held
    private bool isCounting = false; // Flag to track if the counting is in progress
    private float startTime; // Time when the holding action started
    private int currentValue = 0; // Current value of the text

    void Start()
    {
        // Load the score from PlayerPrefs when the scene starts
        currentValue = PlayerPrefs.GetInt("Score", 0);
        UpdateText();
    }

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            if (touch.phase == TouchPhase.Began)
            {
                // Check if the touch is over the sprite
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    isHolding = true;
                    startTime = Time.time;

                    if (!isCounting)
                    {
                        isCounting = true;
                        currentValue = 0; // Reset the count
                        UpdateText();
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                isHolding = false;
            }
        }

        // Update the text value if holding
        if (isHolding)
        {
            float holdTime = Time.time - startTime;
            if (holdTime >= holdDuration)
            {
                currentValue++;
                UpdateText();
                startTime = Time.time;
            }
        }
    }

    void UpdateText()
    {
        // Update the text value
        textComponent.text = currentValue.ToString();

        // Save the score to PlayerPrefs
        PlayerPrefs.SetInt("Score", currentValue);
        PlayerPrefs.Save();
    }
}
