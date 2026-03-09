using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    private ZombieAI movement;
    public int maxHP = 50;
    public int currentHP;
    private bool isDead = false;

    Animator anim;

    void Start()
    {
        currentHP = maxHP;
        anim = GetComponent<Animator>();
        movement = GetComponent<ZombieAI>();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Zombien tog skada! HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        anim.SetTrigger("Die");
        if (movement != null)
            movement.enabled = false;
        Debug.Log("Koden triggas");
        GetComponent<Collider2D>().enabled = false;
    }
}