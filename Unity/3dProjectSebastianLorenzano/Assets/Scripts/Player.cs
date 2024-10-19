using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 3;
    public float jumpStrength;
    public float speed;
    private int pickUpCount;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private Renderer r;
    private AudioSource audioSource;        //Audio source component attached
    [SerializeField] protected Transform prefabCollisionWall;       // This is the prefab of the explotion
    [SerializeField] protected Transform prefabCollisionPickup;  // This is the prefab of the death explotion
    public int level = 1;
    public int PickUpCount => pickUpCount;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

        if (transform.position.y <= -25)            // If the player falls off the map
        {
            health--;
            if (health <= 0)
                winText.text = "You lose!";
                
            else
            {
                transform.position = new Vector3(0, 4, 0);          // Teleports him back to the start
                rb.velocity = new Vector3(0, 0, 0);                 // Makes it so he is not affected by mover prior to the teleport
            }
                
        }
            
       
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f,
        moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.transform.position = new Vector3(0, -100, 0);        // Moves the pickup to a place where it can't be seen
            pickUpCount++;
            SetCountText();
            Transform explosion = Instantiate(prefabCollisionPickup, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("WallNoCollision"))           
        {
            audioSource.Play();
            Transform explosion = Instantiate(prefabCollisionWall, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 0.5f);
        }
    }


    void SetCountText()
    {
        countText.text = "Health:  " + health + "\nPoints: " + pickUpCount;
        if (pickUpCount >= 24)
        {
            winText.text = "You Win!";
            if (level == 1)
                SceneManager.LoadScene("Level2");
        }
            
    }


}
