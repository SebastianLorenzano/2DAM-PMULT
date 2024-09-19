using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraScript : MonoBehaviour
{
    public float Width => Screen.width;
    public float Height => Screen.height;
    public float X => Camera.main.transform.position.x;
    public float Y => Camera.main.transform.position.y;

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
