using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Force_On_Button : MonoBehaviour {

	public KeyCode Button_To_Press; // creating a public button for what button the player should press to add force

	public float Max_Force_To_Add; // creating a public float for the amount of force to add

	[HideInInspector] // hiding the variable to not be edited
	public float Current_Force_Counter; // ceating a float to track the amount of force at any given time

	public float Charge_Speed; // creating a public float for the speed of charging

	Rigidbody My_Rigidbody; // creating a reference to our rigidbody

	public GameObject Movement_Arrow; // creating a gameobject reference for our movement arrow

	// Use this for initialization
	void Start () {

		My_Rigidbody = GetComponent<Rigidbody> (); // assiging our rigidbody
		Current_Force_Counter = 0; // ressetting our currect force counter to 0


	}
	
	// Update is called once per frame
	void Update () {




		if (Input.GetKey(Button_To_Press)) { // if our button is held down

			if (Current_Force_Counter < Max_Force_To_Add) {	 // if the object is not fully charged 

				Current_Force_Counter += Time.deltaTime * Charge_Speed; // charge the objcet

			}

		}


		if (Input.GetKeyUp (Button_To_Press)) { // if we click the button to press

			Vector3 Target_Direction = Movement_Arrow.transform.position - transform.position; // using this formula to get the angle between  the direciton arrow and the player object

			My_Rigidbody.AddForce (Target_Direction * Current_Force_Counter, ForceMode.Impulse); // adding a force to our object
		

			Current_Force_Counter = 0; // resseting our current force counter to begin again
		}
	}
}
