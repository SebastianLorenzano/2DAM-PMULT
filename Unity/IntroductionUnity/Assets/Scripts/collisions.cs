using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollisionWrapper           //This item is a wrapper which holds the booleans from which directions a gameObject is outside the bounds of the map
{
    public bool CollidingWithWest { get; set; } = false;
    public bool CollidingWithEast { get; set; } = false;
    public bool CollidingWithNorth { get; set; } = false;
    public bool CollidingWithSouth { get; set; } = false;

}

public class Collisions : MonoBehaviour
{

    public static CollisionWrapper IsOutOfBounds(GameObject element)        //It returns a CollisionWrapper that has the different bools that say if its outside of bounds
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

    public static bool IsOutOfBoundsWest(GameObject e)      //Compares if its outside of the bounds of the camera from the west
    {
        return e.transform.position.x < mainCameraScript.X + e.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    public static bool IsOutOfBoundsSouth(GameObject e)    //Compares if its outside of the bounds of the camera from the south
    {
        return e.transform.position.y < mainCameraScript.Y + e.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    public static bool IsOutOfBoundsEast(GameObject e)    //Compares if its outside of the bounds of the camera from the east
    {
        return e.transform.position.x + e.GetComponent<SpriteRenderer>().bounds.size.x / 2 > mainCameraScript.X + mainCameraScript.Width;
    }

    public static bool IsOutOfBoundsNorth(GameObject e)   //Compares if its outside of the bounds of the camera from the north
    {
        return e.transform.position.y + e.GetComponent<SpriteRenderer>().bounds.size.y / 2 > mainCameraScript.Y + mainCameraScript.Height;
    }
}

