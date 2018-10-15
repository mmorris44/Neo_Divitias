using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Animate text scrolling along screens in final cutscene
public class ScrollingText : MonoBehaviour {

    public float scrollX = 0.5f;
    public float scrollY = 0.5f;

    Material material;

    // Get material on object
    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update offset of texture over time
    void Update () {
        float offsetX = Time.time * scrollX;
        float offsetY = Time.time * scrollY;

        material.mainTextureOffset = new Vector2(offsetX, offsetY);
	}
}
