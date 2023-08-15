using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyController : MonoBehaviour
{

    private string mainGame = "MainGame";
    private string startScreen = "StartScreen";
    public void NormalMode()
    {
        PlayerPrefs.SetInt("normalMode", 1);
        SceneManager.LoadScene(mainGame);
    }

    public void ImpossibleMode()
    {
        PlayerPrefs.SetInt("normalMode", 0);
        SceneManager.LoadScene(mainGame);
    }

    public void BackToStart()
    {
        SceneManager.LoadScene(startScreen);
    }

}
