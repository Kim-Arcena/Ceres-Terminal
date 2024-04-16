using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;

            currentRotation.y -= rotateSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(currentRotation);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;

            currentRotation.y += rotateSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(currentRotation);
        }
    }

}