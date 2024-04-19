using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehavior : MonoBehaviour
{
    private PlayerMovement playerManager;

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
            playerManager.isAlive = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
