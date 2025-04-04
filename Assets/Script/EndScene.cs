using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;
}

[System.Serializable]
public class ScoreList
{
    public List<ScoreEntry> scores = new List<ScoreEntry>();
}

public class EndScene : MonoBehaviour
{
    [SerializeField] GameObject creditScroll;
    [SerializeField] GameObject finalScore;
    [SerializeField] GameObject nameInputPanel;
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TextMeshProUGUI rankText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject questionPanel;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject clearLeaderboardButton;

    private int finalScoreValue;

    private void Start()
    {
        finalScoreValue = ScoreManager.Instance != null ? ScoreManager.Instance.GetCumulativeScore() : 0;

        // Show final score
        finalScore.SetActive(true);

        // Show leaderboard immediately
        ShowScoreboard();

        // Ask for name input after short delay
        Invoke("AskForName", 4f);
    }


    void AskForName()
    {
        // finalScore.SetActive(false);
        nameInputPanel.SetActive(true);
    }

    public void SubmitName()
    {
        string playerName = nameInputField.text;
        if (string.IsNullOrWhiteSpace(playerName)) return;

        AddScoreToLeaderboard(playerName, finalScoreValue);
        ShowScoreboard();
    }

    void AddScoreToLeaderboard(string name, int score)
    {
        // Load existing
        string json = PlayerPrefs.GetString("Leaderboard", JsonUtility.ToJson(new ScoreList()));
        ScoreList scoreList = JsonUtility.FromJson<ScoreList>(json);

        // Add new
        scoreList.scores.Add(new ScoreEntry { playerName = name, score = score });

        // Sort descending and keep top 10
        scoreList.scores.Sort((a, b) => b.score.CompareTo(a.score));
        if (scoreList.scores.Count > 10)
            scoreList.scores = scoreList.scores.GetRange(0, 10);

        // Save back to PlayerPrefs
        string updatedJson = JsonUtility.ToJson(scoreList);
        PlayerPrefs.SetString("Leaderboard", updatedJson);
        PlayerPrefs.Save();
    }


    void ShowScoreboard()
    {
        string json = PlayerPrefs.GetString("Leaderboard", JsonUtility.ToJson(new ScoreList()));
        ScoreList scoreList = JsonUtility.FromJson<ScoreList>(json);

        // Reset each column
        rankText.text = "<b>RANK</b>\n";
        nameText.text = "<b>NAME</b>\n";
        scoreText.text = "<b>SCORE</b>\n";

        for (int i = 0; i < scoreList.scores.Count; i++)
        {
            var entry = scoreList.scores[i];
            rankText.text += (i + 1) + "\n";
            nameText.text += entry.playerName + "\n";
            scoreText.text += entry.score + "\n";
        }
    }

    public void ClearLeaderboard()
    {
        PlayerPrefs.DeleteKey("Leaderboard");
        PlayerPrefs.Save();
        ShowScoreboard();
        Debug.Log("Leaderboard cleared.");
    }


    void AskToContinue()
    {
        // scoreboardText.gameObject.SetActive(false);
        questionPanel.SetActive(true);
        buttons.SetActive(true);
    }

    public void HandleYesLoad()
    {
        SceneManager.LoadScene("Menu Screen");
    }

    public void HandleNoLoad()
    {
        questionPanel.SetActive(false);
        buttons.SetActive(false);
        creditScroll.SetActive(true);
        Invoke("EndGame", 20f);
    }

    void EndGame()
    {
        Application.Quit();
    }
}
