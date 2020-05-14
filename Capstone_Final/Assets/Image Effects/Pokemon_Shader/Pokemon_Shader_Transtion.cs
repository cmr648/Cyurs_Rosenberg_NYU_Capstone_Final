using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[ExecuteInEditMode] // having this script run at all times

public class Pokemon_Shader_Transtion : MonoBehaviour {

	public Material Transition_Material; // creating a public refernce for the material we want to edit

	public List<Texture2D> Transition_Textures; // creating a publci list of textures to choose from when doing our transitions

	public float Time_To_Transition; // creating a public float based on the time to transtiion
	float Fade_In_Time = 0; // creating a float for fade in time
	float Fade_Out_Time = 0; // creating a float for fade out time

	[Range(0,1)] // creating a range from 0,1
	public float Point_Of_Transition; // creating a public float for the point we want in our transition

	public string Next_Level; // creating a public string for what our next level we want to be is

	public bool Can_Transition; // creating a public bool to tell wheather we are able to transitionn at any given time

	bool Has_Set_Material_1 = false; // creating a boolean to set our material for our fade in
	bool Has_Set_Material_2 = false; // creating a boolean to set our material for our fade out

	void Awake(){ // a function that happens before the first frame

		Point_Of_Transition = 1; // setting our point of transition to the max value
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Start_Scene (); // implementing our start scene function
		End_Scene(); // implementinf our end scene function

		Transition_Material.SetFloat ("_Cutoff", Point_Of_Transition); // setting our point of transition from this script to the cutoff on our material

		
	}

	void Start_Scene(){ // creating a function for the start of our scene

		if (Has_Set_Material_1 == false) { // if we have not set a material
			Transition_Material.SetTexture("_TransitionTex",Transition_Textures[Random.Range(0,Transition_Textures.Count)]); // setting a random transtion texture on our start scene
			Has_Set_Material_1 = true; // stopping our reset of materials
		}

		if (Fade_In_Time < 1) {// if our fade in time is less than 1
			 
			Fade_In_Time += Time.deltaTime / Time_To_Transition; // setting our fade in time to last as long as our time to transition
		
		}

		Point_Of_Transition = Mathf.Lerp (1, 0, Fade_In_Time); // lerping our texture based on the fade in time


	}

	void End_Scene(){ // creating a function to end our scene

		if (Can_Transition == true) { // if we are currently able to transition

			if (Has_Set_Material_2 == false) { // if we have not set a material
				Transition_Material.SetTexture("_TransitionTex",Transition_Textures[Random.Range(0,Transition_Textures.Count)]); // setting a random transtion texture on our start scene
				Has_Set_Material_2 = true; // stopping our reset of materials
			}
				
			if (Fade_Out_Time < 1) { // if our fadeout time is less than 1

				Fade_Out_Time += Time.deltaTime / Time_To_Transition; // setting our fade out time to last as long as our transition

			}

			Point_Of_Transition = Mathf.Lerp (0, 1, Fade_Out_Time); // lersping our texture based on the fade out time

			if (Point_Of_Transition == 1) { // if our point of transition has completely faded out

				SceneManager.LoadScene (Next_Level); // load into our next level
			}
		}
	}
}
