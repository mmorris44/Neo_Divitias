using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private static int collectedObjectives = 0;
	private static int totalObjectives;
	
	void Start ()
	{
		totalObjectives = GameObject.FindGameObjectsWithTag("objective").Length;
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
