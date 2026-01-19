using UnityEngine;
using UnityEngine.UI;

// Video guiden är: https://www.youtube.com/watch?v=bRcMVkJS3XQ 3:38
public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxhealth;
    public Image healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxhealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = Mathf.Clamp(health / maxhealth, 0, 1);
    }
}
