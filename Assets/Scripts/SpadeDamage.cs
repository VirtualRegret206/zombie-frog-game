using UnityEngine;

public class SpadeDamage : MonoBehaviour
{
    public int damage = 25;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ZombieHealth enemy = other.GetComponent<ZombieHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}