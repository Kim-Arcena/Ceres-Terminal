using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBehaviour : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    [SerializeField] public float bulletForce = 500f;
    [SerializeField] public float fireInterval = 1f;

    private GameObject player;
    [SerializeField] private float fireTimer = 0f;

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
}