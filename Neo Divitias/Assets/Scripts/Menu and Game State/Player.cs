using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player
{
    public Dictionary<string, int> Equipment = new Dictionary<string, int>();

    public string name { get; set; }
    public string primary { get; set; }
    public string secondary { get; set; }
    public int money { get; set; }

    public string movement { get; set; }

    public Player(string name)
    {
        this.name = name;
        this.money = 30;
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

    public void selectWeapon(string weapon){
        primary = secondary;
        secondary = weapon;
    }

    public void deselectWeapon(string weapon)
    {
        // If they choose to deselect a weapon. Default that weapon to a pistol.
        if (primary == weapon)
        {
            primary = string.Format("pistol", name);
        }
        else if (secondary == weapon)
        {
            secondary = string.Format("pistol", name);
        }
    }

    public void selectMovement(string att)
    {
        movement = att;
    }

    public void deselectMovement()
    {
        movement = string.Format("jump", name);
    }

    public void playerDebug()
    {
        Debug.Log(string.Format("Player: {0} : P - {1}({2}) S - {3}({4}) M - {5}({6}) A - {7}", name, primary, Equipment[primary], secondary, Equipment[secondary], movement, Equipment[movement], Equipment["armour"]));
    }
}