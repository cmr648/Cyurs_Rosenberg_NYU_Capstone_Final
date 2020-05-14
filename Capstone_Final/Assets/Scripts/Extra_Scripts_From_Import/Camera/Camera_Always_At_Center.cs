using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Always_At_Center : MonoBehaviour {

	[HideInInspector]
	public List <GameObject> All_Player_Gameobjects; // geting all of the player gameobjects in our scene

	Vector3 Center_Position = Vector3.zero; // creating a vector3 that will act as our center position between all player gameobjects

	// Use this for initialization
	void Start () {

		All_Player_Gameobjects.AddRange (GameObject.FindGameObjectsWithTag ("Player")); // assigning all gameobjects with the tag player to our list of player gameobjects
		
	}
	
	// Update is called once per frame
	void Update () {

		Get_Average_Position (); // getting our average position
		Assign_Current_Object_Position(); // assiging our current objecst positon based on the average
		
	}

	void Get_Average_Position(){ // creating a function to get the position at the center of each player


		for (int i = 0; i < All_Player_Gameobjects.Count; i++) { // for each item in all of our player gameobjects, basically counting to up to 4


			Center_Position += All_Player_Gameobjects [i].transform.position; // adding all of the positions of all of our player gameobjects to to our center position

		}

		Center_Position = Center_Position / All_Player_Gameobjects.Count; // devidign it to create the average 


	}



	void Assign_Current_Object_Position(){ // creating a seperate function to assign camera position

		transform.position = new Vector3 (Center_Position.x, transform.position.y, Center_Position.z); // moving our objects positiont to the center of all of the gameobjects


	}


}

