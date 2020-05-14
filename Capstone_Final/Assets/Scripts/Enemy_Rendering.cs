using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Rendering : MonoBehaviour
{
    public Color Start_Color; // getting our start color
    public Color Current_Color; // getting our current color
    public Color Damage_Color; // creating a damage color

    SpriteRenderer Enemy_Renderer; // getting our sprite renderer
    
    // Start is called before the first frame update
    void Start()
    {
        Enemy_Renderer = GetComponent<SpriteRenderer>(); // assiging our sprite renderer
        Start_Color = Enemy_Renderer.color; // assigning our start color
        Current_Color = Start_Color; // assiging a current color
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Renderer.color = Current_Color;
    }
}
