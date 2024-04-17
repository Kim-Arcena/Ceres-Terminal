using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    private float buffer = 0.1f;

    private void Update()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        Vector3 moveAdjustment = Vector3.zero;

        if (viewportPosition.x < -buffer)
        {
            moveAdjustment.x += 1.09f;
        }
        else if (viewportPosition.x > 1 + buffer)
        {
            moveAdjustment.x -= 1.09f;
        }

        if (viewportPosition.y < -buffer)
        {
            moveAdjustment.y += 1.09f;
        }
        else if (viewportPosition.y > 1 + buffer)
        {
            moveAdjustment.y -= 1.09f;
        }

        viewportPosition += moveAdjustment;

        transform.position = Camera.main.ViewportToWorldPoint(viewportPosition);
    }
}
