using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float xSpeed = 2;
    [SerializeField] private float ySpeed = -1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(xSpeed * Time.deltaTime,ySpeed * Time.deltaTime, 0);
        if ((transform.position.x < -6.60) || (transform.position.x > 6.60))
            xSpeed = -xSpeed;
        else if ((transform.position.y < -2.80) || (transform.position.y > 2.80))
            ySpeed = -ySpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            
    }
}
