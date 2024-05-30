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

    [SerializeField] private string asteroidType;
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
            spawnSpeed = -7f * 4f + 7f;
        } else if (asteroidName[0] == 'm') {
            spawnSpeed = -7f * 3f + 4f;
        } else if (asteroidName[0] == 's') {
            spawnSpeed = -7f * 2f + 3f;
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
                if (asteroidType != "Base")
                {
                    HandleDestruction();
                }
                else
                {
                    StartCoroutine(DestroyAsteroid());
                }
            }
        }
    }

    private void HandleDestruction() {
        if (gameManager != null) {
            gameManager.asteroidCount--;
        }

        // Add score based on asteroid size
        if (asteroidName[0] == 'l')
        {
            ScoreManager.Instance.AddScore(10);
        }
        else if (asteroidName[0] == 'm')
        {
            ScoreManager.Instance.AddScore(20);
        }
        else if (asteroidName[0] == 's')
        {
            ScoreManager.Instance.AddScore(30);
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
