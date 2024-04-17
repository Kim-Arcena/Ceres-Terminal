using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ship Movement")]
    [SerializeField] private float maxMoveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 180f;
    [SerializeField] private float acceleration = 10f;

    private Rigidbody shipRb;
    private bool isAlive = true;
    private bool isAccelerating = false;
    

    private void Start(){
        shipRb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        if (isAlive)
        {
            ShipAccelaration();
            ShipRotation();
        }
        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        // }

        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     Vector3 currentRotation = transform.rotation.eulerAngles;

        //     currentRotation.y -= rotateSpeed * Time.deltaTime;

        //     transform.rotation = Quaternion.Euler(currentRotation);
        // }

        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     Vector3 currentRotation = transform.rotation.eulerAngles;

        //     currentRotation.y += rotateSpeed * Time.deltaTime;

        //     transform.rotation = Quaternion.Euler(currentRotation);
        // }
    }
    private void ShipAccelaration()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            shipRb.AddForce(transform.up * acceleration, ForceMode.Acceleration);
            shipRb.velocity = Vector3.ClampMagnitude(shipRb.velocity, maxMoveSpeed);
        }
    }
    private void ShipRotation()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
    }

}