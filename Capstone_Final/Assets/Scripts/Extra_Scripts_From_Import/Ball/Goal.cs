using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter(Collider col) // if any object has entered this trigger
    {
        if(col.gameObject.tag == "Ball"){ // if that object is the ball
            

            if(col.gameObject.GetComponent<Ball_Score_Tracker>().Last_Object_Touched.GetComponent<Character_Assignment>().Player_Assignment_Number == 1){ // checking to see if the player touched is player 1

                Important_Variables.Player_1_Score += 10;

            }


            if (col.gameObject.GetComponent<Ball_Score_Tracker>().Last_Object_Touched.GetComponent<Character_Assignment>().Player_Assignment_Number == 2)
            { // checking to see if the player touched is player 1

                Important_Variables.Player_2_Score += 10;

            }

            if (col.gameObject.GetComponent<Ball_Score_Tracker>().Last_Object_Touched.GetComponent<Character_Assignment>().Player_Assignment_Number == 3)
            { // checking to see if the player touched is player 1

                Important_Variables.Player_3_Score += 10;

            }

            if (col.gameObject.GetComponent<Ball_Score_Tracker>().Last_Object_Touched.GetComponent<Character_Assignment>().Player_Assignment_Number == 4)
            { // checking to see if the player touched is player 1

                Important_Variables.Player_4_Score += 10;

            }

            FindObjectOfType<Character_Spawner>().Spawn_Ball(); // respawn a new ball

            Destroy(col.gameObject); // destroy the ball

        }
    }


}
