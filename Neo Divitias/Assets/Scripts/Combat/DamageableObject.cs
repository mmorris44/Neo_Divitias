using UnityEngine;

// Any object that can be damaged by projectiles or raycasting
public abstract class DamageableObject : MonoBehaviour {

    public GameObject deathFX;
    public AudioSource deathSound;

    // Must implement this when extending
    public abstract bool damage(float damage);
}
