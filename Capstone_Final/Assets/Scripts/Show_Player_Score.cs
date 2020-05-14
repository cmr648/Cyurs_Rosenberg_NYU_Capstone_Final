using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_Player_Score : MonoBehaviour
{
    [Header("Team UI")]
    public GameObject Team_Score;

    [Header("UI Objects Player 1")]
    public GameObject Player_1_Coin_Score;
    public GameObject Player_1_Chest_Score;
    public GameObject Player_1_Throw_Score;
    public GameObject Player_1_Catch_Score;
    public GameObject Player_1_Enemy_Score;

    [Header ("UI Objects Player 2")]
    public GameObject Player_2_Coin_Score;
    public GameObject Player_2_Chest_Score;
    public GameObject Player_2_Throw_Score;
    public GameObject Player_2_Catch_Score;
    public GameObject Player_2_Enemy_Score;

    [Header("UI Objects Player 3")]
    public GameObject Player_3_Coin_Score;
    public GameObject Player_3_Chest_Score;
    public GameObject Player_3_Throw_Score;
    public GameObject Player_3_Catch_Score;
    public GameObject Player_3_Enemy_Score;

    [Header("UI Objects Player 4")]
    public GameObject Player_4_Coin_Score;
    public GameObject Player_4_Chest_Score;
    public GameObject Player_4_Throw_Score;
    public GameObject Player_4_Catch_Score;
    public GameObject Player_4_Enemy_Score;

    [Header("Player_Objects")]
    public GameObject Pirate_Object;
    public GameObject Cyborg_Oject;
    public GameObject Ghost_Object;
    public GameObject Adventurer_Object;
    public float Player_Tween_Scale;

    [Header("Text_Scale")]
    public float Text_Scale;
    public float Team_Text_Scale;

    [Header ("Time Between SHowings")]
    public float Show_Wait_Time_Players;
    public float Start_Team_Time;
    public float Start_Player_Time;
    

    [Header ("Time To Tween")]
    public float Tween_Time;

    public LeanTweenType Bounce_Curve;

    [Header("Colors")]
    public Color Best_Color;
    public Color Normal_Color;

    [Header("Scene Transition")]
    public Pokemon_Shader_Transtion Transition_Script; // the script we will use to transition
    public float Transition_Wait_Time; // tranision wait time

    [Header("Arcade Controls")] //setting up our arcade controls for this scene
    public Arcade_Controls Player_1_Controls;
    public Arcade_Controls Player_2_Controls;
    public Arcade_Controls Player_3_Controls;
    public Arcade_Controls Player_4_Controls;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Audio_Manager>().Play_Sound("Background Music"); // setting our audio manager to play background music

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        Controller_Move_On_Scene(); // alllowing us to move scenes using our arcade controls
    }


    IEnumerator Reveal_Scores_Player_1()
    {
        yield return new WaitForSeconds(Start_Player_Time);
        if(Gameplay_Variables.Player_1_In_Game == true)
        {
            Pirate_Object.LeanScale(new Vector3(Player_Tween_Scale, Player_Tween_Scale, Player_Tween_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_1_Coin_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_1_Chest_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_1_Throw_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_1_Catch_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_1_Enemy_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);

            // at the end of scoring transition our scene
            yield return new WaitForSeconds(Transition_Wait_Time);
            Transition_Script.Can_Transition = true;
        }

       
    }

    IEnumerator Reveal_Scores_Player_2()
    {
        yield return new WaitForSeconds(Start_Player_Time);
        if (Gameplay_Variables.Player_2_In_Game == true)
        {
            Cyborg_Oject.LeanScale(new Vector3(Player_Tween_Scale, Player_Tween_Scale, Player_Tween_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_2_Coin_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_2_Chest_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_2_Throw_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_2_Catch_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_2_Enemy_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);

            yield return new WaitForSeconds(Transition_Wait_Time);
            Transition_Script.Can_Transition = true;
        }

    }

    IEnumerator Reveal_Scores_Player_3()
    {
        yield return new WaitForSeconds(Start_Player_Time);
        if (Gameplay_Variables.Player_3_In_Game == true)
        {
            Ghost_Object.LeanScale(new Vector3(Player_Tween_Scale, Player_Tween_Scale, Player_Tween_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_3_Coin_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_3_Chest_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_3_Throw_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_3_Catch_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_3_Enemy_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);

            yield return new WaitForSeconds(Transition_Wait_Time);
            Transition_Script.Can_Transition = true;
        }

    }

    IEnumerator Reveal_Scores_Player_4()
    {
        yield return new WaitForSeconds(Start_Player_Time);
        if (Gameplay_Variables.Player_4_In_Game == true)
        {
            Adventurer_Object.LeanScale(new Vector3(Player_Tween_Scale, Player_Tween_Scale, Player_Tween_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_4_Coin_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_4_Chest_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_4_Throw_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_4_Catch_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);
            yield return new WaitForSeconds(Show_Wait_Time_Players);
            Player_4_Enemy_Score.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Tween_Time).setEase(Bounce_Curve);

            yield return new WaitForSeconds(Transition_Wait_Time);
            Transition_Script.Can_Transition = true;
        }

    }

    IEnumerator Reveal_Team_Score()
    {
        yield return new WaitForSeconds(Start_Team_Time);
        Team_Score.LeanScale(new Vector3(Team_Text_Scale, Team_Text_Scale, Team_Text_Scale), Tween_Time).setEase(Bounce_Curve);

    }

    void StartGame()
    {
        Set_Text(); // setting our text to the proper scores
        Color_Text();

        StartCoroutine("Reveal_Team_Score");
        StartCoroutine("Reveal_Scores_Player_1");
        StartCoroutine("Reveal_Scores_Player_2");
        StartCoroutine("Reveal_Scores_Player_3");
        StartCoroutine("Reveal_Scores_Player_4");
    }

    void Set_Text()
    {
        Team_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Team_Score;

        Player_1_Coin_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_1_Coin_Score;
        Player_2_Coin_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_2_Coin_Score;
        Player_3_Coin_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_3_Coin_Score;
        Player_4_Coin_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_4_Coin_Score;


        Player_1_Catch_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_1_Catch_Score;
        Player_2_Catch_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_2_Catch_Score;
        Player_3_Catch_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_3_Catch_Score;
        Player_4_Catch_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_4_Catch_Score;

        Player_1_Throw_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_1_Throw_Score;
        Player_2_Throw_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_2_Throw_Score;
        Player_3_Throw_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_3_Throw_Score;
        Player_4_Throw_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_4_Throw_Score;

        Player_1_Chest_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_1_Chest_Score;
        Player_2_Chest_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_2_Chest_Score;
        Player_3_Chest_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_3_Chest_Score;
        Player_4_Chest_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_4_Chest_Score;


        Player_1_Enemy_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_1_Enemy_Score;
        Player_2_Enemy_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_2_Enemy_Score;
        Player_3_Enemy_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_3_Enemy_Score;
        Player_4_Enemy_Score.GetComponent<Text>().text += " " + Gameplay_Variables.Player_4_Enemy_Score;



    }

    void Color_Text()
    {
        int[] Player_Coin_Scores = { Gameplay_Variables.Player_1_Coin_Score, Gameplay_Variables.Player_2_Coin_Score, Gameplay_Variables.Player_3_Coin_Score, Gameplay_Variables.Player_4_Coin_Score };

        int Greatest_Coin_Score = Game_Design_Functions.Find_Greatest_In_Int_Array(Player_Coin_Scores);

        if (Gameplay_Variables.Player_1_Coin_Score == Greatest_Coin_Score)
        {
            Player_1_Coin_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_1_Coin_Score.GetComponent<Text>().color = Normal_Color;
        }

        if (Gameplay_Variables.Player_2_Coin_Score == Greatest_Coin_Score)
        {
            Player_2_Coin_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_2_Coin_Score.GetComponent<Text>().color = Normal_Color;

        }

        if (Gameplay_Variables.Player_3_Coin_Score == Greatest_Coin_Score)
        {
            Player_3_Coin_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_3_Coin_Score.GetComponent<Text>().color = Normal_Color;

        }

        if (Gameplay_Variables.Player_4_Coin_Score == Greatest_Coin_Score)
        {
            Player_4_Coin_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_4_Coin_Score.GetComponent<Text>().color = Normal_Color;

        }




        int[] Player_Throw_Scores = { Gameplay_Variables.Player_1_Throw_Score, Gameplay_Variables.Player_2_Throw_Score, Gameplay_Variables.Player_3_Throw_Score, Gameplay_Variables.Player_4_Throw_Score };

        int Greatest_Throw_Score = Game_Design_Functions.Find_Greatest_In_Int_Array(Player_Throw_Scores);

        if (Gameplay_Variables.Player_1_Throw_Score == Greatest_Throw_Score)
        {
            Player_1_Throw_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_1_Throw_Score.GetComponent<Text>().color = Normal_Color;
        }

        if (Gameplay_Variables.Player_2_Throw_Score == Greatest_Throw_Score)
        {
            Player_2_Throw_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_2_Throw_Score.GetComponent<Text>().color = Normal_Color;

        }

        if (Gameplay_Variables.Player_3_Throw_Score == Greatest_Throw_Score)
        {
            Player_3_Throw_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_3_Throw_Score.GetComponent<Text>().color = Normal_Color;

        }

        if (Gameplay_Variables.Player_4_Throw_Score == Greatest_Throw_Score)
        {
            Player_4_Throw_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_4_Throw_Score.GetComponent<Text>().color = Normal_Color;

        }



        int[] Player_Catch_Scores = { Gameplay_Variables.Player_1_Catch_Score, Gameplay_Variables.Player_2_Catch_Score, Gameplay_Variables.Player_3_Catch_Score, Gameplay_Variables.Player_4_Catch_Score };

        int Greatest_Catch_Scores = Game_Design_Functions.Find_Greatest_In_Int_Array(Player_Catch_Scores);

        if (Gameplay_Variables.Player_1_Catch_Score == Greatest_Catch_Scores)
        {
            Player_1_Catch_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_1_Catch_Score.GetComponent<Text>().color = Normal_Color;
        }

        if (Gameplay_Variables.Player_2_Catch_Score == Greatest_Catch_Scores)
        {
            Player_2_Catch_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_2_Catch_Score.GetComponent<Text>().color = Normal_Color;

        }

        if (Gameplay_Variables.Player_3_Catch_Score == Greatest_Catch_Scores)
        {
            Player_3_Catch_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_3_Catch_Score.GetComponent<Text>().color = Normal_Color;

        }

        if (Gameplay_Variables.Player_4_Catch_Score == Greatest_Catch_Scores)
        {
            Player_4_Catch_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_4_Catch_Score.GetComponent<Text>().color = Normal_Color;

        }


        int[] Player_Chest_Score = { Gameplay_Variables.Player_1_Chest_Score, Gameplay_Variables.Player_2_Chest_Score, Gameplay_Variables.Player_3_Chest_Score, Gameplay_Variables.Player_4_Chest_Score };

        int Greatest_Chest_Score = Game_Design_Functions.Find_Greatest_In_Int_Array(Player_Chest_Score);

        if (Gameplay_Variables.Player_1_Chest_Score == Greatest_Chest_Score)
        {
            Player_1_Chest_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_1_Chest_Score.GetComponent<Text>().color = Normal_Color;
        }

        if (Gameplay_Variables.Player_2_Chest_Score == Greatest_Chest_Score)
        {
            Player_2_Chest_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_2_Chest_Score.GetComponent<Text>().color = Normal_Color;

        }

        if (Gameplay_Variables.Player_3_Chest_Score == Greatest_Chest_Score)
        {
            Player_3_Chest_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_3_Chest_Score.GetComponent<Text>().color = Normal_Color;

        }

        if (Gameplay_Variables.Player_4_Catch_Score == Greatest_Chest_Score)
        {
            Player_4_Chest_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_4_Chest_Score.GetComponent<Text>().color = Normal_Color;

        }


        int[] Enemy_Scores = { Gameplay_Variables.Player_1_Enemy_Score, Gameplay_Variables.Player_2_Enemy_Score, Gameplay_Variables.Player_3_Enemy_Score, Gameplay_Variables.Player_4_Enemy_Score };

        int Greatest_Enemy_SCore = Game_Design_Functions.Find_Greatest_In_Int_Array(Enemy_Scores);

        if (Gameplay_Variables.Player_1_Enemy_Score == Greatest_Enemy_SCore)
        {
            Player_1_Enemy_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_1_Enemy_Score.GetComponent<Text>().color = Normal_Color;
        }

        if (Gameplay_Variables.Player_2_Enemy_Score == Greatest_Enemy_SCore)
        {
            Player_2_Enemy_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_2_Enemy_Score.GetComponent<Text>().color = Normal_Color;

        }

        if (Gameplay_Variables.Player_3_Enemy_Score == Greatest_Enemy_SCore)
        {
            Player_3_Enemy_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_3_Enemy_Score.GetComponent<Text>().color = Normal_Color;

        }

        if (Gameplay_Variables.Player_4_Enemy_Score == Greatest_Enemy_SCore)
        {
            Player_4_Enemy_Score.GetComponent<Text>().color = Best_Color;
        }
        else
        {
            Player_4_Enemy_Score.GetComponent<Text>().color = Normal_Color;

        }
    }

    public void Controller_Move_On_Scene()
    {
        if (Input.GetButtonDown(Player_1_Controls.Player_Button_Start))
        {
            Transition_Script.Can_Transition = true;
        }

        if (Input.GetButtonDown(Player_2_Controls.Player_Button_Start))
        {
            Transition_Script.Can_Transition = true;
        }
       
       if (Input.GetButtonDown(Player_3_Controls.Player_Button_Start))
        {
            Transition_Script.Can_Transition = true;
        }

        if (Input.GetButtonDown(Player_4_Controls.Player_Button_Start))
        {
            Transition_Script.Can_Transition = true;
        }
    }

}
