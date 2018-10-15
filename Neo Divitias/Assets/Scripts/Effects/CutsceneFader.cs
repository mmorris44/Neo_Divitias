using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Controls the fadeout from the end or skipping of a cutscene
public class CutsceneFader : MonoBehaviour {
    public Animator animator;
    public Image img;
    public bool fadeOnStart = true;

    // Check for which animation to play
	void Start () {
        if (fadeOnStart)
            animator.Play("FadeIn");
        else
        {
            StartCoroutine(FadeOutSlow());
        }
	}
	
    // Play fadeout animation
	public void FadeOut () {
        animator.Play("FadeOut");
    }

    // See if fully faded yet
    public bool FadedOut()
    {
        return img.color.a == 1f;
    }

    // Fade out slowly over time
    public IEnumerator FadeOutSlow()
    {
        animator.Play("FadeOutSlow");
        float wait_until = Time.time + 37f;

        // Wait until animation is done
        while (Time.time < wait_until)
        {
            yield return null;

        }
        Color c = img.color;
        c.a = 1f;
        img.color = c;

        SceneManager.LoadSceneAsync("Main");
    }
}
