using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour {
    public Color ready;
    public Color notReady;
    public Image dash;
    public Image leap;
    public string player;

    private bool dashEquipped = false;
    private Image activeImage;

    private void Start()
    {
        if (player == "player2")
        {
            if (GameState.player_two.movement == "dash")
            {
                dashEquipped = true;
                dash.enabled = true;
                leap.enabled = false;
                activeImage = dash;
            }
            else
            {
                dashEquipped = false;
                dash.enabled = false;
                leap.enabled = true;
                activeImage = leap;
            }
        }
        else
        {
            if (GameState.player_one.movement == "dash")
            {
                dashEquipped = true;
                dash.enabled = true;
                leap.enabled = false;
                activeImage = dash;
            }
            else
            {
                dashEquipped = false;
                dash.enabled = false;
                leap.enabled = true;
                activeImage = leap;
            }
        }
    }

    public IEnumerator abilityActivate(float reset, float cooldown)
    {
        Color change = notReady;
        change.a = 0f;
        activeImage.color = change;

        while (Time.time < reset)
        {
            change = activeImage.color;
            change.a = 0.85f - (reset - Time.time) / cooldown;
            activeImage.color = change;

            yield return null;
        }

        activeImage.color = ready;
    }
}
