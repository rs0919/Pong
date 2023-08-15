using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsScreenController : MonoBehaviour
{

    private string mainGame = "MainGame";
    private string mainMenu = "StartScreen";

    private GameObject[] results;


    /* Screen needs to set the right result.
     * First check if it's 2 player or single player
     * Then check if top or bottom player won
     */

    private void Start()
    {
        results = GameObject.FindGameObjectsWithTag("Result");

        foreach(GameObject title in results)
        {
            title.SetActive(false);
        }

        GameObject resultTitle = PrintResult();
        resultTitle.SetActive(true);

    }


    private GameObject PrintResult()
    {
        if (PlayerPrefs.GetInt("twoPlayer") == 1)
        {
            // If 2 player game
            if (PlayerPrefs.GetInt("PlayerOneWins") == 1)
            {
                // Print Player One Wins
                return results[0];
            }
            else
            {
                // Print Player Two Wins
                return results[1];
            }

        }
        else
        {
            // Single Player game
            if (PlayerPrefs.GetInt("PlayerOneWins") == 1)
            {
                // Print You Win
                return results[2];
            }
            else
            {
                // Print You Lose
                return results[3];
            }
        }
    }



    // For Buttons to load different scenes.
    public void RestartGame()
    {
        SceneManager.LoadScene(mainGame);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }


}
