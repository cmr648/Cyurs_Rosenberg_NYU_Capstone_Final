using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] // this will allow this script to run without us clicking play mode

public class PixelatedImageEffect : MonoBehaviour {

	public Material Pixel_Effect_Material; // creating a public material reference for our pixel effect material

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnRenderImage(RenderTexture Source_Texture, RenderTexture DestinationTexture){ // using this function to modify the image rendered on screen

		Graphics.Blit (Source_Texture, DestinationTexture, Pixel_Effect_Material); //this one line takes in a source texture and wraps it onto our public material
	}
}
