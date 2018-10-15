using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control energy to fly back towards the player
public class EnergyController : MonoBehaviour {

    public float speed = 3f;
    public Transform player;
	
	void Update () {
        transform.LookAt(player.position);
        float moveDist = speed * Time.deltaTime;

        // Check if at target
        if ((transform.position - player.position).magnitude < moveDist + 0.0001)
        {
            Destroy(gameObject);
        }

        // Move towards goal position
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveDist);
    }
}
