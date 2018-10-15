using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Handles logic of upgrading weapons using the upgrade button
// Manages the GUI when doing do
public class UpgradeScript : MonoBehaviour {
    private Button button;
    private string item;
    private Toggle toggle;
    int player;

    private void Start()
    {
        // Find which player is assigned to the buton
        player = 1;
        if (gameObject.layer == 9)
        {
            player = 2;
        }

        // Get toggle assigned to activate corresponding equipment
        toggle = transform.GetComponentInParent<Toggle>();
        item = transform.parent.name;
        button = GetComponent<Button>();

        // Listen for button press
        button.onClick.AddListener(OnButtonClick);

        // Set default button colours
        ColorBlock cb = button.colors;
        cb.normalColor = GameState.offColour;
        cb.highlightedColor = GameState.offSelectColour;
        cb.disabledColor = GameState.uninteractableColour;
        button.colors = cb;

        // Refresh GUI
        Refresh();
    }

    // Listen for button being pressed
    public void OnButtonClick(){

        // Dont need to check if player can afford item because items that are too expensive won't be interactable
        int current_level;
        int cost_of_upgrade;

        // Upgrade weapon of correct player
        if (player == 1){
            current_level = GameState.player_one.Equipment[item.ToLower()];
            cost_of_upgrade = PlayerPrefs.GetInt(string.Format("{0}_{1}", item.ToLower(), current_level + 1));
            GameState.player_one.Equipment[item.ToLower()]++;
            GameState.player_one.money -= cost_of_upgrade;
        }
        else if (player == 2){
            current_level = GameState.player_two.Equipment[item.ToLower()];
            cost_of_upgrade = PlayerPrefs.GetInt(string.Format("{0}_{1}", item.ToLower(), current_level + 1));
            GameState.player_two.Equipment[item.ToLower()]++;
            GameState.player_two.money -= cost_of_upgrade;
        }

        // Update toggle to on if armour is upgraded
        if (item.ToLower().Equals("armour"))
        {
            toggle.gameObject.GetComponent<ToggleScript>().Refresh();
        }

        // Jump across onto toggle after upgrading
        toggle.interactable = true;
        toggle.Select();

        // Refresh GUI
        Refresh();
    }

    public void Refresh()
    {
        // Update toggle level text
        int moneyLeft;

        if(player == 1)
        {
            moneyLeft = GameState.player_one.money;
        }
        else
        {
            moneyLeft = GameState.player_two.money;
        }

        // Display money left
        GameObject p = transform.parent.parent.parent.gameObject;
        TextMeshProUGUI cl = p.GetComponentsInChildren<TextMeshProUGUI>()[11];
        cl.text = string.Format("$ {0}", moneyLeft);

        // For every upgrade button
        foreach (Button b in transform.parent.parent.parent.GetComponentsInChildren<Button>())
        {
            // Find cost text to update
            Text costText = b.gameObject.GetComponentInChildren<Text>();
            int c_level;

            // Get current level
            if (player == 1)
            {
                c_level = GameState.player_one.Equipment[b.transform.parent.name.ToLower()];
            }
            else
            {
                c_level = GameState.player_two.Equipment[b.transform.parent.name.ToLower()];
            }
            
            // Find and update cost on GUI
            int cost = PlayerPrefs.GetInt(string.Format("{0}_{1}", b.transform.parent.name.ToLower(), c_level+1));
            costText.text = string.Format("{0}", cost);
            Toggle t = b.GetComponentInParent<Toggle>();

            // Update current level
            t.gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text = string.Format("{0}", c_level);

            // Deactivate if levels maxed out or out of money, otherwise let it be interactable
            if (c_level >= 3)
            {
                b.interactable = false;
                costText.text = "MAX";
            }
            else if (cost > moneyLeft)
            {
                b.interactable = false;
            }
            else
            {
                b.interactable = true;
            }
        }
    }
}
