using UnityEngine;

public class StarsDistancing : MonoBehaviour
{
    [SerializeField] private float increaseRate = 0.0f;
    [SerializeField] private float maxAspectRatio = 1.5f;
    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (transform.localScale.x < initialScale.x * maxAspectRatio)
        {
            transform.localScale += new Vector3(increaseRate * Time.deltaTime, 0, 0);
        }
    }
}
