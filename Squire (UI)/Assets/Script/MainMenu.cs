using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayTutorial ()
    {
        // loads onto the tutorial scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayLevel1()
    {
        // loads onto the Level 1 scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void PlayLevel2()
    {
        // loads onto the Level 2 scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void BackToMainMenu()
    {
        // Reverses the the scene change to go back to Title Scene
        SceneManager.LoadScene("Title Scene");
    }

    public void QuitGame ()
    {
        // types out Quitting Game on Console and Quits game
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
