using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public string fireButton;
    public string switchButton;

    public Camera playerCamera;
    public Weapon shotgun;
    public Weapon pistol;
    public Weapon smg;
    public Weapon rifle;

    public Weapon equipped;
	public Weapon unequipped;
	
	void Update () {
		if (Input.GetButton(fireButton))
		{
			equipped.Shoot(playerCamera);
		}
		
		if (Input.GetButtonDown(switchButton))
		{
			Weapon tmp = equipped;
			equipped = unequipped;
			unequipped = tmp;

            unequipped.gameObject.SetActive(false);
            equipped.gameObject.SetActive(true);
        }
	}


}
