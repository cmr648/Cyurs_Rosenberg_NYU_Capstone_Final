using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill_Bar_For_Charge : MonoBehaviour {

	Add_Force_On_Button Character_Script;

	Image This_Image; // using an image 

	// Use this for initialization
	void Start () {

		Character_Script = GetComponentInParent<Add_Force_On_Button> (); // assignign our character script

		This_Image = GetComponent<Image> (); // getting our image and assigingin it 
		
	}
	
	// Update is called once per frame
	void Update () {

		This_Image.fillAmount = (Character_Script.Current_Force_Counter / Character_Script.Max_Force_To_Add); // creatinga  percentage so our bar can grow

	}
}
