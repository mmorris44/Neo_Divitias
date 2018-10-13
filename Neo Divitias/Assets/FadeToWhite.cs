using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToWhite : MonoBehaviour {

    public Animator fadeToWhite;
    public Image fadeImg;
    public float fadeOutDuration = 3f;
    public bool done = false;

    public IEnumerator Fade()
    {
        fadeToWhite.Play("FadeOut");

        float playUntil = Time.time + fadeOutDuration;
        while (fadeImg.color.a < 0.95f)
        {
            Debug.Log(fadeImg.color.a);
            Time.timeScale -= (0.75f / (fadeOutDuration / 2) * Time.deltaTime);
            fadeToWhite.speed = 2 - Time.timeScale;
            
            yield return null;
        }

        done = true;
    }
}
