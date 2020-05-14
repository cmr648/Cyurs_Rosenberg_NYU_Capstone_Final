using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Transition_Script : MonoBehaviour {

	public Material Pixel_Material; // creating a public reference for the material we want to edit

	[Range(0,1000)] // creating a range
	public int Amount_Of_Pixels_In_Scene; // creating a range for eht amount of pixels we want in both rows and collums

	public float Time_To_Transition; // creating a public float based on the amount of time we want to transition
	float Fade_In_Time = 0; // creating a float for the amount of time to fade int
	float Fade_Out_Time = 0; // creating a float for the amount of time to fade out



	public int Max_Pixels; // creating a public int for the max pixels we want
	public int Min_Pixels; // creating a public int for the min pixels we want
	public bool Can_Transition; // creating a public bool to be able to transition between scenes

	public string Next_Level; // creating a public string for what we want our next level to be

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		Start_Scene (); // implementing our start scene
		End_Scene ();  // implementing our end scene

		Pixel_Material.SetFloat ("_PixelCollums", Amount_Of_Pixels_In_Scene); // setting our materials collums to the amount of pixels range

		Pixel_Material.SetFloat ("_PixelRows", Amount_Of_Pixels_In_Scene); // setting our materials collums to the amount of pixels range

	}

	void Start_Scene(){ // creating a void to start our scenne with

		if (Fade_In_Time < 1) { // if our fade in time is less than 100%
			Fade_In_Time += Time.deltaTime/Time_To_Transition; // adding time to our fade in value

		}

		Amount_Of_Pixels_In_Scene = (int)Mathf.Lerp (Min_Pixels, Max_Pixels, Fade_In_Time); // actually lerping out pixels based on out fade in time


	}

	void End_Scene(){ //creating a public void to be able to end our scene

		if (Can_Transition == true) { // checking to see if we can transition at all

			if (Fade_Out_Time < 1) { // if our fadeout time has not completed
				Fade_Out_Time += Time.deltaTime / Time_To_Transition; // adding time to our fade out value

			}

			Amount_Of_Pixels_In_Scene = (int)Mathf.Lerp (Max_Pixels, Min_Pixels, Fade_Out_Time); // acctually lerping our pixels based on our fade out time

			if (Amount_Of_Pixels_In_Scene == Min_Pixels) { // if we have depleted all pixels

				SceneManager.LoadScene (Next_Level); // loading into our next scene
			}

		}
	}
}
