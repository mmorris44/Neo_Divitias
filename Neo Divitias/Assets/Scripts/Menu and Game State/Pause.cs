using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for debugging and demos that allows one to skip a level using the escape key
public class Pause : MonoBehaviour {

    MainMenu mm;

    void Start () {
        mm = new MainMenu();
	}

	void Update () {

        // Escape to end the level
        if (Input.GetKeyUp(KeyCode.Escape)){

            mm.FinishLevel();
        }
    }
}
