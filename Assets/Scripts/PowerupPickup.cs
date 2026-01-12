using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class PowerupPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}