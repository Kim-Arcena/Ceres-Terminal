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
    [SerializeField] public float xPosBoundary = 8f;
    [SerializeField] public float zPosBoundary = 4f;
    [SerializeField] public float xRange = 8f;
    [SerializeField] public float minZRange = -4f;
    [SerializeField] public float maxZRange = 4f;
    [SerializeField] private int currentBlackholeCount = 0;
    [SerializeField] private float scaleFactor;
    [SerializeField] private float minScale = 0.005f;
    [SerializeField] private float maxScale = 0.01f;
    [SerializeField] private float newXPos;
    [SerializeField] private float newZPos;
    [SerializeField] private int blackholeCount = 5;
    [SerializeField] private AudioClip blackholeSound;
    private BlackHoleSfx blackHoleSfx;


    void Start()
    {
        InvokeRepeating("SpawnBlackhole", startDelay, Random.Range(minRepeatRate, maxRepeatRate));
        blackHoleSfx = GetComponent<BlackHoleSfx>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBlackhole()
    {
        if (currentBlackholeCount < blackholeCount)
        {
            AudioSource.PlayClipAtPoint(blackholeSound, transform.position);
            blackHoleSfx.PlayBlackHoleSound();
            bool isValidSpawnPosition = false;
            Vector3 newSpawnPos = Vector3.zero;

            // Keep generating new spawn positions until a valid one is found
            while (!isValidSpawnPosition)
            {
                // Generate a random spawn position within boundaries
                newXPos = Random.Range(-8, 8);
                newZPos = Random.Range(-4, 4);
                newSpawnPos = new Vector3(newXPos, 50, newZPos);

                // Check distance from existing black holes
                isValidSpawnPosition = IsPositionValid(newSpawnPos);
            }

            // Instantiate the blackhole prefab
            GameObject newBlackHole = Instantiate(blackholePrefab, newSpawnPos, Quaternion.identity);

            // Get the box collider of the spawned asteroid
            BoxCollider collider = newBlackHole.transform.GetChild(0).GetComponent<BoxCollider>();

            // Start scaling coroutine
            StartCoroutine(ScaleUpBlackHole(newBlackHole.transform, collider));

            currentBlackholeCount++;
        }
    }
    bool IsPositionValid(Vector3 position)
    {
        // Iterate through all existing black holes
        foreach (GameObject blackHole in GameObject.FindGameObjectsWithTag("BlackHole"))
        {
            // Calculate the distance between the new position and existing black holes
            float distance = Vector3.Distance(position, blackHole.transform.position);
            // If the distance is less than 2 units, return false (not a valid position)
            if (distance < 5f)
            {
                return false;
            }
        }
        // If no black holes are too close, return true (valid position)
        return true;
    }


    IEnumerator ScaleUpBlackHole(Transform asteroidTransform, BoxCollider collider)
    {
        collider.isTrigger = true;
        float timer = 0f;

        // Initial scale of the asteroid
        Vector3 initialScale = Vector3.one * 0.1f;

        // Final scale of the asteroid
        Vector3 targetScale = Vector3.one *Random.Range(0.5f, 1.0f);

        // Slowly scale up the asteroid over 2 seconds
        while (timer < 2f)
        {
            timer += Time.deltaTime;

            float t = timer / 2f;
            if (t > 1f)
            {
                collider.isTrigger = false;
            }

            

            // Interpolate scale from initial to target scale
            asteroidTransform.localScale = Vector3.Lerp(initialScale, targetScale, t);

            yield return null;
        }

        // Ensure the asteroid has reached its final scale
        asteroidTransform.localScale = targetScale;
        yield return new WaitForSeconds(10f);
        // Scale down the asteroid over 2 seconds
        timer = 0f;
        while (timer < 2f)
        {
            timer += Time.deltaTime;

            float t = timer / 2f;

            // Interpolate scale from target scale to initial scale
            asteroidTransform.localScale = Vector3.Lerp(targetScale, initialScale, t);

            yield return null;
        }

        // Ensure the asteroid has reached its initial scale
        asteroidTransform.localScale = initialScale;
        blackHoleSfx.StopBlackHoleSound();
        Destroy(asteroidTransform.gameObject);
    }
}
