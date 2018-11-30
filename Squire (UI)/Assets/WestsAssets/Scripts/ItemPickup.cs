using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    public bool pickedUp = false;

    //Once the player enters this area, the pickedUp boolean will turn true, indicating that the item has been picked up.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pickedUp = true;
        }
    }
}
