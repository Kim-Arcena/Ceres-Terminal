using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehavior : MonoBehaviour
{
    private PlayerMovement playerManager;
    [SerializeField] private GameObject explosion;
    [SerializeField] AudioClip accelarationSound;
    private AudioSource audioSource;
    private Collider shipCollider;

    void Start()
    {
        playerManager = FindObjectOfType<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
        shipCollider = GetComponent<Collider>();
        
        StartCoroutine(Invincible());
        StartCoroutine(FlickerWhileInvincible());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            playerManager.isAlive = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
        if(collision.gameObject.CompareTag("HugeAsteroid"))
        {
            Debug.Log("Big asteroid hit");
        }
    }
    private void Flicker(){
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }
    private IEnumerator Invincible(){
        shipCollider.isTrigger = true;
        yield return new WaitForSeconds(1f);
        shipCollider.isTrigger = false;
    }
    private IEnumerator FlickerWhileInvincible()
    {
        float flickerTime = 1f; // Total time for flickering (same as invincible time)
        float flickerDuration = 0.1f; // Duration of each flicker
        float flickerInterval = 0.05f; // Interval between flickers

        while (flickerTime > 0f)
        {
            Flicker();
            flickerTime -= flickerDuration;

            // Wait for flickerDuration
            yield return new WaitForSeconds(flickerDuration);

            // Wait for flickerInterval
            yield return new WaitForSeconds(flickerInterval);
        }

        // Ensure renderer is enabled after flickering ends
        GetComponent<Renderer>().enabled = true;
    }
    public void PlayAccelarationSound()
    {
        audioSource.clip = accelarationSound;
        audioSource.Play();
    }
    public void StopAccelarationSound()
    {
        audioSource.Stop();
    }
}
