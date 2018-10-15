using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField]                                        // instantiates field
    string hoverOverSound = "ButtonHover";                  // instantiates Hover Over Sound
    [SerializeField]                                        // instantiates field
    string pressButtonSound = "ButtonPress";                // instantiates Press Button Sound

    AudioManager audioManager;

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
        audioManager.PlaySound(hoverOverSound);             // all buttons makes a sound when hovering
    }

    public void PlayTutorial ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);       // loads onto the tutorial scene
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);       // loads onto the Level 1 scene
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);       // loads onto the Level 2 scene
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Title Scene");      // Reverses the the scene change to go back to Title Scene
    }

    public void QuitGame ()
    {
        Debug.Log("Quitting Game");     // types out ~Quitting Game~
        Application.Quit();             // and quits game
    }

}
