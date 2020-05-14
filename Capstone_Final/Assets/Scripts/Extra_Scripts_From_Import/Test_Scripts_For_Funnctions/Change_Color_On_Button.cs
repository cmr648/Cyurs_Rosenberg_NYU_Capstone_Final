using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Color_On_Button : MonoBehaviour {

    public Color Color_To_Change; // creatingn a color to chagne into
    public KeyCode Button_To_Press; // creatign a button to press

    public Material My_Material;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(Button_To_Press)){

            My_Material.color = Color_To_Change;
        }
		
	}
}
