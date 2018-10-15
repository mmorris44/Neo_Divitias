using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Any object that can explode on death
public class ExplodingObject : DamageableObject {

    public float currentHealth = 3;
    public GameObject explosion;

    // Damage and create explosion prefab when dead
	public override bool damage (float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return true;
        }

        return false;
    }
}
