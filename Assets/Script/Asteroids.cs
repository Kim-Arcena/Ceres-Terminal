using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private float size;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // transform.localScale = 0.5f * size * Vector3.one;

        Rigidbody rb = GetComponent<Rigidbody>();

        float directionX = Random.Range(-1f, 1f);
        float directionZ = Random.Range(-1f, 1f);
        Vector3 direction = new Vector3(directionX, 0f, directionZ).normalized;
        float spawnSpeed = (Random.Range(4f - size, 5f - size)) + 1f;

        rb.AddForce(direction * spawnSpeed, ForceMode.Impulse);

        gameManager.asteroidCount++;
    }
}
