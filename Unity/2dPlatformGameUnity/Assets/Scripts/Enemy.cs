using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    [SerializeField] float speed = 2f;
    Vector3 nextPosition;
    float changeDistance = 0.2f;
    int waypointIndex = 0;          // Index of the waypoint it goes to
    int loopDirection = 1;          // -1 = goes backwards, 1 = goes forwards

    SceneController sceneController;

    // Start is called before the first frame update
    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        nextPosition = wayPoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints.Length > 0)
        {
            if (nextPosition.x > transform.position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (nextPosition.x < transform.position.x)
                        transform.localScale = new Vector3(1, 1, 1);

            transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, nextPosition) < changeDistance)
            {
                waypointIndex += loopDirection;
                if (waypointIndex >= wayPoints.Length || waypointIndex < 0) // If it reached the end or the beginning of the array
                {
                    loopDirection *= -1;
                    waypointIndex += loopDirection;
                }
                nextPosition = wayPoints[waypointIndex].position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
            sceneController.PlayerLoseHp();
    }

}
