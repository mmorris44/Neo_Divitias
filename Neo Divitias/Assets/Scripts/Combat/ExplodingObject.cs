using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingObject : DamageableObject {

    public float currentHealth = 3;
    public GameObject explosion;

	public override void damage (float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
