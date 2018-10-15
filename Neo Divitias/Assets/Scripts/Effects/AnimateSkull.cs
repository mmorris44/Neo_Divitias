using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Animation of skull fading in and out
public class AnimateSkull : MonoBehaviour {

    public Image skull;

	void Update () {
        // Adjust alpha value based on trig function
        Color c = skull.color;
        c.a = 1f - 0.4f * Mathf.Sin(Time.time);
        skull.color = c;
	}
}
