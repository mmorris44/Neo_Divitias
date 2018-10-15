using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

// Stores static information about the current state of the level and collected objectives
public class GameManager : MonoBehaviour {
    public static Image[] fadeImgs;
    public static Animator[] fadeAnims;
    public static bool timerOn;

	private static int collectedObjectives = 0;
	private static int totalObjectives;
    private static int penaltyTotal;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI p1Money;
    public TextMeshProUGUI p2Money;

    // Collect variables and play fadein
    void Start ()
	{
        fadeAnims = new Animator[2];
        fadeImgs = new Image[2];
        GameObject[] players = GameObject.FindGameObjectsWithTag("fadeAnimator");
        for (int i = 0; i < players.Length; i++)
        {
            fadeAnims[i] = players[i].GetComponent<Animator>();
        }
        for (int i = 0; i < players.Length; i++)
        {
            fadeImgs[i] = players[i].GetComponent<Image>();
        }

        // Fade in level
        foreach (Animator anim in fadeAnims)
        {
            if (anim != null)
            {
                anim.Play("fadeIn");
            }
        }

        // Set GUI data
        timerOn = true;
        penaltyTotal = 0;
        totalObjectives = GameObject.FindGameObjectsWithTag("objective").Length;
        objectiveText.SetText("" + collectedObjectives + "/" + totalObjectives);
    }

    void Update()
    {
        // Updated timer
        if (timerOn)
        {
            timeText.SetText("" + Mathf.Min((int)Time.timeSinceLevelLoad + penaltyTotal, 99999));
            p1Money.SetText("$" + GameState.player_one.money);
            p2Money.SetText("$" + GameState.player_two.money);
        }

        // Check for skipping level if it is the tutorial
        if (Input.GetButtonDown("Skip"))
        {
            if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                StartCoroutine(changeLevel());
            }
        }
    }

    // Collect an objective, mark it as done and update GUI
    public void CollectObjective()
	{
		collectedObjectives += 1;
        objectiveText.SetText("" + collectedObjectives + "/" + totalObjectives);

        if (collectedObjectives == totalObjectives)
		{
            FindObjectOfType<GameManager>().StartCoroutine(changeLevel());
		}
	}

    // Play animation to fade out of level and slow time
	public static IEnumerator changeLevel()
	{
		collectedObjectives = 0;
        timerOn = false;
        float originalTimeScale = Time.timeScale;

        // Play fade to black animation
        foreach (Animator anim in fadeAnims)
        {
            if (anim != null)
                anim.Play("fadeOut");
        }

        // Gradually slow down timescale until fadeout is complete
        while (fadeImgs[0].color.a < 0.99f)
        {
            Time.timeScale = Mathf.Max(Time.timeScale - 0.01f, 0.4f);
            foreach (Animator anim in fadeAnims)
            {
                if (anim != null)
                    anim.speed = 1f + (1f - Time.timeScale);
            }
            yield return null;
        }

        // Reset timescale, set prefs & change level
        Time.timeScale = originalTimeScale;
        MainMenu m = new MainMenu();
       
        m.FinishLevel();
    }
}
