using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private float size;
    private string asteroidType;
    [SerializeField] private ParticleSystem destroyFx;
    private int hits = 0;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        asteroidType = gameObject.name;
        // transform.localScale = 0.5f * size * Vector3.one;

        Rigidbody rb = GetComponent<Rigidbody>();

        float directionX = Random.Range(-1f, 1f);
        float directionZ = Random.Range(-1f, 1f);
        Vector3 direction = new Vector3(directionX, 0f, directionZ).normalized;
        float spawnSpeed = (Random.Range(4f - size, 5f - size)) + 1f;

        rb.AddForce(direction * spawnSpeed, ForceMode.Impulse);

        gameManager.asteroidCount++;
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hits++;
            if (hits == 3 && asteroidType[0] == 'l')
            {
                OnDestroy();
                gameManager.asteroidCount--;
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            if (hits == 2 && asteroidType[0] == 'm')
            {
                OnDestroy();
                gameManager.asteroidCount--;
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            if (hits == 1 && asteroidType[0] == 's')
            {
                OnDestroy();
                gameManager.asteroidCount--;
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
    void OnDestroy()
    {
        Instantiate(destroyFx, transform.position, transform.rotation); 
    }
}
