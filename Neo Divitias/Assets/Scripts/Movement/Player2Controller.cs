using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    public float moveSpeed = 50f,
        sprintMultiplier = 3f,
        maxVelocity = 3f,
        friction = 1f,
        jumpForce = 1f;
    public Camera currentCamera;
    public bool restrictVel = true;

    Rigidbody body;
    Vector3 forward, right;
    float distToGround;
    

    void Start()
    {
        body = GetComponent<Rigidbody>();
        forward = transform.forward;
        right = transform.right;
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void FixedUpdate()
    {
        // Get speed and max velocity
        float moveSpeedCurrent = moveSpeed, maxVelocityCurrent = maxVelocity;
        if (Input.GetButton("Sprint p2"))
        {
            moveSpeedCurrent *= sprintMultiplier;
        }

        // Aim in direction of camera
        forward = currentCamera.transform.forward;
        forward.y = 0;
        right = currentCamera.transform.right;
        right.y = 0;

        if (restrictVel)
        {
            // Set velocity
            if (Input.GetAxis("Vertical p2") > 0)
            {
                body.AddForce(forward * moveSpeedCurrent);
            }
            else if (Input.GetAxis("Vertical p2") < 0)
            {
                body.AddForce(-forward * moveSpeedCurrent);
            }

            if (Input.GetAxis("Horizontal p2") > 0)
            {
                body.AddForce(right * moveSpeedCurrent);
            }
            else if (Input.GetAxis("Horizontal p2") < 0)
            {
                body.AddForce(-right * moveSpeedCurrent);
            }
        }

        // If not movement input
        if (Input.GetAxis("Horizontal p2") == 0 && Input.GetAxis("Vertical p2") == 0)
        {
            Vector3 reverse = -body.velocity;
            reverse.y = 0;
            body.AddForce(reverse * friction);
        }

        // Clamp horizontal velocity

        if (restrictVel)
        {
            float y = body.velocity.y;
            body.velocity = new Vector3(body.velocity.x, 0, body.velocity.z);
            body.velocity = Vector3.ClampMagnitude(body.velocity, maxVelocityCurrent);
            body.velocity = new Vector3(body.velocity.x, y, body.velocity.z);
        }
    }

    void Update()
    {
        // Check for jumping
        if (Input.GetButtonDown("Jump p2") && isGrounded())
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.2f);
    }
}
