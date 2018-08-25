using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState{

    public static int game_level;
    public static Player player_one;
    public static Player player_two;

    // Get all player prefs
    public static void GetPrefs () {
        game_level = PlayerPrefs.GetInt("game_level");

        player_one.name = PlayerPrefs.GetString("1_name");
        player_one.Equipment["pistol"] = PlayerPrefs.GetInt("1_pistol");
        player_one.Equipment["shotgun"] = PlayerPrefs.GetInt("1_shotgun");
        player_one.Equipment["smg"] = PlayerPrefs.GetInt("1_smg");
        player_one.Equipment["rifle"] = PlayerPrefs.GetInt("1_rifle");
        player_one.Equipment["jump"] = PlayerPrefs.GetInt("1_jump");
        player_one.Equipment["dash"] = PlayerPrefs.GetInt("1_dash");
        player_one.Equipment["armour"] = PlayerPrefs.GetInt("1_armour");
        player_one.Equipment["accuracy"] = PlayerPrefs.GetInt("1_accuracy");

        player_one.name = PlayerPrefs.GetString("2_name");
        player_two.Equipment["pistol"] = PlayerPrefs.GetInt("2_pistol");
        player_two.Equipment["shotgun"] = PlayerPrefs.GetInt("2_shotgun");
        player_two.Equipment["smg"] = PlayerPrefs.GetInt("2_smg");
        player_two.Equipment["rifle"] = PlayerPrefs.GetInt("2_rifle");
        player_two.Equipment["jump"] = PlayerPrefs.GetInt("2_jump");
        player_two.Equipment["dash"] = PlayerPrefs.GetInt("2_dash");
        player_two.Equipment["armour"] = PlayerPrefs.GetInt("2_armour");
        player_two.Equipment["accuracy"] = PlayerPrefs.GetInt("2_accuracy");
    }

    // Set player prefs
    public static void SetPrefs() {
        PlayerPrefs.SetInt("game_level", game_level);

        PlayerPrefs.SetString("1_name", player_one.name);
        PlayerPrefs.SetInt("1_pistol", player_one.Equipment["pistol"]);
        PlayerPrefs.SetInt("1_shotgun", player_one.Equipment["shotgun"]);
        PlayerPrefs.SetInt("1_smg", player_one.Equipment["smg"]);
        PlayerPrefs.SetInt("1_rifle", player_one.Equipment["rifle"]);
        PlayerPrefs.SetInt("1_jump", player_one.Equipment["jump"]);
        PlayerPrefs.SetInt("1_dash", player_one.Equipment["dash"]);
        PlayerPrefs.SetInt("1_armour", player_one.Equipment["armour"]);
        PlayerPrefs.SetInt("1_accuracy", player_one.Equipment["accuracy"]);

        PlayerPrefs.SetString("2_name", player_two.name);
        PlayerPrefs.SetInt("2_pistol", player_two.Equipment["pistol"]);
        PlayerPrefs.SetInt("2_shotgun", player_two.Equipment["shotgun"]);
        PlayerPrefs.SetInt("2_smg", player_two.Equipment["smg"]);
        PlayerPrefs.SetInt("2_rifle", player_two.Equipment["rifle"]);
        PlayerPrefs.SetInt("2_jump", player_two.Equipment["jump"]);
        PlayerPrefs.SetInt("2_dash", player_two.Equipment["dash"]);
        PlayerPrefs.SetInt("2_armour", player_two.Equipment["armour"]);
        PlayerPrefs.SetInt("2_accuracy", player_two.Equipment["accuracy"]);
    }
}
