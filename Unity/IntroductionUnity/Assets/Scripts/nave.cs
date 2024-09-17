using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField] Transform prefabDisparo;
    [SerializeField] private int xSpeed = 2;
    [SerializeField] private int ySpeed = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(x * xSpeed * Time.deltaTime, y * ySpeed * Time.deltaTime, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            var disparo = Instantiate(prefabDisparo, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("La nave ha sido golpeada!");
    }
}
