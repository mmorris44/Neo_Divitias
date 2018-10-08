using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public static int deathPenalty;

	private static int collectedObjectives = 0;
	private static int totalObjectives;
    private static int penaltyTotal;
    public TextMeshProUGUI timeText;
	
	void Start ()
	{
        penaltyTotal = 0;
        totalObjectives = GameObject.FindGameObjectsWithTag("objective").Length;
        timeText.SetText("Time: 0s");
    }

    void Update()
    {
        timeText.SetText("Time: " + ((int)Time.timeSinceLevelLoad + penaltyTotal) + "s");
    }

    public static void CollectObjective()
	{
		collectedObjectives += 1;

		if (collectedObjectives == totalObjectives)
		{
            FindObjectOfType<GameManager>().StartCoroutine(changeLevel());
		}
	}

	static IEnumerator changeLevel()
	{
		collectedObjectives = 0;

        float originalTimeScale = Time.timeScale;
        // fade to black and gradual time slow
        /*
        while(!faded) {

            yield return null;
        }
 
        */

        // reset timescale, set prefs & change level
        Time.timeScale = originalTimeScale;
        GameState.SetPrefs();
        SceneManager.LoadScene("Shop");

        yield return null; // placeholder
	}

    public static void addTimePenalty()
    {
        penaltyTotal += deathPenalty;
    }
}
