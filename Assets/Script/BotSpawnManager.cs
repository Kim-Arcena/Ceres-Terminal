using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BotSpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject botPrefab;
    [SerializeField] public UnityEngine.Vector3 spawnPos; 
    [SerializeField] public float startDelay = 5.0f;
    [SerializeField] public float minRepeatRate = 1.0f;
    [SerializeField] public float maxRepeatRate = 5.5f;
    [SerializeField] public float xPosBoundary = 10f;
    [SerializeField] public float zPosBoundary = 10f;
    [SerializeField] public float newXPos;
    [SerializeField] public float newZPos;
    [SerializeField] public float xRange = 50;
    [SerializeField] public float zRange = 50;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBot", startDelay, Random.Range(minRepeatRate, maxRepeatRate));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBot()
    {
        do
        {
            newXPos = Random.Range(-xRange, xRange);
        }while((newXPos < xPosBoundary) && (newXPos > -xPosBoundary));

        do
        {
            newZPos = Random.Range(-zRange, zRange);
        }while((newZPos < zPosBoundary) && (newZPos > -zPosBoundary));

        spawnPos = new UnityEngine.Vector3(newXPos, 15, newZPos);
        Instantiate(botPrefab, spawnPos, botPrefab.transform.rotation);
    }
}