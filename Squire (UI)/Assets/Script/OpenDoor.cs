using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour {

    public GameObject TriggerDoor;
    public GameObject Jiren;
	public GameObject Squire;
	public GameObject Jiren2;
	public GameObject InvisibleDoor;
	public CompositeCollider2D SquireBoxCollider;
	public CompositeCollider2D InvisibleDoorCollider;
	public BoxCollider2D JirenBoxCollider;
	public BoxCollider2D TriggerDoorBoxCollider;

	void Update()
    {
		if (!GameObject.Find("Jiren"))
        {
			Destroy(InvisibleDoor);
            /* Jiren shows up on the bottom right which means he is in the inventory */
            Jiren2.SetActive(true);
		}
	}


	// void OnTriggerEnter2D(Collider2D collision) {
		/* happens when the squire collides with the TriggerDoor */
		//if (collision.gameObject.name == "TriggerDoor") {
			/* New scene in loaded */
			//Debug.Log ("TriggeredDoor was touched");
			//SceneManager.LoadScene(0);
		//}
	//} 
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "TriggerDoor") {
			/* New scene in loaded */
			Debug.Log ("TriggeredDoor was touched");
			SceneManager.LoadScene(0);
		}
	}
}