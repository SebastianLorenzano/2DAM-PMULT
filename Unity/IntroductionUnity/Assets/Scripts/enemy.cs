using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float xSpeed = 2f;
    [SerializeField] private float ySpeed = -0.001f;
    [SerializeField] Transform prefabEnemyBullet;
    private bool HasHitBounds = false;


    void Start()
    {
        int random;
        StartCoroutine(Shoot());
        if (Random.Range(-1, 1) > 0)
            random = 1;
        else
            random = -1;
        xSpeed *= random;
    }


    void Update()
    {

        transform.Translate(xSpeed * Time.deltaTime, 0, 0);
        CollisionWrapper collision = Collisions.IsOutOfBounds(gameObject);
        var x = transform.position.x;
        var y = transform.position.y;
        if (x > 0 && collision.CollidingWithEast && !HasHitBounds || x < 0 && collision.CollidingWithWest && !HasHitBounds)
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

    IEnumerator Shoot()
    {
        float pause = Random.Range(2.0f, 5.0f);
        yield return new WaitForSeconds(pause);
        Transform disparo = Instantiate(prefabEnemyBullet, transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
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

    private IEnumerator HitBounds()
    {
        HasHitBounds = true;
        yield return new WaitForSeconds(1.0f);
        HasHitBounds = false;

    }

    public void IsHit()
    {
        Nave.Points += 10;
        Destroy(gameObject);
    }
}
