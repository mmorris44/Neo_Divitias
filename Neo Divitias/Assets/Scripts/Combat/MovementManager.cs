using UnityEngine;

public class MovementManager : MonoBehaviour {
    public string activateButton;
    public string alternateActivateButton;
    PlayerHealth playerHealth;
    public int playerNumber;

    public MovementItem dash;
    public MovementItem rocket;
    public MovementItem equipped;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        if (playerNumber == 1)
        {
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
        // check for movement ability input
        if ((Input.GetButtonDown(activateButton) || Input.GetButtonDown(alternateActivateButton)) && !playerHealth.isDead)
        {
            equipped.Activate();
        }
    }
}
