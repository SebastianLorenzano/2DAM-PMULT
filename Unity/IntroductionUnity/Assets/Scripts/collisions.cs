using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class collisions : MonoBehaviour
{

    public static bool IsOutOfBounds(GameObject element)
    {
        var x = element.transform.position.x;
        var y = element.transform.position.y;
        var width = element.GetComponent<SpriteRenderer>().bounds.size.x;
        var height = element.GetComponent<SpriteRenderer>().bounds.size.y;

        var map = GameObject.Find("Main Camera").GetComponent<mainCameraScript>();
        var mapX = map.X;
        var mapY = map.Y;
        var mapWidth = map.Width;
        var mapHeight = map.Height;
        if (x < mapX + width / 2)               // Leaves from the west side
            return true;
        if (y < mapY + height / 2)              // Leaves from the south side
            return true;
        if (x + width / 2 > mapX + mapWidth)    // Leaves from the East side
            return true;
        if (y + width / 2 > mapY + mapHeight)   // Leaves from the North side
            return true;
        return false;
    }

}
