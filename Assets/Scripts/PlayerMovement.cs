using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    float moveX;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        bool isRunning = x != 0 || y != 0;
        animator.SetBool("isRunning", isRunning);
        Vector3 movement = new Vector3(x, y, 0f);
        transform.position += movement * speed * Time.deltaTime;
        Debug.DrawLine(transform.position, movement);
        moveX = Input.GetAxisRaw("Horizontal");
        if (moveX > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveX < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}