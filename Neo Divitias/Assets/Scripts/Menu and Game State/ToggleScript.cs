using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ToggleScript : MonoBehaviour {
    private Toggle toggle;
    Toggle[] ws;

    private void Start() {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);

        Refresh();
    }

    private void selectItem(int player, string w){
        w = w.Split(' ')[0];
        if (w.Equals("armour"))
        {

        }
        else if (w.Equals("jump") || w.Equals("dash"))
        {
            if (player == 1)
            {
                GameState.player_one.selectMovement(w);
            }
            else if (player == 2)
            { 
                GameState.player_two.selectMovement(w);
            }
        }
        else
        {
            if (player == 1)
            {
                GameState.player_one.selectWeapon(w);
            }
            else if (player == 2)
            {
                GameState.player_two.selectWeapon(w);
            }
        }
    }

    private void deselectItem(int player, string w){
        if (w.Equals("armour"))
        {

        }
        else if (w.Equals("jump") || w.Equals("dash"))
        {
            if (player == 1)
            {
                GameState.player_one.deselectMovement();
            }
            else if (player == 2)
            {
                GameState.player_two.deselectMovement();
            }
        }
        else
        {
            if (player == 1)
            {
                GameState.player_one.deselectWeapon(w);
            }
            else if (player == 2)
            {
                GameState.player_two.deselectWeapon(w);
            }
        }
    }

    public void makeDark()
    {
        UnityEngine.UI.ColorBlock cb = toggle.colors;
        cb.normalColor = Color.gray;
        cb.highlightedColor = Color.yellow;

        toggle.colors = cb;
    }

    public void autoOff()
    {
       toggle.isOn = false;
    }

    public void autoOn()
    {
        toggle.isOn = false;
    }

    public void makeGreen()
    {
        toggle = GetComponent<Toggle>();
        UnityEngine.UI.ColorBlock cb = toggle.colors;

        cb.normalColor = Color.green;
        cb.highlightedColor = Color.yellow;

        toggle.colors = cb;
    }

    private void OnToggleValueChanged(bool isOn){
        if (isOn)
        {
            if (gameObject.layer == 8)
            {
                deselectItem(1, gameObject.GetComponent<Toggle>().ToString().ToLower());
            }
            else if (gameObject.layer == 9)
            {
                deselectItem(2, gameObject.GetComponent<Toggle>().ToString().ToLower());
            }
            makeDark();
        }
        else
        {
            // Change the toggle to selected. This should then call refresh to deactivate the oldest weapon.
            if (gameObject.layer == 8)
            {
                selectItem(1, gameObject.GetComponent<Toggle>().ToString().ToLower());
            }
            else if (gameObject.layer == 9)
            {
                selectItem(2, gameObject.GetComponent<Toggle>().ToString().ToLower());
            }
            makeGreen();
        }
        //debug blah
        if (gameObject.layer == 8)
        {
            GameState.player_one.playerDebug();
        }
        else if (gameObject.layer == 9)
        {
            GameState.player_two.playerDebug();
        }

    }

    public void Refresh() {

        TextMeshProUGUI mText = gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0];
        TextMeshProUGUI cash_left = transform.parent.parent.GetComponentsInChildren<TextMeshProUGUI>()[11];
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
        else
        {
            cost.text = string.Format("MAX");
            upgrade.interactable = false;
            // Was a bug where if item became too expensive or max, it would become unclickable. However this would also mean you can select more things on controller.
            // In this case, just move the selection to the actual toggle
           // toggle.Select();
        }
        
        // Can't click if cant afford
        if (!affordable){
            upgrade.interactable = false;
           // toggle.Select();
           // toggle.Select();
        }


        if (current_level == 0)
        {
            toggle.interactable = false;
        }
        else
        {
            toggle.interactable = true;
        }
        mText.text = string.Format("{0}", current_level);
        cash_left.text = string.Format("$ {0}", money);

    }
}



