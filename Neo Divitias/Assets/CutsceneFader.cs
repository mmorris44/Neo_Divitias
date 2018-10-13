using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneFader : MonoBehaviour {
    public Animator animator;
    public Image img;

	void Start () {
        animator.Play("FadeIn");
	}
	
	public void FadeOut () {
        animator.Play("FadeOut");
    }

    public bool FadedOut()
    {
        return img.color.a == 1f;
    }
}
