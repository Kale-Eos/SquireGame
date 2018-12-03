using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public GameObject Squire;
	/* When the player has one heart left */
	public GameObject Hearts1;
	/* When the player has two hearts left */
	public GameObject Hearts2;
	/* When the player has three hearts left */
	public GameObject Hearts3;
	/* The squire initially has 3 hearts, so he can take 3 hits before he dies */
	public int Hearts;
	/* The squire becomes invincible for a while if he takes damage */
	public bool invincible;

	// Use this for initialization
	void Start () {
		Hearts = 3;
		Hearts3.SetActive (true);
		invincible = false;
	}
	
	// Update is called once per frame
	void Update () {
		/* When the number of hearts equals 0, the squire will die. */
		if (Hearts == 0) {
			/* Plays a death animation if there is any and then transitions to death scene */
		} 
		/* When the number of hearts equals 1, hearts1 appears */
		else if (Hearts == 1) {
			Hearts3.SetActive (false);
			Hearts2.SetActive (false);
			Hearts1.SetActive (true);
		} 
		/* When the number of hearts equals 2, hearts2 appears */
		else if (Hearts == 2) {
			Hearts3.SetActive (false);
			Hearts2.SetActive (true);
		} 
	}
	void OnCollisionEnter2D(Collision2D collision) {
		if (!invincible) {
			/* If the squire touches anything with the tag "harmful" while he isn't invincible, he will take damage */
			if (collision.gameObject.CompareTag("harmful")) {
				/* Paco you can add in the animation right here */
				Hearts = Hearts - 1;
				invincible = true;
				/* Invulnerability period ends after 0.5 seconds*/
				Invoke("notInvincible", 0.5f);
			}
		}
	}
	void notInvincible() {
		invincible = false;
	}
}
