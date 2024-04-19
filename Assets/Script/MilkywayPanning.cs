using System.Collections;
using UnityEngine;

public class MilkywayPanning : MonoBehaviour
{
    [SerializeField] private float targetScale;
    [SerializeField] private float startScale;
    [SerializeField] private float duration;

    void Start()
    {
        StartCoroutine(ScaleOverTime());
    }

    IEnumerator ScaleOverTime()
    {
        float currentTime = 0f;

        while (currentTime <= duration)
        {
            float scale = Mathf.Lerp(startScale, targetScale, currentTime / duration);
            transform.localScale = new Vector3(scale, scale, scale);
            currentTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = new Vector3(targetScale, targetScale, targetScale);
    }
}
