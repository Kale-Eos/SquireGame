using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempGoBack : MonoBehaviour {

    public void BackToMainMenu ()
    {
        // Reverses the the scene change to go back one scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
