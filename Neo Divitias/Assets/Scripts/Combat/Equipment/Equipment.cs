using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// General equipment class for items bought in shop to store stats
public class Equipment : MonoBehaviour {
	
	public int level;
	public int cost;

    // Level up the equipment
	public void Upgrade()
	{
		level += 1;
		cost *= 2;
	}

    // Check if at max level yet
	public bool Upgradable(int currentPoints)
	{
		return (currentPoints >= cost) && (level < 3);
	}
}
