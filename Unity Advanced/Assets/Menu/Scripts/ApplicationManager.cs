using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {

    private void Start()
    {
        Cursor.visible = true;
    }

    public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

    public void PlayGame ()
    {
        SceneManager.LoadScene("Game");
    }

    public void PlayTutorial ()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
