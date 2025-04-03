using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;
    private int cumulativeScore = 0;
    private int currentLevelStartScore = 0;
    private int score = 0;
    private String hearts = "♥♥♥♥♥♥";
    private int heartCount = 5;
    private TypingEffect typingEffect;
    [SerializeField] TextMeshProUGUI heartText;
    [SerializeField] private string sceneName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    // This method will be called every time a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneName = scene.name;
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        heartText = GameObject.Find("Hearts")?.GetComponent<TextMeshProUGUI>();

        if (sceneName == "End Menu")
        {
            typingEffect = GameObject.FindObjectOfType<TypingEffect>();
            if (typingEffect != null)
            {
                typingEffect.SetFinalScore("Final Score: " + cumulativeScore);
                Destroy(gameObject);
            }
        }
        else
        {
            UpdateScoreText();
            UpdateHeartText();
        }
    }
    private void UpdateHeartText()
    {
        if (heartText != null)
        {
            heartText.text = new string('♥', heartCount);
        }
    }

    public void DeductHeart()
    {
        heartCount--;

        // Clamp heartCount to prevent it from going below 0
        heartCount = Mathf.Max(heartCount, 0);

        if (heartText != null)
        {
            heartText.text = new string('♥', heartCount);
        }

        // Optional: handle game over
        if (heartCount <= 0)
        {
            Debug.Log("Game Over!");
            // Load game over scene or handle end of game
            SceneManager.LoadScene("End Menu");
        }
    }

    public void AddScore(int points)
    {
        score += points;
        cumulativeScore += points;
        UpdateScoreText();
    }

    public void ResetScoreToCurrentLevelStart()
    {
        score = currentLevelStartScore;
        UpdateScoreText();
    }

    public void SetCurrentLevelStartScore()
    {
        currentLevelStartScore = cumulativeScore;
        score = currentLevelStartScore;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null && sceneName != "End Menu")
        {
            scoreText.text = "Score: " + score;
        }
    }
    public void ResetGame()
    {
        cumulativeScore = 0;
        currentLevelStartScore = 0;
        score = 0;
        heartCount = 5;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
