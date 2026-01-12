using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRange = 5f;
    Transform player;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    [Header("Seperation")]
    public float separationRadius = 1.2f;
    public float separationStrength = 1.5f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (player.position.x < transform.position.x)
            sprite.flipX = true;
        else
            sprite.flipX = false;
        if (distance <= detectionRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
        
    }
}
