using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class Nave : MonoBehaviour
{

    [SerializeField] private float xSpeed = 2.0f;
    [SerializeField] private float ySpeed = 3.0f;
    [SerializeField] private int health = 4;
    [SerializeField] Transform prefabBullet;                    // This is the prefab of the bullet
    [SerializeField] protected Transform prefabExplotion;       // This is the prefab of the explotion
    [SerializeField] protected Transform prefabDeathExplotion;  // This is the prefab of the death explotion
    public static int points = 0;                               // Amount of points the player has
    public bool isInvulnerable = false;                         // Checks if the object should recieve damage or not
    private SpriteRenderer spriteRenderer;                      // This allows me to change the opacity of the sprite


    public UnityEngine.UI.Text txtStats;                        // This text is the one that indicates the player's health and points
    public UnityEngine.UI.Text txtEnd;                          // This text is the one that indicates that the player lost


    // Start is called before the first frame update
    void Start()
    {
        txtEnd.enabled = false;                                 // It is iniciated as false and when the player lost it is enabled
        spriteRenderer = GetComponent<SpriteRenderer>();        // Shortway to get object's SpriteRenderer
    }

    // Update is called once per frame
    void Update()
    {
        txtStats.text = "Health = " + health + "\nPoints: " + points;       //Updates text in screen


        float x1 = Input.GetAxis("Horizontal");
        float y1 = Input.GetAxis("Vertical");

        float x2 = x1 * xSpeed * Time.deltaTime;
        float y2 = y1 * ySpeed * Time.deltaTime;

        CollisionWrapper collision = Collisions.IsOutOfBounds(gameObject);                      // Checks for collisions
        if (x1 > 0 && !collision.CollidingWithEast || x1 < 0 && !collision.CollidingWithWest)   // Only moves if there is no collisions in that direction
            transform.Translate(x2, 0, 0);
        if (y1 > 0 && !collision.CollidingWithNorth || y1 < 0 && !collision.CollidingWithSouth)
            transform.Translate(0, y2, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            var shot = Instantiate(prefabBullet, transform.position, Quaternion.identity);      // Creates bullet
            GetComponent<AudioSource>().Play();                                                 // Creates bullet's sound
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)  //It triggers when it collides with something
    {
        if (collision != null && !isInvulnerable)       // When he is invulnerable, he cannot lose HP
        {
            if (collision.tag == "Enemy" || collision.tag == "EnemyBullet" || collision.tag == "Asteroid")
            {
                health--;
                if (health >= 0)
                {
                    StartCoroutine(TemporalInvulnerability());          // If its damaged, it is invulnerable
                    Transform explosion = Instantiate(prefabExplotion,
                    transform.position, Quaternion.identity);
                    Destroy(explosion.gameObject, 1f);
                }

            }
        }
        if (health < 0)                         // This if is outside because it caused discrepencies when it was inside
        {
            Transform explosion = Instantiate(prefabDeathExplotion,
            transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
            txtEnd.enabled = true;
            txtEnd.text = "Game Over";
            Destroy(gameObject);
        }
    }

    private IEnumerator TemporalInvulnerability()       // It makes the object invulnerable and sets its opacity to 0.5f
    {                                                   // for 1 second, then it comes back to normal

        Color color = spriteRenderer.color;             // Gets spriteRenderer's color
        isInvulnerable = true;
        color.a = Mathf.Clamp01(0.5f);                  // Makes sure number is between 0 and 1
        spriteRenderer.color = color;                   // Then assigns it back
        yield return new WaitForSeconds(1.0f);
        isInvulnerable = false;
        color.a = 1.0f;
        spriteRenderer.color = color;                   // Assigns it back to original
    }
}
