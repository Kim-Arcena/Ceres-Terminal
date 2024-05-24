using UnityEngine;

public class ParabolicMovement : MonoBehaviour
{
    private Vector3 startPoint = new Vector3(-50f, 15f, -9f);
    private Vector3 endPoint = new Vector3(50f, 15f, -9f);
    public float height = 5f;
    public float speed = 1f;

    private float journeyLength;
    private float startTime;

    void Start()
    {
        journeyLength = Vector3.Distance(startPoint, endPoint);
        startTime = Time.time;
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;

        float fracJourney = distCovered / journeyLength;

        float zOffset = -height * Mathf.Sin(Mathf.PI * fracJourney);

        transform.position = Vector3.Lerp(startPoint, endPoint, fracJourney) + Vector3.forward * zOffset;

        if (fracJourney >= 1.0f)
        {
            startTime = Time.time;
        }
    }
}
