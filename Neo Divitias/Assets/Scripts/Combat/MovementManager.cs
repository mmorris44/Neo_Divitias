using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {
    public string activateButton;
    public string alternateActivateButton;
    PlayerHealth playerHealth;

    public MovementItem dash;
    public MovementItem rocket;

    public MovementItem equipped;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update () {
        if ((Input.GetButtonDown(activateButton) || Input.GetButtonDown(alternateActivateButton)) && !playerHealth.isDead)
        {
            equipped.Activate();
        }
    }
}
