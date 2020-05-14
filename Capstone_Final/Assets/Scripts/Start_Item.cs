using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Item : MonoBehaviour
{
    public Start_Conditions Start_Script; //creating ap ublic reference to our start script

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent != null)
        {
            Start_Script.Start_Game(); // if we ever pick up this coin then begin the game
            GetComponent<Start_Item>().enabled = false; // stop this script
        }
    }
}
