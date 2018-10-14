using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateSkull : MonoBehaviour {

    public Image skull;

	// Update is called once per frame
	void Update () {
        Color c = skull.color;
        c.a = 1f - 0.4f * Mathf.Sin(Time.time);
        skull.color = c;
	}
}
