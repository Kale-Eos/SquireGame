using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    AudioManager audioManager;

    bool gameEnded = false;

    public float delay = 1f;

    public GameObject GameOverUI;

	void Start ()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

	public void EndGame()
    {
        if (gameEnded == false)                 // checks if game ended
        {
            gameEnded = true;                   // condition is true
            Invoke("Retry", delay);
            
            // trying to activate GameOverUI gameobject, but i fucked up somewhere
            //Invoke("GameOverUI", delay);        // waits 1 sec then calls UI
            //if (GameOverUI == false)
            //{
            //    GameOverUI.SetActive(true);
            //}
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        audioManager.PlaySound("Return2Game_UI");
    }
}