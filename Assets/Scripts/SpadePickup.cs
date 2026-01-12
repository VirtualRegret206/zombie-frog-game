using UnityEngine;

public class SpadePickup : MonoBehaviour
{
    public GameObject SpadeOnPlayer;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    void PickUp()
    {
        SpadeOnPlayer.SetActive(true);
        Destroy(gameObject);
    }
}