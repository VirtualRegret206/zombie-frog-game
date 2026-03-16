using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections; // Behövs för IEnumerator

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxhealth;
    public Image healthbar;

    [Header("Death")]
    public GameObject gravestonePrefab;

    private bool isDead;

    void Start()
    {
        maxhealth = health;
    }

    void Update()
    {
        healthbar.fillAmount = Mathf.Clamp(health / maxhealth, 0, 1);

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        // 1. Spawn gravstenen
        Instantiate(gravestonePrefab, transform.position, Quaternion.identity);

        // 2. Istället för SetActive(false), gör vi spelaren "osynlig" och stänger av fysik
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // Om du har en Rigidbody2D, gör den statisk så spelaren inte faller genom marken
        if (TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            rb.simulated = false;
        }

        // 3. Starta timern på RespawnManagern istället! 
        // Eftersom RespawnManager inte stängs av, kommer timern fungera.
        RespawnManager.instance.StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Vänta t.ex. 3 sekunder (10 är ganska länge!)

        // Återställ hälsa och status
        health = maxhealth;
        isDead = false;

        // Aktivera grafik och fysik igen
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        if (TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            rb.simulated = true;
        }

        // Flytta spelaren till senaste checkpoint
        RespawnManager.instance.Respawn(gameObject);
    }

    private IEnumerator RestartLevelCoroutine()
    {
        // Vänta 10 sekunder
        yield return new WaitForSeconds(10f);

        // Ladda om nuvarande scen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

