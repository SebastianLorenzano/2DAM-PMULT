using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{   
    public float rotationSpeed = 100f;      //This is the amount of rotation it does

    void Start()
    {
        
    }

    void Update()       
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);     //This rotates the gameObject its attached to relative to time
    }
}
