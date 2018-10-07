using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

	private static int collectedObjectives = 0;
	private static int totalObjectives;
    public TextMeshProUGUI timeText;
	
	void Start ()
	{
		totalObjectives = GameObject.FindGameObjectsWithTag("objective").Length;
        timeText.SetText("Time: 0s");
    }

    void Update()
    {
        timeText.SetText("Time: " + (int)Time.timeSinceLevelLoad + "s");
    }

    public static void CollectObjective()
	{
		collectedObjectives += 1;

		if (collectedObjectives == totalObjectives)
		{
			changeLevel();
		}
	}

	static void changeLevel()
	{
		collectedObjectives = 0;
		throw new System.NotImplementedException();
	}
}
