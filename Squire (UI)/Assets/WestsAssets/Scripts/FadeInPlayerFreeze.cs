using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInPlayerFreeze : MonoBehaviour
{
    //This script's purpose is to freeze the player while the fade-in plays.
    public GameObject player;
    public float waitTime = 2.0f;
    private bool waitTimeOver = false;

    void Update ()
    {
        if (waitTimeOver == false)
        {
            player.GetComponent<PlayerControllerV3>().enabled = false;
            waitTime -= Time.deltaTime;
        }


        if (waitTime <= 0)
        {
            player.GetComponent<PlayerControllerV3>().enabled = true;
            waitTimeOver = true;
            gameObject.SetActive(false);
        }
    }
}
