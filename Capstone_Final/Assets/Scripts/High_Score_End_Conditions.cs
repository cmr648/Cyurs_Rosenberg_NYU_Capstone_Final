using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class High_Score_End_Conditions : MonoBehaviour
{
    [Header("Transition")]
    public Pokemon_Shader_Transtion Transition_Script; // a reference to our trnasition script

    [Header("Player has High Score")]
    public High_Score_Name_Editor Level_Manager;
    public float Seconds_To_Transition;
    public bool Can_Transition;

    [Header("Time")]
    public float Time_Before_Transition_High_Score;
    public float Time_Before_Transition_No_Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player_Has_High_Score();
        Player_Does_Not_Have_High_Score();

        if(Can_Transition == true)
        {
            StartCoroutine("Begin_Transition");
            //Can_Transition = false;
        }
    }

    void Player_Has_High_Score()
    {
        if(Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_10_Score"))
        {
            if(Level_Manager.Letter_Index >= 4)
            {
                Can_Transition = true;
            }
        }
    }

    void Player_Does_Not_Have_High_Score()
    {
        if(Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_10_Score"))
        {
            Can_Transition = true;
        }

    }

    IEnumerator Begin_Transition()
    {
        if (Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_10_Score"))
        {
            yield return new WaitForSeconds(Time_Before_Transition_High_Score);
            Transition_Script.Can_Transition = true;
        }
        else
        {
            yield return new WaitForSeconds(Time_Before_Transition_No_Score);
            Transition_Script.Can_Transition = true;
        }


    }

}
