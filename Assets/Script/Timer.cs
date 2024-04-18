using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float startTime = 60f; // Initial time in seconds

    private float currentTime;

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        // Update timer
        currentTime -= Time.deltaTime;

        // Display timer in minutes and seconds format
        string minutes = ((int)currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");

        // Update the text UI element
        timerText.text = minutes + ":" + seconds;

        // If timer reaches zero, do something (e.g., end game)
        if (currentTime <= 0)
        {
            // Timer has reached zero, handle this condition
            // For example:
            // EndGame();
        }
    }

    // Other methods can be added for pausing, resetting, etc., depending on your needs
}
