using UnityEngine;
using TMPro;

public class FadeOut : MonoBehaviour
{
    public float fadeDuration = 1f; // Duration in seconds for the fade-in and fade-out effects
    private TMP_Text textComponent; // Use TMP_Text instead of Text for TextMeshPro
    private bool touched = false; // Flag to track if the screen is touched

    void Start()
    {
        // Get the TMP_Text component instead of Text
        textComponent = GetComponent<TMP_Text>();

        if (textComponent == null)
        {
            Debug.LogError("TextFadeInOut script attached to GameObject without TMP_Text component!");
        }
    }

    void Update()
    {
        // Check if the screen is touched
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            touched = true;
        }

        // Perform fade-in and fade-out effects based on touch input
        PerformFadeEffect();
    }

    void PerformFadeEffect()
    {
        // Calculate the alpha value based on time for fade-in and fade-out
        float alpha = Mathf.Clamp01(Time.time / fadeDuration);

        // If the screen is touched, perform fade-out
        if (touched)
        {
            alpha = 1f - alpha;
        }

        // Interpolate the color based on the alpha value
        Color color = textComponent.color;
        color.a = alpha;
        textComponent.color = color;

        // Disable the script once the fade-in and fade-out are complete
        if ((alpha >= 1f && !touched) || (alpha <= 0f && touched))
        {
            enabled = false;
        }
    }
}
