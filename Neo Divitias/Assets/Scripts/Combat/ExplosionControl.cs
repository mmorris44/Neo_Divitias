using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates explosion and destroys it when the particle system has finished
public class ExplosionControl : MonoBehaviour {

    public AudioSource explosionSfx;
    ParticleSystem ps;

	void Start () {
        ps = GetComponent<ParticleSystem>();
        explosionSfx.Play();
	}
	
	void Update () {
		if (!ps.IsAlive())
        {
            Destroy(gameObject);
        }
	}
}
