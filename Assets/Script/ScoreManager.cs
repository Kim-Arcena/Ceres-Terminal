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
    private TypingEffect typingEffect;

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

        if (sceneName == "End Menu")
        {
            typingEffect = GameObject.FindObjectOfType<TypingEffect>();
            if (typingEffect != null)
            {
                typingEffect.SetFinalScore("Final Score: " + cumulativeScore);
            }
        }
        else
        {
            score = currentLevelStartScore;
            UpdateScoreText();
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

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
