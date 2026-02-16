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

    [Header("Knockback")]
    public float knockbackForce = 8f;
    public float knockbackDuration = 0.2f;

    private float knockbackTimer;
    private Vector2 knockbackDirection;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (knockbackTimer > 0)
        {
            // Under knockback – ingen kontroll
            transform.position += (Vector3)(knockbackDirection * knockbackForce * Time.deltaTime);
            knockbackTimer -= Time.deltaTime;
            return;
        }


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

    public void TakeKnockback(Vector2 sourcePosition)
    {
        knockbackDirection = ((Vector2)transform.position - sourcePosition).normalized;
        knockbackTimer = knockbackDuration;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeKnockback(collision.gameObject.transform.position);
        }
    }
}