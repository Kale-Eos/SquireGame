using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]                                        // instantiates field
    string hoverOverSound = "ButtonHover";                  // instantiates Hover Over Sound
    [SerializeField]                                        // instantiates field
    string pressButtonSound = "ButtonPress";                // instantiates Press Button Sound

    AudioManager audioManager;

    public Animator animator;

    void Start()
    {
        audioManager = AudioManager.instance;               // instantiates AudioManager
        if (audioManager == null)
        {
            Debug.LogError("No AudioManager Found");
        }
    }

    public void OnMouseOver()
    {
        audioManager.PlaySound(hoverOverSound);             // all buttons makes a sound when hovering
    }

    public void OnMouseDown()
    {
        audioManager.PlaySound(pressButtonSound);           // all buttons makes a sound when pressed
    }


    public void InGameResume()
    {
        audioManager.PlaySound("Return2Game_UI");

    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);       // loads onto the tutorial scene
        audioManager.PlaySound("Tutorial_BGM");                                     // Plays Tutorial_BGM
        audioManager.StopSound("Music");                                            // Stops main menu music
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);       // loads onto the Level 1 scene
        audioManager.PlaySound("Level1_BGM");                                       // Plays Level1_BGM
        audioManager.StopSound("Music");                                            // Stops main menu music
    }

    //    public void PlayLevel2()
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);       // loads onto the Level 2 scene
    //        audioManager.PlaySound("Level2_BGM");                                       // Plays Level2_BGM
    //        audioManager.StopSound("Music");                                            // Stops main menu music
    //    }

    public void PlayCredits()
    {
        SceneManager.LoadScene("Credits Scene");    // loads onto the Credits scene
        audioManager.StopSound("Music");            // Stops main menu music
        audioManager.StopSound("Tutorial_BGM");     // Stops tutorial music
        audioManager.StopSound("Level1_BGM");       // Stops level 1 music
    }

    public void CreditsTransition()
    {
        audioManager.StopSound("Music");            // Stops main menu music
        audioManager.StopSound("Tutorial_BGM");     // Stops tutorial music
        audioManager.StopSound("Level1_BGM");       // Stops level 1 music
        audioManager.PlaySound("Credits_BGM");      // Plays Credits_BGM
    }


    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Title Scene");      // Reverses the the scene change to go back to Title Scene
        audioManager.StopSound("Tutorial_BGM");     // Stop Tutorial Music
        audioManager.StopSound("Level1_BGM");       // Stops level 1 music
        audioManager.PlaySound("Music");            // Restarts main menu music
    }

    public void CreditsToMainMenu()
    {
        //     animation.Play(Credits.clip.name);
        //     yield WaitForSeconds(Credits.clip.length + 0);
        //     Application.LoadLevel("Credits");

        SceneManager.LoadScene("Title Scene");       // Reverses the the scene change to go back to Title Scene
        audioManager.StopSound("Credits_BGM");       // Stop playing Credits_BGM
        audioManager.PlaySound("Music");             // Restarts main menu music
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");     // types out ~Quitting Game~
        Application.Quit();             // and quits game
    }
}
