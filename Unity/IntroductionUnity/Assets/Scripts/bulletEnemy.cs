using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : bullet
{
    void Update()                   
    {
        if (Collisions.IsOutOfBoundsSouth(gameObject))      //After leaving the screen from the south, it is destroyed
            Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)     //Once the bullet hits something, it plays the explotion animation and it destroys itself
    {

        if (collision.tag == "Player")
        {
            Transform explosion = Instantiate(prefabExplotion,
            collision.transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
            Destroy(gameObject);
        }
    }
}
