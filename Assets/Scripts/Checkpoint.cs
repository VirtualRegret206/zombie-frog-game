using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kolla om det är din spelare "Överlevare" som nuddar den
        if (other.CompareTag("Player"))
        {
            RespawnManager.instance.UpdateCheckpoint(transform.position);
            Debug.Log("Checkpoint sparad!");
        }
    }
}
