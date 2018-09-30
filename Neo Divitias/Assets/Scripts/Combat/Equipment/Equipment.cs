using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {
	
	public int level;
	public int cost;

	/**
	 * Placeholder values
	 */
	public void Upgrade()
	{
		level += 1;
		cost *= 2;
	}

	public bool Upgradable(int currentPoints)
	{
		return (currentPoints >= cost) && (level < 3);
	}
}
