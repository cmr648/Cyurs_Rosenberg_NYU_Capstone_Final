using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Score_Tracker : MonoBehaviour {

    [HideInInspector]
    public GameObject Last_Object_Touched = null; // creating a gameobject reference for the last object touched
    float Player_Number; // creating an int that will track the actual player number that has hit the ball

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	void OnCollisionEnter(Collision col){ //checking to see if any collision was made with nay object
		
		if (col.gameObject.tag == "Player") { // if a player has touched the ball


			Last_Object_Touched = col.gameObject; // assignign the last obejct hit to our gameobject variable

            Player_Number = col.gameObject.GetComponent<Character_Assignment>().Player_Assignment_Number; // assigning our player number to our last object touched

          
		
		}


	
	}
}
