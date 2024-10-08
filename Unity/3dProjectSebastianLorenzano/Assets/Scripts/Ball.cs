using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody body;
    float speed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        // Recogemos el Rigidbody del objeto
        body = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float newX = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float newZ = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        body.velocity = new Vector3(newX, 0, newZ);
    }
}
