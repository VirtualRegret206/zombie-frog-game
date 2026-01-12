using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHP = 50;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
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
        Destroy(gameObject);
    }
}