using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovement : MonoBehaviour
{
    [Header("Ship Movement")]
    [SerializeField] private float maxMoveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 180f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] GameObject rotateCanvas;
    [SerializeField] GameObject arrowUPCanvas;
    [SerializeField] GameObject shooterCanvas;
    [SerializeField] GameObject destroyCanvas;
    [SerializeField] GameObject largeAsteroidManager;

    [Header("Ship Components")]
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float bulletSpeed = 20f;

    private Rigidbody shipRb;
    private bool isAlive = true;
    private bool isAccelerating = false;

    [Header("Tutorial")]
    private bool rotateTutorial = true;
    private bool thrusterTutorial = false;
    private bool shooterTutorial = false;
    private bool destroyTutorial = false;
    private bool sceneOne = false;
    private bool largeAsteroidScene = false;

    private bool leftArrowPressed = false;
    private bool rightArrowPressed = false;
    private bool topArrowPressed = false;
    private bool spaceBarPressed = false;
    private float leftArrowPressTime = 0f;
    private float rightArrowPressTime = 0f;
    private float topArrowPressTime = 0f;
    private int spaceBarPressedCounter = 0;

    private void Start()
    {
        shipRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rotateTutorial)
        {
            ShipRotation();

            if (leftArrowPressed)
                leftArrowPressTime += Time.deltaTime;

            if (rightArrowPressed)
                rightArrowPressTime += Time.deltaTime;

            if (leftArrowPressTime >= 1f || rightArrowPressTime >= 1f)
            {
                thrusterTutorial = true;
                acceleration = 10f;
            }
        }
        
        if(thrusterTutorial){
            ShipRotation();
            ShipAccelaration();

            if (topArrowPressed)
                topArrowPressTime += Time.deltaTime;
            
            if (topArrowPressTime >= 1f){
                shooterTutorial = true;
            }
            rotateCanvas.SetActive(false);
            arrowUPCanvas.SetActive(true);
        }

        if(shooterTutorial){
            ShipRotation();
            ShipAccelaration();
            ShipShoot();

            if(spaceBarPressed){
                spaceBarPressedCounter += 1;
            }

            if(spaceBarPressedCounter >= 5){
                destroyTutorial = true;
            }

            Debug.Log("shooterTutorial" + destroyTutorial.ToString());

            arrowUPCanvas.SetActive(false);
            shooterCanvas.SetActive(true);
        }

        if(destroyTutorial){
            largeAsteroidManager.SetActive(true);
            shooterCanvas.SetActive(false);
            destroyCanvas.SetActive(true);
        }
    }

    private void ShipRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            leftArrowPressed = true;
        }
        else
        {
            leftArrowPressed = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);
            rightArrowPressed = true;
        }
        else
        {
            rightArrowPressed = false;
        }
    }

    private void ShipAccelaration()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            shipRb.AddForce(transform.up * acceleration);
            shipRb.velocity = Vector3.ClampMagnitude(shipRb.velocity, maxMoveSpeed);
            topArrowPressed = true;
        }
        else{
            topArrowPressed = false;
        }
    }

    private void ShipShoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody bullet = Instantiate(bulletPrefab, spawnBullet.position, Quaternion.identity);
            Vector3 shipVelocity = shipRb.velocity;
            Vector3 shipDirection = transform.rotation * Vector3.up;
            float shipSpeed = Vector3.Dot(shipVelocity, shipDirection);
            if(shipSpeed <0){
                shipSpeed = 0;
            }
            bullet.velocity = shipSpeed * shipDirection;
            bullet.AddForce(spawnBullet.up * bulletSpeed, ForceMode.Impulse);
            spaceBarPressed = true;
        }
        else{
            spaceBarPressed = false;
        }
    }
}
