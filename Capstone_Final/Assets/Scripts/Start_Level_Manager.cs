using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; // we will be using videos


public class Start_Level_Manager : MonoBehaviour
{
    [Header("Transition")]
    public Pokemon_Shader_Transtion Transition; // a slot for our pokemon shader transition

    [Header("Player Controls")]
    public Start_Level_Controls Controls_Script; // a slot for our controls script

    // Controls Classes to Implement Controler Support
    public Arcade_Controls Player_1_Controls;
    public Arcade_Controls Player_2_Controls;
    public Arcade_Controls Player_3_Controls;
    public Arcade_Controls Player_4_Controls;

    [Header("Start Level Videos")] // creating a label for all of our video functionality
    public VideoPlayer Start_Level_Player; // creating a refrence for our start level player
    public VideoClip[] Start_Video_Clips; // creating a list of all potential clips

    [Header("Next Level")]
    public string Next_Level;


    private void Awake() // a function that happens even before the game starts
    {
        Cursor.lockState = CursorLockMode.Locked; // locking our cursor to the center
        Cursor.visible = false; // setting it to be invisible
        Select_Start_Video(); // implementing our start video selection function
    }

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        FindObjectOfType<Audio_Manager>().Play_Sound("Background Music"); // playing our background music from our audio manager

        Time.timeScale = 1; // setting our time to be 1 at the start of every singel game
    }

    // Update is called once per frame
    void Update()
    {
        Transition_To_Next_Level();

       

    }

    void Transition_To_Next_Level() // a function
    {
        if (Input.GetKeyDown(Controls_Script.Player_1_Start) || Input.GetButtonDown(Player_1_Controls.Player_Button_Start)) // if we press player 1 start
        {
            Transition.Next_Level = Next_Level;
            Transition.Can_Transition = true; // set the transition to start

            Gameplay_Variables.Player_1_In_Game = true;

        }

        if (Input.GetKeyDown(Controls_Script.Player_2_Start) || Input.GetButtonDown(Player_2_Controls.Player_Button_Start)) // if we press player 1 start
        {
            Transition.Next_Level = Next_Level;
            Transition.Can_Transition = true; // set the transition to start

            Gameplay_Variables.Player_2_In_Game = true;
        }

        if (Input.GetKeyDown(Controls_Script.Player_3_Start) || Input.GetButtonDown(Player_3_Controls.Player_Button_Start)) // if we press player 1 start
        {
            Transition.Next_Level = Next_Level;
            Transition.Can_Transition = true; // set the transition to start

            Gameplay_Variables.Player_3_In_Game = true;
        }

        if (Input.GetKeyDown(Controls_Script.Player_4_Start) || Input.GetButtonDown(Player_4_Controls.Player_Button_Start)) // if we press player 1 start
        {
            Transition.Next_Level = Next_Level;
            Transition.Can_Transition = true; // set the transition to start

            Gameplay_Variables.Player_4_In_Game = true;
        }

    }

    void Select_Start_Video() // a function so select the video that will play at the start of our game
    {
        int Index = Random.Range(0, Start_Video_Clips.Length); // creating an index that will be a random start video

        Start_Level_Player.clip = Start_Video_Clips[Index]; // assigning our start video clip to our start video player

    }
}
