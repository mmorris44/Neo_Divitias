using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {
    public string activateButton;
    public MovementItem dash;
    public MovementItem rocket;

    public MovementItem equipped;
	
	void Update () {
        if (Input.GetButtonDown(activateButton))
        {
            equipped.Activate();
        }
    }
}
