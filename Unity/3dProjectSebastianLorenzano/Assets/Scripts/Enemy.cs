using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    [SerializeField] float speed = 5f;
    Vector3 nextPosition;
    float changeDistance = 0.2f;
    int waypointObjetiveNumber = 0;
    int loopDirection = 1; // -1 = goes backwards, 1 = goes forwards



    void Start()
    {
        nextPosition = wayPoints[waypointObjetiveNumber].position;
    }
    void Update()
    {
        // Nos movemos hacia la siguiente posición
        transform.position = Vector3.MoveTowards(transform.position,
        nextPosition,
       speed * Time.deltaTime);
        // Si la distancia al punto es corta cambiamos al siguiente
        if (Vector3.Distance(transform.position,
        nextPosition) < changeDistance)
        {
            waypointObjetiveNumber += loopDirection;
            if (waypointObjetiveNumber >= wayPoints.Length || waypointObjetiveNumber < 0)
            {
                loopDirection *= -1;
                waypointObjetiveNumber += loopDirection;
            }
            nextPosition = wayPoints[waypointObjetiveNumber].position;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tocado");
        Destroy(other.gameObject);
    }
}
