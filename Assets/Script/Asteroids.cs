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
    
    // [SerializeField] private ParticleSystem explosion;

    public GameManager gameManager;
    private int hits = 0;
    private string asteroidName;

    // Start is called before the first frame update
    void Start()
    {
        // transform.localScale = 0.5f * size * Vector3.one;
        asteroidName = gameObject.name;
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            hits++;
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            Destroy(other.gameObject); //destroys the bullet
            if(hits == 3 && asteroidName[0] == 'l'){
                OnDestroy();
                for(int i = 0; i < 2; i++){
                    Instantiate(mediumAsteroids[Random.Range(0, 5)], transform.position, transform.rotation);
                }
                Destroy(gameObject);
            }
            if(hits == 2 && asteroidName[0] == 'm'){
                OnDestroy();
                for(int i = 0; i < 2; i++){
                    Instantiate(smallAsteroids[Random.Range(0, 4)], transform.position, transform.rotation);
                }
                Destroy(gameObject);
            }
            if(hits == 1 && asteroidName[0] == 's'){
                OnDestroy();
                Destroy(gameObject);
            }
        }
    }
    private void OnDestroy() {
        if(gameManager != null){
            gameManager.asteroidCount--;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(destroySound, transform.position);
    }
}
