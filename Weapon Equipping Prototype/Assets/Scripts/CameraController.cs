using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    enum CameraState
    {
        FPP, TPP
    }

    public Transform fppOffset, tppOffset, player;
    CameraState state;

	// Use this for initialization
	void Start () {
        state = CameraState.TPP;
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
            case CameraState.FPP:
                transform.position = player.position + fppOffset.position;
                break;
            case CameraState.TPP:
                transform.position = player.position + tppOffset.position;
                break;
        }
	}
}
