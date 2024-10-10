using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Ball : MonoBehaviour
{
    /*
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
    */

    // Este script es otra forma de mover la bola
    float velocidadAvance = 2.0f; // 2 m/s
    float velocidadRotac = 180.0f; // 180 grados por segundo
                                   // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // Para coger el avance con las flechas adelante y atrás
        float avance = Input.GetAxis("Vertical")
        * velocidadAvance * Time.deltaTime;
        // La rotación con las flechas izq y dcha.
        float rotacion = Input.GetAxis("Horizontal")
        * velocidadRotac * Time.deltaTime;
        transform.Translate(Vector3.forward * avance);
        transform.Rotate(Vector3.up * rotacion);
    }
}
