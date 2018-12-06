using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    private PlayerControllerV3 PCV3Script;
    private DoorSceneTransition DSTScript;

    [Space]
    [Header("Dialogue Settings:")]
    public float dialogueDuration;
    public GameObject dialogueText;
    public GameObject textBox;

    [Space]
    [Header("Other:")]
    public GameObject player;

    public GameObject screenDim;

    private float movementSpeedReset;

    Animation anim;

    void Start()
    {
        //References the PlayerControllerV3 Script by finding the GameObject with the "Player" tag so that components from the Player GameObject can be used.
        PCV3Script = GameObject.FindWithTag("Player").GetComponent<PlayerControllerV3>();

        //References the DoorSceneTransition Script by finding the ClosedDoor GameObject.
        DSTScript = GameObject.Find("ClosedDoor").GetComponent<DoorSceneTransition>();

        //Used to later reset the movementSpeed value back to whatever it was previously set to.
        movementSpeedReset = PCV3Script.movementSpeed;
    }


    //When the player comes in contact with the invisible sprite, he'll stop moving and a dialogue will pop up for a set amount of time.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DSTScript.EndTextEarly();                    //If there's dialogue from the Squire saying "I can't leave without the Knight's greaves." currently playing, it'll be ended early.
            PCV3Script.movementSpeed = 0.0f;
            if (PCV3Script.movementSpeed == 0.0f)
            {
                StartCoroutine(Wait());
            }
            dialogueText.gameObject.SetActive(true);
            textBox.gameObject.SetActive(true);
            screenDim.gameObject.SetActive(true);
            StartCoroutine(ResetTime());
        }
    }
    //After a certain amount of time the player will be able to move and the dialogue will disappear.
    IEnumerator ResetTime()
    {

        yield return new WaitForSeconds(dialogueDuration);
        PCV3Script.movementSpeed = movementSpeedReset;
        player.GetComponent<PlayerControllerV3>().enabled = true;

        dialogueText.gameObject.SetActive(false);
        textBox.gameObject.SetActive(false);
        gameObject.SetActive(false);

        screenDim.gameObject.SetActive(false);

    }

    //This function will wait an extremely short amount of time before disabling the PlayerController script, otherwise he'd keep moving.
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<PlayerControllerV3>().enabled = false;
    }
}
