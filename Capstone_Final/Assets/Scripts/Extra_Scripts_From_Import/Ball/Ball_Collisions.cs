using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Collisions : MonoBehaviour {

	public float Player_Force; // creating a force for when we hit the player

	public float Wall_Force; // creating a force for when we hit the wall

	Rigidbody My_Rigidbody; // creating a reference for the rigidbody


	// Use this for initialization
	void Start () {

		My_Rigidbody = GetComponent<Rigidbody> (); // assiging the rigidbody
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay(Collision col){ // checking to see if the ball has collided with anything

		Vector3 Direction_To_Hit = transform.position - col.contacts[0].point; // in this we are getting the angle of exactly where the ball hit

		Direction_To_Hit.Normalize(); // in this we are taking the direction and normalizeing it to hit so it will always hit the same way

		if (col.gameObject.tag == "Player") { // if the object has hit the player

			My_Rigidbody.AddForce (Direction_To_Hit * Player_Force); // adding a force that weve decided when it hit sthe player

		}

		if (col.gameObject.tag == "Wall") { // if the ball has hit a wall

			My_Rigidbody.AddForce (Direction_To_Hit * Wall_Force); // adding a dorce that we have decided when the ball has hit a wall



		}


	}
}
