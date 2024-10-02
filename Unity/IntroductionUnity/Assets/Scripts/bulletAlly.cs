using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletAlly : bullet
{
    void Update()
    {
        if (Collisions.IsOutOfBoundsNorth(gameObject))  //After leaving the screen from the north, it is destroyed
            Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision) //Once the bullet hits something, it plays the explotion animation and it destroys itself
    {

        if (collision.tag == "Enemy")
        {
            Transform explosion = Instantiate(prefabExplotion,
            collision.transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
            Destroy(gameObject);
        }
    }
}
