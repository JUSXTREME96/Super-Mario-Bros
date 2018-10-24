using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimate : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
			anim.SetBool ("Running", true);
		} else {
			anim.SetBool ("Running", false);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			anim.SetTrigger ("Jumping");
		}
}
}