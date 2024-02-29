using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwipe : MonoBehaviour
{
    public float minSwipeDistance = 100f;
    public int nextSceneIndex;

    private Vector2 touchStartPosition;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check for the beginning of the touch
            if (touch.phase == TouchPhase.Began)
            {
                // Store the touch start position
                touchStartPosition = touch.position;
            }
            // Check for the end of the touch
            else if (touch.phase == TouchPhase.Ended)
            {
                // Calculate the swipe distance
                float swipeDistance = touch.position.y - touchStartPosition.y;

                // Check if the swipe distance is greater than the minimum required distance
                if (Mathf.Abs(swipeDistance) >= minSwipeDistance)
                {
                    // Check if the swipe direction is downwards
                    if (swipeDistance < 0)
                    {
                        // Change scene to the next scene index
                        ChangeScene();
                    }
                }
            }
        }
    }

    void ChangeScene()
    {
        // Check if the next scene index is valid
        if (nextSceneIndex >= 0 && nextSceneIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("Invalid scene index!");
        }
    }
}
