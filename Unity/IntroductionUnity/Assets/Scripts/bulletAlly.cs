using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletAlly : bullet
{
    void Update()
    {

        if (transform.position.y > 3.50)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);

        }
    }
}
