using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Aspect_Ratio : MonoBehaviour
{
    public float Width; // a float to decide the width
    public float Height; // a float to decide the height

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().aspect = (Width / Height) * (Screen.width / Screen.height); // setting our aspect ratio
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
