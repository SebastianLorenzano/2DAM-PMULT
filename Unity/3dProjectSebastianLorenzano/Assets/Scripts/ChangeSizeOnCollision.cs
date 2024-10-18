using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSmallerOnCollision : MonoBehaviour
{

    public float changePlayerSize = 0.2f; //How much the player is going to change its scale when it collisions. 
                                        // Its public so each wall can decide how they want to change it
    private float changeWallSize = -2;    //How much the wall is going to reduce its scale when it collisions  
    private float minWallSize = 4;
    private float maxPlayerSize = 3;
    private float minPlayerSize = 0.6f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float newSizeYWall = transform.localScale.y + changeWallSize;
            float newSizeYPlayer = collision.transform.localScale.y + changePlayerSize;
            if (newSizeYWall > minWallSize && newSizeYPlayer < maxPlayerSize && newSizeYPlayer > minPlayerSize)  // It doesn't allow the ball to be bigger or smaller than a limit
            {                                                                                                    // It doesn't allow the wall to be smaller than a limit
                transform.localScale = ChangeSize(gameObject, changeWallSize);
                collision.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
                collision.transform.localScale = ChangeSize(collision.gameObject, changePlayerSize);
            }
        }

    }

    private static Vector3 ChangeSize(GameObject obj, float change)
    {
        Vector3 vector = obj.transform.localScale;
        if (obj.tag == "Player")
            return vector + new Vector3(change, change, change);
        else
            return vector + new Vector3(0, change, 0);
    }
}
