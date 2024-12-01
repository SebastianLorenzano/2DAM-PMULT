using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    System.Random r = new System.Random();
    [SerializeField] Transform[] wayPoints;
    int numeroSiguientePosicion;
    [SerializeField] float changeDistance = 0.2f;
    [SerializeField] Transform objetivo;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Collider collider;
    private int hp = 3;
    private bool hasBeenHit = false;
    private bool canAttack = true;

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
        collider = GetComponent<Collider>();
    }
    

    void Update()
    {   
        if (DistanceToPlayer() < 30)
            navMeshAgent.SetDestination(objetivo.position); // Chase the player
        else
            MoveToNextWayPoint();

        if (canAttack && DistanceToPlayer() < 2)
        {
            FindAnyObjectByType<SceneController>().SendMessage("PlayerLoseHp");
            animator.Play("Attack");
            StartCoroutine(ResetCanAttack());
        }

    }


    public void TakeDamage()
    {
        hp--;
        if (!hasBeenHit) // If the enemy has not been hit
        {
            hasBeenHit = true;
            animator.Play("Hurted");
            StartCoroutine(ResetCanMove());
        }
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
        navMeshAgent.ResetPath(); // Clears the current path
        collider.enabled = false;
        canAttack = false;
        if (r.Next(0, 2) == 0)
            animator.Play("Death1");
        else
            animator.Play("Death2");
        Destroy(gameObject, 30f);
    }

    IEnumerator ResetCanAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(2.3f);
        canAttack = true;
    }


    IEnumerator ResetCanMove()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
        canAttack = false;
        yield return new WaitForSeconds(2.3f);
        navMeshAgent.speed = 1;
        navMeshAgent.isStopped = false;
        canAttack = true;

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
