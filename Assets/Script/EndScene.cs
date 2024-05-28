using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    [SerializeField] GameObject creditScroll;

    [SerializeField] GameObject question;
    [SerializeField] GameObject buttons;
    
    private void Start()
    {
        Invoke("showButton", 2.5f);
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
    }
}
