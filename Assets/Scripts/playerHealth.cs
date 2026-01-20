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
        isDead = true;

        // Spawn gravstenen
        Vector3 spawnPos = transform.position;
        GameObject grave = Instantiate(gravestonePrefab, spawnPos, Quaternion.identity);
        grave.SetActive(true);

        // Ta bort spelaren
        gameObject.SetActive(false);

        // Starta coroutine istället för Invoke
        StartCoroutine(RestartLevelCoroutine());
    }

    private IEnumerator RestartLevelCoroutine()
    {
        // Vänta 10 sekunder
        yield return new WaitForSeconds(10f);

        // Ladda om nuvarande scen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

