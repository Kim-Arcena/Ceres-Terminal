using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // [SerializeField] public Text timerText;
    [SerializeField] public float startTime = 60f;

    [SerializeField] private float currentTime;
    private PlayerMovement playerManager;
    // public GameObject nextLevelTrigger;
    [SerializeField] public bool setTrigger = false;
    [SerializeField] private string scenename;
    
    void Start()
    {
        currentTime = startTime;
        playerManager = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (playerManager.isAlive && setTrigger == false)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                if(setTrigger == false)
                {
                    // SetNextLevelTrigger();
                    Invoke("NextLevel", 5f);
                }
            }
        }
        else
        {
            currentTime = startTime;
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(scenename);
    }

    // void SetNextLevelTrigger()
    // {
    //     BoxCollider collider = nextLevelTrigger.GetComponent<BoxCollider>();
    //     if (collider != null)
    //     {
    //         collider.enabled = true;
    //     }
    //     else
    //     {
    //         collider = nextLevelTrigger.AddComponent<BoxCollider>();
    //         collider.isTrigger = true;
    //         collider.enabled = true;
    //         collider.size = new Vector3(75.0f, 120.0f, 1f);
    //     }

    //     setTrigger = true;
    // }
}
