using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneFader : MonoBehaviour {
    public Animator animator;
    public Image img;
    public bool fadeOnStart = true;

	void Start () {
        if (fadeOnStart)
            animator.Play("FadeIn");
        else
        {
            StartCoroutine(FadeOutSlow());
        }
	}
	
	public void FadeOut () {
        animator.Play("FadeOut");
    }

    public bool FadedOut()
    {
        return img.color.a == 1f;
    }

    public IEnumerator FadeOutSlow()
    {
        animator.Play("FadeOutSlow");
        float wait_until = Time.time + 37f;
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
