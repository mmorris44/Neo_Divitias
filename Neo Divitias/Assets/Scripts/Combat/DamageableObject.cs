using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageableObject : MonoBehaviour {

    public GameObject deathFX;
    public AudioSource deathSound;

    public abstract void damage(float damage);
}
