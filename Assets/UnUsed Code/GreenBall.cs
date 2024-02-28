using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBall : MonoBehaviour
{
    public GameObject objectToHold;
    public GameObject objectToAppearPrefab;
    public float holdTime = 3f; // Time in seconds to hold the object

    private bool isTouching = false;
    private float touchStartTime = 0f;
    public float objectSpeed = 1f; // Speed of the spawned objects


    void Update()
    {
        
        if (Input.touchCount > 0) // Check that there is at least one touch
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            // Check if the touch phase is began
            if (touch.phase == TouchPhase.Began && IsTouchingObject(touch, objectToHold))
            {
                isTouching = true;
                touchStartTime = Time.time; // Record the time when the touch began
                Debug.Log("Touch began on objectToHold");
            }

            // Check if the touch phase is ended
            if (touch.phase == TouchPhase.Ended)
            {
                    // If the touch duration is greater than the hold time, show the object

                    //print(isTouching);
                    //print(Time.time);
                   // print(touchStartTime);
                    print(Time.time - touchStartTime);

                    isTouching = false;
                
                if(isTouching && Time.time - touchStartTime >= holdTime)
                {
                    SpawnObject();
                }

                Debug.Log("Touch ended");
            }

        
     }
        GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("SpawnedObject");
        foreach (GameObject obj in spawnedObjects)
        {
            obj.transform.Translate(Vector3.down * objectSpeed * Time.deltaTime);
        }
        
        
    }

    // Check if the touch is on a specific GameObject
    bool IsTouchingObject(Touch touch, GameObject obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == obj)
            {
                return true;
            }
        }

        return false;
    }

    void SpawnObject()
    {
                print("spawn object");

               Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(150, Screen.height, 200));
        spawnPosition.z = 0; // Set the z-coordinate to 0 to ensure it's in the scene

        // Instantiate the object at the calculated position
        GameObject newObject = Instantiate(objectToAppearPrefab, spawnPosition, Quaternion.identity);
        newObject.tag = "SpawnedObject"; 
    }
    
}