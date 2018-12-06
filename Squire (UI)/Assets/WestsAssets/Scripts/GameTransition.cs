using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameTransition : MonoBehaviour
{
    AudioManager audioManager;
	private LevelChanger2 levelChanger2;
	public GameObject player;

	void Start()
    {
		levelChanger2 = GameObject.Find("LevelChanger").GetComponent<LevelChanger2> ();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}


    // Scene transition when player enters collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
			levelChanger2.FadeToLevel(3);
            audioManager.StopSound("Music");
            audioManager.StopSound("Tutorial_BGM");
            audioManager.PlaySound("Credits_BGM");
			player.GetComponent<PlayerControllerV3>().enabled = false;
        }
    }
}