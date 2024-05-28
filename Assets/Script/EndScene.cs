using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    [SerializeField] GameObject creditScroll;
    
    public void handleYesLoad(){
        SceneManager.LoadScene("Menu Screen");
    }

    public void handleNoLoad(){
        creditScroll.SetActive(true);
    }
}
