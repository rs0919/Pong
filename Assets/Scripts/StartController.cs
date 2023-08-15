using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{

    private string difficultySelect = "DifficultySelectScreen";
    private string twoPlayerGame = "MainGame";

    public void DifficultySelect()
    {
        // 0 is false, 1 is true.
        PlayerPrefs.SetInt("twoPlayer", 0); 
        // use player prefs to store data across scenes
        SceneManager.LoadScene(difficultySelect);
    }

    public void TwoPlayerGame()
    {
        PlayerPrefs.SetInt("twoPlayer", 1);
        SceneManager.LoadScene(twoPlayerGame);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
