using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPlayerController : MonoBehaviour
{
    // This script controls which type of movement that the top paddle uses:
    // either real person, normal ai, or impossible ai


    private bool twoPlayerGame;
    private bool normalAi;
    
    private PlayerTwoMovement playerTwo;
    private AiMovement aiMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("twoPlayer") == 1)
        {
            twoPlayerGame = true;
        } 
        else
        {
            twoPlayerGame = false;

        }

        if (PlayerPrefs.GetInt("normalMode") == 1)
        {
            normalAi = true;
        }
        else
        {
            normalAi = false;
        }
        
        playerTwo = this.GetComponent<PlayerTwoMovement>();
        aiMovement = this.GetComponent<AiMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (twoPlayerGame) // 2 real players
        {
            playerTwo.enabled = true;
            aiMovement.enabled = false;
        }
        else // 1 player v AI
        {
            playerTwo.enabled = false;
            aiMovement.enabled = true;
            
            if (normalAi)
            {
                aiMovement.impossibleMode = false;
            }
            else
            {
                aiMovement.impossibleMode = true;
            }
        
        }
    }
}
