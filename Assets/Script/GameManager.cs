using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Asteroids[] asteroidPrefabs;
    [SerializeField] private Asteroids asteroidPrefab;

    public int asteroidCount = 3;
    private int level = 1;
    private float asteroidSize;
    private int asteroidIndex;
    private bool asteroidsSpawned = false;

    private void Update()
    {
        if (!asteroidsSpawned)
        {
            for(int i = 0; i< asteroidCount; i++){
                asteroidSize = Random.Range(0.8f,1.2f);
                asteroidIndex = Random.Range(0,3);
                SpawnAsteroid(asteroidSize, asteroidIndex);
            }
            asteroidsSpawned = true;
        }
    }



    private void SpawnAsteroid(float asteroidSize, int asteroidIndex)
    {
        int edge = Random.Range(0, 4);
        Vector3 spawnPosition = Vector3.zero;

        Debug.Log("asteroidSize " + spawnPosition);

        switch (edge)
        {
            case 0: // Top edge
                spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, 1.1f, 10));
                break;
            case 1: // Bottom edge
                spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, -0.1f, 10));
                break;
            case 2: // Left edge
                spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, Random.value, 10));
                break;
            case 3: // Right edge
                spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, Random.value, 10));
                break;
        }

        Asteroids asteroid = Instantiate(asteroidPrefabs[asteroidIndex], spawnPosition, Quaternion.Euler(90, 0, 0));

        asteroid.transform.localScale = Vector3.one * -asteroidSize;
        
        asteroid.gameManager = this;
    }


}
