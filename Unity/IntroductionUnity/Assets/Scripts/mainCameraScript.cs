using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraScript : MonoBehaviour
{
    public float Width => Height * Camera.main.aspect;
    public float Height => 2 * Camera.main.orthographicSize;
    public float X => Camera.main.transform.position.x - Width / 2;
    public float Y => Camera.main.transform.position.y - Height / 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Width: " + Width);
        Debug.Log("Height: " + Height);
        Debug.Log("Camera X: " + X);
        Debug.Log("Camera Y: " + Y);
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.transform.position.x < gameObject.transform.position.x)
               
        }
    }
    */
}
