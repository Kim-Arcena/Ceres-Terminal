using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoIntroductionManager : MonoBehaviour
{
    [SerializeField] public GameObject shipPlayer;
    [SerializeField] public GameObject FirstDialogue;
    [SerializeField] public GameObject SecondDialogue;
    [SerializeField] public bool moveShip = true;
    [SerializeField] public bool firstEvent = false;
    [SerializeField] public bool secondEvent = false;
    [SerializeField] public float moveSpeed = 2f;
    [SerializeField] public Vector3 firstPosition = new Vector3(0f, 50.0f, -1.5f);
    [SerializeField] public Vector3 secondPosition = new Vector3(0f, 50.0f, 5f);
    public float speed = 5f;

    void Start()
    {
    }

    void Update()
    {
        if (moveShip && firstEvent == false)
        {
            shipPlayer.transform.Translate((firstPosition + shipPlayer.transform.position).normalized * moveSpeed * Time.deltaTime);
            Debug.Log(Vector3.Distance(shipPlayer.transform.position, firstPosition));
            if (Vector3.Distance(shipPlayer.transform.position, firstPosition) < 0.25f)
            {
                shipPlayer.transform.position = firstPosition;
                moveShip = false;
                firstEvent = true;
                FirstDialogue.SetActive(true);
            }
        }

        if(moveShip == false && firstEvent)
        {
            Invoke("StartSecondEvent", 7.5f);
        }

        if(moveShip && secondEvent)
        {
            shipPlayer.transform.Translate((secondPosition + shipPlayer.transform.position).normalized * moveSpeed * Time.deltaTime);
            Debug.Log(Vector3.Distance(shipPlayer.transform.position, secondPosition));
            if (Vector3.Distance(shipPlayer.transform.position, secondPosition) < 0.25f)
            {
                shipPlayer.transform.position = secondPosition;
            }
        }
    }

    void StartSecondEvent()
    {
        SecondDialogue.SetActive(true);
        secondEvent = true;
        Invoke("MoveShip", 5f);
    }

    void MoveShip()
    {
        moveShip = true;
    }

}
