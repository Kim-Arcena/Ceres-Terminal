using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotBehaviour : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 2.5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    [SerializeField] public float bulletForce = 250f;
    [SerializeField] public float fireInterval = 3f;

    private GameObject player;
    [SerializeField] private float fireTimer = 1.0f;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip destroySound;

    [SerializeField] private ParticleSystem explosion;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);

            fireTimer += Time.deltaTime;
            if (fireTimer >= fireInterval)
            {
                fireTimer = 0f;
                AttackPlayer();
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
            }
        }
    }

    void AttackPlayer()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        Vector3 directionToPlayer = (player.transform.position - firePoint.position).normalized;
        bulletRigidbody.AddForce(directionToPlayer * bulletForce);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
            Destroy(collision.gameObject);
            Destroy(gameObject);

            BotSpawnManager spawnManager = FindObjectOfType<BotSpawnManager>();
            if (spawnManager != null)
            {
                spawnManager.DecrementBotCount(gameObject);
            }
        }
    }
}