using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] AudioClip audZombieGrunt;              // Sound of the zombieHurted
    [SerializeField] AudioClip audZombieDeath;              // Sound of the zombieDeath
    [SerializeField] Transform[] wayPoints;                 // Waypoints for the enemy to follow
    [SerializeField] float changeDistance = 0.2f;           // Distance to change to the next waypoint
    [SerializeField] Transform objetive;                    // The player
    int numeroSiguientePosicion;                            // Index of the next waypoint
    private NavMeshAgent navMeshAgent;                      
    private Animator animator;
    private Collider collider;
    private AudioSource audioSource;

    private int hp = 3;                                     // Enemy hp
    private bool hasBeenHit = false;                        // If the enemy has been hit
    private bool canAttack = true;                          // If the enemy is allowed to attack

    void Start()
    {
        if (objetive == null)
        {
            objetive = FindAnyObjectByType<Player>().transform;     // If the objetive is not set, find the player
        }
        numeroSiguientePosicion = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();                // Getters
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
    }
    

    void Update()
    {   
        if (hp <= 0)                                    // If the enemy is dead, do nothing
            return; 
        if (DistanceToPlayer() < 30)
            navMeshAgent.SetDestination(objetive.position);         // Chase the player if its close enough
        else
            MoveToNextWayPoint();

        if (canAttack && DistanceToPlayer() < 2)                    // If the enemy is close enough to the player, attack
        {
            FindAnyObjectByType<SceneController>().SendMessage("PlayerLoseHp");     // Tell the scene controller to make the player lose hp
            animator.Play("Attack");                                                // Play the attack animation
            StartCoroutine(ResetCanAttack());                                       // Make the enemy wait before attacking again
        }

    }


    public void TakeDamage()
    {
        hp--;
        if (!hasBeenHit) // If the enemy has not been hit
        {
            audioSource.PlayOneShot(audZombieGrunt, 1f);        // Play the hurted sound
            animator.Play("Hurted");                            // Play the hurted animation
            hasBeenHit = true;                                  // Set hasBeenHit to true so it doesn't play the sound or animation again
            StartCoroutine(ResetCanMove());                     // Make the enemy wait before moving again
        }
        if (hp <= 0)                                            // If the enemy doesn't have hp left, it dies
        {
            Die();
        }
    }

    void Die()
    {
        System.Random r = new System.Random();                   // Random number generator to select random death animation
        navMeshAgent.isStopped = true;                           // Stops the enemy
        navMeshAgent.speed = 0;                                  // Sets the speed to 0 so it doesn't keep moving
        navMeshAgent.ResetPath();                                // Clears the current path just in case
        collider.enabled = false;                                // Disables the collider so the player can walk through the enemy
        canAttack = false;                                       // Disables the attack
        if (r.Next(0, 2) == 0)
            animator.Play("Death1");                            // r.Next(0, 2) returns 0 or 1, so it has a 50% chance of playing one of the two death animations
        else
            animator.Play("Death2");
        audioSource.Stop();                                                 // Stops the audio source
        audioSource.PlayOneShot(audZombieDeath, 1f);                        // play audio of the zombie death sound on full volume
        FindAnyObjectByType<SceneController>().SendMessage("AddPoints");    // Tell the scene controller to add points
        Destroy(gameObject, 30f);                                           // Destroy the enemy after 30 seconds
    }

    IEnumerator ResetCanAttack()
    {
        canAttack = false;                      // Disables the attack
        yield return new WaitForSeconds(2.3f);  // Waits for the duration of the cooldown
        canAttack = true;                       // Enables the attack
    }


    IEnumerator ResetCanMove()
    {
        navMeshAgent.isStopped = true;              // Stops the enemy movement and after a bit of time, it enables moving again
        navMeshAgent.speed = 0;
        canAttack = false;
        yield return new WaitForSeconds(2.3f);
        navMeshAgent.speed = 1;
        navMeshAgent.isStopped = false;
        canAttack = true;

    }

    float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, objetive.position);
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
