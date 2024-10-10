using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;

    // Este script es otra forma de mover la bola
    float velocidadAvance = 2.0f; // 2 m/s
    float velocidadRotac = 180.0f; // 180 grados por segundo
                                   // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame

    void FixedUpdate()
    {
        // Recogemos el valor de las flechas
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // Creamos un Vector3 X será el horizontal y Z el vertica
        Vector3 movement = new Vector3(moveHorizontal, 0.0f,
        moveVertical);
        // Aplicamos una fuerza teniendo en cuenta los ejes y la velocidad
        rb.AddForce(movement * speed);
    }


    /*
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
    */
}
