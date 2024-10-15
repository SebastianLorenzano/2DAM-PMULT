using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{ 
    public Vector3 spin = new Vector3(15, 30, 45);
    // Before rendering each frame..
    void Update()
    {
        transform.Rotate(spin * Time.deltaTime);
    }

}
