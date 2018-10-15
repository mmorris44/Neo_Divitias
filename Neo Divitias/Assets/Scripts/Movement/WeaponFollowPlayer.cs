using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Makes the weapon controller follow the player based around
public class WeaponFollowPlayer : MonoBehaviour {

    public Transform player;
	
	void Update () {
        // Set position to just above ball model
        transform.position = player.position + new Vector3(0, 0.5f, 0);
	}
}
