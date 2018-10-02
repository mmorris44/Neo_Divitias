using System.Collections;
using UnityEngine;

public abstract class Weapon : Equipment
{
	public float impactForce;
	public GameObject impactFx;
    public float maxRecoil;
    public float recoilRecovery;
	public int[] damage;
	public float[] range;
	public float[] recoil; // amount of recoil per shot
	public float[] fireRate; // (per second)	

    private float currentRecoil = 0.0f;
	private ParticleSystem muzzleFlash;
	private AudioSource gunAudio;
	private float nextFire;
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

	void Start()
	{
		gunAudio = GetComponent<AudioSource>();
		muzzleFlash = GetComponent<ParticleSystem>();
	}

    void Update()
    {
        float xRotation = recoilRecovery;
        currentRecoil -= recoilRecovery;
        if (currentRecoil < 0.0f)
        {
            xRotation += currentRecoil;
            currentRecoil = 0.0f;
        }
        gameObject.transform.Rotate(xRotation, 0.0f, 0.0f);
    }

    public void Shoot(Camera playerCam)
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + (1 / fireRate[level-1]);
            Recoil();
            StartCoroutine(shotEffect());

            Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

			if (Physics.Raycast(rayOrigin, playerCam.transform.forward, out hit, range[level-1]))
			{
				DamageableObject target = hit.collider.GetComponent<DamageableObject>();

				if (target != null)
				{
                    if (target.gameObject.tag != "player" || GameState.game_level == 4 )
                    {
                        target.damage(damage[level - 1]);
                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * impactForce);
                        }
                    }

				}

                Instantiate(impactFx, target.transform);
            }
            else
			{
				// spawn particle effect at end of range
				Instantiate(impactFx, playerCam.transform.position + (playerCam.transform.forward * range[level-1]), Quaternion.identity);
			}
		}
	}
	
	private IEnumerator shotEffect ()
	{
        gunAudio.Play();
        muzzleFlash.Play();
        yield return shotDuration;
	}

    private void Recoil()
    {
        float xRotation = recoil[level - 1];
        currentRecoil += recoil[level - 1];
        if (currentRecoil > maxRecoil)
        {
            xRotation += maxRecoil - currentRecoil;
            currentRecoil = maxRecoil;
        }
        gameObject.transform.Rotate(-xRotation, 0.0f, 0.0f);
    }
}
