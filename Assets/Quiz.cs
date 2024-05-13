using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Quiz : MonoBehaviour

{
    public GameObject[] questionPanels; // Array of question panels
    public float timeLimit = 60f; // Time limit for answering each question
    public TMP_Text timerText; // Reference to the TMP Text for displaying the timer
    private int currentQuestionIndex = 0; // Index of the current question panel
    private float timer; // Timer for tracking the time remaining
    private bool isTimerRunning = false; // Flag to track if the timer is running

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                // Mark the question as wrong if the time runs out
                Debug.Log("Time's up! Question marked as wrong.");
                AnswerQuestion(false);
            }

            // Update the timer text to display the remaining time
            timerText.text = Mathf.Round(timer).ToString();
        }
    }

    public void StartTimer()
    {
        timer = timeLimit;
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void AnswerQuestion(bool isCorrect)
    {
        StopTimer(); // Stop the timer when answering a question

        if (isCorrect)
        {
            // Move to the next question panel if the answer is correct
            currentQuestionIndex++;
            if (currentQuestionIndex < questionPanels.Length)
            {
                questionPanels[currentQuestionIndex].SetActive(true);
                StartTimer(); // Start the timer for the next question
            }
            else
            {
                // End the quiz if all questions are answered correctly
                Debug.Log("Congratulations! Quiz completed.");
            }
        }
        else
        {
            // End the quiz if the answer is incorrect
            Debug.Log("Game Over! You answered a question incorrectly.");
        }
    }
}
