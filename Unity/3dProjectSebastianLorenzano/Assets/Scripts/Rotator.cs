using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{ 
    public Vector3 spin = new Vector3(0, 0, 0);
    // Before rendering each frame..

    private void Start()
    {
        SetSpin();
    }
    void Update()
    {
        transform.Rotate(spin * Time.deltaTime);
    }

    void SetSpin()
    {
        spin.x = Random.Range(-15, 15);
        spin.y = Random.Range(-30, 30);
        spin.z = Random.Range(-45, 45);
    }
}
