using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeSelectionManager : MonoBehaviour
{
    string movement;
    Toggle[] ws;

    // Use this for initialization
    void Start()
    {
        ws = gameObject.GetComponentsInChildren<Toggle>();
    }

    void Update()
    {
        if (gameObject.layer == 8)
        {
            movement = GameState.player_one.movement.Split('_')[1].Split(' ')[0];
        }
        else if (gameObject.layer == 9)
        {
            movement = GameState.player_two.movement.Split('_')[1].Split(' ')[0];
        }

        foreach (Toggle t in ws)
        {
            ToggleScript ts = t.GetComponent<ToggleScript>();

            if (!string.Equals(t.name.ToLower(), movement))
            {
                // Debug.Log("ATTR: " + t.name.ToLower() + " " + movement);
                ts.makeDark();
                ts.autoOff();
                // (FIXED)The bug with having to double click is because we only change the colout here. WE do not deselect the toggle
            }
        }
    }
}

