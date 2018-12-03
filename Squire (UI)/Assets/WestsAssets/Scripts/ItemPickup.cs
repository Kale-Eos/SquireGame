using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    public bool pickedUp = false;

    public GameObject dialogueSpot;

    //Once the player enters this area, the pickedUp boolean will turn true, indicating that the item has been picked up.
    //Entering the area will also enable the DialogueText4 GameObject, the dialogue seen before leaving the level.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pickedUp = true;
        }

        if (pickedUp == true)
        {
            dialogueSpot.gameObject.SetActive(true);
        }
        else
        {
            dialogueSpot.gameObject.SetActive(false);
        }
    }
}
