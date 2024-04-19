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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBlackHoleSound()
    {
        audioSource.PlayOneShot(blackHoleSound);
    }

    public void StopBlackHoleSound()
    {
        audioSource.Stop();
    }
}
