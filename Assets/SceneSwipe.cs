using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwipe : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField]
    private float minDistanceForSwipe = 20f;

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
                fingerUpPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerUpPosition = touch.position;
                CheckSwipe();
            }
        }
    }

    void CheckSwipe()
    {
        if (Vector2.Distance(fingerDownPosition, fingerUpPosition) > minDistanceForSwipe)
        {
            float deltaX = fingerDownPosition.x - fingerUpPosition.x;
            float deltaY = fingerDownPosition.y - fingerUpPosition.y;

            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
            {
                if (deltaX > 0)
                {
                    // Left swipe
                    SceneManager.LoadScene("NextScene"); // Replace "NextScene" with the name of your scene
                }
                else
                {
                    // Right swipe
                    SceneManager.LoadScene("PreviousScene"); // Replace "PreviousScene" with the name of your scene
                }
            }
        }
    }
}
