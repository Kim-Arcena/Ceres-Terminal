using UnityEngine;
using UnityEngine.UI;

public class LeaderboardEntryUI : MonoBehaviour
{
    [SerializeField] Text rankText;
    [SerializeField] Text nameText;
    [SerializeField] Text scoreText;
    
    public void SetEntry(int rank, string playerName, int score)
    {
        if (rankText != null)
            rankText.text = rank.ToString();
            
        if (nameText != null)
            nameText.text = playerName;
            
        if (scoreText != null)
            scoreText.text = score.ToString();
    }
}