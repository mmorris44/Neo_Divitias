using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtPlayer : MonoBehaviour {

    public GameObject projectile;
    public Transform spawnSpot;

	public void straightFire(Transform player, int damage)
    {
        GameObject p = Instantiate(projectile, spawnSpot.position, Quaternion.identity) as GameObject;
        p.GetComponent<ProjectileController>().damage = damage;
        p.transform.LookAt(player.position);
    }

    public void predictiveFire(Transform player, Rigidbody playerBody, int damage)
    {
        Debug.Log("predictiveFire() method not yet implemented");
    }

}
