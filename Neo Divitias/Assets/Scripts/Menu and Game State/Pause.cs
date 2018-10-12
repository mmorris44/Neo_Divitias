using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    MainMenu mm;
    // Use this for initialization
    void Start () {
        mm = new MainMenu();
	}
	
	// Update is called once per frame
	void Update () {

        // Escape to end the level
        if (Input.GetKeyUp(KeyCode.Escape)){

            mm.FinishLevel();
        }
    }
}
