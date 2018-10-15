using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rotates the second player with the joystick
public class Player2Rotate : MonoBehaviour {

    public float speed = 3f;
	
	void FixedUpdate () {
        // Rotate with joystick
        transform.Rotate((new Vector3(0, Input.GetAxis("Horizontal Look p2"), 0)) * speed);
    }
}
