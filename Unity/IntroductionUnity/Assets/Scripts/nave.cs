using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class Nave : MonoBehaviour
{
    [SerializeField] Transform prefabDisparo;
    [SerializeField] private float xSpeed = 2.0f;
    [SerializeField] private float ySpeed = 3.0f;
    [SerializeField] private int health = 2;

    public UnityEngine.UI.Text txtStats;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtStats.text = "Health = " + health;

        float x1 = Input.GetAxis("Horizontal");
        float y1 = Input.GetAxis("Vertical");

        float x2 = x1 * xSpeed * Time.deltaTime;
        float y2 = y1 * ySpeed * Time.deltaTime;

        if 
        transform.Translate(, , 0);

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
