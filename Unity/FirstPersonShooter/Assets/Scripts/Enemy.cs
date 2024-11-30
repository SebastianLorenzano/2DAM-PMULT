using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    int numeroSiguientePosicion;
    [SerializeField] float changeDistance = 0.2f;
    [SerializeField] Transform objetivo;
    private NavMeshAgent navMeshAgent;
    private Animator animator;


    void Start()
    {
        if (wayPoints.Length == 0)
        {
            Debug.LogError("Waypoints not assigned");
            enabled = false;
            return;
        }

        if (objetivo == null)
        {
            Debug.LogError("Target not assigned");
            enabled = false;
            return;
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        numeroSiguientePosicion = 0;
        animator = GetComponent<Animator>();
        animator.applyRootMotion = false; // Enable Root Motion
    }
    

    void Update()
    {
        if (DistanceToPlayer() < 30)
        {
            navMeshAgent.SetDestination(objetivo.position); // Chase the player
        }
        else
        {
            MoveToNextWayPoint();
        }
    }


    float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, objetivo.position);
    }

    void MoveToNextWayPoint()
    {
        if (navMeshAgent.remainingDistance < changeDistance)
        {
            numeroSiguientePosicion = (numeroSiguientePosicion + 1) % wayPoints.Length;
            navMeshAgent.SetDestination(wayPoints[numeroSiguientePosicion].position);
        }
    }
}
