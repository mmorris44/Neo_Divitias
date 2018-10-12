using System.Collections;
using UnityEngine;

public abstract class Weapon : Equipment
{
	public float impactForce;
	public float swapDelay;
    public Transform endOfBarrel;
	public GameObject impactFx;
    public GameObject fizzleFx;
    public GameObject muzzleFx;
    public float maxRecoil;
    public float recoilRecovery;
	public int[] damage;
	public float[] range;
	public float[] recoil; // amount of recoil per shot
	public float[] fireRate; // (per second)

    private bool switching = true;
    private float currentRecoil = 0.0f;
	private ParticleSystem muzzleFlash;
	private AudioSource gunAudio;
	private float nextFire;
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

	private void OnEnable()
	{
		StartCoroutine(switchIn());
	}

	void Start()
	{
		gunAudio = GetComponent<AudioSource>();
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
	}

    void Update()
    {
        if (!switching)
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
    }

    public void Shoot(Camera playerCam)
	{
		if (Time.time > nextFire && !switching)
		{
			nextFire = Time.time + (1 / fireRate[level-1]);
            Recoil();
            if (gameObject.activeSelf) StartCoroutine(shotEffect());

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

                Instantiate(impactFx, hit.point, Quaternion.identity);
            }
            else
			{
				// spawn particle effect at end of range
				Instantiate(fizzleFx, playerCam.transform.position + (playerCam.transform.forward * range[level-1]), Quaternion.identity);
			}
		}
	}
	
	private IEnumerator shotEffect ()
	{
        gunAudio.Play();
        //muzzleFlash.Play();
        var muzzle = Instantiate(muzzleFx, endOfBarrel.position, endOfBarrel.rotation);
        muzzle.transform.parent = endOfBarrel;
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

    public IEnumerator switchOut(Weapon switchingIn)
    {
        switching = true;

        // rotate down
        float rotateAmount = 0.0f;
        float rotateStep = 10f;
        while (rotateAmount < 49.0f)
        {
            rotateAmount += rotateStep;
            gameObject.transform.Rotate(-10.0f, 0.0f, 0.0f);
            yield return null;
        }

	    // swap active
        gameObject.SetActive(false);
	    switchingIn.gameObject.SetActive(true);
	    
	    // clean up
        gameObject.transform.Rotate(currentRecoil + 50.0f, 0.0f, 0.0f);
        currentRecoil = 0.0f;
    }

    private IEnumerator switchIn()
    {
        float rotateAmount = 50.0f;
        float rotateStep = 10.0f;
        gameObject.transform.Rotate(50.0f, 0.0f, 0.0f);

        // rotate up
        while (rotateAmount > 1.0f)
        {
            rotateAmount -= rotateStep;
            gameObject.transform.Rotate(-10.0f, 0.0f, 0.0f);
            yield return null;
        }

	    switching = false;
    }
}
