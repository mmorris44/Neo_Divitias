using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmourManager : MonoBehaviour
{
    int level;
    Toggle ws;
    ToggleScript ts;

    // Use this for initialization
    void Start()
    {
        ws = gameObject.GetComponentsInChildren<Toggle>()[0];
        ts = ws.GetComponent<ToggleScript>();
    }

    void Update()
    {
        if (gameObject.layer == 8)
        {
            level = GameState.player_one.Equipment["armour"];
        }
        else if (gameObject.layer == 9)
        {
            level = GameState.player_two.Equipment["armour"];
        }

        if(level != 0)
        {
            ts.makeGreen();
            ts.autoOn();
        }
        else
        {
            ts.makeDark();
            ts.autoOff();
        }
    }
}

