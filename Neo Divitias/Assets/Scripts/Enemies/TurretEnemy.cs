﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : DamageableObject {

    public float range = 15f;
    public float rotationSpeed = 1f;
    public int damageDone = 1;
    public float fireCooldown = 1f;
    public int health = 5;

    public FireAtPlayer shooter;
    public bool isDestructible = true;

    float currentCooldown = 0;
    Transform[] player;
    Rigidbody[] playerBody;

    void Start ()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        player = new Transform[players.Length];
        playerBody = new Rigidbody[players.Length];
        for (int i = 0; i < players.Length; ++i)
        {
            player[i] = players[i].transform;
            playerBody[i] = players[i].GetComponent<Rigidbody>();
        }
    }

    public override void damage(int damage)
    {
        if (!isDestructible) return;
        health -= 1;
        if (health <= 0)
        {
            Destroy(gameObject);
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

        if (distance < range) {
            transform.LookAt(player[playerIndex].position);

            // Fire if able
            if (currentCooldown <= 0)
            {
                shooter.straightFire(player[playerIndex], damageDone);
                currentCooldown = fireCooldown;
            }
        }

        if (currentCooldown > -1)
        {
            currentCooldown -= Time.deltaTime;
        }
    }
}
