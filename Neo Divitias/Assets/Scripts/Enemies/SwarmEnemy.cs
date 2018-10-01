using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmEnemy : MonoBehaviour {

    public int numberOfMinions = 5;
    public float radius = 2f;
    public GameObject minion;

    public float swarmDistance = 10f;
    public float patrolSpeed = 2f;
    public float swarmSpeed = 10f;
    public Transform[] positions;

    public bool swarming = false;

    int currentTarget = 0;
    Transform[] player;
    Rigidbody[] playerBody;

    void Start () {
        // Create minions
		for (int i = 0; i < numberOfMinions; ++i)
        {
            GameObject m = Instantiate(minion, randomLocation(), Quaternion.identity);
            SwarmMinion s = m.GetComponent<SwarmMinion>();
            s.swarm = this;
        }
        
        // Set position to 0th tranform
        //transform.position = positions[0].position;

        // Find players
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        player = new Transform[players.Length];
        playerBody = new Rigidbody[players.Length];
        for (int i = 0; i < players.Length; ++i)
        {
            player[i] = players[i].transform;
            playerBody[i] = players[i].GetComponent<Rigidbody>();
        }
    }

	void Update () {
        int playerIndex = 0;
        float distance = float.MaxValue;

        // Find closest player
        for (int i = 0; i < player.Length; ++i)
        {
            float tempD = (player[i].position - transform.position).magnitude;
            if (tempD < distance)
            {
                playerIndex = i;
                distance = tempD;
            }
        }

        // Patrol
        if (distance > swarmDistance)
        {
            float moveDist = patrolSpeed * Time.deltaTime;
            swarming = false;

            // Check if at target
            if ((transform.position - positions[currentTarget].position).magnitude < moveDist + 0.0001)
            {
                currentTarget = (currentTarget + 1) % positions.Length;
            }

            // Move towards goal position
            transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget].position, moveDist);
        }

        // Chase
        else
        {
            float moveDist = swarmSpeed * Time.deltaTime;
            swarming = true;

            transform.position = Vector3.MoveTowards(transform.position, player[playerIndex].position, moveDist);
        }
    }

    Vector3 randomLocation()
    {
        return Random.onUnitSphere * radius + transform.position;
    }

}
