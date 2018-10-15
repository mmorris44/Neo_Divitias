using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rotates the first player with the joystick or mouse
public class PlayerRotate : MonoBehaviour {

    public float speed = 3f;
	
	void FixedUpdate () {
        // Rotate with mouse
        transform.Rotate((new Vector3(0, Input.GetAxis("Mouse X"), 0)) * speed);

        // Rotate with joystick
        transform.Rotate((new Vector3(0, Input.GetAxis("Horizontal Look p1"), 0)) * speed);
    }
}
