using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //PlayerPrefs.SetFloat("currentlevel", 1);
    

	public void PlayGame(){
        PlayerPrefs.SetInt("next_level", 1);
		SceneManager.LoadScene ("Shop");
	}

    public void StartNextLevel()
    {
        // Get level from static script or persistent data and load the next level
        int next_level = PlayerPrefs.GetInt("next_level");
        SceneManager.LoadScene(string.Format("Level {0}", next_level));
    }

    public void QuitGame(){
        Debug.Log("Quitting!");
        Application.Quit();
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
