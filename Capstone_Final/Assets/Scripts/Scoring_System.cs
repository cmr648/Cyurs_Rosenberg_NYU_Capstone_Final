using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring_System : MonoBehaviour
{
    [Header ("Individual Player Scores")]
    // setting slots to store our scores
    public Player_Score Player_1_Score;
    public Player_Score Player_2_Score;
    public Player_Score Player_3_Score;
    public Player_Score Player_4_Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Set_Gameplay_Variables(); // setting our gameplay variables

    }

    void Set_Gameplay_Variables()
    {
        Gameplay_Variables.Player_1_Coin_Score = Player_1_Score.Coin_Score;
        Gameplay_Variables.Player_1_Catch_Score = Player_1_Score.Catch_Score;
        Gameplay_Variables.Player_1_Chest_Score = Player_1_Score.Chest_Opened_Score;
        Gameplay_Variables.Player_1_Enemy_Score = Player_1_Score.Enemies_Killed_Score;
        Gameplay_Variables.Player_1_Throw_Score = Player_1_Score.Throw_Score;

        Gameplay_Variables.Player_2_Coin_Score = Player_2_Score.Coin_Score;
        Gameplay_Variables.Player_2_Catch_Score = Player_2_Score.Catch_Score;
        Gameplay_Variables.Player_2_Chest_Score = Player_2_Score.Chest_Opened_Score;
        Gameplay_Variables.Player_2_Enemy_Score = Player_2_Score.Enemies_Killed_Score;
        Gameplay_Variables.Player_2_Throw_Score = Player_2_Score.Throw_Score;

        Gameplay_Variables.Player_3_Coin_Score = Player_3_Score.Coin_Score;
        Gameplay_Variables.Player_3_Catch_Score = Player_3_Score.Catch_Score;
        Gameplay_Variables.Player_3_Chest_Score = Player_3_Score.Chest_Opened_Score;
        Gameplay_Variables.Player_3_Enemy_Score = Player_3_Score.Enemies_Killed_Score;
        Gameplay_Variables.Player_3_Throw_Score = Player_3_Score.Throw_Score;

        Gameplay_Variables.Player_4_Coin_Score = Player_4_Score.Coin_Score;
        Gameplay_Variables.Player_4_Catch_Score = Player_4_Score.Catch_Score;
        Gameplay_Variables.Player_4_Chest_Score = Player_4_Score.Chest_Opened_Score;
        Gameplay_Variables.Player_4_Enemy_Score = Player_4_Score.Enemies_Killed_Score;
        Gameplay_Variables.Player_4_Throw_Score = Player_4_Score.Throw_Score;


    }
}


[System.Serializable]
public class Player_Score // creating a system for all of our player scores
{
    public int Coin_Score;
    public int Throw_Score;
    public int Catch_Score;
    public int Enemies_Killed_Score;
    public int Chest_Opened_Score;
}
