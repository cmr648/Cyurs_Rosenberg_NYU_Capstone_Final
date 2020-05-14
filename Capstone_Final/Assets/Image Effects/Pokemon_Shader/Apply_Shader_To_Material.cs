using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] // use this script even not in play mode

public class Apply_Shader_To_Material : MonoBehaviour {

	public Material Material_To_Apply_Shader; // creating a public material refrence of the material we wish to apply our shader to

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnRenderImage(RenderTexture Source, RenderTexture Destination){ // setting up our on render image function to render on to a destination


		Graphics.Blit (Source, Destination, Material_To_Apply_Shader); // applying our actual shader onto our image


	}


}
