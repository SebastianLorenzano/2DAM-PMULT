using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : bullet
{
    void Update()
    {
        if (Collisions.IsOutOfBoundsSouth(gameObject))
            Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
