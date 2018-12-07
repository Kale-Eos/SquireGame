using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    AudioManager audioManager;

    private PlayerControllerV3 PCV3;

    bool gameEnded = false;

    public float delay = 1f;
    private float delay2 = 0.2f;

    public GameObject player;

    public GameObject GameOverUI;

    Animation anim;

	void Start ()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        PCV3 = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerV3>();

    }

	public void EndGame()
    {

        if (gameEnded == false)                 // checks if game ended
        {
            gameEnded = true;
            Invoke("ActivateUI", delay);        // Waits 1 second and then turns on the GameOver UI.
            FreezePlayer();                     // Freezes the player.
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        audioManager.PlaySound("Return2Game_UI");
        audioManager.StopSound("Tutorial_BGM");
        audioManager.PlaySound("Tutorial_BGM");
    }

    public void ActivateUI()
    {
        GameOverUI.SetActive(true);
    }

    public void FreezePlayer()
    {
        PCV3.movementSpeed = 0;
        Invoke("PlayerControllerOff", delay2);   //Waits 0.1 seconds and then disables PlayerControllerV3. It's coded this way because otherwise the player would continue sliding.
    }

    public void PlayerControllerOff()
    {
        player.GetComponent<PlayerControllerV3>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
    }

}