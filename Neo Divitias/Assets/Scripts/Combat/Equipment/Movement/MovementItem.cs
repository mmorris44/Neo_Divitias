using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores abstract logic for movement abilities
public abstract class MovementItem : Equipment
{
    public Camera playerCam;
    public Rigidbody player;
    public AbilityCooldown cooldownTimer;
    public float[] cooldown;
    public float[] movementForce;
    public AudioSource activationSound;

    protected float nextActivate = 0.0f;

    // Use the movement ability
    public abstract void Activate();
}
