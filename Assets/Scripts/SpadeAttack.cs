using UnityEngine;
using System.Collections;

public class SpadeAttack : MonoBehaviour
{
    public Transform spade;
    public float swingAngle = 90f;
    public float swingTime = 0.2f;
    public Collider2D spadeCollider;

    private bool isAttacking = false;
    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = spade.localRotation;
        spadeCollider.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(SwingSpade());
        }
    }

    IEnumerator SwingSpade()
    {
        isAttacking = true;
        spadeCollider.enabled = true;

        float halfAngle = swingAngle / 2f;
        float elapsed = 0f;

        
        while (elapsed < swingTime)
        {
            float angle = Mathf.Lerp(-halfAngle, halfAngle, elapsed / swingTime);
            spade.localRotation = Quaternion.Euler(0, 0, angle);
            elapsed += Time.deltaTime;
            yield return null;
        }

        spade.localRotation = originalRotation;
        spadeCollider.enabled = false;
        isAttacking = false;
    }
}