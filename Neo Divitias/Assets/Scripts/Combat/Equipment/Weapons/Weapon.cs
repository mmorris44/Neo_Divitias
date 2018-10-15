using System.Collections;
using UnityEngine;

// General weapon class to store a variety of stats
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
	public float[] damage;
	public float[] range;
	public float[] recoil; // amount of recoil per shot
	public float[] fireRate; // (per second)

    private bool switching = true;
    private float currentRecoil = 0.0f;
	private AudioSource gunAudio;
	private float nextFire;
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

    // Switch in animation
	private void OnEnable()
	{
		StartCoroutine(switchIn());
	}

	void Start()
	{
		gunAudio = GetComponent<AudioSource>();
	}

    void Update()
    {
        // Recover to normal position from recoil if not currently switching weapons
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

    // Perform raycast shoot
    public void Shoot(Camera playerCam)
	{
        // If able to fire
		if (Time.time > nextFire && !switching)
		{
            // Play fire effects
			nextFire = Time.time + (1 / fireRate[level-1]);
            Recoil();
            if (gameObject.activeSelf) StartCoroutine(shotEffect());

            Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

            // Perform raycast
			if (Physics.Raycast(rayOrigin, playerCam.transform.forward, out hit, range[level-1], Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore))
			{
				DamageableObject target = hit.collider.GetComponent<DamageableObject>();

                // If hit object can be damaged
				if (target != null)
				{
                    // Check for friendly fire
                    if (target.gameObject.tag != "Player" || GameState.game_level == 4 )
                    {
                        // Damage object and check if that killed it
                        bool kill = target.damage(damage[level - 1]);
                        if (kill)
                        {
                            // Provide money if shot got a kill
                            if (transform.parent.gameObject.GetComponent<WeaponManager>().playerNumber == 1)
                            {
                                GameState.player_one.money += 6;
                                GameState.player_two.money += 4;
                            }
                            else
                            {
                                GameState.player_two.money += 6;
                                GameState.player_one.money += 4;
                            }
                        }
                        // Knock back if hit object has physics
                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * impactForce);
                        }
                    }

				}

                // Create impact effect
                Instantiate(impactFx, hit.point, Quaternion.identity);
            }
            else
			{
				// Spawn scatter particle effect at end of range
				Instantiate(fizzleFx, playerCam.transform.position + (playerCam.transform.forward * range[level-1]), Quaternion.identity);
			}
		}
	}
	
    // Animation a shot
	private IEnumerator shotEffect ()
	{
        gunAudio.Play();

        // Parent muzzle to barrel to avoid displaced muzzle flashes when moving weapon while shooting
        var muzzle = Instantiate(muzzleFx, endOfBarrel.position, endOfBarrel.rotation);
        muzzle.transform.parent = endOfBarrel;

        yield return shotDuration;
	}

    // Rotate gun back and force to simulate recoil
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

    // Switch out weapons and animate transition
    public IEnumerator switchOut(Weapon switchingIn)
    {
        switching = true;

        // Rotate up
        float rotateAmount = 0.0f;
        float rotateStep = 10f;
        while (rotateAmount < 49.0f)
        {
            rotateAmount += rotateStep;
            gameObject.transform.Rotate(-10.0f, 0.0f, 0.0f);
            yield return null;
        }

	    // Swap active
        gameObject.SetActive(false);
	    switchingIn.gameObject.SetActive(true);
	    
	    // Clean up
        gameObject.transform.Rotate(currentRecoil + 50.0f, 0.0f, 0.0f);
        currentRecoil = 0.0f;
    }

    // Switch in other weapon
    private IEnumerator switchIn()
    {
        float rotateAmount = 50.0f;
        float rotateStep = 10.0f;
        gameObject.transform.Rotate(50.0f, 0.0f, 0.0f);

        // Rotate up
        while (rotateAmount > 1.0f)
        {
            rotateAmount -= rotateStep;
            gameObject.transform.Rotate(-10.0f, 0.0f, 0.0f);
            yield return null;
        }

	    switching = false;
    }
}
