using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotate_Arrow : MonoBehaviour {

	public float Rotate_Arrow_Speed;


	public string Player_Axis; // creating a public string to edit and choose the player access that we are going to use

  
    public KeyCode Right_Arrow;

    public KeyCode Left_Arrow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if(Input.GetKey(Right_Arrow)){ // if the right arrow has been pressed
		transform.RotateAround (transform.parent.transform.position, Vector3.up, Time.deltaTime * Rotate_Arrow_Speed); // actually rotating our object
		}

        if(Input.GetKey(Left_Arrow)){ // if the left arrow has been pressed
			transform.RotateAround (transform.parent.transform.position, Vector3.up, Time.deltaTime * -Rotate_Arrow_Speed); // actually rotating our object
		}

		if (Input.GetAxis (Player_Axis) > 0) { // using the input axis of the controller for right

			transform.RotateAround (transform.parent.transform.position, Vector3.up, Time.deltaTime * Rotate_Arrow_Speed); // actually rotating our object

		}

		if (Input.GetAxis (Player_Axis) < 0) { // using the input axis of the controller for the left

			transform.RotateAround (transform.parent.transform.position, Vector3.up, Time.deltaTime * -Rotate_Arrow_Speed); // actually rotating our object

		}





	}

   
}
