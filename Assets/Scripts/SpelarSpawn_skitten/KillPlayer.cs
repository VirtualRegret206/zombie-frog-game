using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject Överlevare;
    public Transform respawnPoint; 
    //Video Guide: https://www.youtube.com/watch?v=tBj-FWcIwYw 4:32
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Överlevare"))
        {
            Överlevare.transform.position = respawnPoint.position;
        }
    }
}
