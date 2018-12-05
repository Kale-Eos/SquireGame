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
	}


    // Scene transition when player enters collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
			levelChanger2.FadeToLevel(4);
			player.GetComponent<PlayerControllerV3>().enabled = false;
        }
    }
}