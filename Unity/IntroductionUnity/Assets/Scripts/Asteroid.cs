using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] protected Transform prefabExplotion;       
    [SerializeField] protected Transform prefabAsteroid;                // It has the prefab of itself so it can instantiate another objects like itself
    [SerializeField] private float ySpeed = -1.0f;
    void Start()                                                        // When its created, its position is randomized
    {
        float x = mainCameraScript.X + 1 + Random.Range(0, mainCameraScript.Width - 1);
        float y = mainCameraScript.Y + mainCameraScript.Height + 4;
        transform.position = new Vector3(x, y, 0);
        StartCoroutine(CreateAsteroid());                               // Creates another asteroid as it is created
    }

    void Update()
    {
        transform.Translate(0, ySpeed * Time.deltaTime, 0);             // Moves and checks if it left the map, if it did it is destroyed
        if (Collisions.IsOutOfBoundsSouth(gameObject))
            Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)         
    {
        if (collision != null)
        {
            if (collision.tag == "Player")                          // When it hits a player, it damages it and creates a collision effect
            {
                Transform explosion = Instantiate(prefabExplotion,
                collision.transform.position, Quaternion.identity);
                Destroy(explosion.gameObject, 1f);
            }
            else if (collision.tag == "AllyBullet")                 // Whe it hits a bullet, it destroys the bullet and keeps existing
                Destroy(collision.gameObject);
        }
    }

    private IEnumerator CreateAsteroid()                    // Creates a new asteroid after a random amount of time
    {

        float pause = Random.Range(1.5f, 3.0f);
        yield return new WaitForSeconds(pause);
        Instantiate(prefabAsteroid, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void IsHit()                        // Empty function created for when its needed just in case later on
    {

    }
}
