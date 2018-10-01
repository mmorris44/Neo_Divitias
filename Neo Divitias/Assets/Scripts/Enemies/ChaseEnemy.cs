using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : DamageableObject {

    public float chaseSpeed = 2.5f;
    public float catchUpSpeed = 10f;
    public float distanceFromPlayer = 5f;
    public float catchUpDistance = 30f;
    public float range = 10f;
    public float verticaleOffset = 1f;
    public int damageDone = 1;
    public float fireCooldown = 1f;
    public int health = 5;

    public FireAtPlayer shooter;
    public bool isDestructible = true;

    float currentCooldown = 0;
    Transform[] player;
    Rigidbody[] playerBody;

    public override void damage(int damage)
    {
        if (!isDestructible) return;
        health -= 1;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Start () {
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

        float moveDist = chaseSpeed * Time.deltaTime;

        // If far away
        if (distance > catchUpDistance) moveDist = catchUpSpeed * Time.deltaTime;

        // Look at player and move towards if outside range
        transform.LookAt(player[playerIndex].position);
        if (distance > distanceFromPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player[playerIndex].position + new Vector3(0, verticaleOffset, 0), moveDist);
        }

        // Fire if able
        if (currentCooldown <= 0 && distance < range)
        {
            shooter.straightFire(player[playerIndex], damageDone);
            currentCooldown = fireCooldown;
        } else if (currentCooldown > -1)
        {
            currentCooldown -= Time.deltaTime;
        }
	}
}
