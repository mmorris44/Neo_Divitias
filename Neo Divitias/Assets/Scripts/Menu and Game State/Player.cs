using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Stores data about player equipment, money and stats
public class Player
{
    // Stores levels of equipment
    public Dictionary<string, int> Equipment = new Dictionary<string, int>();

    public string name { get; set; }
    public string primary { get; set; }
    public string secondary { get; set; }
    public int money { get; set; }
    public int kills { get; set; }

    public string movement { get; set; }

    // Set equipment and money to default
    public Player(string name)
    {
        this.name = name;
        this.money = 30;
        this.kills = 0;
        Equipment.Add("pistol", 1);
        Equipment.Add("shotgun", 0);
        Equipment.Add("smg", 0);
        Equipment.Add("rifle", 0);
        Equipment.Add("jump", 1);
        Equipment.Add("dash", 0);
        Equipment.Add("armour", 0);
        Equipment.Add("money", money);

        this.primary = string.Format("pistol", name);
        this.secondary = string.Format("pistol", name);
        this.movement = string.Format("jump", name);
    }

    // Select the weapon with the given name
    public void selectWeapon(string weapon){
        primary = secondary;
        secondary = weapon;
    }

    // Deselect the weapon with the given name
    public void deselectWeapon(string weapon)
    {
        // If they choose to deselect a weapon, default that weapon to a pistol.
        if (primary.Equals(weapon))
        {
            primary = string.Format("pistol", name);
        }
        else if (secondary.Equals(weapon))
        {
            secondary = string.Format("pistol", name);
        }
    }

    // Choose movement ability
    public void selectMovement(string att)
    {
        movement = att;
    }

    // Deselect movement ability and set it to jump by default
    public void deselectMovement()
    {
        movement = string.Format("jump", name);
    }

    // Used to see current equipment for player
    public void playerDebug()
    {
        Debug.Log(string.Format("Player: {0} : P - {1}({2}) S - {3}({4}) M - {5}({6}) A - {7}", name, primary, Equipment[primary], secondary, Equipment[secondary], movement, Equipment[movement], Equipment["armour"]));
    }
}