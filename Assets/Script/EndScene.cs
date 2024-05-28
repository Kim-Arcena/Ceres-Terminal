using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    [SerializeField] GameObject creditScroll;

    [SerializeField] GameObject finalScore;
    [SerializeField] GameObject question;
    [SerializeField] GameObject buttons;
    
    private void Start()
    {
        Invoke("showQuestion", 10f);
    }

    void showQuestion(){
        finalScore.SetActive(false);
        question.SetActive(true);
        Invoke("showButton", 3.25f);
    }
    void showButton(){
        buttons.SetActive(true);
    }

    public void handleYesLoad(){
        SceneManager.LoadScene("Menu Screen");
    }

    public void handleNoLoad(){
        creditScroll.SetActive(true);
        question.SetActive(false);
        buttons.SetActive(false);
        Invoke("EndGame", 12f);
    }

    void EndGame(){
        Application.Quit();
    }
}
