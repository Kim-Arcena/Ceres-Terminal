 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private float size;
<<<<<<< Updated upstream

=======
    private string asteroidType;
    [SerializeField] private ParticleSystem destroyFx;
    [SerializeField] private Asteroids[] mediumAsteroidPrefabs;
    [SerializeField] private Asteroids[] smallAsteroidPrefabs;


    private int hits = 0;
>>>>>>> Stashed changes
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
        if(gameManager != null){
            gameManager.asteroidCount++;
        }
        
    }
<<<<<<< Updated upstream
=======
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
                for(int i = 0; i < 2; i++){
                    Instantiate(mediumAsteroidPrefabs[Random.Range(0, 5)], transform.position, transform.rotation);
                }
                OnDestroy();
                gameManager.asteroidCount--;
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            if (hits == 2 && asteroidType[0] == 'm')
            {
                for(int i = 0; i < 2; i++){
                    Instantiate(smallAsteroidPrefabs[Random.Range(0, 4)], transform.position, transform.rotation);
                }
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
>>>>>>> Stashed changes
}
