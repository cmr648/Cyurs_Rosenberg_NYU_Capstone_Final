using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character_Spawner : MonoBehaviour {

	public float Amount_of_Players; // creating a public float that will decide how many players to spawn
	public GameObject Player_Game_Object; //creating a reference to the player object that will spawn
	public GameObject Ball_Game_Object; // creating a reference to the ball we wish to spawn

	[HideInInspector]
	public List<GameObject> Character_Spawn_Points; // creating aa list of gameobjects that will gather all of the points a character could spawn at
	[HideInInspector]
	public List<GameObject> Player_Game_Objects_List; // creating a list of all of the player gameobejcts by finding objecst tagged Player


	void Awake(){ // a function that happens even before the first frame

		Spawn_Players (); // spawning our players to begin
		Spawn_Ball(); // spawning our ball to begin the game
	}


	// Use this for initialization
	void Start () {
	
		Player_Game_Objects_List.AddRange(GameObject.FindGameObjectsWithTag("Player")); // assiging all of the objecst tagged player to this list

        Assign_Player_Numbers(); // implemennting annd assigningn our player numbers


		Assign_Player_Locations (); // implementing our assigin player locations function



	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn_Players(){ // spawninng players using a function

		for (int i = 0; i < Amount_of_Players; i++) { // repeat this function as many times as the amount of players

			Instantiate (Player_Game_Object, transform.position, Quaternion.identity); // instantiating a player gameobject

		}


	}


	public void Spawn_Ball(){ // creating a functionn to spawnn the ball

		Instantiate (Ball_Game_Object, new Vector3 (0, 1, 0), Quaternion.identity); // instantiating the ball in the center of our map at the beginning of the game

	}

	public void Assign_Player_Locations(){ // assiging player locations based on this void
	
		Character_Spawn_Points.AddRange(GameObject.FindGameObjectsWithTag("Spawn_Point")); // finding all of the gameobjects in our scene with the tag of spawn point

		for (int i = 0; i < Player_Game_Objects_List.Count; i++) { // repeat for however many players are in the game

			GameObject Spawn_Point_Location = Character_Spawn_Points[Random.Range (0, Character_Spawn_Points.Count)]; // taking a random gameobejct position from the list of our character spawn points

			Player_Game_Objects_List [i].transform.position = Spawn_Point_Location.transform.position ; // moving one of the player gameobejcts to the location of our random spawn point choice

			Character_Spawn_Points.Remove (Spawn_Point_Location); // removing that random location from the possible locations that we can spawn at
		
			}


	}

    void Assign_Player_Numbers(){ // creating a void to assignn player numbers

        for (int i = 0; i < Player_Game_Objects_List.Count; i++){ // creating an int to check every single player inn player list

            Player_Game_Objects_List[i].GetComponent<Character_Assignment>().Player_Assignment_Number = i + 1; // assigning number i to every single player gameobject

        }

    }


    }


		

