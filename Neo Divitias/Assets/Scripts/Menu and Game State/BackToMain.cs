using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls navigation back into main menu
public class BackToMain : MonoBehaviour {
    public GameObject main;
    public GameObject controls;

    private void Update()
    {
        if (Input.GetButtonDown("Back"))
        {
            main.SetActive(true);
            controls.SetActive(false);
        }
    }
}
