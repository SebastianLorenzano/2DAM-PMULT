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
    [SerializeField] private int health = 2;
    [SerializeField] private GameObject background;
    public static int Points = 0;
    private Camera cam;
    private Renderer shipRenderer;
    public float Width { get; private set; }
    public float Height { get; private set; }


    public UnityEngine.UI.Text txtStats;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        shipRenderer = GetComponent<Renderer>();
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
            var disparo = Instantiate(prefabDisparo, transform.position, Quaternion.identity);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Enemy" || collision.tag == "EnemyBullet")
                health--;
            if (health < 0)
                Destroy(gameObject);
        }
    }
}
