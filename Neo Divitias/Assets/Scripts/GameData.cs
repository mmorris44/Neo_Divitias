using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData {
    public static int Level { get; set; }
    public static void IncrLevel(){
        Level++;
    }
}

public static class PlayerOne {
    public static int Weapon { get; set; }
    public static int Armour { get; set; }
    public static int Movement { get; set; }
    public static int Kills { get; set; }
}