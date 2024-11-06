using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float jumpPower = 10;
    private float spawnX = -1.5f, spawnY = 4f;
    private float height;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        height = GetComponent<Collider2D>().bounds.size.y;
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1));
        isGrounded = hit.collider != null && hit.distance < height;



        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0.1f || horizontal < -0.1f)
        {
            if (horizontal > 0.1f)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);

            if (isGrounded)                     // Prevents from the running animation being used while jumping
                animator.Play("Running");
            transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    void Jump()
    {
        Debug.Log("Trying to jump");
        if (isGrounded)
        {
            Debug.Log("Jumping to jump");
            animator.SetTrigger("JumpTrigger");
            Vector3 fuerzaSalto = new Vector2(0, jumpPower);
            rb.AddForce(fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    void SpawnInCheckpoint()
    {
        transform.position = new Vector3(spawnX, spawnY, 0);
        rb.velocity = Vector3.zero;
    }
}



