using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class Nave : MonoBehaviour
{
    [SerializeField] Transform prefabDisparo;
    [SerializeField] private float xSpeed = 2.0f;
    [SerializeField] private float ySpeed = 3.0f;
    [SerializeField] private int health = 3;
    [SerializeField] protected Transform prefabExplotion;
    [SerializeField] protected Transform prefabDeathExplotion;
    public static int Points = 0;
    public float Width { get; private set; }
    public float Height { get; private set; }
    public bool isInvulnerable = false;
    private SpriteRenderer spriteRenderer;                      // This allows me to change the opacity of the sprite


    public UnityEngine.UI.Text txtStats;
    public UnityEngine.UI.Text txtEnd;


    // Start is called before the first frame update
    void Start()
    {
        txtEnd.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        txtStats.text = "Health = " + health + "\nPoints: " + Points;


        float x1 = Input.GetAxis("Horizontal");
        float y1 = Input.GetAxis("Vertical");

        float x2 = x1 * xSpeed * Time.deltaTime;
        float y2 = y1 * ySpeed * Time.deltaTime;

        CollisionWrapper collision = Collisions.IsOutOfBounds(gameObject);
        if (x1 > 0 && !collision.CollidingWithEast || x1 < 0 && !collision.CollidingWithWest)
            transform.Translate(x2, 0, 0);
        if (y1 > 0 && !collision.CollidingWithNorth || y1 < 0 && !collision.CollidingWithSouth)
            transform.Translate(0, y2, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            var shot = Instantiate(prefabDisparo, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && !isInvulnerable)
        {
            if (collision.tag == "Enemy" || collision.tag == "EnemyBullet" || collision.tag == "Asteroid")
            {
                health--;
                if (health >= 0)
                {
                    StartCoroutine(TemporalInvulnerability());
                    Transform explosion = Instantiate(prefabExplotion,
                    transform.position, Quaternion.identity);
                    Destroy(explosion.gameObject, 1f);
                }

            }
        }
        if (health < 0)
        {
            Transform explosion = Instantiate(prefabDeathExplotion,
            transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
            txtEnd.enabled = true;
            txtEnd.text = "Game Over";
            Destroy(gameObject);
        }
    }

    private IEnumerator TemporalInvulnerability()
    {
        Color color = spriteRenderer.color;
        isInvulnerable = true;
        color.a = Mathf.Clamp01(0.5f);
        spriteRenderer.color = color;
        yield return new WaitForSeconds(1.0f);
        isInvulnerable = false;
        color.a = 1.0f;
        spriteRenderer.color = color;
    }
}
