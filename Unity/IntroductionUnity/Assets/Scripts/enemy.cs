using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private float xSpeed = 2;
    private float ySpeed = -1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(xSpeed * Time.deltaTime,ySpeed * Time.deltaTime, 0);
        if ((transform.position.x < -4) || (transform.position.x > 4))
            xSpeed = -xSpeed;
        else if ((transform.position.y < -2.5) || (transform.position.y > 2.5))
            ySpeed = -ySpeed;


    }
}
