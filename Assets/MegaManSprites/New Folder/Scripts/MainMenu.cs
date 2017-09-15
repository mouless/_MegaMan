using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void NewGame(string startGame)
    {
        //Application.LoadLevel(startGame);
        SceneManager.LoadScene(startGame);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
