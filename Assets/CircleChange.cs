using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CircleChange : MonoBehaviour

{
    public TMP_Text textComponent; // Reference to the TextMeshPro text component showing the score
    public GameObject[] circles; // Array of circle GameObjects
    public Color grayColor = Color.gray; // Customize the shade of gray
    public Color greenColor = Color.green; // Customize the shade of green
    private int currentValue = 0; // Current value of the score

    void Start()
    {
        // Load the score from PlayerPrefs when the scene starts
        currentValue = PlayerPrefs.GetInt("Score", 0);
        UpdateCirclesColor();
    }

    void Update()
    {
        // Update the score from the text component
        currentValue = int.Parse(textComponent.text);
        UpdateCirclesColor();
    }

    void UpdateCirclesColor()
    {
        // Iterate through the circles and change their color based on the score
        for (int i = 0; i < circles.Length; i++)
        {
            // Determine if the circle should be green or gray based on the score
            Color color = i < currentValue ? greenColor : grayColor;
            // Change the color of the circle
            circles[i].GetComponent<Renderer>().material.color = color;
        }
    }
}

