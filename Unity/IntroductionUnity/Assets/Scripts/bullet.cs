using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private int bulletSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 3.50)
            Destroy(gameObject);
    }
}
