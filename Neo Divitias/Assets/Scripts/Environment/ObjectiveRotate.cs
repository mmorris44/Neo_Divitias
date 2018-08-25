using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveRotate : MonoBehaviour {

    public float rotateSpeed = 1f;
    public float vertSpeed = 0.05f;
    public float vertDist = 0.5f;

    float currentDist = 0;
    int vertMult = 1;

	void FixedUpdate () {
        transform.Rotate(0, rotateSpeed, 0);

        if (currentDist > vertDist)
        {
            vertMult = (-1) * vertMult;
            currentDist = 0;
        }

        transform.Translate(vertSpeed * vertMult * Vector3.up);
        currentDist += vertSpeed;
    }
}
