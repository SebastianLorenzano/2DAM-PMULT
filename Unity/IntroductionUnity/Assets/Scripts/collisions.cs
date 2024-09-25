using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public enum Direction
{
    TOP = 1,
    RIGHT = 2,
    BOTTOM = 3,
    LEFT = 4
}

public class CollisionWrapper
{
    public bool CollidingWithWest { get; set; } = false;
    public bool CollidingWithEast { get; set; } = false;
    public bool CollidingWithNorth { get; set; } = false;
    public bool CollidingWithSouth { get; set; } = false;

}

    public class Collisions : MonoBehaviour
    {

    public static CollisionWrapper IsOutOfBounds(GameObject element)
    {
        CollisionWrapper result = new();
        if (element == null)
            return result;
        var x = element.transform.position.x;
        var y = element.transform.position.y;
        var map = GameObject.Find("Main Camera").GetComponent<mainCameraScript>();
        var width = element.GetComponent<SpriteRenderer>().bounds.size.x;
        var height = element.GetComponent<SpriteRenderer>().bounds.size.y;

        var mapX = map.X;
        var mapY = map.Y;
        var mapWidth = map.Width;
        var mapHeight = map.Height;

        if (x < mapX + width / 2)               // Leaves from the west side
        {
            Debug.Log("Hitting West wall || " + map.X);
            result.CollidingWithWest = true;
        }
            
        if (y < mapY + height / 2)              // Leaves from the south side
            result.CollidingWithSouth = true;
        if (x + width / 2 > mapX + mapWidth)    // Leaves from the East side
            result.CollidingWithEast = true;
        if (y + width / 2 > mapY + mapHeight)   // Leaves from the North side
            result.CollidingWithNorth = true;
        return result;
    }

}

