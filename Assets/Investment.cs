using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Investment : MonoBehaviour

{
    public TMP_Text balanceText; // Reference to the TextMeshPro text component displaying the player's balance
    public TMP_InputField wagerInputField; // Reference to the TMP_InputField for entering the wager amount
    private int playerBalance; // Player's balance

    void Start()
    {
        // Load the player's balance from PlayerPrefs when the scene starts
        playerBalance = PlayerPrefs.GetInt("PlayerBalance", 0);
        UpdateBalanceText();
    }

    // Function to update the balance text
    private void UpdateBalanceText()
    {
        balanceText.text = "Balance: " + playerBalance.ToString();
    }

    // Function to handle the wager button click
    public void WagerButtonClick()
    {
        // Get the wager amount from the input field
        int wagerAmount = int.Parse(wagerInputField.text);

        // Check if the wager amount is valid (not exceeding the player's balance)
        if (wagerAmount <= playerBalance)
        {
            // Deduct the wager amount from the player's balance
            playerBalance -= wagerAmount;
            UpdateBalanceText();

            // Store the updated balance in PlayerPrefs
            PlayerPrefs.SetInt("PlayerBalance", playerBalance);

            // Proceed with further actions (transition to the next scene, etc.)
        }
        else
        {
            // Provide feedback to the player that the wager amount exceeds their balance
            Debug.Log("Insufficient balance to place the wager.");
        }
    }
}
