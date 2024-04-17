using UnityEngine;

public class BotSpawnManager : MonoBehaviour
{
    public GameObject botPrefab;
    [SerializeField] public Vector3 spawnPos; 
    [SerializeField] public float startDelay = 5.0f;
    [SerializeField] public float minRepeatRate = 1.0f;
    [SerializeField] public float maxRepeatRate = 5.5f;
    [SerializeField] public float xPosBoundary = 10f;
    [SerializeField] public float zPosBoundary = 10f;
    [SerializeField] public float xRange = 50;
    [SerializeField] public float zRange = 50;

    [SerializeField] private int currentBotCount = 0;

    void Start()
    {
        InvokeRepeating("SpawnBot", startDelay, Random.Range(minRepeatRate, maxRepeatRate));
    }

    void Update()
    {
        
    }

    void SpawnBot()
    {
        if (currentBotCount < 2)
        {
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

            spawnPos = new Vector3(newXPos, 15, newZPos);
            Instantiate(botPrefab, spawnPos, botPrefab.transform.rotation);
            currentBotCount++;
        }
    }

    public void DecrementBotCount()
    {
        currentBotCount--;
    }
}
