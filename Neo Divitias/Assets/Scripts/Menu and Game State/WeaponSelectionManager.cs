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
        Debug.Log("Blah" + pistol.name);
        ToggleScript tsp = pistol.GetComponent<ToggleScript>();
        //tsp.makeDark();
        tsp.makeGreen();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.layer == 8)
        {
            primary = GameState.player_one.primary.Split('_')[1].Split(' ')[0];
            secondary = GameState.player_one.secondary.Split('_')[1].Split(' ')[0];
        }
        else if (gameObject.layer == 9)
        {
            primary = GameState.player_two.primary.Split('_')[1].Split(' ')[0];
            secondary = GameState.player_two.secondary.Split('_')[1].Split(' ')[0];
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
        }
    }
}
