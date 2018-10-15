using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PvpLevelManager : MonoBehaviour {
    public Slider player1progress;
    public Slider player2progress;
    public TextMeshProUGUI player1scoreText;
    public TextMeshProUGUI player2scoreText;
    public PlayerHealth player1;
    public PlayerHealth player2;

    public int playTo = 5;
    public float timeToCapture = 30;

    int player1score = 0;
    int player2score = 0;

    bool player1inZone = false;
    bool player2inZone = false;
    bool resetting = false;
    bool playerHealthReset = true;

	// Use this for initialization
	void Start () {
        player1scoreText.SetText("0/" + playTo);
        player2scoreText.SetText("0/" + playTo);
    }

    void Update () {
        if (!playerHealthReset)
        {
            if (player1.currentHealth > 0f && player2.currentHealth > 0f) playerHealthReset = true;
        }

        if (!resetting && playerHealthReset)
        {
            bool roundEnded = false;

            // check players fell
            if (player1.transform.position.y < -25f)
            {
                player1.damage(1000f);
            }
            else if (player2.transform.position.y < -25f)
            {
                player2.damage(1000f);
            }

            // check player healths
            if (player1.currentHealth <= 0f)
            {
                endRound(2);
                roundEnded = true;
            }
            else if (player2.currentHealth <= 0f)
            {
                endRound(1);
                roundEnded = true;
            }

            
            if (!roundEnded)
            {
                // update capture progress
                if (player1inZone && !player2inZone)
                {
                    player1progress.value += 10f * 10 / timeToCapture * Time.deltaTime;
                }
                else if (player2inZone && !player1inZone)
                {
                    player2progress.value += 10f * 10 / timeToCapture * Time.deltaTime;
                }

                // check if someone has won the round
                if (player1progress.value >= player1progress.maxValue)
                {
                    endRound(1);
                }
                if (player2progress.value >= player2progress.maxValue)
                {
                    endRound(2);
                }
            }
        }
    }

    void endRound(int winner)
    {
        if (resetting)
            return;
        resetting = true;

        if (winner == 1)
        {
            player1score++;
            player1scoreText.SetText("" + player1score + "/" + playTo);
        }
        else if (winner == 2)
        {
            player2score++;
            player2scoreText.SetText("" + player2score + "/" + playTo);
        }


        // end level if someone has reached max score
        if (player1score == playTo || player2score == playTo)
        {
            StartCoroutine(GameManager.changeLevel());
            return;
        }

        // otherwise reset for next round
        else
        {
            player1.damage(1000f);
            player2.damage(1000f);
        }

        player1progress.value = 0f;
        player2progress.value = 0f;

        playerHealthReset = false;
        resetting = false;
    }

    // keep track of players entering capture zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<Player1Controller>() != null)
            {
                player1inZone = true;
            }
            else
            {
                player2inZone = true;
            }
        }
    }

    // keep track of players leaving capture zone
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<Player1Controller>() != null)
            {
                player1inZone = false;
            }
            else
            {
                player2inZone = false;
            }
        }
    }
}
