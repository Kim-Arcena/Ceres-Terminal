using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    [SerializeField] private float buffer = 0.1f;
    [SerializeField] private float cornerLimit = 1.1f;

    private void Update()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        Vector3 moveAdjustment = Vector3.zero;

        if (viewportPosition.x < -buffer)
        {
            moveAdjustment.x += cornerLimit;
        }
        else if (viewportPosition.x > 1 + buffer)
        {
            moveAdjustment.x -= cornerLimit;
        }

        if (viewportPosition.y < -buffer)
        {
            moveAdjustment.y += cornerLimit;
        }
        else if (viewportPosition.y > 1 + buffer)
        {
            moveAdjustment.y -= cornerLimit;
        }

        viewportPosition += moveAdjustment;

        transform.position = Camera.main.ViewportToWorldPoint(viewportPosition);
    }
}
