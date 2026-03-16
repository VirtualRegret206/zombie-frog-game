using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int zombiesKilled = 0;
    public GameObject nextLevelBox;

    void Awake()
    {
        instance = this;
    }

    public void ZombieKilled()
    {
        zombiesKilled++;

        Debug.Log("Zombies dödade: " + zombiesKilled);

        if (zombiesKilled >= 3)
        {
            nextLevelBox.SetActive(true);
        }
    }
}