using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// General abstract class containing specifications for a player controller
public class PlayerController : MonoBehaviour {

    public float moveSpeed = 50f,
        sprintMultiplier = 3f,
        maxVelocity = 3f,
        friction = 1f,
        jumpForce = 1f;
    public Camera currentCamera;
    public bool restrictVel = true;
}
