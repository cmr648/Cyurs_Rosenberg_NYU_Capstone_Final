using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raw_Image_Scroll : MonoBehaviour
{
    [Header("Direction")]
    public bool Can_Scroll;


    [Header ("Scroll Speed")]
    public float Speed;

    RawImage This_Image;

    // Start is called before the first frame update
    void Start()
    {
        This_Image = GetComponent<RawImage>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Can_Scroll == true)
        {
            This_Image.uvRect = new Rect(This_Image.uvRect.x, This_Image.uvRect.y + Time.deltaTime * Speed, This_Image.uvRect.width, This_Image.uvRect.height);
        }


    }
}
