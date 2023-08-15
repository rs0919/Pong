using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private AudioSource button_sfx;

    private bool isPaused = false;
    private string startScene = "StartScreen";

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // pause/resume game if esc is pressed
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }

    }


    public void Pause()
    {
        button_sfx.Play();

        Time.timeScale = 0;
        isPaused = true;
        pauseMenu.SetActive(isPaused); // display pause menu
    }

    public void Unpause()
    {
        button_sfx.Play();

        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(isPaused);
    }

    public void QuitGame()
    {
        // go back to main menu
        SceneManager.LoadScene(startScene);
    }

}
