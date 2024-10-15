using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraWall : MonoBehaviour
{
    public float opacity = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color color = renderer.material.color;
        color.a = opacity;
        renderer.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
