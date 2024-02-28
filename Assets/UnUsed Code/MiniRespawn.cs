using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRespawn : MonoBehaviour
{
    public GameObject newPrefab; 
    public GameObject GreenBall;// Drag the prefab into this field in the Unity editor
    public float holdTime = 3f;
    private bool isHeld = false;
    private float startTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isHeld = true;
            startTime = Time.time;
        }

        if (isHeld && Time.time - startTime >= holdTime)
        {
            ExpandCircle();
            SpawnNewObject();
        }
    }

    void ExpandCircle()
    {
        // Code to scale up the circle GameObject over three seconds
        // Example: transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
    }

    void SpawnNewObject()
    {
        Vector3 oppositePosition = CalculateOppositePosition(transform.position);
        Instantiate(newPrefab, oppositePosition, Quaternion.identity);
    }

    Vector3 CalculateOppositePosition(Vector3 currentPosition)
    {
        Vector3 oppositePosition = currentPosition;
        // Calculate the opposite position based on the screen size or game world bounds
        // Example: oppositePosition.x = Screen.width - currentPosition.x;
        return oppositePosition;
    }
}

