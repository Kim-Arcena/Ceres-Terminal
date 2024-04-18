using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeBehavior : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 30f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
