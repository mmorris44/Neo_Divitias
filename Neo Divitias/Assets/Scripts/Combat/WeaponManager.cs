using UnityEngine;

// Handles which weapons are currently active, which is currently equipped
// and passes call to shoot onto equipped weapon
public class WeaponManager : MonoBehaviour
{
    public string fireButton;
    public string alternareFireButton;
    public string switchButton;
    public string alternateSwitchButton;
    public int playerNumber;

    public Camera playerCamera;
    public PlayerHealth playerHealth;
    public Weapon shotgun;
    public Weapon pistol;
    public Weapon smg;
    public Weapon rifle;

    public Weapon equipped;
	public Weapon unequipped;
    public AudioSource swapSound;

    private void Start()
    {
        // Load in active weapons
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
            equipped.level = GameState.player_one.Equipment[primary];
            unequipped.level = GameState.player_one.Equipment[secondary];
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
            equipped.level = GameState.player_two.Equipment[primary];
            unequipped.level = GameState.player_two.Equipment[secondary];
        }
        equipped.gameObject.SetActive(true);

    }

    void Update () {
        // Check for shooting
		if ((Input.GetAxis(fireButton) > 0 || Input.GetButton(alternareFireButton)) && !playerHealth.isDead)
		{
			equipped.Shoot(playerCamera);
		}
		
        // Check for being able to switch
		if ((Input.GetButtonDown(switchButton) || Input.GetButtonDown(alternateSwitchButton)) && !playerHealth.isDead)
        {
            // Swap equipped and unequipped weapons
			Weapon tmp = equipped;
			equipped = unequipped;
			unequipped = tmp;

            // Play switch animation
            swapSound.Play();
            StartCoroutine(unequipped.switchOut(equipped));
        }
	}
}
