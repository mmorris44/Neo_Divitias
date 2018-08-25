using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	public Camera playerCamera;
	private Weapon equipped;
	private Weapon unequipped;

	void Start()
	{
		playerCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
		{
			equipped.Shoot(playerCamera);
		}
		
		// input check for weapon switching
		if (Input.GetButton("SwitchWeapon"))
		{
			Weapon tmp = equipped;
			equipped = unequipped;
			unequipped = tmp;
		}
	}
}
