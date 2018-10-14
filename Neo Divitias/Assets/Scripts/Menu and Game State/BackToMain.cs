using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
