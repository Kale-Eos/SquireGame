using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSceneTransition : MonoBehaviour
{
    private PlayerControllerV3 PCV3Script;
    private ItemPickup IPScript;
    public GameObject openDoor;
    public GameObject openDoorTeleport;

    public GameObject dialogueText5;
    private bool textEnabled;

    // Use this for initialization
    void Start()
    {
        //References the PlayerControllerV3 Script on the PlayerTest Object so that components from PlayerTest can be used.
        PCV3Script = GameObject.Find("Squire").GetComponent<PlayerControllerV3>();

        //References the ItemPickup script so that I can use the boolean to check if the item has been collected.
        IPScript = GameObject.Find("DialogueSpot3/ItemCollect").GetComponent<ItemPickup>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is next to the door, presses the interaction key, and the item has been picked up, then the closed door gameobject will be disabled and the open door gameobject will be enabled.
        if (Input.GetButtonDown("Interaction") && PCV3Script.isNextToInteractable == true && IPScript.pickedUp == true|| Input.GetButtonDown("Interaction") && PCV3Script.isNextToInteractable2 == true && IPScript.pickedUp == true)
        {
            openDoor.SetActive(true);
            openDoorTeleport.SetActive(true);
            //openDoor.SceneTransition.SetActive(true);
            gameObject.SetActive(false);
        }
        //If the player is next to the door, presses the interaction key, but has not yet collected the item, then Squire will say a line.
        else if (Input.GetButtonDown("Interaction") && PCV3Script.isNextToInteractable == true && IPScript.pickedUp != true && textEnabled != true|| Input.GetButtonDown("Interaction") && PCV3Script.isNextToInteractable2 == true && IPScript.pickedUp != true && textEnabled != true)
        {
            dialogueText5.gameObject.SetActive(true);
            textEnabled = true;
            StartCoroutine(TextDuration());
        }


        //if (textEnabled == true)
        //{

            //StartCoroutine(TextDuration());
        //}
    }

    IEnumerator TextDuration()
    {
        yield return new WaitForSeconds(4.0f);
        dialogueText5.gameObject.SetActive(false);
        textEnabled = false;
    }

}
