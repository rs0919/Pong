using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverLogic : MonoBehaviour
{

    private string playerOneScore; // bottom player
    private string playerTwoScore; // top player

    private string resultsScreen = "ResultsScreen";

    void Update()
    {
        playerOneScore = GameObject.Find("PlayerOneScore").GetComponent<Text>().text; // change
        playerTwoScore = GameObject.Find("PlayerTwoScore").GetComponent<Text>().text;

        if (playerOneScore == "7")
        {
            PlayerPrefs.SetInt("PlayerOneWins", 1);
            SceneManager.LoadScene(resultsScreen); // add delay
        } 
        else if (playerTwoScore == "7")
        {
            PlayerPrefs.SetInt("PlayerOneWins", 0);
            SceneManager.LoadScene(resultsScreen); // add delay
        }


    }
}
