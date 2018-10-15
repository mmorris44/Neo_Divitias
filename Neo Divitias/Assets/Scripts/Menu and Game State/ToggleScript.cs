using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Handles the toggles that activate and deactivate equipment
public class ToggleScript : MonoBehaviour {
    private Toggle toggle;
    Toggle[] ws;
    public bool changedByCode; // Is the state being changed manually in the code

    // Set default values and update GUI
    private void Start() {
        toggle = GetComponent<Toggle>();

        // Listen for when a toggle is used
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        changedByCode = false;

        Refresh();
    }

    // Select the item with the given name
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

    // Deselect item with the given name
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

    // Check for when the toggle value changes (toggle is pressed)
    private void OnToggleValueChanged(bool isOn){
        if (!changedByCode)
        {
            if (!isOn) { // Deselect
                if (gameObject.layer == 8) // Player 1
                {
                    deselectItem(1, gameObject.GetComponent<Toggle>().name.ToLower());
                }
                else if (gameObject.layer == 9) // Player 2
                {
                    deselectItem(2, gameObject.GetComponent<Toggle>().name.ToLower());
                }
            }
            else
            { // Select
                if (gameObject.layer == 8) // Player 1
                {
                    selectItem(1, gameObject.GetComponent<Toggle>().name.ToLower());
                }
                else if (gameObject.layer == 9) // Player 2
                {
                    selectItem(2, gameObject.GetComponent<Toggle>().name.ToLower());
                }
            }
        }

        // Update GUI
        Refresh();
    }

    // Update the GUI with proper info and colour representations
    public void Refresh() {
        string item_name = gameObject.name;
        int current_level = 0;

        // Find which player is allowed on the object
        int player = 1;
        if (gameObject.layer == 9)
        {
            player = 2;
        }

        // Get current level of equipment
        if (player == 1){
            current_level = GameState.player_one.Equipment[item_name.ToLower()];
        }
        else if (player == 2){
            current_level = GameState.player_two.Equipment[item_name.ToLower()];
        }

        // Make toggle interacterable if levelled up already, otherwise uninteracterable
        if (current_level == 0)
        {
            toggle.interactable = false;
        }
        else
        {
            toggle.interactable = true;
        }

        // Find all toggles
        Toggle[] toggles = gameObject.transform.parent.GetComponentsInChildren<Toggle>();

        // Get names of active weapons and abilities from game script
        List<string> active = new List<string>();
        int armour;
        if (player == 1)
        {
            active.Add(GameState.player_one.primary);
            active.Add(GameState.player_one.secondary);
            active.Add(GameState.player_one.movement);
            armour = GameState.player_one.Equipment["armour"];
        }
        else
        {
            active.Add(GameState.player_two.primary);
            active.Add(GameState.player_two.secondary);
            active.Add(GameState.player_two.movement);
            armour = GameState.player_two.Equipment["armour"];
        }
        if (armour > 0)
        {
            // Armour active by default if levelled up
            active.Add("armour");
        }

        // For every toggle
        foreach (Toggle t in toggles)
        {
            // Get colours
            ColorBlock cb = t.colors;

            // If active
            if (active.Contains(t.name.ToLower()))
            {
                cb.normalColor = GameState.onColour;
            }

            // If inactive
            else
            {
                cb.normalColor = GameState.offColour;
                cb.highlightedColor = GameState.offSelectColour;
                t.GetComponent<ToggleScript>().changedByCode = true;
                t.isOn = false;
                t.GetComponent<ToggleScript>().changedByCode = false;
            }

            // Check for being selected and highlighted
            if (cb.normalColor == GameState.onColour)
            {
                cb.highlightedColor = GameState.onSelectColour;
            }
            else if (cb.normalColor == GameState.offColour)
            {
                cb.highlightedColor = GameState.offSelectColour;

            }

            // Update colours
            t.colors = cb;  
        }
    }
}



