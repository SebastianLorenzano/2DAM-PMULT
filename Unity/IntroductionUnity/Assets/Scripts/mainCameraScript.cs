using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraScript : MonoBehaviour
{
    public static float Width => Height * Camera.main.aspect;
    public static float Height => 2 * Camera.main.orthographicSize;
    public static float X => Camera.main.transform.position.x - Width / 2;
    public static float Y => Camera.main.transform.position.y - Height / 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
