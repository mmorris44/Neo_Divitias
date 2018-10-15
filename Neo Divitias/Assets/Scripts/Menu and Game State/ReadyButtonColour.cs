using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manages the colour of the buttons used for readying up in the shop
// Also handles transition to next level once both players are ready
public class ReadyButtonColour : MonoBehaviour {
    public Button button1;
    public Button button2;
    bool ready1;
    bool ready2;
    MainMenu m = new MainMenu();

    // Set not ready by default
    void Start () {
        ready1 = false;
        ready2 = false;
        makeGray(button1);
        makeGray(button2);
    }

    // Highlight the button a different colour if selected by player
    public void hover(int player)
    {
        if (player == 1)
        {
            ColorBlock cb = button1.colors;
            if (ready1)
            {
                cb.highlightedColor = GameState.onSelectColour;
            }
            else
            {
                cb.highlightedColor = GameState.offSelectColour;
            }
            button1.colors = cb;
        }
        else if (player == 2)
        {
            ColorBlock cb = button2.colors;
            if (ready2)
            {
                cb.highlightedColor = GameState.onSelectColour;
            }
            else
            {
                cb.highlightedColor = GameState.offSelectColour;
            }
            button2.colors = cb;
        }
    }

    // Set button to ready green
    void makeGreen(Button b)
    {
        ColorBlock cb = b.colors;
        cb.normalColor = GameState.onColour;
        cb.highlightedColor = GameState.onSelectColour;
        b.colors = cb;
    }

    // Set button to not ready grey
    void makeGray(Button b)
    {
        ColorBlock cb = b.colors;
        cb.normalColor = GameState.offColour;
        cb.highlightedColor = GameState.offSelectColour;
        b.colors = cb;
    }

    // Press button and update colours
    public void click(int player)
    {
        if (player == 1)
        {
            if (ready1)
            {
                ready1 = false;
                makeGray(button1);
                hover(1);
            }
            else
            {
                ready1 = true;
                makeGreen(button1);
                hover(1);
            }
        }
        else if(player == 2)
        {
            if (ready2)
            {
                ready2 = false;
                makeGray(button2);
                hover(2);
            }
            else
            {
                ready2 = true;
                makeGreen(button2);
                hover(2);
            }
        }

        // Transition to next level if both players are ready
        if(ready1 && ready2)
        {
            m.StartNextLevel();
        }  
    }
}
