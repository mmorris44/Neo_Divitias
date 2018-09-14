using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeScript : MonoBehaviour {
    private UnityEngine.UI.Toggle toggle;

    public void UpgradeItem(string item){
        toggle = GameObject.FindGameObjectWithTag(item.ToLower()).GetComponent<UnityEngine.UI.Toggle>();

        int current_level;
        int cost_of_upgrade;
        // Dont need to check if player can afford item because items that are too expensive wont be interactable
        if (gameObject.layer == 8){
            current_level = GameState.player_one.Equipment[item.ToLower()];
            cost_of_upgrade = PlayerPrefs.GetInt(string.Format("{0}_{1}", item.ToLower(), current_level + 1));
            GameState.player_one.Equipment[item.ToLower()]++;
            GameState.player_one.money -= cost_of_upgrade;
            //Debug.Log(GameState.player_one.money);
        }
        else if (gameObject.layer == 9){
            current_level = GameState.player_two.Equipment[item.ToLower()];
            cost_of_upgrade = PlayerPrefs.GetInt(string.Format("{0}_{1}", item.ToLower(), current_level + 1));
            GameState.player_two.Equipment[item.ToLower()]++;
            GameState.player_two.money -= cost_of_upgrade;
        }
        
        foreach (UnityEngine.UI.Toggle t in gameObject.GetComponentsInChildren <UnityEngine.UI.Toggle>())
        {
            Debug.Log("Please");
            ToggleScript ts = t.GetComponent<ToggleScript>();
            ts.Refresh();
        }
    }
}
