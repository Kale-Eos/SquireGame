using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSceneTransition : MonoBehaviour
{
    private PlayerControllerV3 PCV3Script;
    private ItemPickup IPScript;
    private AudioManager audioManager;
    public GameObject openDoor;
    public GameObject openDoorTeleport;

    // Use this for initialization
    void Start()
    {
        //References the PlayerControllerV3 Script on the PlayerTest Object so that components from PlayerTest can be used.
        PCV3Script = GameObject.Find("Squire").GetComponent<PlayerControllerV3>();

        //References the ItemPickup script so that I can use the boolean to check if the item has been collected.
        IPScript = GameObject.Find("ItemCollect").GetComponent<ItemPickup>();
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
        //If the player is next to the door, presses the interaction key, but has not yet collected the item, then the door will play a locked sound.
        else if (Input.GetButtonDown("Interaction") && PCV3Script.isNextToInteractable != true && IPScript.pickedUp == true || Input.GetButtonDown("Interaction") && PCV3Script.isNextToInteractable2 == true && IPScript.pickedUp != true)
        {
            Debug.Log("Locked");
            //audioManager.PlaySound(LockedSound);
        }
    }
}
