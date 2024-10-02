using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] private float xSpeed = 2f;                     //Speed in x plane
    [SerializeField] private float ySpeed = -1.0f;                  //Speed in x plane
    [SerializeField] Transform prefabEnemyBullet;
    [SerializeField] private int health = 15;                       //Number of Health Points
    [SerializeField] protected Transform prefabDeathExplosion;      //This prefab is the explosion when it dies
    private static float BULLET_POSITION_MODIFIER = 1.2f;           //The distance difference between the bullets

    void Start()
    {
        StartCoroutine(Shoot());                    
        StartCoroutine(RandomizeMovement());
    }


    void Update()
    {
        Vector3 movementX = new Vector3(1, 0, 0) * xSpeed * Time.deltaTime; 
        Vector3 movementY = new Vector3(0, 1, 0) * ySpeed * Time.deltaTime; 
        CollisionWrapper collision = Collisions.IsOutOfBounds(gameObject);         //Checks for Collisions
        if (movementX.x > 0 && !collision.CollidingWithEast           //If it isn't coliding in the 
            || movementX.x < 0 && !collision.CollidingWithWest)       // direction it wants to go, it moves
            transform.Translate(movementX, Space.World);                                                        
        if (movementY.y > 0 && !collision.CollidingWithNorth || movementY.y < 0 && !collision.CollidingWithSouth)
            transform.Translate(movementY, Space.World);
        else
            ySpeed = -ySpeed;           // Makes the boss stick on the topside of the screen
    }

    float GetRandomSpeed()              //Gets a random int which is used for the speed
    {
        int random;
        if (Random.Range(-1, 1) > 0)
            random = 1;
        else
            random = -1;

        return Random.Range(2, 5) * random;
        
    }

    IEnumerator RandomizeMovement()     //Uses GetRandomSpeed() to get 2 random speeds and modify the movement
    {                                    //after a period of time
        
        float pause = Random.Range(3.0f, 5.0f);
        yield return new WaitForSeconds(pause);
        xSpeed = GetRandomSpeed();
        ySpeed = GetRandomSpeed();
        StartCoroutine(RandomizeMovement());
    }

    IEnumerator Shoot()          //Shoots three shots, using a global static variable to distance the three bullets from each other.
    {
        float pause = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(pause);         
        Transform bullet1 = Instantiate(prefabEnemyBullet, new Vector2(transform.position.x - BULLET_POSITION_MODIFIER, transform.position.y), Quaternion.identity);
        Transform bullet2 = Instantiate(prefabEnemyBullet, transform.position, Quaternion.identity);
        Transform bullet3 = Instantiate(prefabEnemyBullet, new Vector2(transform.position.x + BULLET_POSITION_MODIFIER, transform.position.y), Quaternion.identity);
        GetComponent<AudioSource>().Play();
        StartCoroutine(Shoot());
    }

    private void OnTriggerEnter2D(Collider2D collision)     //Is called when a collision is triggered
    {
        if (collision != null)
        {
            if (collision.tag == "Player" || collision.tag == "AllyBullet")
                IsHit();
        }
    }

    public void IsHit() //It reduces the health and checks if the health is <= 0: If it is, it destroys the object
    {
        health--;
        if (health <= 0)
        {
            Nave.points += 100;
            Transform explosion = Instantiate(prefabDeathExplosion,
                transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
            Destroy(gameObject);
        }
    }
}
