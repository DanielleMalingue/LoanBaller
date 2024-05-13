using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class CircleChange : MonoBehaviour
{
    public TMP_Text textComponent; // Reference to the TextMeshPro text component showing the score
    public GameObject[] circles; // Array of circle GameObjects
    public Color grayColor = Color.gray; // Customize the shade of gray
    public Color greenColor = Color.green; // Customize the shade of green
    public string sceneToLoad = "NextScene"; // Name of the scene to load when all circles are full
    public float delayBeforeLoad = 2f; // Delay before loading the scene in seconds
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
        int filledCircleCount = 0; // Counter to track the number of filled circles

        // Iterate through the circles and change their color based on the score
        for (int i = 0; i < circles.Length; i++)
        {
            // Determine if the circle should be green or gray based on the score
            Color color = i < currentValue ? greenColor : grayColor;
            // Change the color of the circle
            circles[i].GetComponent<Renderer>().material.color = color;

            // Check if the circle is filled
            if (i < currentValue)
            {
                filledCircleCount++;
            }
        }

        // If all circles are filled, start the coroutine to load the next scene with a delay
        if (filledCircleCount == circles.Length)
        {
            StartCoroutine(LoadNextSceneWithDelay());
        }
    }

    // Coroutine to load the next scene with a delay
    IEnumerator LoadNextSceneWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
