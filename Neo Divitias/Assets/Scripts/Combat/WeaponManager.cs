using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public string fireButton;
    public string switchButton;
    public int playerNumber;

    public Camera playerCamera;
    public Weapon shotgun;
    public Weapon pistol;
    public Weapon smg;
    public Weapon rifle;

    public Weapon equipped;
	public Weapon unequipped;

    private void Start()
    {
        // Still need to add level in here
        if (playerNumber == 1)
        {
            string primary = GameState.player_one.primary;
            string secondary = GameState.player_one.secondary;
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
            equipped.level = GameState.player_one.Equipment["primary"];
            unequipped.level = GameState.player_one.Equipment["secondary"];
        }
        else
        {
            string primary = GameState.player_two.primary;
            string secondary = GameState.player_two.secondary;
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
            equipped.level = GameState.player_two.Equipment["primary"];
            unequipped.level = GameState.player_two.Equipment["secondary"];
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
