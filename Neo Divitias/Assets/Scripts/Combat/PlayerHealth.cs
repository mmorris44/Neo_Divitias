using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : DamageableObject
{
    public int currentHealth;
    public int maxHealth;
    public int regenPerSecond;
    public bool isDead;

    public Slider healthbar;

    private Transform playerTransform;
    private Vector3 spawnLocation;
    private Quaternion spawnRotation;

    public void Start()
    {
        playerTransform = transform;
        spawnLocation = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
        spawnRotation = new Quaternion(playerTransform.rotation.x, playerTransform.rotation.y, playerTransform.rotation.z, playerTransform.rotation.w);
        InvokeRepeating("Regenerate", 0.0f, 1.0f / regenPerSecond);
    }

    public void Update()
    {
        if (playerTransform.position.y < -35)
        {
            StartCoroutine(die());
        }

        healthbar.value = (float)currentHealth / (float)maxHealth;
    }

    public override void damage(int damage)
    {

        if (currentHealth - damage <= 0)
        {
            StartCoroutine(die());
        }
        else
        {
            currentHealth -= damage;
        }
    }

    private IEnumerator die()
    {
        isDead = true;
        currentHealth = 0;

        /* //fade to black
        while (!faded)
        {
            yield return null;
        }
        */

        StartCoroutine(respawn());
        yield return null; // just a placeholder until fade is implemented
    }

    private IEnumerator respawn()
    {
        currentHealth = maxHealth;

        // teleport player back to start position
        playerTransform.position = spawnLocation;
        playerTransform.rotation = spawnRotation;

        /* //fade from black
        while (!faded)
        {
            yield return null;
        }
        */

        isDead = false;

        yield return null; // just a placeholder until fade is implemented
    }

    void Regenerate()
    {
        if (currentHealth < maxHealth && !isDead)
            currentHealth++;
    }
}