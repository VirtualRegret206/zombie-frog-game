using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Överlevare");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

    }
}
