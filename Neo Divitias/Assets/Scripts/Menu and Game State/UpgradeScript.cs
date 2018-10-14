using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeScript : MonoBehaviour {
    private Button button;
    private string item;
    private Toggle toggle;
    int player;



    private void Start()
    {
        player = 1;
        if (gameObject.layer == 9)
        {
            player = 2;
        }
        toggle = transform.GetComponentInParent<Toggle>();
        item = transform.parent.name;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);

        ColorBlock cb = button.colors;
        cb.normalColor = GameState.offColour;
        cb.highlightedColor = GameState.offSelectColour;
        cb.disabledColor = GameState.uninteractableColour;
        button.colors = cb;

        Refresh();
    }

    public void OnButtonClick(){

        int current_level;
        int cost_of_upgrade;

        // Dont need to check if player can afford item because items that are too expensive wont be interactable
        // Wasn't sure how to best differentiate between player 1 and player 2 here. So put them in different layers
        // Also couldnt find a wayto get gameobject layer by naem, so have to use integer values
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
        if (item.ToLower().Equals("armour"))
        {
            toggle.gameObject.GetComponent<ToggleScript>().Refresh();
        }
        toggle.interactable = true;
        toggle.Select();
        Refresh();
    }

    public void Refresh()
    {
        //Update toggle level text
        int moneyLeft;

        if(player == 1)
        {
            moneyLeft = GameState.player_one.money;
        }
        else
        {
            moneyLeft = GameState.player_two.money;
        }
        GameObject p = transform.parent.parent.parent.gameObject;
        TextMeshProUGUI cl = p.GetComponentsInChildren<TextMeshProUGUI>()[11];
        cl.text = string.Format("$ {0}", moneyLeft);

        //cash_left.text = string.Format("$ {0}", moneyLeft);

        foreach (Button b in transform.parent.parent.parent.GetComponentsInChildren<Button>())
        {
            Text costText = b.gameObject.GetComponentInChildren<Text>();
            int c_level;
            if (player == 1)
            {
                c_level = GameState.player_one.Equipment[b.transform.parent.name.ToLower()];
            }
            else
            {
                c_level = GameState.player_two.Equipment[b.transform.parent.name.ToLower()];
            }
            
            int cost = PlayerPrefs.GetInt(string.Format("{0}_{1}", b.transform.parent.name.ToLower(), c_level+1));
            costText.text = string.Format("{0}", cost);
            Toggle t = b.GetComponentInParent<Toggle>();

            t.gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text = string.Format("{0}", c_level);

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
            // Update cash left test
        }
    }
}
