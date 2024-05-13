using System.Collections;
using System.Collections.Generic;
using Text = TMPro.TextMeshProUGUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour
{
    public TMP_Text tmpText; // Reference to the TMP text displaying the tmp value
    private int maxScore; // Maximum score earned previously

    void Start()
    {
        // Load the maximum score earned previously from PlayerPrefs
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        
        // Load the current score from PlayerPrefs
        int playerScore = PlayerPrefs.GetInt("Score", 0);
        
        // Display the current score
        tmpText.text = playerScore.ToString();
    }

    // Function to increase tmp value
    public void IncreaseTmp()
    {
        // Get the current player score from PlayerPrefs
        int playerScore = PlayerPrefs.GetInt("Score", 0);

        // Increment the score if it's less than or equal to the maximum score
        if (playerScore < maxScore)
        {
            int newScore = playerScore + 1;
            PlayerPrefs.SetInt("Score", newScore);
            PlayerPrefs.Save();
            tmpText.text = newScore.ToString();
        }
    }

    // Function to decrease tmp value
    public void DecreaseTmp()
    {
        // Decrease the player score in PlayerPrefs
        int playerScore = PlayerPrefs.GetInt("Score", 0);
        playerScore--;
        PlayerPrefs.SetInt("Score", playerScore);
        PlayerPrefs.Save();

        // Update the TMP text
        tmpText.text = playerScore.ToString();
    }
}
