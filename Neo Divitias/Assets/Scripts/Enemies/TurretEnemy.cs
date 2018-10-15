using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stationary turret enemy that fires on player when it is within range
public class TurretEnemy : DamageableObject {

    public float range = 15f;
    public float rotationSpeed = 1f;
    public int damageDone = 1;
    public float fireCooldown = 1f;
    public float health = 5;
    public float agroDuration = 10f;

    public FireAtPlayer shooter;
    public bool isDestructible = true;
    public GameObject deathAnimation;

    float currentCooldown = 0;
    float agroEnd = -1f;
    Transform[] player;
    Rigidbody[] playerBody;

    // Find players
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

    public override bool damage(float damage)
    {
        // Damage enemy if able
        if (!isDestructible) return false;
        health -= damage;
        if (health <= 0)
        {
            Instantiate(deathFX, transform.position, Quaternion.identity);
            Instantiate(deathAnimation, transform.position, Quaternion.identity);
            deathSound.Play();
            Destroy(gameObject);
            return true;
        }

        // Agro onto player when damage taken (enemy knows you're there)
        agroEnd = Time.time + agroDuration;
        return false;
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

        // If within turret range
        if (distance < range || agroEnd > Time.time) {
            transform.LookAt(player[playerIndex].position);

            // Fire if able
            if (currentCooldown <= 0)
            {
                shooter.straightFire(player[playerIndex], damageDone);
                currentCooldown = fireCooldown;
            }
        }

        // Decrease cooldown on firing
        if (currentCooldown > -1)
        {
            currentCooldown -= Time.deltaTime;
        }
    }
}
