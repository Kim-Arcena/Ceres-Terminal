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
        if(playerManager.isAlive == false)
        {
            Debug.Log("Invoking reset scene");
            Invoke("ResetScene", 1.5f);
        }
    }

    public void ResetScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
