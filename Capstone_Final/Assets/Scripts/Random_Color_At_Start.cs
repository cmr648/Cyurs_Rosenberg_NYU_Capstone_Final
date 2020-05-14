using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Color_At_Start : MonoBehaviour
{
    public Color[] Start_Colors;

   
    public Sprite[] Sprite_Array;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, Start_Colors.Length);
        int Sprite_Index = Random.Range(0, Sprite_Array.Length);
        GetComponent<SpriteRenderer>().color = (Start_Colors[index]);
        GetComponent<SpriteRenderer>().sprite = (Sprite_Array[Sprite_Index]);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
