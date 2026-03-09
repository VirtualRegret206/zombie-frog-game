using UnityEngine;
public class SpadeKnockback : MonoBehaviour
{
    public float knockbackForce = 8f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Rigidbody2D zombieRb = collision.GetComponent<Rigidbody2D>();

            if (zombieRb != null)
            {
                Vector2 knockbackDir =
                    (collision.transform.position - transform.position).normalized;

                zombieRb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}