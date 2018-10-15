using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Handles logic for player death, damage, regen and respawning
// Also animates deaths and respawns
public class PlayerHealth : DamageableObject
{
    public Image fadeImg;
    public Animator fade;
    public Transform cameraTransform;
    public float currentHealth;
    public float maxHealth;
    public float regenPerSecond;
    public bool isDead;
    public GameObject[] meshParents;

    public Slider healthbar;

    public float[] extraHpPerArmourLevel;
    public float baseHp = 100;

    private Transform playerTransform;
    private Vector3 spawnLocation;
    private Quaternion spawnRotation;
    private ArrayList playerMeshes;

    public void Start()
    {
        // Start on full HP
        currentHealth = maxHealth;

        // Setup player meshes to hide when dead
        playerMeshes = new ArrayList();
        foreach (GameObject parent in meshParents)
        {
            MeshRenderer[] meshes = parent.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer mesh in meshes)
            {
                playerMeshes.Add(mesh);
            }
        }

        // Set spawn locations
        playerTransform = transform;
        spawnLocation = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
        spawnRotation = new Quaternion(cameraTransform.rotation.x, cameraTransform.rotation.y, cameraTransform.rotation.z, cameraTransform.rotation.w);

        // Constant regen
        InvokeRepeating("Regenerate", 0.0f, 0.1f / regenPerSecond);
    }

    public void Update()
    {
        // Check if player has fallen too far off the platforms
        if (playerTransform.position.y < -30 && !isDead)
        {
            StartCoroutine(die());
        }

        // Update healthbar slider
        healthbar.value = currentHealth / maxHealth;
    }

    // Set max hp at start of level
    public void setMaxHp (int armourLevel)
    {
        maxHealth = baseHp;
        if (armourLevel != 0) maxHealth += extraHpPerArmourLevel[armourLevel - 1];
    }

    // Deal damage to the player
    public override bool damage(float damage)
    {
        if (currentHealth - damage <= 0 && !isDead)
        {
            StartCoroutine(die());
            return true;
        }
        else
        {
            currentHealth -= damage;
            return false;
        }
    }

    // Animate death and respawn
    private IEnumerator die()
    {
        isDead = true;
        currentHealth = 0;

        // Play death particle and make player invisible
        Instantiate(deathFX, transform.position, Quaternion.identity);

        foreach (MeshRenderer mr in playerMeshes)
        {
            mr.enabled = false;
        }
        deathSound.Play();

        // Fade out
        fade.Play("fadeOut");

        while (fadeImg.color.a < 1)
        {
            yield return null;
        }

        StartCoroutine(respawn());
    }

    // Repawn player with fadein animation
    private IEnumerator respawn()
    {
        currentHealth = maxHealth;

        // Set player back to start position and rotation
        playerTransform.position = spawnLocation;
        cameraTransform.rotation = spawnRotation;

        // Make player visible again
        foreach (MeshRenderer mr in playerMeshes)
        {
            mr.enabled = true;
        }

        // Fade in from black
        fade.Play("fadeIn");
        while (fadeImg.color.a > 0)
        {
            yield return null;
        }

        isDead = false;
    }

    // Restore player health over time
    void Regenerate()
    {
        if (currentHealth < maxHealth && !isDead)
            currentHealth += 0.1f;
    }
}