using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {

    public Camera firstPersonCamera,
        thirdPersonCamera,
        orbitingCamera;

    int activeCamera = 0;
    Camera[] cameras = new Camera[3];

	// Use this for initialization
	void Start () {
        firstPersonCamera.enabled = false;
        thirdPersonCamera.enabled = false;
        orbitingCamera.enabled = false;

        cameras[0] = firstPersonCamera;
        cameras[1] = thirdPersonCamera;
        cameras[2] = orbitingCamera;

        cameras[activeCamera].enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Toggle Camera"))
        {
            cameras[activeCamera].enabled = false;
            activeCamera = (activeCamera + 1) % 3;
            cameras[activeCamera].enabled = true;
        }
	}

    public Camera getActiveCamera ()
    {
        return cameras[activeCamera];
    }
}
