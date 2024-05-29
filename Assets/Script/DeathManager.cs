// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class DeathManager : MonoBehaviour
// {
//     private PlayerMovement playerManager;
//     void Start()
//     {
//         playerManager = FindObjectOfType<PlayerMovement>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         Debug.Log("playerManager.isAlive " + playerManager.isAlive.ToString());
//         if(playerManager.isAlive == false)
//         {
//             Debug.Log("Invoking reset scene");
//             Invoke("ResetScene", 1.5f);
//         }
//     }

//     public void ResetScene()
//     {
//         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
//         SceneManager.LoadScene(currentSceneIndex);
//     }
// }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class DeathManager : MonoBehaviour
// {
//     private PlayerMovement playerManager;
//     void Start()
//     {
//         playerManager = FindObjectOfType<PlayerMovement>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         Debug.Log("playerManager.isAlive " + playerManager.isAlive.ToString());
//         if (playerManager.isAlive == false)
//         {
//             Debug.Log("Invoking reset scene");
//             Invoke("ResetScene", 1.5f);
//         }
//     }

//     public void ResetScene()
//     {
//         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
//         ScoreManager.Instance.ResetScore();  // Reset the score before restarting the scene
//         SceneManager.LoadScene(currentSceneIndex);
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private PlayerMovement playerManager;
    void Start()
    {
        playerManager = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("playerManager.isAlive " + playerManager.isAlive.ToString());
        if (playerManager.isAlive == false)
        {
            Debug.Log("Invoking reset scene");
            Invoke("ResetScene", 1.5f);
        }
    }

    public void ResetScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        ScoreManager.Instance.ResetScoreToCurrentLevelStart();  // Reset the score to the start of the current level
        SceneManager.LoadScene(currentSceneIndex);
    }
}
