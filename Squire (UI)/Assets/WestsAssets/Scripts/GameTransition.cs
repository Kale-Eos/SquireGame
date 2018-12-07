using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameTransition : MonoBehaviour
{
    AudioManager audioManager;
	private LevelChanger2 levelChanger2;
    private PlayerControllerV3 PCV3;
    public GameObject player;
    private Animator anim;

	void Start()
    {
        //Access multiple different scripts and components here
        PCV3 = GameObject.FindWithTag("Player").GetComponent<PlayerControllerV3>();
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        levelChanger2 = GameObject.Find("LevelChanger").GetComponent<LevelChanger2> ();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}


    // Scene transition when player enters collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
			levelChanger2.FadeToLevel(2);
            audioManager.StopSound("Music");
            audioManager.StopSound("Tutorial_BGM");
            audioManager.PlaySound("Credits_BGM");
            DisablePCV3();
            //Invoke("StopAnimation", 0.1f);
        }
    }
    //private void StopAnimation()
    //{
    //    EnablePCV3();
    //    PCV3.movementSpeed = 0;
    //    Invoke("DisablePCV3", 0.01f);
    //    Invoke("Idle", 0.02f);
    //}

    private void EnablePCV3()
    {
        player.GetComponent<PlayerControllerV3>().enabled = true;
    }

    private void DisablePCV3()
    {
        player.GetComponent<PlayerControllerV3>().enabled = false;
    }

    //private void IdleAnim()
    //{
    //    anim.Play("Idle");
    //}
}