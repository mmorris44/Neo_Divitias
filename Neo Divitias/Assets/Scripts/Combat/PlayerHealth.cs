using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : DamageableObject
{
    public int currentHealth;
    public int maxHealth;
    public int regenPerSecond;

    public Slider healthbar;

    public void Start()
    {
        InvokeRepeating("Regenerate", 0.0f, 1.0f);
    }

    public void Update()
    {
        //currentHealth = Mathf.Min(currentHealth + (int)(regenPerSecond * Time.deltaTime), maxHealth);
        healthbar.value = (float)currentHealth / (float)maxHealth;
    }

    public override void damage(int damage)
    {
        currentHealth -= damage;
    }

    void Regenerate()
    {
        if (currentHealth < maxHealth)
            currentHealth++;
    }
}