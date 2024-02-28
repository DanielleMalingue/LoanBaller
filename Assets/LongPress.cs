using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class LongPress : MonoBehaviour
{
    public GameObject prefabToInstantiate; // Drag the prefab sprite circle here in the Unity editor
    private bool isPressing = false;
    private float pressStartTime = 0f;
    private float longPressDuration = 3f;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressing = true;
        pressStartTime = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;
    }

    void Update()
    {
        if (isPressing && Time.time - pressStartTime >= longPressDuration)
        {
            // Long press detected, instantiate the prefab
            Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
            isPressing = false; // Reset the flag
        }
    }
}
