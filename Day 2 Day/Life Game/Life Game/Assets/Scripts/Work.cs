using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Work : MonoBehaviour
{
    // UI Elements
    public Text wordDisplay;     // Displays the word to type
    public InputField inputField; // User input field
    public Text scoreText;       // Displays the score
    public Text timerText;       // Displays the remaining time

    // Game Data
    private List<string> wordList = new List<string> { "unity", "typing", "game", "income", "system", "develop" };
    private string currentWord;
    private int score = 0;
    private float timeLeft = 60f; // 60 seconds game session
    private bool isGameActive = false; // Flag to check if the game is active

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the inputField is assigned before trying to add listeners
        if (inputField != null)
        {
            inputField.onValueChanged.AddListener(delegate { CheckInput(); }); // Listen for input field changes
        }
        else
        {
            Debug.LogError("inputField is not assigned in the Inspector!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            // Update timer
            if (timerText != null)
            {
                timeLeft -= Time.deltaTime;
                timerText.text = "Time: " + Mathf.CeilToInt(timeLeft).ToString();
            }
            else
            {
                Debug.LogError("timerText is not assigned in the Inspector!");
            }

            if (timeLeft <= 0)
            {
                EndGame();
            }
        }
    }

    // Triggered when the GameObject with BoxCollider is clicked
    void OnMouseDown()
    {
        if (!isGameActive)
        {
            StartGame(); // Start the game when clicked
        }
    }

    void StartGame()
    {
        isGameActive = true;
        score = 0;
        timeLeft = 60f;
        UpdateScore();
        GenerateNewWord();
        inputField.interactable = true; // Enable input field
    }

    void GenerateNewWord()
    {
        // Randomly pick a word from the list
        int randomIndex = Random.Range(0, wordList.Count);
        currentWord = wordList[randomIndex];
        
        // Ensure wordDisplay is assigned before using it
        if (wordDisplay != null)
        {
            wordDisplay.text = currentWord;
        }
        else
        {
            Debug.LogError("wordDisplay is not assigned in the Inspector!");
        }
        
        // Clear previous input
        if (inputField != null)
        {
            inputField.text = "";
        }
        else
        {
            Debug.LogError("inputField is not assigned in the Inspector!");
        }
    }

    void CheckInput()
    {
        if (inputField.text.Trim().ToLower() == currentWord.ToLower())
        {
            score += currentWord.Length; // Example scoring: add points equal to word length
            UpdateScore();
            GenerateNewWord();
        }
    }

    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("scoreText is not assigned in the Inspector!");
        }
    }

    void EndGame()
    {
        // Disable input and show final score
        if (inputField != null)
        {
            inputField.interactable = false;
        }
        else
        {
            Debug.LogError("inputField is not assigned in the Inspector!");
        }

        if (wordDisplay != null)
        {
            wordDisplay.text = "Game Over!";
        }
        else
        {
            Debug.LogError("wordDisplay is not assigned in the Inspector!");
        }
    }
}
