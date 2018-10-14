using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyButtonColour : MonoBehaviour {
    public Button button1;
    public Button button2;
    bool ready1;
    bool ready2;
    MainMenu m = new MainMenu();

    // Use this for initialization
    void Start () {
        ready1 = false;
        ready2 = false;
        makeGray(button1);
        makeGray(button2);
    }

    public void hover(int player)
    {
        if (player == 1)
        {
            ColorBlock cb = button1.colors;
            if (ready1)
            {
                cb.highlightedColor = Color.cyan;
            }
            else
            {
                cb.highlightedColor = Color.red;
            }
            button1.colors = cb;
        }
        else if (player == 2)
        {
            ColorBlock cb = button2.colors;
            if (ready2)
            {
                cb.highlightedColor = Color.cyan;
            }
            else
            {
                cb.highlightedColor = Color.red;
            }
            button2.colors = cb;
        }
    }

    void makeGreen(Button b)
    {
        ColorBlock cb = b.colors;
        cb.normalColor = Color.green;
        cb.highlightedColor = Color.green;
        b.colors = cb;
    }

    void makeGray(Button b)
    {
        ColorBlock cb = b.colors;
        cb.normalColor = Color.gray;
        cb.highlightedColor = Color.gray;
        b.colors = cb;
    }

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
        if(ready1 && ready2)
        {
            m.StartNextLevel();
        }  
    }
}
