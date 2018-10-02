using UnityEngine;

public class PlayerHealth : DamageableObject
{
    public int currentHealth;
    public int maxHealth;
    public int regenPerSecond;

    public void Update()
    {
        currentHealth = Mathf.Min(currentHealth + (int)(regenPerSecond * Time.deltaTime), maxHealth);
    }

    public override void damage(int damage)
    {
        currentHealth -= damage;
    }

    public void heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
}