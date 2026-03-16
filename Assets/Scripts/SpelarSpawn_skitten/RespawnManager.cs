using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance;
    private Vector3 currentCheckpoint;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // Hitta din spelare (Överlevare) och sätt startpositionen
        GameObject player = GameObject.Find("Överlevare");
        if (player != null) currentCheckpoint = player.transform.position;
    }

    public void UpdateCheckpoint(Vector3 newPos)
    {
        currentCheckpoint = newPos;
    }

    public void Respawn(GameObject player)
    {
        player.transform.position = currentCheckpoint;

        // Nollställ fysik om du har Rigidbody2D
        if (player.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}