using UnityEngine;

public class Chekpoint_Kod : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //RespawnManager.instance.SetCheckpoint(transform.position);
            // valfritt: animation/ljud/partikel
        }
    }
}

