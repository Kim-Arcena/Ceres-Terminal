using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ParticleSystem destroyFx;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(destroyFx, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }
}
