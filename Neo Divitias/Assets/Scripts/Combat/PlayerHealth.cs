using UnityEngine;

public class PlayerHealth : DamageableObject
{
    int currentHealth;
    int maxHealth;

    public void Update()
    {
        // TODO: Implement health regen mechanic
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