using UnityEngine;

public class ParabolicMovement : MonoBehaviour
{
    private Vector3 startPoint = new Vector3(-50f, 0f, -12f);
    private Vector3 endPoint = new Vector3(50f, 0f, -12f);
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

        Vector3 newPosition = Vector3.Lerp(startPoint, endPoint, fracJourney) + Vector3.forward * zOffset;
        newPosition.y = 17;

        transform.position = newPosition;

        if (fracJourney >= 1.0f)
        {
            startTime = Time.time;
        }
    }
}
