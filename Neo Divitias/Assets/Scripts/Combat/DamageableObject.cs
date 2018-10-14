using UnityEngine;

public abstract class DamageableObject : MonoBehaviour {

    public GameObject deathFX;
    public AudioSource deathSound;

    public abstract bool damage(float damage);
}
