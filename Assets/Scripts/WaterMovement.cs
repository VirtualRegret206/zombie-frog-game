using UnityEngine;

public class WaterParticles : MonoBehaviour
{
    public ParticleSystem splashParticles;
    private bool inWater = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if player is moving
        bool isMoving = rb.linearVelocity.magnitude > 0.1f;

        if (inWater && isMoving)
        {
            if (!splashParticles.isPlaying)
                splashParticles.Play();
        }
        else
        {
            if (splashParticles.isPlaying)
                splashParticles.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            inWater = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            inWater = false;
        }
    }
}