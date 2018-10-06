using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject TriggerDoor;
    public GameObject Jiren;
	public GameObject Squire;
	public BoxCollider2D SquireBoxCollider;
	public BoxCollider2D JirenBoxCollider;
	/* In the beginning Jiren isn't defeated yet. */
	bool jirenDefeated = false;

	/* Checks if the box collider of the squire meets the box colldier of Jiren */
	bool BoxCollidersCheck (){
		// Happens if the box collider for the player meets with Jiren's box collider 
		if(SquireBoxCollider.IsTouching(JirenBoxCollider)) {
			return true;
		}
		else {
			return false;
		}
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Jiren") {
			Destroy(collision.gameObject);
		}
	}

	void Update() {
		/*Checks to see if Jiren is defeated */
		if(BoxCollidersCheck()){
			jirenDefeated = true;
			/* Removes Jiren */

		}
		/*Happens when Jiren is defeated */
		if(jirenDefeated){
			/* door opens */
		}
	}
}