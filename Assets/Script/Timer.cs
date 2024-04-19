using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // [SerializeField] public Text timerText;
    [SerializeField] public float startTime = 60f;

    [SerializeField] private float currentTime;
    private PlayerMovement playerManager;
    public GameObject nextLevelTrigger;
    [SerializeField] public bool setTrigger = false;

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

            // string minutes = ((int)currentTime / 60).ToString("00");
            // string seconds = (currentTime % 60).ToString("00");

            // timerText.text = minutes + ":" + seconds;

            if (currentTime <= 0)
            {
                if(setTrigger == false)
                {
                    SetNextLevelTrigger();
                }
            }
        }
        else
        {
            currentTime = startTime;
        }
    }

    void SetNextLevelTrigger()
    {
        BoxCollider collider = nextLevelTrigger.GetComponent<BoxCollider>();
        if (collider != null)
        {
            collider.enabled = true;
        }
        else
        {
            collider = nextLevelTrigger.AddComponent<BoxCollider>();
            collider.isTrigger = true;
            collider.enabled = true;
            collider.size = new Vector3(75.0f, 120.0f, 1f);
        }

        setTrigger = true;
    }
}
