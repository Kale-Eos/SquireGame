using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameTransition : MonoBehaviour
{
    AudioManager audioManager;

    // Scene transition when player enters collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("Credits Scene");
        }
    }
}