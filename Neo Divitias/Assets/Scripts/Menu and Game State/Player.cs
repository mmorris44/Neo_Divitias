using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player
{
    public Dictionary<string, int> Equipment = new Dictionary<string, int>();

    public string name { get; set; }
    public int money { get; set; }

    public string weapon_1 { get; set; }
    public string weapon_2 { get; set; }
    public string movement { get; set; }

    public Player(string name)
    {
        this.name = name;
        this.money = 500;
        Equipment.Add("pistol", 1);
        Equipment.Add("shotgun", 0);
        Equipment.Add("smg", 0);
        Equipment.Add("rifle", 0);
        Equipment.Add("jump", 0);
        Equipment.Add("dash", 0);
        Equipment.Add("armour", 0);
        Equipment.Add("accuracy", 0);
        Equipment.Add("money", 150);

        this.weapon_1 = string.Format("{0}_Pistol", name);
    }
}