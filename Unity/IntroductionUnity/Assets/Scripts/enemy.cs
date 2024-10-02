using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float xSpeed = -2f;         
    [SerializeField] private float ySpeed = -0.001f;
    [SerializeField] Transform prefabEnemyBullet;
    private bool HasHitBounds = false;                  


    void Start()
    {
        StartCoroutine(Shoot());
    }


    void Update()
    {
        transform.Translate(xSpeed * Time.deltaTime, 0, 0);                         // Enemy moves
        CollisionWrapper collision = Collisions.IsOutOfBounds(gameObject);          // Enemy checks for collision
        var x = transform.position.x;
        var y = transform.position.y;
        if (x > 0 && collision.CollidingWithEast && !HasHitBounds || x < 0 && collision.CollidingWithWest && !HasHitBounds) //If it collides, it changes positions
        {
            StartCoroutine(HitBounds());
            xSpeed = -xSpeed;
            transform.Translate(0, ySpeed, 0);
        }
            
        if (y > 0 && collision.CollidingWithNorth || y < 0 && collision.CollidingWithSouth)
        {
            ySpeed = -ySpeed;
            transform.Translate(0, ySpeed, 0);
        }
            
    }

    IEnumerator Shoot()     //After a few seconds it shoots
    {
        float pause = Random.Range(2.0f, 5.0f);
        yield return new WaitForSeconds(pause);
        Transform disparo = Instantiate(prefabEnemyBullet, transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();         //Plays shot's audio
        StartCoroutine(Shoot());
    }


    private void OnTriggerEnter2D(Collider2D collision)     
    {
        if (collision != null)
        {
            if (collision.tag == "Player" && collision.gameObject.GetComponent<Nave>().isInvulnerable == false || collision.tag == "AllyBullet")
                IsHit();

        }
    }

    public void IsHit()
    {
        Nave.points += 10;
        Destroy(gameObject);
    }

    private IEnumerator HitBounds()             //This makes sure it doesn't hit the wall multiple times, and can only hit it once
    {
        HasHitBounds = true;
        yield return new WaitForSeconds(1.0f);
        HasHitBounds = false;

    }
}
