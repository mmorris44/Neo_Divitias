using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to make the cursor invisible when the game starts
public class CursorController : MonoBehaviour {

	void Start () {
        Cursor.visible = false;
	}
}
