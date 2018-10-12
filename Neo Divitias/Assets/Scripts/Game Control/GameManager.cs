using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public static Image[] fadeImgs;
    public static Animator[] fadeAnims;
    public static int deathPenalty;
    public static bool timerOn;

	private static int collectedObjectives = 0;
	private static int totalObjectives;
    private static int penaltyTotal;
    public TextMeshProUGUI timeText;
    public static TextMeshProUGUI objectiveText;

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

        foreach (Animator anim in fadeAnims)
        {
            if (anim != null)
            {
                anim.Play("fadeIn");
            }
        }
        timerOn = true;
        penaltyTotal = 0;
        totalObjectives = GameObject.FindGameObjectsWithTag("objective").Length;
        timeText.SetText("Time: 0s");
    }

    void Update()
    {
        if (timerOn)
        {
            timeText.SetText("" + Mathf.Min((int)Time.timeSinceLevelLoad + penaltyTotal, 99999));
        }
    }

    public static void CollectObjective()
	{
		collectedObjectives += 1;
        objectiveText.SetText("" + collectedObjectives + "/" + totalObjectives);

        if (collectedObjectives == totalObjectives)
		{
            FindObjectOfType<GameManager>().StartCoroutine(changeLevel());
		}
	}

	static IEnumerator changeLevel()
	{
		collectedObjectives = 0;
        timerOn = false;
        float fadeOutDuration = 3f;
        float originalTimeScale = Time.timeScale;

        foreach (Animator anim in fadeAnims)
        {
            if (anim != null)
                anim.Play("fadeOut");
        }
        float playUntil = Time.time + fadeOutDuration;
        while(fadeImgs[0].color.a < 0.95f) {
            Debug.Log(fadeImgs[0].color.a);
            Time.timeScale -= (0.75f / (fadeOutDuration / 2) * Time.deltaTime);
            foreach (Animator anim in fadeAnims)
            {
                if (anim != null)
                    anim.speed = 2 - Time.timeScale;
            }
            yield return null;
        }

        // reset timescale, set prefs & change level
        Time.timeScale = originalTimeScale;
        MainMenu m = new MainMenu();
        m.FinishLevel();
        //GameState.SetPrefs();

        if (SceneManager.GetActiveScene().name == "Tutorial" )
            SceneManager.LoadScene("Main");
        else if (SceneManager.GetActiveScene().name == "PvP Level")
            SceneManager.LoadScene("Main");
        else
            SceneManager.LoadScene("Shop");

    }

    public static void addTimePenalty()
    {
        penaltyTotal += deathPenalty;
    }
}
