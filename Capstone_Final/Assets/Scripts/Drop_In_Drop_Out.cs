using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_In_Drop_Out : MonoBehaviour
{ 
    // TO BE REPLACED WITH ARCADE CONTROLS
    public KeyCode One;
    public KeyCode Two;
    public KeyCode Three;
    public KeyCode Four;

    [Header("Player Arcaed Controls")]
    public Player_Controls_Manager Player_1_Controls;
    public Player_Controls_Manager Player_2_Controls;
    public Player_Controls_Manager Player_3_Controls;
    public Player_Controls_Manager Player_4_Controls;

    [SerializeField]
    End_Conidtions_New End_Conditions; // our end conditions script that we will be using for our game

    // Start is called before the first frame update
    void Start()
    {
        End_Conditions = GetComponent<End_Conidtions_New>(); // Assignign End Conditions
    }

    // Update is called once per frame
    void Update()
    {
        Drop_In(); // implementing our drop in funciton
    }

    void Drop_In() // a function that allows players to join the game in the middle of a round
    {
        //ADD SOUND SOMEWHERE

        if (Input.GetKeyDown(One) || Input.GetButtonDown(Player_1_Controls.Player_Arcade_Controls.Player_Button_Start)) // if we press a button
        {
            Gameplay_Variables.Player_1_In_Game = true; // our player is in the game
            FindObjectOfType<Audio_Manager>().Play_Sound("Player Join"); // playing the sound for a player joining the game
            End_Conditions.StartCoroutine("Introduce_New_Player"); // introduce them to the sence
        }

        if (Input.GetKeyDown(Two) || Input.GetButtonDown(Player_2_Controls.Player_Arcade_Controls.Player_Button_Start))
        {
            Gameplay_Variables.Player_2_In_Game = true;
            FindObjectOfType<Audio_Manager>().Play_Sound("Player Join"); // playing the sound for a player joining the game
            End_Conditions.StartCoroutine("Introduce_New_Player");
        }

        if (Input.GetKeyDown(Three) || Input.GetButtonDown(Player_3_Controls.Player_Arcade_Controls.Player_Button_Start))
        {
            Gameplay_Variables.Player_3_In_Game = true;
            FindObjectOfType<Audio_Manager>().Play_Sound("Player Join"); // playing the sound for a player joining the game
            End_Conditions.StartCoroutine("Introduce_New_Player");
        }

        if (Input.GetKeyDown(Four) || Input.GetButtonDown(Player_4_Controls.Player_Arcade_Controls.Player_Button_Start))
        {
            Gameplay_Variables.Player_4_In_Game = true;
            FindObjectOfType<Audio_Manager>().Play_Sound("Player Join"); // playing the sound for a player joining the game
            End_Conditions.StartCoroutine("Introduce_New_Player");
        }
    }
}
