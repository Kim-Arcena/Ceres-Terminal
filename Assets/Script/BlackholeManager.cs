using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeManager : MonoBehaviour
{
    public GameObject blackholePrefab;
    [SerializeField] public Vector3 spawnPos; 
    [SerializeField] public float startDelay = 5.0f;
    [SerializeField] private float minRepeatRate = 3.0f;
    [SerializeField] private float maxRepeatRate = 6.0f;
    [SerializeField] public float xPosBoundary = 5f;
    [SerializeField] public float zPosBoundary = 5f;
    [SerializeField] public float xRange = 8f;
    [SerializeField] public float zRange = 4f;
    [SerializeField] private int currentBlackholeCount = 0;
    [SerializeField] private float scaleFactor;
    [SerializeField] private float minScale = 1.5f;
    [SerializeField] private float maxScale = 4.0f;
    [SerializeField] private float newXPos;
    [SerializeField] private float newZPos;

    void Start()
    {
        InvokeRepeating("SpawnBlackhole", startDelay, Random.Range(minRepeatRate, maxRepeatRate));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBlackhole()
    {
        if (currentBlackholeCount < 2)
        {
            do
            {
                newXPos = Random.Range(-xRange, xRange);

            } while ((newXPos < xPosBoundary) && (newXPos > -xPosBoundary));

            do
            {
                newZPos = Random.Range(-zRange, zRange);

            } while ((newZPos < zPosBoundary) && (newZPos > -zPosBoundary));

            scaleFactor = Random.Range(minScale, maxScale);
            spawnPos = new Vector3(newXPos, 50, newZPos);

            Vector3 scale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

            // Instantiate(blackholePrefab, spawnPos, blackholePrefab.transform.rotation);

            GameObject newBlackHole = Instantiate(blackholePrefab, spawnPos, Quaternion.identity);
            newBlackHole.transform.localScale = scale;
            currentBlackholeCount++;
        }
    }

    public void DecrementBotCount()
    {
        currentBlackholeCount--;
    }
}
