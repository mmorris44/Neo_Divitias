using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ToggleScript : MonoBehaviour {
    private UnityEngine.UI.Toggle toggle;

    private void Start() { 
        toggle = GetComponent<UnityEngine.UI.Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);

        Refresh();
    }

    private void OnToggleValueChanged(bool isOn){
    UnityEngine.UI.ColorBlock cb = toggle.colors;
    if (isOn){
        cb.normalColor = Color.gray;
        cb.highlightedColor = Color.gray;
    }
    else{
        cb.normalColor = Color.green;
        cb.highlightedColor = Color.green;
    }
    toggle.colors = cb;
    }

    public void Refresh(){
        TextMeshProUGUI mText = gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0];
        TextMeshProUGUI cash_left = transform.parent.parent.GetComponentsInChildren<TextMeshProUGUI>()[8];
        Text cost = gameObject.GetComponentsInChildren<Text>()[0];
        Button upgrade = gameObject.GetComponentsInChildren<Button>()[0];

        string item_name = gameObject.name;
        int current_level = 0;
        int money = 0;
        bool upgradeable = false;
        bool affordable = false;

        if (gameObject.layer == 8){
            current_level = GameState.player_one.Equipment[item_name.ToLower()];
            money = GameState.player_one.money;
        }
        else if (gameObject.layer == 9){
            current_level = GameState.player_two.Equipment[item_name.ToLower()];
            money = GameState.player_two.money;
        }

        // Check if weapon is at max level or not
        int cost_of_upgrade = PlayerPrefs.GetInt(string.Format("{0}_{1}", item_name.ToLower(), current_level + 1));
        if (cost_of_upgrade != 0){
            upgradeable = true;
            if (cost_of_upgrade <= money){
                affordable = true;
            }
        }
        
        // Disable if max level and replace price with MAX
        if (upgradeable){
            cost.text = string.Format("{0}", PlayerPrefs.GetInt(string.Format("{0}_{1}", item_name.ToLower(), current_level + 1)));
        }
        else{
            cost.text = string.Format("MAX");
            upgrade.interactable = false;
        }
        
        // Can't click if cant afford
        if (!affordable){
            upgrade.interactable = false;
        }

        mText.text = string.Format("{0}", current_level);
        cash_left.text = string.Format("$ {0}", GameState.player_one.money);
    }
}



