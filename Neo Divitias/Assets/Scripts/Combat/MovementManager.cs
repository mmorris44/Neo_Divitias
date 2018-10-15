using UnityEngine;

// Manages which movement ability is active and passes activate call on to it when input is given
public class MovementManager : MonoBehaviour {
    public string activateButton;
    public string alternateActivateButton;
    PlayerHealth playerHealth;
    public int playerNumber;

    public MovementItem dash;
    public MovementItem rocket;
    public MovementItem equipped;

    // Check which abilities are currently equipped
    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        if (playerNumber == 1)
        {
            playerHealth.setMaxHp(GameState.player_one.Equipment["armour"]);

            string movement = GameState.player_one.movement;
            switch (movement)
            {
                case "dash":
                    equipped = dash;
                    break;
                case "jump":
                    equipped = rocket;
                    break;
            }
            equipped.level = GameState.player_one.Equipment[movement];
        }
        else
        {
            playerHealth.setMaxHp(GameState.player_two.Equipment["armour"]);

            string movement = GameState.player_two.movement;
            switch (movement)
            {
                case "dash":
                    equipped = dash;
                    break;
                case "jump":
                    equipped = rocket;
                    break;
            }
            equipped.level = GameState.player_two.Equipment[movement];
        }
        equipped.gameObject.SetActive(true);
    }

    void Update () {
        // Check for movement ability input
        if ((Input.GetButtonDown(activateButton) || Input.GetButtonDown(alternateActivateButton)) && !playerHealth.isDead)
        {
            equipped.Activate();
        }
    }
}
