using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private string tutorialSceneName;
    [SerializeField] private GameObject confirmationDialog;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    
    private void Start()
    {
        // Hide the dialog initially
        if (confirmationDialog != null)
            confirmationDialog.SetActive(false);
            
        // Set up button listeners
        if (yesButton != null)
            yesButton.onClick.AddListener(SkipTutorial);
            
        if (noButton != null)
            noButton.onClick.AddListener(GoToTutorial);
    }
    
    // Call this method when you want to transition to the next scene
    public void PrepareSceneTransition()
    {
        // Pause the game
        Time.timeScale = 0f;
        
        // Show the confirmation dialog
        if (confirmationDialog != null)
            confirmationDialog.SetActive(true);
    }
    
    private void SkipTutorial()
    {
        // Resume normal time
        Time.timeScale = 1f;
        
        // Load the main scene directly
        SceneManager.LoadScene(nextSceneName);
    }
    
    private void GoToTutorial()
    {
        // Resume normal time
        Time.timeScale = 1f;
        
        // Load the tutorial scene
        SceneManager.LoadScene(tutorialSceneName);
    }
}