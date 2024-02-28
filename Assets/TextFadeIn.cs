using UnityEngine;
using TMPro;


public class TextFadeIn : MonoBehaviour
{
    public float fadeDuration = 1f; // Duration in seconds for the fade-in effect
    public float delay = 1f; // Delay before the fade-in effect starts
    private TMP_Text textComponent; // Use TMP_Text instead of Text for TextMeshPro
    private float elapsedTime = 0f; // Elapsed time since the script started running

    void Start()
    {
        // Get the TMP_Text component instead of Text
        textComponent = GetComponent<TMP_Text>();

        if (textComponent != null)
        {
            // Set the text color to white initially
            textComponent.color = Color.white;
        }
        else
        {
            Debug.LogError("TextFadeIn script attached to GameObject without TMP_Text component!");
        }
    }

    void Update()
    {
        // Check if textComponent is not null before proceeding
        if (textComponent == null)
        {
            return;
        }

        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the delay time has elapsed
        if (elapsedTime < delay)
        {
            // If delay time has not yet elapsed, do not start the fade-in effect
            return;
        }

        // Subtract the delay time from the elapsed time before calculating the alpha value
        float adjustedTime = elapsedTime - delay;

        // Calculate the alpha value based on the adjusted time and fade duration
        float alpha = Mathf.Clamp01(adjustedTime / fadeDuration);

        // Interpolate the color from white to black
        Color color = Color.Lerp(Color.white, Color.black, alpha);

        // Apply the new color to the text
        textComponent.color = color;

        // Disable the script once the fade-in is complete
        if (alpha >= 1f)
        {
            enabled = false;
        }
    }
}
