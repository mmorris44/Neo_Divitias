using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Quaternion forwardRotation, backwardRotation, leftRotation, rightRotation;

	// Use this for initialization
	void Start () {
        forwardRotation = Quaternion.Euler(10, 0, 0);
        backwardRotation = Quaternion.Euler(-10, 0, 0);
        leftRotation = Quaternion.Euler(0, 0, 10);
        rightRotation = Quaternion.Euler(0, 0, -10);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("w"))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, forwardRotation, Time.deltaTime * 20f);
            transform.Translate(Vector3.forward * Time.deltaTime * 5f);
        } else if (Input.GetKey("s"))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, backwardRotation, Time.deltaTime * 20f);
            transform.Translate(Vector3.back * Time.deltaTime * 5f);
        }

        if (Input.GetKey("a"))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, leftRotation, Time.deltaTime * 20f);
            transform.Translate(Vector3.left * Time.deltaTime * 5f);
        }
        else if (Input.GetKey("d"))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rightRotation, Time.deltaTime * 20f);
            transform.Translate(Vector3.right * Time.deltaTime * 5f);
        }

        if (!(Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("w")))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, Time.deltaTime * 50f);
        }
    }
}
