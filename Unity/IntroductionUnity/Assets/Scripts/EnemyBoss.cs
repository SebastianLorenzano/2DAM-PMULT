using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] private float xSpeed = 2f;
    [SerializeField] private float ySpeed = -1.0f;
    [SerializeField] Transform prefabEnemyBullet;


    void Start()
    {
        
        StartCoroutine(Disparar());
        StartCoroutine(Move());
    }


    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        CollisionWrapper collision = Collisions.IsOutOfBounds(gameObject);
        if (x > 0 && collision.CollidingWithEast || x < 0 && collision.CollidingWithWest)   //copy from main character
            xSpeed = -xSpeed;
        if (y > 0 && collision.CollidingWithNorth || y < 0 && collision.CollidingWithSouth)
            ySpeed = -ySpeed;
    }

    float GetRandomSpeed()
    {
        int random;
        if (Random.Range(-1, 1) > 0)
            random = 1;
        else
            random = -1;

        return Random.Range(2, 5) * random;
        
    }

    IEnumerator Move()
    {
        
        float pause = Random.Range(3.0f, 5.0f);
        yield return new WaitForSeconds(pause);
        xSpeed = GetRandomSpeed();
        ySpeed = GetRandomSpeed();
        StartCoroutine(Move());
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
