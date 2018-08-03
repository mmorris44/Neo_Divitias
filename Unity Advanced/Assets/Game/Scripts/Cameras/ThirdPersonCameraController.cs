using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour {

    public float radius,
        height;
    public Transform player;
    public float speed = 0.125f;
    public float dr = 0.05f, dh = 0.05f;
	
	void FixedUpdate () {
        // Check for radius and height change
        if (Input.GetAxis("3rd P Camera Radius") > 0)
        {
            radius += dr;
        }
        if (Input.GetAxis("3rd P Camera Radius") < 0)
        {
            radius -= dr;
        }
        if (Input.GetAxis("3rd P Camera Height") > 0)
        {
            height += dh;
        }
        if (Input.GetAxis("3rd P Camera Height") < 0)
        {
            height -= dh;
        }

        // Find displacement for camera
        Vector3 displacement = transform.position - player.transform.position;
        displacement.y = 0;
        float planarDistance = 0;
        if (radius > height)
        {
            planarDistance = Mathf.Sqrt(radius * radius - height * height);
        }

        // Prevent 0 displacement
        if (displacement == Vector3.zero)
        {
            displacement.x = 1;
        }
        displacement = displacement.normalized * planarDistance;
        displacement.y = height;

        // Move camera
        Vector3 targetPosition = player.transform.position + displacement;
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed);

        // Look at player
        transform.LookAt(player);
	}
}
