using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeplerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float xOutSight = -13f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        
        if(transform.position.x <= xOutSight)
        {
            Destroy(gameObject);
        }
    }
}
