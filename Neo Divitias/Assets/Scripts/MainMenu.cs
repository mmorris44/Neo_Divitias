using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public void NewGame(){
        GameState.game_level = 1;
        GameState.player_one = new Player("1");
        GameState.player_two = new Player("2");
        GameState.SetPrefs();

        LoadShop();
    }

    public void StartNextLevel(){
        GameState.SetPrefs();
        SceneManager.LoadScene(string.Format("Level {0}", GameState.game_level));
    }

    public void LoadShop()
    {
        GameState.GetPrefs();
        SceneManager.LoadScene("Shop");
    }
    
    // This will be done by Matt
    public void FinishLevel(){
        GameState.game_level++;
        GameState.SetPrefs();
        LoadShop();
    }

    public void QuitGame(){
        GameState.SetPrefs();
        Debug.Log("Quitting!");
        Application.Quit();
    }

    public void UpgradeItem(string item){
        // This is vom, change it
        //if (player == 1){
            Debug.Log("Upgrade item");
            Debug.Log(item);
            Debug.Log(GameState.player_one.Equipment[item.ToLower()]);
            GameState.player_one.Equipment[item.ToLower()]++;
            Debug.Log(GameState.player_one.Equipment[item.ToLower()]);
       // }
    }

    public void ReturnToMain(){
        GameState.SetPrefs();
        SceneManager.LoadScene("Main");
    }
}
