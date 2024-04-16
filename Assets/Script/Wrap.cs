using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        Vector3 moveAdjustment = Vector3.zero;

        if(viewportPosition.x < 0){
            moveAdjustment.x += 1;
        }
        else if(viewportPosition.x > 1){
            moveAdjustment.x -= 1;
        }
        
        if(viewportPosition.y < 0){
            moveAdjustment.y += 1;
        }
        else if(viewportPosition.y > 1){
            moveAdjustment.y -= 1;
        }

        // Reset the viewportPosition with the original value plus moveAdjustment
        viewportPosition += moveAdjustment;

        // Update the transform position using the adjusted viewportPosition
        transform.position = Camera.main.ViewportToWorldPoint(viewportPosition);
    }
}
