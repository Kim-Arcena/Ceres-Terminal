using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehavior : MonoBehaviour
{
    private PlayerMovement playerManager;
    [SerializeField] private GameObject explosion;

    void Start()
    {
        playerManager = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            playerManager.isAlive = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
        if(collision.gameObject.CompareTag("HugeAsteroid"))
        {
            Debug.Log("Big asteroid hit");
        }
    }
}
