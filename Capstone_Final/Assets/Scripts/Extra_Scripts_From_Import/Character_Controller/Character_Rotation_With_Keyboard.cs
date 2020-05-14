using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Rotation_With_Keyboard : MonoBehaviour {

	public KeyCode Left; // a left key public
	public KeyCode Right; // a right keycode public

	public float Rotation_Speed; // rotation speed for the object

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (Left)) { // if our rotation key is pressed
			transform.Rotate(new Vector3 (0,-1*Rotation_Speed,0)); // rotate the object left

		}

		if (Input.GetKey (Right)) { // if our rotation key is pressed
			transform.Rotate(new Vector3 (0,1*Rotation_Speed,0)); // rotate the object right

		}
		
	}
}
