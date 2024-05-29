// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// public class ScoreManager : MonoBehaviour
// {
//     public static ScoreManager Instance;

//     public TextMeshProUGUI scoreText;
//     private int score = 0;

//     private void Awake()
//     {
//         // Singleton pattern to ensure only one instance of ScoreManager exists
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }

//     private void Start()
//     {
//         UpdateScoreText();
//     }

//     public void SetScoreText(TextMeshProUGUI newScoreText)
//     {
//         scoreText = newScoreText;
//         UpdateScoreText();
//     }

//     public void AddScore(int points)
//     {
//         score += points;
//         UpdateScoreText();
//     }

//     private void UpdateScoreText()
//     {
//         if (scoreText != null)
//         {
//             scoreText.text = "Score: " + score;
//         }
//     }
// }


// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class ScoreManager : MonoBehaviour
// {
//     public static ScoreManager Instance;

//     public TextMeshProUGUI scoreText;
//     private int score = 0;

//     private void Awake()
//     {
//         // Singleton pattern to ensure only one instance of ScoreManager exists
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(gameObject);
//             SceneManager.sceneLoaded += OnSceneLoaded;  // Subscribe to the sceneLoaded event
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }

//     private void Start()
//     {
//         UpdateScoreText();
//     }

//     // This method will be called every time a new scene is loaded
//     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//     {
//         // Find the new scoreText object in the scene
//         scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
//         UpdateScoreText();
//     }

//     public void AddScore(int points)
//     {
//         score += points;
//         UpdateScoreText();
//     }

//     private void UpdateScoreText()
//     {
//         if (scoreText != null)
//         {
//             scoreText.text = "Score: " + score;
//         }
//     }

//     private void OnDestroy()
//     {
//         // Unsubscribe from the sceneLoaded event to prevent memory leaks
//         SceneManager.sceneLoaded -= OnSceneLoaded;
//     }
// }


// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class ScoreManager : MonoBehaviour
// {
//     public static ScoreManager Instance;

//     public TextMeshProUGUI scoreText;
//     private int score = 0;

//     private void Awake()
//     {
//         // Singleton pattern to ensure only one instance of ScoreManager exists
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(gameObject);
//             SceneManager.sceneLoaded += OnSceneLoaded;  // Subscribe to the sceneLoaded event
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }

//     private void Start()
//     {
//         UpdateScoreText();
//     }

//     // This method will be called every time a new scene is loaded
//     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//     {
//         // Find the new scoreText object in the scene
//         scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
//         UpdateScoreText();
//     }

//     public void AddScore(int points)
//     {
//         score += points;
//         UpdateScoreText();
//     }

//     public void ResetScore()
//     {
//         score = 0;
//         UpdateScoreText();
//     }

//     private void UpdateScoreText()
//     {
//         if (scoreText != null)
//         {
//             scoreText.text = "Score: " + score;
//         }
//     }

//     private void OnDestroy()
//     {
//         // Unsubscribe from the sceneLoaded event to prevent memory leaks
//         SceneManager.sceneLoaded -= OnSceneLoaded;
//     }
// }

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
    [SerializeField] private string sceneName;
	private TypingEffect typingEffect;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of ScoreManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;  // Subscribe to the sceneLoaded event
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
        typingEffect = GetComponent<TypingEffect>();
	}

    // This method will be called every time a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the new scoreText object in the scene
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        score = currentLevelStartScore;
        UpdateScoreText();
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
		else{
			typingEffect.setFinalScore("Final Score: " + score.ToString());
		}
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
