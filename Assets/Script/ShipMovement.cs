using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ship Movement")]
    [SerializeField] private float maxMoveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 180f;
    [SerializeField] private float acceleration = 10f;

    [Header("Ship Components")]
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float bulletSpeed = 20f;
    private GameObject tail;

    private Rigidbody shipRb;
    public bool isAlive = true;
    

    private void Start(){
        shipRb = GetComponent<Rigidbody>();
        tail = this.gameObject.transform.GetChild(1).gameObject;
        tail.SetActive(false);

    }
    private void Update()
    {
        if (isAlive)
        {
            ShipAccelaration();
            ShipRotation();
            ShipShoot();
        }
    }
    private void ShipAccelaration()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            shipRb.AddForce(transform.up * acceleration);
            shipRb.velocity = Vector3.ClampMagnitude(shipRb.velocity, maxMoveSpeed);
            tail.SetActive(true);
        }else{
            tail.SetActive(false);
        }
    }
    private void ShipRotation()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);
        }
    }
    private void ShipShoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Shoot");
            Rigidbody bullet = Instantiate(bulletPrefab, spawnBullet.position, Quaternion.identity);
            Vector3 shipVelocity = shipRb.velocity;
            Vector3 shipDirection = transform.rotation * Vector3.up;
            float shipSpeed = Vector3.Dot(shipVelocity, shipDirection);
            if(shipSpeed <0){
                shipSpeed = 0;
            }
            bullet.velocity = shipSpeed * shipDirection;
            bullet.AddForce(spawnBullet.up * bulletSpeed, ForceMode.Impulse);
        }
    }

}