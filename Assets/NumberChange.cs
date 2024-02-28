using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class NumberChange : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float holdDuration = 3f; // Duration in seconds for holding to change text
    public TMP_Text textComponent; // Reference to the TextMeshPro text component
    private bool isHolding = false; // Flag to track if the GameObject is being held
    private float startTime; // Time when the holding action started

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        startTime = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
    }

    void Update()
    {
        if (isHolding)
        {
            float holdTime = Time.time - startTime;
            float progress = Mathf.Clamp01(holdTime / holdDuration);
            // Update the text value gradually from 0 to 1
            textComponent.text = Mathf.Lerp(0f, 1f, progress).ToString();
        }
    }
}
