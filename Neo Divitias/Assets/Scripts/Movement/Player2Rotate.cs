using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Rotate : MonoBehaviour {

    public float speed = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
        // Rotate with mouse
        transform.Rotate((new Vector3(0, Input.GetAxis("Horizontal Look p2"), 0)) * speed);
    }
}
