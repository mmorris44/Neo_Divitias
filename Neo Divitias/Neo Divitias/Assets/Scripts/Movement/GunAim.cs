using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour {

    public float speed = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
        // Rotate
        transform.Rotate((new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0)) * speed);

        // Fix z rotation
        float z = transform.eulerAngles.z;
        transform.Rotate(0, 0, -z);
    }
}
