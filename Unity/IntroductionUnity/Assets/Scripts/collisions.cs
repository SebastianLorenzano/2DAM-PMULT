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
        if (IsOutOfBoundsWest(element))     // Leaves from the West side
            result.CollidingWithWest = true;
        if (IsOutOfBoundsSouth(element))    // Leaves from the south side
            result.CollidingWithSouth = true;
        if (IsOutOfBoundsEast(element))    // Leaves from the East side
            result.CollidingWithEast = true;
        if (IsOutOfBoundsNorth(element))   // Leaves from the North side
            result.CollidingWithNorth = true;
        return result;
    }

    public static bool IsOutOfBoundsWest(GameObject e)
    {
        return e.transform.position.x < mainCameraScript.X + e.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    public static bool IsOutOfBoundsSouth(GameObject e)
    {
        return e.transform.position.y < mainCameraScript.Y + e.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    public static bool IsOutOfBoundsEast(GameObject e)
    {
        return e.transform.position.x + e.GetComponent<SpriteRenderer>().bounds.size.x / 2 > mainCameraScript.X + mainCameraScript.Width;
    }

    public static bool IsOutOfBoundsNorth(GameObject e)
    {
        return e.transform.position.y + e.GetComponent<SpriteRenderer>().bounds.size.y / 2 > mainCameraScript.Y + mainCameraScript.Height;
    }



}

