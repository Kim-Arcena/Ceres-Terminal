using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private float size;
    [SerializeField] private Asteroids[] mediumAsteroids;
    [SerializeField] private Asteroids[] smallAsteroids;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private AudioClip destroySound;
    [SerializeField] private AudioClip hitSound;

    public GameManager gameManager;
    private int hits = 0;
    private string asteroidName;

    void Start()
    {
        asteroidName = gameObject.name;
        Rigidbody rb = GetComponent<Rigidbody>();

        float directionX = Random.Range(-1f, 1f);
        float directionZ = Random.Range(-1f, 1f);
        Vector3 direction = new Vector3(directionX, 0f, directionZ).normalized;
        
        float spawnSpeed = 0f;
        if (asteroidName[0] == 'l') {
            spawnSpeed = -7.5f * 5f + 11f;
        } else if (asteroidName[0] == 'm') {
            spawnSpeed = -7.5f * 4f + 9f;
        } else if (asteroidName[0] == 's') {
            spawnSpeed = -7.5f * 3f + 7f;
        }
        rb.AddForce(direction * spawnSpeed, ForceMode.Impulse);

        if (gameManager != null) {
            gameManager.asteroidCount++;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hits++;
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            Destroy(other.gameObject); // destroys the bullet

            if ((hits == 3 && asteroidName[0] == 'l') ||
                (hits == 2 && asteroidName[0] == 'm') ||
                (hits == 1 && asteroidName[0] == 's'))
            {
                HandleDestruction();
            }
        }
    }

    private void HandleDestruction() {
        if (gameManager != null) {
            gameManager.asteroidCount--;
        }

        StartCoroutine(DestroyAsteroid());
    }

    private IEnumerator DestroyAsteroid() {
        Instantiate(explosion, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(destroySound, transform.position);
        yield return new WaitForSeconds(0.1f);

        if (asteroidName[0] == 'l') {
            for (int i = 0; i < 2; i++) {
                Instantiate(mediumAsteroids[Random.Range(0, 5)], transform.position, transform.rotation);
            }
        } else if (asteroidName[0] == 'm') {
            for (int i = 0; i < 2; i++) {
                Instantiate(smallAsteroids[Random.Range(0, 4)], transform.position, transform.rotation);
            }
        }

        Destroy(gameObject);
    }
}
