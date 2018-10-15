using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Controls fade to white at end of final cutscene
public class FadeToWhite : MonoBehaviour {

    public Animator fadeToWhite;
    public Image fadeImg;
    public float fadeOutDuration = 3f;
    public bool done = false;

    // Play fade animation
    public IEnumerator Fade()
    {
        fadeToWhite.Play("FadeOut");

        float playUntil = Time.time + fadeOutDuration;
        while (fadeImg.color.a < 0.95f)
        {
            // Scale speed of animation based on time
            Time.timeScale -= (0.75f / (fadeOutDuration / 2) * Time.deltaTime);
            fadeToWhite.speed = 2 - Time.timeScale;
            
            yield return null;
        }

        done = true;
    }
}
