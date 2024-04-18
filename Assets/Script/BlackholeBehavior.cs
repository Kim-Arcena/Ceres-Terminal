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
            Transform parentTransform = transform.parent;
            float delaySeconds = (parentTransform.localScale.x * -0.6f) + 3.9f;
            print(parentTransform.localScale.x);
            print(delaySeconds);
            Destroy(collision.gameObject, delaySeconds);
        }
    }
}
