using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    AudioManager audioManager;

    private LevelChanger2 levelChanger2;

    public static bool PauseGame = false;
    public GameObject pauseUI;

    void Start()
    {
        levelChanger2 = GameObject.Find("LevelChanger").GetComponent<LevelChanger2>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();                       // resumes game
            }

            else
            {
                Pause();                        // pauses game
            }
        }         
    }

    public void Resume()
    {
        pauseUI.SetActive(false);               // unpauses game
        Time.timeScale = 1f;                    // time is unfrozen
        PauseGame = false;
    }

    public void Pause()
    {
        pauseUI.SetActive(true);                // pauses game
        Time.timeScale = 0f;                    // time is frozen
        PauseGame = true;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;                        // time is frozen
        levelChanger2.FadeToLevel(0);               // returns back to main menu
        audioManager.StopSound("Tutorial_BGM");     // Stop Tutorial Music
        audioManager.PlaySound("Music");            // Restarts main menu music
    }

    public void QuitGame()
    {
        Application.Quit();                         // quits game
    }
}