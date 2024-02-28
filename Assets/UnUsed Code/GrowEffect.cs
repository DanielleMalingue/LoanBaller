using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowEffect : MonoBehaviour
{
    public float maxScale = 2f; // Maximum scale to grow to
    public float growSpeed = 1f; // Speed at which the GameObject grows
    public float shrinkSpeed = 1f; // Speed at which the GameObject shrinks back

    private Vector3 initialScale; // Initial scale of the GameObject
    private bool isTouchingObject = false; // Flag to track touch input on the GameObject

    void Start()
    {
        initialScale = transform.localScale; // Store the initial scale
    }

    void Update()
    {
        // Check if there is any touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch
        
            if (touch.phase==TouchPhase.Began){
                isTouchingObject = true;


            }
            
            // Check if the touch phase is ended or canceled
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouchingObject = false;
            }
        }

        // If touching the GameObject, grow it
        if (isTouchingObject)
        {
            // Increase the scale of the GameObject
            transform.localScale += Vector3.one * growSpeed * Time.deltaTime;

            // Clamp the scale to the maximum scale
            transform.localScale = Vector3.Min(transform.localScale, initialScale * maxScale);
        }
        // If not touching the GameObject, shrink it back to its initial scale
        else
        {
            // Shrink the GameObject back to its initial scale
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

            // Ensure the scale does not go below the initial scale
            transform.localScale = Vector3.Max(transform.localScale, initialScale);
        }
    }
}
