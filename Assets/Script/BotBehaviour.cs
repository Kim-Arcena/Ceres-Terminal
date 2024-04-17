using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBehaviour : MonoBehaviour
{
    [SerializeField] public float speed = 5f; // Adjust this to control the speed of the enemy ship
    public Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}