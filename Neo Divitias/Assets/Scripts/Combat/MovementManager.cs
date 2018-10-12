using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {
    public string activateButton;
    public string alternateActivateButton;
    public MovementItem dash;
    public MovementItem rocket;

    public MovementItem equipped;
	
	void Update () {
        if (Input.GetButtonDown(activateButton) || Input.GetButtonDown(alternateActivateButton))
        {
            equipped.Activate();
        }
    }
}
