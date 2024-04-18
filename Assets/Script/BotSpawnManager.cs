using UnityEngine;
using System.Collections.Generic;

public class BotSpawnManager : MonoBehaviour
{
    public GameObject botPrefab;
    [SerializeField] public Vector3 spawnPos; 
    [SerializeField] public float delaySpawn = 2.0f;
    [SerializeField] public float minRepeatRate = 1.0f;
    [SerializeField] public float maxRepeatRate = 5.5f;
    [SerializeField] public float xPosBoundary = 5f;
    [SerializeField] public float zPosBoundary = 5f;
    [SerializeField] public float xRange = 15f;
    [SerializeField] public float zRange = 15f;
    [SerializeField] private int currentBotCount = 0;
    private List<GameObject> spawnedBots = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("SpawnBot", delaySpawn, Random.Range(minRepeatRate, maxRepeatRate));
    }

    void Update()
    {
        
    }

    void SpawnBot()
    {
        if (currentBotCount >= 2) // If already at max bot count, return without spawning
        {
            return;
        }

        float newXPos;
        do
        {
            newXPos = Random.Range(-xRange, xRange);
        } while ((newXPos < xPosBoundary) && (newXPos > -xPosBoundary));

        float newZPos;
        do
        {
            newZPos = Random.Range(-zRange, zRange);
        } while ((newZPos < zPosBoundary) && (newZPos > -zPosBoundary));

        spawnPos = new Vector3(newXPos, 50, newZPos);
        // Instantiate(botPrefab, spawnPos, botPrefab.transform.rotation);
        GameObject newBot = Instantiate(botPrefab, spawnPos, botPrefab.transform.rotation);
        spawnedBots.Add(newBot);
        currentBotCount++;
    }

    public void DecrementBotCount(GameObject bot)
    {
        currentBotCount--;
        spawnedBots.Remove(bot);
    }
}