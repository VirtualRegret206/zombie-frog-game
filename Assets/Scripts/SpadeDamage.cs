using UnityEngine;

public class SpadeDamage : MonoBehaviour
{
    public int damage = 25;
    public ParticleSystem bloodParticles;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kontrollera om objektet vi krockar med är en fiende
        if (other.CompareTag("Enemy"))
        {
            ZombieHealth enemy = other.GetComponent<ZombieHealth>();

            if (enemy != null)
            {
                // Ge skada till zombien
                enemy.TakeDamage(damage);

                // HÄR ÄR DIN NYA KOD:
                // Vi kollar först om bloodParticles faktiskt är tilldelad i Unity
                if (bloodParticles != null)
                {
                    Instantiate(
                        bloodParticles,
                        other.ClosestPoint(transform.position),
                        Quaternion.identity
                    );
                }

                Debug.Log("Låt blodet spruta!");
            }
        }
    }
}