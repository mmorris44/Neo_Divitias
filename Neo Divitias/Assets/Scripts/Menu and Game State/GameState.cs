using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState{

    public static int game_level;
    public static Player player_one;
    public static Player player_two;
    public static int time_1 = -1;
    public static int time_2 = -1;
    public static int time_3 = -1;
    public static int winner = 0;

    public static Color offColour = new Color(30f/255,30f/255,150f/255,0.2f);
    public static Color offSelectColour = new Color(30f/255, 30f/255, 150f/255, 1f);

    public static Color onColour = new Color(0, 255, 0, 0.3f);
    public static Color onSelectColour = new Color(0, 255, 0, 1f);

    public static Color uninteractableColour = new Color(220,220,220, 0.6f);

    // Set weapon prices once. We should maybe store these in a file somewhere and just do a single read in. But this is fine for now.
    // We could store a dict with base and scale factors example {"pistol": [100, 0, 1, 3]}. pistol_1 = 100*0, pistol_2 = 100*1 etc.
    public static void BaseSetup() {
        PlayerPrefs.SetInt("pistol_1", 0);
        PlayerPrefs.SetInt("pistol_2", 60);
        PlayerPrefs.SetInt("pistol_3", 90);

        PlayerPrefs.SetInt("shotgun_1", 20);
        PlayerPrefs.SetInt("shotgun_2", 80);
        PlayerPrefs.SetInt("shotgun_3", 130);

        PlayerPrefs.SetInt("smg_1", 20);
        PlayerPrefs.SetInt("smg_2", 80);
        PlayerPrefs.SetInt("smg_3", 130);

        PlayerPrefs.SetInt("rifle_1", 20);
        PlayerPrefs.SetInt("rifle_2", 80);
        PlayerPrefs.SetInt("rifle_3", 130);

        PlayerPrefs.SetInt("dash_1", 30);
        PlayerPrefs.SetInt("dash_2", 90);
        PlayerPrefs.SetInt("dash_3", 150);

        PlayerPrefs.SetInt("jump_1", 0);
        PlayerPrefs.SetInt("jump_2", 90);
        PlayerPrefs.SetInt("jump_3", 150);

        PlayerPrefs.SetInt("armour_1", 50);
        PlayerPrefs.SetInt("armour_2", 100);
        PlayerPrefs.SetInt("armour_3", 150);
    }

    // Get all player prefs
    public static void GetPrefs () {
        game_level = PlayerPrefs.GetInt("game_level");
        time_1 = PlayerPrefs.GetInt("time_1");
        time_2 = PlayerPrefs.GetInt("time_2");
        time_3 = PlayerPrefs.GetInt("time_3");
        winner = PlayerPrefs.GetInt("winner");

        player_one.name = PlayerPrefs.GetString("1_name");
        player_one.money = PlayerPrefs.GetInt("1_money");
        player_one.kills = PlayerPrefs.GetInt("1_kills");
        player_one.primary = PlayerPrefs.GetString("1_primary");
        player_one.secondary = PlayerPrefs.GetString("1_secondary");
        player_one.Equipment["pistol"] = PlayerPrefs.GetInt("1_pistol");
        player_one.Equipment["shotgun"] = PlayerPrefs.GetInt("1_shotgun");
        player_one.Equipment["smg"] = PlayerPrefs.GetInt("1_smg");
        player_one.Equipment["rifle"] = PlayerPrefs.GetInt("1_rifle");
        player_one.Equipment["jump"] = PlayerPrefs.GetInt("1_jump");
        player_one.Equipment["dash"] = PlayerPrefs.GetInt("1_dash");
        player_one.Equipment["armour"] = PlayerPrefs.GetInt("1_armour");

        player_two.name = PlayerPrefs.GetString("2_name");
        player_two.money = PlayerPrefs.GetInt("2_money");
        player_two.kills = PlayerPrefs.GetInt("2_kills");
        player_two.primary = PlayerPrefs.GetString("2_primary");
        player_two.secondary = PlayerPrefs.GetString("2_secondary");
        player_two.Equipment["pistol"] = PlayerPrefs.GetInt("2_pistol");
        player_two.Equipment["shotgun"] = PlayerPrefs.GetInt("2_shotgun");
        player_two.Equipment["smg"] = PlayerPrefs.GetInt("2_smg");
        player_two.Equipment["rifle"] = PlayerPrefs.GetInt("2_rifle");
        player_two.Equipment["jump"] = PlayerPrefs.GetInt("2_jump");
        player_two.Equipment["dash"] = PlayerPrefs.GetInt("2_dash");
        player_two.Equipment["armour"] = PlayerPrefs.GetInt("2_armour");
    }

    // Set player prefs
    public static void SetPrefs() {
        Debug.Log("SET PREFS");
        PlayerPrefs.SetInt("game_level", game_level);
        PlayerPrefs.SetInt("time_1", time_1);
        PlayerPrefs.SetInt("time_2", time_2);
        PlayerPrefs.SetInt("time_3", time_3);
        PlayerPrefs.SetInt("winner", winner);

        PlayerPrefs.SetString("1_name", player_one.name);
        PlayerPrefs.SetInt("1_money", player_one.money);
        PlayerPrefs.SetInt("1_kill", player_one.kills);
        PlayerPrefs.SetString("1_primary", player_one.primary);
        PlayerPrefs.SetString("1_secondary", player_one.secondary);
        PlayerPrefs.SetInt("1_pistol", player_one.Equipment["pistol"]);
        PlayerPrefs.SetInt("1_shotgun", player_one.Equipment["shotgun"]);
        PlayerPrefs.SetInt("1_smg", player_one.Equipment["smg"]);
        PlayerPrefs.SetInt("1_rifle", player_one.Equipment["rifle"]);
        PlayerPrefs.SetInt("1_jump", player_one.Equipment["jump"]);
        PlayerPrefs.SetInt("1_dash", player_one.Equipment["dash"]);
        PlayerPrefs.SetInt("1_armour", player_one.Equipment["armour"]);

        PlayerPrefs.SetString("2_name", player_two.name);
        PlayerPrefs.SetInt("2_money", player_two.money);
        PlayerPrefs.SetInt("2_kill", player_two.kills);
        PlayerPrefs.SetString("2_primary", player_two.primary);
        PlayerPrefs.SetString("2_secondary", player_two.secondary);
        PlayerPrefs.SetInt("2_pistol", player_two.Equipment["pistol"]);
        PlayerPrefs.SetInt("2_shotgun", player_two.Equipment["shotgun"]);
        PlayerPrefs.SetInt("2_smg", player_two.Equipment["smg"]);
        PlayerPrefs.SetInt("2_rifle", player_two.Equipment["rifle"]);
        PlayerPrefs.SetInt("2_jump", player_two.Equipment["jump"]);
        PlayerPrefs.SetInt("2_dash", player_two.Equipment["dash"]);
        PlayerPrefs.SetInt("2_armour", player_two.Equipment["armour"]);
    }
}
