using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionManager : MonoBehaviour {
    string primary;
    string secondary;

    Toggle[] ws;

    // Use this for initialization
    void Start () {
        ws = gameObject.GetComponentsInChildren<Toggle>();
        Toggle pistol = ws[0];
        ToggleScript tsp = pistol.GetComponent<ToggleScript>();
        //tsp.makeDark();
        tsp.makeGreen();
    }
    //55 92
	
	// Update is called once per frame
	void Update () {
        if (gameObject.layer == 8)
        {
            primary = GameState.player_one.primary;
            secondary = GameState.player_one.secondary;
        }
        else if (gameObject.layer == 9)
        {
            primary = GameState.player_two.primary;
            secondary = GameState.player_two.secondary;
        }

        foreach (Toggle t in ws)
        {
            ToggleScript ts = t.GetComponent<ToggleScript>();

            if (!string.Equals(t.name.ToLower(),primary) && !string.Equals(t.name.ToLower(), secondary))
            {
                ts.makeDark();
                ts.autoOff();
                // (FIXED)The bug with having to double click is because we only change the colout here. WE do not deselect the toggle
            }
            else
            {
                ts.makeGreen();
                ts.autoOn();
            }
        }
    }
}
