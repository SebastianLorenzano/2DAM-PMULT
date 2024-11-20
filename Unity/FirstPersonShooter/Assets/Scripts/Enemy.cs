using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    Vector3 siguientePosicion;
    byte numeroSiguientePosicion;
    float changeDistance = 0.2f;
    float speed = 2;

    void Start()
    {
        siguientePosicion = wayPoints[0].position;
        numeroSiguientePosicion = 0;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, siguientePosicion, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, siguientePosicion) < changeDistance)
        {
            numeroSiguientePosicion++;
            if (numeroSiguientePosicion >= wayPoints.Length)
                numeroSiguientePosicion = 0;
            siguientePosicion = wayPoints[numeroSiguientePosicion].position;
            transform.LookAt(siguientePosicion);
        }
    }
}
