using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    bool player1;
    bool player2;

    public void NewGame(){
        GameState.game_level = 1;
        GameState.player_one = new Player("1");
        GameState.player_two = new Player("2");
        GameState.SetPrefs();

        LoadShop();
    }

    public void StartNextLevel(){
        
       /* if (p == 1)
        {
            player1 = true;
        }else if(p == 2)
        {
            player2 = true;
        }
        if (player1 && player2)
        {*/
        
            GameState.SetPrefs();
            SceneManager.LoadScene(string.Format("Cutscene {0}", GameState.game_level));
        //}
       
    }

    public void PlayTutorial()
    {
        GameState.game_level = 1;
        GameState.player_one = new Player("1");
        GameState.player_two = new Player("2");
        GameState.player_one.Equipment["dash"] = 3;
        GameState.player_one.movement = "dash";
        GameState.player_two.Equipment["dash"] = 3;
        GameState.player_two.movement = "dash";
        //GameState.SetPrefs();
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadShop(){
        player1 = false;
        player2 = false;
        // This should ideally be somewhere that only gets called once on setup.
        GameState.BaseSetup();
        try
        {
            GameState.GetPrefs();
        }
        catch (System.Exception e)
        {
            NewGame();
        }
        //GameState.GetPrefs();
        SceneManager.LoadScene("Shop");
    }
    
    public void FinishLevel(){
        if (SceneManager.GetActiveScene().name.Equals("Tutorial"))
        {
            ReturnToMain();
        }
        else
        {
            GameState.game_level++;
            GameState.SetPrefs();
            if (GameState.game_level > 4)
                SceneManager.LoadScene("Cutscene 5");
            else
                LoadShop();
        }
    }

    public void QuitGame(){
        GameState.SetPrefs();
        Application.Quit();
    }

    public void ReturnToMain(){
        // This is a bit hacky but it allows us to go back to main menu from settings and controls before a game has been started.
        // Maybe fix if we have extra time at the end
        Debug.Log(SceneManager.GetActiveScene().name);
        if (!SceneManager.GetActiveScene().name.Equals("Tutorial"))
        {
            try
            {
                GameState.SetPrefs();
            }
            catch (System.Exception e)
            {
                Debug.Log("Prefs couldnt be set because GameState hasnt been instantiated.");
            }
        }
        else
        {
            //return to main from tutorial
        }
        SceneManager.LoadScene("Main");
    }
}
