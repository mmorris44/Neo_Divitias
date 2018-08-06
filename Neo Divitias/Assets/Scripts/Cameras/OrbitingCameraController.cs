using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingCameraController : MonoBehaviour {

    public float radius,
        height;
    public Transform player;
    public float speed = 1f;
    public float epsilon = 0.1f;
    public float dr = 0.05f, dh = 0.05f;

    void FixedUpdate()
    {
        // Check for radius and height change
        if (Input.GetAxis("Orbiting Camera Radius") > 0)
        {
            radius += dr;
        }
        if (Input.GetAxis("Orbiting Camera Radius") < 0)
        {
            radius -= dr;
        }
        if (Input.GetAxis("Orbiting Camera Height") > 0)
        {
            height += dh;
        }
        if (Input.GetAxis("Orbiting Camera Height") < 0)
        {
            height -= dh;
        }

        // Put camera on circle if not
        if (!isOnCircle())
        {
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
            transform.position = targetPosition;
        }

        // Rotate around player
        transform.RotateAround(player.position, Vector3.up, speed);
        transform.LookAt(player);
    }

    bool isOnCircle ()
    {
        float distance = (transform.position - player.position).magnitude;
        float currentHeight = (transform.position - player.transform.position).y;
        return distance - epsilon < radius && radius < distance + epsilon
            && currentHeight - epsilon < height && height < currentHeight + epsilon;
    }
}
