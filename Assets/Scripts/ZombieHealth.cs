using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    private ZombieAI movement;
    public int maxHP = 50;
    public int currentHP;
    private bool isDead = false;

    // NY RAD: Referens till lådan som ska dyka upp
    public GameObject nextLevelBox;

    Animator anim;

    void Start()
    {
        currentHP = maxHP;
        anim = GetComponent<Animator>();
        movement = GetComponent<ZombieAI>();

        // Valfritt: Se till att lådan är gömd från början
        if (nextLevelBox != null)
        {
            nextLevelBox.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Zombien tog skada! HP: " + currentHP);

        if (currentHP <= 0 && !isDead) // Lade till !isDead så den inte dör flera gånger
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

        // NY KOD: Aktivera lådan när zombien dör
        if (nextLevelBox != null)
        {
            nextLevelBox.SetActive(true);
        }

        Debug.Log("Koden triggas - Lådan visas!");
        GetComponent<Collider2D>().enabled = false;
    }
}