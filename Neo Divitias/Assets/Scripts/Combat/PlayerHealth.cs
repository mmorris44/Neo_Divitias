using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : DamageableObject
{
    public Image fadeImg;
    public Animator fade;
    public Transform cameraTransform;
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
        spawnRotation = new Quaternion(cameraTransform.rotation.x, cameraTransform.rotation.y, cameraTransform.rotation.z, cameraTransform.rotation.w);
        InvokeRepeating("Regenerate", 0.0f, 1.0f / regenPerSecond);
    }

    public void Update()
    {
        if (playerTransform.position.y < -30)
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
        GameManager.addTimePenalty();

        fade.Play("fadeOut");

        while (fadeImg.color.a < 1)
        {
            yield return null;
        }

        StartCoroutine(respawn());
    }

    private IEnumerator respawn()
    {
        currentHealth = maxHealth;

        // set player back to start position and rotation
        playerTransform.position = spawnLocation;
        cameraTransform.rotation = spawnRotation;

        fade.Play("fadeIn");

        while (fadeImg.color.a > 0)
        {
            yield return null;
        }

        isDead = false;
    }

    void Regenerate()
    {
        if (currentHealth < maxHealth && !isDead)
            currentHealth++;
    }
}