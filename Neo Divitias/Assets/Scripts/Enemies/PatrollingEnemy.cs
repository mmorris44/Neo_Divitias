using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour {

    public float patrolSpeed = 2f;
    public float chaseSpeed = 2.5f;
    public float chaseDistance = 10f;
    public float distanceFromPlayer = 5f;
    public Transform[] positions;
    public float rotationSpeed = 1f;

    public Transform player;

    int currentTarget = 1;

	void Start () {
        // Set position to 0th tranform
        transform.position = positions[0].position;
	}
	
	void Update () {
        float distance = (player.position - transform.position).magnitude;

        // Patrol
        if (distance > chaseDistance)
        {
            float moveDist = patrolSpeed * Time.deltaTime;

            // Check if at target
            if ((transform.position - positions[currentTarget].position).magnitude < moveDist + 0.0001)
            {
                currentTarget = (currentTarget + 1) % positions.Length;
            }

            // Lerp towards goal rotation
            Quaternion currentRotation = transform.rotation;
            transform.LookAt(positions[currentTarget]);
            Quaternion goalRotation = transform.rotation;
            transform.rotation = currentRotation;
            transform.rotation = Quaternion.Lerp(currentRotation, goalRotation, rotationSpeed * Time.deltaTime);

            // Move towards goal position
            transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget].position, moveDist);
        }

        // Chase
        else
        {
            float moveDist = chaseSpeed * Time.deltaTime;

            // Look at player and move towards if outside range
            transform.LookAt(player.position);
            if (distance > distanceFromPlayer)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveDist);
            }
        }
	}
}
