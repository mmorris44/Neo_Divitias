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

    private void Start()
    {
        // How will we determine which player it is? Put them in different layers?
        string primary = GameState.player_one.primary.Split('_')[1];
        switch (primary)
        {
            case "shotgun":
                equipped = shotgun;
                break;
            case "pistol":
                equipped = pistol;
                break;
            case "rifle":
                equipped = rifle;
                break;
            case "smg":
                equipped = smg;
                break;
        }
        string secondary = GameState.player_one.secondary.Split('_')[1];
        switch (secondary)
        {
            case "shotgun":
                unequipped = shotgun;
                break;
            case "pistol":
                unequipped = pistol;
                break;
            case "rifle":
                unequipped = rifle;
                break;
            case "smg":
                unequipped = smg;
                break;
        }
        equipped.gameObject.SetActive(true);
    }

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

            //unequipped.gameObject.SetActive(false);
            StartCoroutine(unequipped.switchOut(equipped));
            //equipped.gameObject.SetActive(true);
        }
	}
}
