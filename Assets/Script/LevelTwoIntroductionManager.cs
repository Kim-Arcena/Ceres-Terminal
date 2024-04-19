using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoIntroductionManager : MonoBehaviour
{
    [SerializeField] public GameObject shipPlayer;
    [SerializeField] public GameObject FirstDialogue;
    [SerializeField] public GameObject SecondDialogue;
    [SerializeField] public GameObject keplerPlanet;
    [SerializeField] public GameObject fadeIn;
    [SerializeField] public bool moveShip = true;
    [SerializeField] public bool firstEvent = false;
    [SerializeField] public bool secondEvent = false;
    [SerializeField] public float moveSpeed = 2f;
    [SerializeField] public Vector3 firstPosition = new Vector3(0f, 50.0f, -1.5f);
    [SerializeField] public Vector3 secondPosition = new Vector3(-10f, 50.0f, 1f);

    void Start()
    {
        fadeIn.SetActive(true);
    }

    void Update()
    {
        if (moveShip && firstEvent == false)
        {
            shipPlayer.transform.Translate((firstPosition + shipPlayer.transform.position).normalized * moveSpeed * Time.deltaTime);
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

        if (moveShip && secondEvent)
        {
            Vector3 direction = (secondPosition - shipPlayer.transform.position).normalized;
            shipPlayer.transform.Translate(direction * moveSpeed * Time.deltaTime);

            // Store initial y position
            float initialYPosition = shipPlayer.transform.position.y;

            // Calculate the rotation to look towards the second position
            Quaternion targetRotation = Quaternion.LookRotation(secondPosition - shipPlayer.transform.position);

            // Get the Euler angles of the target rotation
            Vector3 targetEulerAngles = targetRotation.eulerAngles;

            // Reset x rotation to initial value
            targetEulerAngles.x = shipPlayer.transform.rotation.eulerAngles.x;

            // Apply the rotation to the ship player
            shipPlayer.transform.rotation = Quaternion.Euler(targetEulerAngles);

            // Reassign initial y position
            Vector3 newPosition = shipPlayer.transform.position;
            newPosition.y = initialYPosition;
            shipPlayer.transform.position = newPosition;

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
