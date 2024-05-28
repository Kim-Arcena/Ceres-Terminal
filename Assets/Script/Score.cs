using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private string scenename;

    private int currentScore = 0;
    private int levelStartScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("Score TextMeshProUGUI is not assigned!");
        }

        //UpdateScoreText();
    }

    public void UpdateScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        Debug.Log("Current Score is: " + currentScore);
        scoreText.text = "SCORE: " + currentScore;
        //UpdateScoreText();
    }

    // public void SaveLevelStartScore()
    // {
    //     levelStartScore = currentScore;
    // }

    // public void ResetScoreToLevelStart()
    // {
    //     currentScore = levelStartScore;
    //     UpdateScoreText();
    // }

    // private void UpdateScoreText()
    // {
    //     scoreText.text = "SCORE: " + currentScore;
    // }

    // void NextLevel()
    // {
    //     SaveLevelStartScore();
    //     SceneManager.LoadScene(scenename);
    // }
}
