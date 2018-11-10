using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameTransition : MonoBehaviour
{
    AudioManager audioManager;

    // Happens when something enters the trigger space.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //gameObject.SetActive(false);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene("Credits Scene");
        }
    }
}