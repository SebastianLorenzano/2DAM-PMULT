using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float xSpeed = 2;
    [SerializeField] private float ySpeed = -1.0f;
    [SerializeField] Transform prefabEnemyBullet;


    void Start()
    {
        StartCoroutine(Disparar());
    }


    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
        CollisionWrapper collision = Collisions.IsOutOfBounds(gameObject);
        if (x > 0 && collision.CollidingWithEast || x < 0 && collision.CollidingWithWest)
            xSpeed = -xSpeed;
        if (y > 0 && collision.CollidingWithNorth || y < 0 && collision.CollidingWithSouth)
            ySpeed = -ySpeed;
    }

    IEnumerator Disparar()
    {
        float pause = Random.Range(2.0f, 5.0f);
        yield return new WaitForSeconds(pause);
        Transform disparo = Instantiate(prefabEnemyBullet, transform.position, Quaternion.identity);
        StartCoroutine(Disparar());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Player" || collision.tag == "AllyBullet")
            {
                Nave.Points += 10;
                Destroy(gameObject);
            }
                
        }
    }
}
