using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHP = 50;
    public int currentHP;

    Animator anim;

    void Start()
    {
        currentHP = maxHP;
        anim = GetComponent<Animator>();
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
        Debug.Log("Zombien dog!");
        anim.SetTrigger("Die");
    }
}