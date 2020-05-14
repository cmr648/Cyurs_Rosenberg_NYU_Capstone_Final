using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls_Manager : MonoBehaviour
{
    [Header("Arrow Key Controls")]
    public KeyCode Forward; // A keycode to get our forward keypress
    public KeyCode Backward;
    public KeyCode Left;
    public KeyCode Right;

    [Header ("Keyboard Buttons")]
    public KeyCode Pickup_Drop_Item;
    public KeyCode Throw_Item;
    public KeyCode Use_Item;

    [Header("Arcade_Controls")]
    public Arcade_Controls Player_Arcade_Controls; // this will be the arcade controls string orginizationt that will be persistent throughout our character controller on multople scripts

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
