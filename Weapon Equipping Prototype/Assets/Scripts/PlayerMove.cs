using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    // Public consts
    public float movePower;
    public float maxVelocityChange;
    public float gravity;
    public float jumpHeight;
    public float rotateSpeed;
    public float maxTilt;

    Rigidbody rbody;
    bool grounded;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
        rbody.freezeRotation = true;
        rbody.useGravity = false;
        grounded = false;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
        // Calculate how fast we should be moving
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= movePower;

        // Apply a force that attempts to reach our target velocity
        Vector3 velocity = rbody.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        rbody.AddForce(velocityChange, ForceMode.VelocityChange);

        // Jump
        if (grounded && Input.GetButton("Jump"))
        {
            rbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
        }

        // We apply gravity manually for more tuning control
        rbody.AddForce(new Vector3(0, -gravity * rbody.mass, 0));
        grounded = false;

        // Set player left/right rotation from mouse
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        // Set player x rotation based off current velocity
        float forwardTilt = Vector3.Dot(rbody.velocity, transform.forward) / maxVelocityChange * maxTilt;
        float leftTilt = - Vector3.Dot(rbody.velocity, transform.right) / maxVelocityChange * maxTilt;
        transform.rotation = Quaternion.Euler(forwardTilt, transform.rotation.y, leftTilt);
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}
