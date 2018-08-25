using System.Collections;
using UnityEngine;

public abstract class Weapon : Equipment
{
	public float impactForce;
	public GameObject impactFx;
	public int[] damage;
	public float[] range;
	public float[] spread; // radius of circle within which a shot's ray will be cast
	public float[] fireRate; // (per second)	

	private ParticleSystem muzzleFlash;
	private AudioSource gunAudio;
	private float nextFire;
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

	void Start()
	{
		gunAudio = GetComponent<AudioSource>();
		muzzleFlash = GetComponent<ParticleSystem>();
	}

	public void Shoot(Camera playerCam)
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate[level-1]/60.0f;
			
			muzzleFlash.Play();
			
			Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

			if (Physics.Raycast(rayOrigin, GetShotDirection(playerCam.transform), out hit, range[level-1]))
			{
				DamageableObject target = hit.collider.GetComponent<DamageableObject>();

				if (target != null)
				{
					target.damage(damage[level-1]);
					if (hit.rigidbody != null)
					{
						hit.rigidbody.AddForce(-hit.normal * impactForce);
					}

					Instantiate(impactFx, target.transform);
				}
			} else
			{
				// spawn particle effect at end of range
				Instantiate(impactFx, playerCam.transform.position + (playerCam.transform.forward * range[level-1]), Quaternion.identity);
			}
		}
	}
	
	private IEnumerator shotEffect ()
	{
		gunAudio.Play();
		yield return shotDuration;
	}

	/**
	 * TO DO: Calculate a direction vector randomly within the spread radius
	 */
	protected Vector3 GetShotDirection(Transform cam)
	{
		return cam.forward;
	}
}
