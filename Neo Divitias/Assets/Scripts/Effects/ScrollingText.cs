using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour {

    public float scrollX = 0.5f;
    public float scrollY = 0.5f;

    Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update () {
        float offsetX = Time.time * scrollX;
        float offsetY = Time.time * scrollY;

        material.mainTextureOffset = new Vector2(offsetX, offsetY);
	}
}
