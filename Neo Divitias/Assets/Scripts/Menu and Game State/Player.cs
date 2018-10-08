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
        this.money = 500;
        Equipment.Add("pistol", 1);
        Equipment.Add("shotgun", 0);
        Equipment.Add("smg", 0);
        Equipment.Add("rifle", 0);
        Equipment.Add("jump", 1);
        Equipment.Add("dash", 0);
        Equipment.Add("armour", 0);
        Equipment.Add("accuracy", 0);
        Equipment.Add("money", 150);

        this.primary = string.Format("{0}_pistol", name);
        this.secondary = string.Format("{0}_pistol", name);
        this.movement = string.Format("{0}_jump", name);
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
            primary = string.Format("{0}_pistol", name);
        }
        else if (secondary == weapon)
        {
            secondary = string.Format("{0}_pistol", name);
        }
    }

    public void selectMovement(string att)
    {
        movement = att;
    }

    public void deselectMovement()
    {
        movement = string.Format("{0}_jump", name);
    }

    public void weaponDebug()
    {
        Debug.Log(string.Format("Primary: {0}", primary));
        Debug.Log(string.Format("Secondary: {0}", secondary));
    }
}