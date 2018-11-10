using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OneWayPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;

    private float waitTime;

    void Start()
    {
        //this effector variable gets the information from the PlatformEffector2D component. This allows us to change things around in the PlatformEffector2D component.
        effector = GetComponent<PlatformEffector2D>();

    }
    void Update()
    {
        //Resets the time it takes to hold down the button to fall through.
        if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.20f;
        }
        //If the player presses and holds the "S" or "DownArrow" keys for 0.20 seconds, the ResetTime() function will be called. See IEnumerator ResetTime() below.
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (waitTime <= 0)
            {
                StartCoroutine(ResetTime());

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    //IEnumerator function is created so we can use a time delay. When called, this function will set the platform's collider to 180 degrees so the player can fall through.
    //Then, after 0.4 seconds, the platform's collider will reset to 0 degrees so the player can't fall through the platforms anymore unless they hold "S" or "DownArrow" once more.
    IEnumerator ResetTime()
    {
        effector.rotationalOffset = 180f;
        waitTime = 0.20f;
        yield return new WaitForSeconds (0.425f);
        effector.rotationalOffset = 0;
    }
}
