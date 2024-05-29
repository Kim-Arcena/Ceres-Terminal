using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BlackholeBehavior : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField] private float scaledRotation;
    [SerializeField] private float delaySeconds = 2.0f;
    private bool destructionScheduled = false;
    private float delayStartTime;
    void Start()
    {
        Transform parentTransform = transform.parent;
        scaledRotation = rotationSpeed / parentTransform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, scaledRotation * Time.deltaTime);
    }

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        // Disable the ShipMovement script
        PlayerMovement shipMovement = collision.gameObject.GetComponent<PlayerMovement>();
        if (shipMovement != null)
        {
            shipMovement.enabled = false;
        }

        Transform parentTransform = transform.parent;
        float delaySeconds = (parentTransform.localScale.x * -0.6f) + 1f;
        print(parentTransform.localScale.x);
        print(delaySeconds);
        Destroy(collision.gameObject);
        shipMovement.isAlive = false;
    }
    else if (collision.gameObject.CompareTag("Obstacle")){
        Destroy(collision.gameObject);
    }
}
private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Bullet"))
    {
        Destroy(other.gameObject);
    }

}}
