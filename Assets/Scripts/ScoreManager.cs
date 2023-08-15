using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text playerOneText;
    public Text playerTwoText;

    int playerOneScore = 0;
    int playerTwoScore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerOneText.text = playerOneScore.ToString();
        playerTwoText.text = playerTwoScore.ToString();
    }

    public void IncreasePlayerOneScore()
    {
        playerOneScore += 1;
        playerOneText.text = playerOneScore.ToString();

    }

    public void IncreasePlayerTwoScore()
    {
        playerTwoScore += 1;
        playerTwoText.text = playerTwoScore.ToString();
    }

    public int GetPlayerOneScore()
    {
        return playerOneScore;
    }

    public int GetPlayerTwoScore()
    {
        return playerTwoScore;
    }


}
