using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains methods for predictive and non-predictive firing
public class FireAtPlayer : MonoBehaviour {

    public GameObject projectile;
    public Transform spawnSpot;
    public float predictBias = 1f;

    // Fire straight at the player with the given damage
	public void straightFire(Transform player, int damage)
    {
        GameObject p = Instantiate(projectile, spawnSpot.position, Quaternion.identity) as GameObject;
        p.GetComponent<ProjectileController>().damage = damage;
        p.transform.LookAt(player.position);
    }

    // Try predict player position and fire using given damage
    public void predictiveFire(Transform player, Rigidbody playerBody, int damage)
    {
        GameObject p = Instantiate(projectile, spawnSpot.position, Quaternion.identity) as GameObject;
        p.GetComponent<ProjectileController>().damage = damage;
        p.transform.LookAt(player.position + predictBias * playerBody.velocity);
    }

}
