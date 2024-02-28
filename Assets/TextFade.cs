using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public float fadeDuration = 2f; // Duration in seconds for the fade effect
    private CanvasGroup canvasGroup;
    private float currentAlpha = 1f; // Starting alpha value

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        // Start the fading coroutine
        StartCoroutine(FadeText());
    }

    private System.Collections.IEnumerator FadeText()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            // Calculate the progress of fading
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            canvasGroup.alpha = alpha;

            // Update the timer
            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure the final alpha value is set
        canvasGroup.alpha = 0f;
    }
}
