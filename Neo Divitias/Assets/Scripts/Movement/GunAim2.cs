using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Aims the gun of the second player based off controller joystick input
public class GunAim2 : MonoBehaviour {

    public float speed = 3f;
    public float maxRotation = 50f;
    public float minRotation = -90f;
	
	void FixedUpdate () {
        // Rotate
        transform.Rotate((new Vector3(-Input.GetAxis("Vertical Look p2"), Input.GetAxis("Horizontal Look p2"), 0)) * speed);

        // Constrain x rotation
        Vector3 angles = transform.rotation.eulerAngles;
        if (angles.x < -180)
        {
            angles.x += 360;
        }
        if (angles.x > 180)
        {
            angles.x -= 360;
        }

        if (angles.x < minRotation)
        {
            angles.x = minRotation;
        }
        if (angles.x > maxRotation)
        {
            angles.x = maxRotation;
        }
        transform.rotation = Quaternion.Euler(angles);

        // Fix z rotation
        float z = transform.eulerAngles.z;
        transform.Rotate(0, 0, -z);
    }
}
