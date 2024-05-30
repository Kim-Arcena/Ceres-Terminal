using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSfx : MonoBehaviour
{
    [SerializeField] private AudioClip blackHoleSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the audioSource
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBlackHoleSound()
    {
        if (audioSource != null && blackHoleSound != null)
        {
            audioSource.PlayOneShot(blackHoleSound);
        }
    }

    public void StopBlackHoleSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
