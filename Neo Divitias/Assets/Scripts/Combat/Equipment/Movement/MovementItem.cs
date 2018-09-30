using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementItem : Equipment
{
    public Camera playerCam;
    public Rigidbody player;
    public float[] cooldown;
    public float[] movementForce;
    public AudioSource activationSound;

    protected float nextActivate = 0.0f;

    // use the movement ability
    public abstract void Activate();
}
