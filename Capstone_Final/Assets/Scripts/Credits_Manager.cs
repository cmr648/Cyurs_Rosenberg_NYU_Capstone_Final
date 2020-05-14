using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_Manager : MonoBehaviour
{
    [Header("Credits Text Objects")]
    public GameObject[] Credits_Objects;

    [Header("Time Management")]
    public float Start_Wait_Time;
    public float Time_Before_Transition;

    [Header("Text Scaling Attributes")]
    public Vector3 Credit_Show_Scale;
    public float Scale_Time;
    public float Up_Scale_Wait_Time;
    public float Between_Credits_Wait_Time;
    public LeanTweenType Credits_Ease_Type;
    public LeanTweenType Credits_Down_Ease_Type;

    [Header("Player Controls")] // TO BE CHANGED TO ARCADE CONTROLS LATER
    public KeyCode Player_1;
    public float Time_Speed;

    [Header("Post Credits Transition")]
    public Pokemon_Shader_Transtion Transition_Script; // getting our pokemon shader transition script

    [Header("Arcade Controls")]
    public Arcade_Controls Player_1_Controls;
    public Arcade_Controls Player_2_Controls;
    public Arcade_Controls Player_3_Controls;
    public Arcade_Controls Player_4_Controls;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Roll_Credits");

        FindObjectOfType<Audio_Manager>().Play_Sound("Background Music"); // playing our background music from the audio manager

    }

    // Update is called once per frame
    void Update()
    {
        Speed_Time(); // implementing our function to speed up time
        Start_To_Skip(); // implementing our start to skip function
    }

    IEnumerator Roll_Credits()
    {
        yield return new WaitForSeconds(Start_Wait_Time);

        for(int i = 0; i < Credits_Objects.Length-1; i++) 
        {
            Credits_Objects[i].LeanScale(Credit_Show_Scale, Scale_Time).setEase(Credits_Ease_Type);
            yield return new WaitForSeconds(Scale_Time + Up_Scale_Wait_Time);
            Credits_Objects[i].LeanScale(Vector3.zero, Scale_Time).setEase(Credits_Down_Ease_Type);
            yield return new WaitForSeconds(Between_Credits_Wait_Time);

        }


        Credits_Objects[Credits_Objects.Length-1].LeanScale(Credit_Show_Scale, Scale_Time).setEase(Credits_Ease_Type); // scaling up thanks for playing
        yield return new WaitForSeconds(Time_Before_Transition); // waiting a little bit
        Transition_Script.Can_Transition = true; // transitioning

    }

    void Speed_Time()
    {
        //if (Input.GetKey(Player_1))
        //{
        //    Time.timeScale = Time_Speed;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //}

        if (Input.GetButton(Player_1_Controls.Player_Button_A))
        {
            Time.timeScale = Time_Speed;
        }
        else if (Input.GetButton(Player_2_Controls.Player_Button_A))
        {
            Time.timeScale = Time_Speed;
        }
        else if (Input.GetButton(Player_3_Controls.Player_Button_A))
        {
            Time.timeScale = Time_Speed;
        }
        else if (Input.GetButton(Player_4_Controls.Player_Button_A))
        {
            Time.timeScale = Time_Speed;
        }
        else
        {
            Time.timeScale = 1;
        }

    }


    void Start_To_Skip() // a function that will allow us to skip the credits if we press the start button
    {
        if (Input.GetButton(Player_1_Controls.Player_Button_Start))
        {
            Transition_Script.Can_Transition = true;
        }

        if (Input.GetButton(Player_2_Controls.Player_Button_Start))
        {
            Transition_Script.Can_Transition = true;
        }
        if (Input.GetButton(Player_3_Controls.Player_Button_Start))
        {
            Transition_Script.Can_Transition = true;
        }
        if (Input.GetButton(Player_4_Controls.Player_Button_Start))
        {
            Transition_Script.Can_Transition = true;
        }
    }
}
