using UnityEngine;
using UnityEngine.SceneManagement;

// Stores logic for moving to/from the main menu and transitioning between levels
public class MainMenu : MonoBehaviour {
    bool player1;
    bool player2;

    private void Update()
    {
        // Check for transition
        if (Input.GetButtonDown("Back") && SceneManager.GetActiveScene().name == "Shop")
        {
            ReturnToMain();
        }
    }

    public void NewGame(){
        // Set all variables to initial values
        GameState.game_level = 1;
        GameState.player_one = new Player("1");
        GameState.player_two = new Player("2");
        GameState.SetPrefs();

        LoadShop();
    }

    // Move to next level
    public void StartNextLevel(){
        GameState.SetPrefs();
        SceneManager.LoadScene(string.Format("Cutscene {0}", GameState.game_level));
    }

    // Setup gamestate info for tutorial level
    public void PlayTutorial()
    {
        GameState.game_level = 1;
        GameState.player_one = new Player("1");
        GameState.player_two = new Player("2");
        GameState.player_one.Equipment["dash"] = 3;
        GameState.player_one.movement = "dash";
        GameState.player_two.Equipment["dash"] = 3;
        GameState.player_two.movement = "dash";
        SceneManager.LoadScene("Tutorial");
    }

    // Setup gamestate for shop info
    public void LoadShop(){
        player1 = false;
        player2 = false;

        GameState.BaseSetup();
        try
        {
            GameState.GetPrefs();
        }
        // Catch exception if continue if pressed without a game currently existing
        catch (System.Exception e)
        {
            // Just make a new game
            NewGame();
        }

        SceneManager.LoadScene("Shop");
    }
    
    // Finish the level and move to next scene
    public void FinishLevel(){
        // Move back to main menu if on tutorial
        if (SceneManager.GetActiveScene().name.Equals("Tutorial"))
        {
            ReturnToMain();
        }
        else
        {
            // Move back to shop (or cutscene 5 if game has ended)
            GameState.game_level++;
            GameState.SetPrefs();
            if (GameState.game_level > 4)
                SceneManager.LoadScene("Cutscene 5");
            else
                LoadShop();
        }
    }

    // Save prefs and quit
    public void QuitGame(){
        GameState.SetPrefs();
        Application.Quit();
    }

    // Transition back to main menu
    public void ReturnToMain(){
        if (!SceneManager.GetActiveScene().name.Equals("Tutorial"))
        {
            // Save prefs if not coming from the tutorial
            try
            {
                GameState.SetPrefs();
            }
            catch (System.Exception e)
            {
                Debug.Log("Prefs couldnt be set because GameState hasn't been instantiated.");
            }
        }

        SceneManager.LoadScene("Main");
    }
}
