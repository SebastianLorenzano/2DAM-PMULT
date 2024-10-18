using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 3;
    public float jumpStrength;
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private Renderer r;
    private int pickUpCount;
    [SerializeField] protected Transform prefabCollisionWall;       // This is the prefab of the explotion
    [SerializeField] protected Transform prefabCollisionPickup;  // This is the prefab of the death explotion
    public int PickUpCount => pickUpCount;

    // Este script es otra forma de mover la bola
    float velocidadAvance = 2.0f; // 2 m/s
    float velocidadRotac = 180.0f; // 180 grados por segundo
                                   // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        r = GetComponent<Renderer>();
        pickUpCount = 0;
        SetCountText();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }

        if (transform.position.y <= -25)
        {
            health--;
            if (health <= 0)
                winText.text = "You lose!";
            else
            {
                transform.position = new Vector3(0, 4, 0);
                rb.velocity = new Vector3(0, 0, 0);
            }
                
        }
            
       
    }

    void FixedUpdate()
    {
        // Recogemos el valor de las flechas
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // Creamos un Vector3 X será el horizontal y Z el vertica
        Vector3 movement = new Vector3(moveHorizontal, 0.0f,
        moveVertical);
        // Aplicamos una fuerza teniendo en cuenta los ejes y la velocidad
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            pickUpCount++;
            SetCountText();
            Transform explosion = Instantiate(prefabCollisionPickup, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Transform explosion = Instantiate(prefabCollisionWall, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 0.5f);
        }
        else if (collision.gameObject.CompareTag("WallNoCollision"))
        {
            Transform explosion = Instantiate(prefabCollisionWall, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 0.5f);
        }

    }


    void SetCountText()
    {
        countText.text = "Count: " + pickUpCount;
        if (pickUpCount >= 12)
            winText.text = "You Win!";
    }


}
