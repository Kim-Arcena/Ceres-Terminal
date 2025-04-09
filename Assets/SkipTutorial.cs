using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipTutorialClass : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private string skipToSceneName; // Scene to load if skipping tutorial
    [SerializeField] private GameObject confirmationDialog;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    
    private void Start()
    {
        // Hide dialog initially
        if (confirmationDialog != null)
        {
            confirmationDialog.SetActive(false);
            Debug.Log("Dialog reference found and set to inactive");
        }
        else
        {
            Debug.LogError("Confirmation dialog is not assigned in the Inspector!");
        }
            
        // Set up button listeners
        if (yesButton != null)
            yesButton.onClick.AddListener(SkipTutorial);
        else
            Debug.LogError("Yes button is not assigned in the Inspector!");
            
        if (noButton != null)
            noButton.onClick.AddListener(ContinueToTutorial);
        else
            Debug.LogError("No button is not assigned in the Inspector!");
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger - attempting to show dialog");
            ShowSkipTutorialDialog();
        }
    }
    
    private void ShowSkipTutorialDialog()
    {
        // Pause the game
        Time.timeScale = 0f;
        Debug.Log("Game paused - Time.timeScale set to 0");
        
        // Enable the dialog
        if (confirmationDialog != null)
        {
            confirmationDialog.SetActive(true);
            Debug.Log("Dialog should now be visible");
            
            // Force update of canvas (sometimes helps with visibility issues)
            Canvas canvas = confirmationDialog.GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                canvas.enabled = false;
                canvas.enabled = true;
            }
        }
        else
        {
            Debug.LogError("Cannot show dialog - reference is null!");
            // Fallback to continue to tutorial if dialog is missing
            SceneManager.LoadScene(sceneName);
        }
    }
    
    private void SkipTutorial()
    {
        Debug.Log("Skip tutorial selected");
        // Resume normal time
        Time.timeScale = 1f;
        
        // Hide dialog
        if (confirmationDialog != null)
            confirmationDialog.SetActive(false);
        
        // Load the main scene directly (skipping tutorial)
        SceneManager.LoadScene(skipToSceneName);
    }
    
    private void ContinueToTutorial()
    {
        Debug.Log("Continue to tutorial selected");
        // Resume normal time
        Time.timeScale = 1f;
        
        // Hide dialog
        if (confirmationDialog != null)
            confirmationDialog.SetActive(false);
        
        // Load the tutorial scene
        SceneManager.LoadScene(sceneName);
    }
}