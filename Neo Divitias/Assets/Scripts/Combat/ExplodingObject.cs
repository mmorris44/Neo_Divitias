using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingObject : DamageableObject {

    public int currentHealth = 3;
    public GameObject explosion;

	public override void damage (int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
