using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float jumpPower = 20;
    private Rigidbody2D rb;
    private float spawnX = -1.5f, spawnY = 4f;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        height = GetComponent<Collider2D>().bounds.size.y;


    }



    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);
        float salto = Input.GetAxis("Jump");
        if (salto > 0)
            Jump();

    }

    void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1));
        if (hit.collider != null && hit.distance < height)
        {
            Vector3 fuerzaSalto = new Vector3(0, jumpPower, 0);
            rb.AddForce(fuerzaSalto);
        }
    }

    void SpawnInCheckpoint()
    {
        transform.position = new Vector3(spawnX, spawnY, 0);
        rb.velocity = Vector3.zero;
    }
}



