using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Script : MonoBehaviour {

	public GameObject INGameCanvas2;

	void Start() {
		/* The in game canvas is not active at first */
		INGameCanvas2.SetActive (false);
	}



	
	// Update is called once per frame
	void Update () {
		/* when esc is pressed, the canvas shows/ disappears depending on whether is was showing before or not */
		if (Input.GetButtonDown("Pause")) {
			Debug.Log ("pause");
			if (INGameCanvas2.activeSelf) {
				INGameCanvas2.SetActive (false);
			} 
			else {
				INGameCanvas2.SetActive (true);
			}
		}
		
	}
}
