using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
   public float speed = 7.5f; // Speed of movement

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}

