using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Start_Conditions : MonoBehaviour
{
    [Header("Camera Effects")] // all of the effects we will put on our camera
    public Camera Main_Camera; // a reference to our camera
    public float Camera_Start_Size; // our camera start size
    float Camera_Current_Size; // the current size of our camera
    public float Camera_Final_Size; // the final size of our camera
    public float Camera_Speed; // the speed at which we want our camera to tween
    public LeanTweenType Camera_Tween; // the tween type we want our camera to tween at

    [Header("Objects To Activate")] // the objects we will activate when starting the game
    public Wave_Spawner Game_Wave_Spawner; // the wave spawner object we will use during our gameplay session

    [Header("Objects To Deactivate")] // the objects that will deactivate when we start the game
    public GameObject Camera_Borders; // Creating a reference to our camera borders gameobejct

    [Header("Start Conditions")] // our boolean conditions to start the game
    public bool Can_Start;



    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Audio_Manager>().Play_Sound("Startup");

        Game_Wave_Spawner.enabled = false; // disabling our game wave spawner at the start of the gmae
        Main_Camera.orthographicSize = Camera_Start_Size; // setting our camera size to be the start size

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) // to be replaced
        //{
        //    Can_Start = true; // we can start the game
        //}


        if (Can_Start == true) // if we can start the game
        {
            Start_Game(); // implement our start game function
            Can_Start = false; // set our game to not be able to start again
        }

    }

    public void Start_Game() // if we are able to start the game
    {
        Game_Wave_Spawner.enabled = true; // enable our wave spawener

        LeanTween.value(Main_Camera.gameObject, Main_Camera.orthographicSize,Camera_Final_Size,Camera_Start_Size).setEase(Camera_Tween).setTime(Camera_Speed).setOnUpdate((float flt) => { // raise our camera size using lean tween
            Main_Camera.orthographicSize = flt;
        });

        //FindObjectOfType<Audio_Manager>().Play_Sound("Background Music"); // playing our music

        Set_Background_Music_And_Play(); // setting and playing our background music based on our function

        Destroy(Camera_Borders); // destroying our camera borders

        GetComponent<Start_Conditions>().enabled = false; // disabling this at the very end of everything PUT THIS LAST

    }

    void Set_Background_Music_And_Play() // a function to set whcihc background theme music we are going to use
    {
        if (Gameplay_Variables.Level_Art_Set == 0)
        {
            FindObjectOfType<Audio_Manager>().Play_Sound("Grass Music"); // playing our music
        }

        if (Gameplay_Variables.Level_Art_Set == 1)
        {
            FindObjectOfType<Audio_Manager>().Play_Sound("Beach Music"); // playing our music
        }

        if (Gameplay_Variables.Level_Art_Set == 2)
        {
            FindObjectOfType<Audio_Manager>().Play_Sound("Snow Music"); // playing our music
        }

        if (Gameplay_Variables.Level_Art_Set == 3)
        {
            FindObjectOfType<Audio_Manager>().Play_Sound("Lava Music"); // playing our music
        }
    }

}




