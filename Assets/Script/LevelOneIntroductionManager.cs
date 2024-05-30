using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneIntroductionManager : MonoBehaviour
{
    [SerializeField] public GameObject shipPlayer;
    [SerializeField] public GameObject FirstDialogue;
    [SerializeField] public GameObject SecondDialogue;
    [SerializeField] public GameObject asteroid;
    [SerializeField] public Vector3 firstPosition = new Vector3(0f, 50.0f, -1.5f);
    [SerializeField] public float moveSpeed = 2f;
    [SerializeField] public bool moveShip = true;
    [SerializeField] public bool firstEvent = false;
    [SerializeField] private float asteroidSpeed = 4f;
    [SerializeField] public bool finishAsteroid = false;
    [SerializeField] public Vector3 secondPosition = new Vector3(0f, 50.0f, 5f);

    void Start()
    {
        
    }

    // Update is called once per frame
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
            }
        }

        if (firstEvent && finishAsteroid == false)
        {
            FirstDialogue.SetActive(true);
            Invoke("showSecondDialogue", 5f);
        }

        if (finishAsteroid && moveShip)
        {
            shipPlayer.transform.Translate((secondPosition + shipPlayer.transform.position).normalized * 3f * Time.deltaTime);
            Debug.Log(Vector3.Distance(shipPlayer.transform.position, secondPosition));
            if (Vector3.Distance(shipPlayer.transform.position, secondPosition) < 0.25f)
            {
                shipPlayer.transform.position = secondPosition;
            }
        }
    }

    void showSecondDialogue(){
        SecondDialogue.SetActive(true);
        ThrowAsteroid();
    }

    void ThrowAsteroid()
    {
        asteroid.SetActive(true);
        Rigidbody asteroidRigidbody = asteroid.GetComponent<Rigidbody>();
        if (asteroidRigidbody != null)
        {
            Vector3 throwDirection = Vector3.right;
            asteroidRigidbody.velocity = throwDirection * asteroidSpeed;
            Invoke("DeactivateAsteroid", 6f);
        }
    }

    void DeactivateAsteroid()
    {
        asteroid.SetActive(false);
        finishAsteroid = true;
        moveShip = true;
    }
}
