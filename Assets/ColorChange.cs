using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public float colorChangeDuration = 1f; // Duration in seconds for color change
    public Color targetGreen = new Color(0.0f, 1.0f, 0.0f, 1.0f); // Specific shade of green
    private SpriteRenderer spriteRenderer;
    private Color startColor; // Starting color
    private Color endColor; // Ending color
    private float t = 0f; // Time variable
    private bool colorChanged = false; // Flag to track if color has changed

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color; // Initialize startColor
        endColor = targetGreen; // Set endColor to the specified green
        // Start color changing coroutine
        StartCoroutine(ChangeColor());
    }

    private System.Collections.IEnumerator ChangeColor()
    {
        // Interpolate between startColor and endColor over colorChangeDuration seconds
        while (t < colorChangeDuration)
        {
            t += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(startColor, endColor, t / colorChangeDuration);
            yield return null;
        }
        // Ensure the final color is set to endColor
        spriteRenderer.color = endColor;
        colorChanged = true; // Set flag to true after color change is complete
    }
}
