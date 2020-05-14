using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_Variables : MonoBehaviour
{

    public static bool Player_1_In_Game;
    public static bool Player_2_In_Game;
    public static bool Player_3_In_Game;
    public static bool Player_4_In_Game;

    public static int Player_1_Coin_Score;
    public static int Player_2_Coin_Score;
    public static int Player_3_Coin_Score;
    public static int Player_4_Coin_Score;

    public static int Player_1_Throw_Score;
    public static int Player_2_Throw_Score;
    public static int Player_3_Throw_Score;
    public static int Player_4_Throw_Score;

    public static int Player_1_Catch_Score;
    public static int Player_2_Catch_Score;
    public static int Player_3_Catch_Score;
    public static int Player_4_Catch_Score;

    public static int Player_1_Enemy_Score;
    public static int Player_2_Enemy_Score;
    public static int Player_3_Enemy_Score;
    public static int Player_4_Enemy_Score;

    public static int Player_1_Chest_Score;
    public static int Player_2_Chest_Score;
    public static int Player_3_Chest_Score;
    public static int Player_4_Chest_Score;

    public static int Level_Art_Set;

    public static int Team_Score;


    // Start is called before the first frame update
    void Start()
    {
        Team_Score = 0;

        Player_1_In_Game = false;
        Player_2_In_Game = false;
        Player_3_In_Game = false;
        Player_4_In_Game = false;

        Player_1_Coin_Score = 0;
        Player_2_Coin_Score = 0;
        Player_3_Coin_Score = 0;
        Player_4_Coin_Score = 0;


        Player_1_Throw_Score = 0;
        Player_2_Throw_Score = 0;
        Player_3_Throw_Score = 0;
        Player_4_Throw_Score = 0;

        Player_1_Catch_Score = 0;
        Player_2_Catch_Score = 0;
        Player_3_Catch_Score = 0;
        Player_4_Catch_Score = 0;

        Player_1_Enemy_Score = 0;
        Player_2_Enemy_Score = 0;
        Player_3_Enemy_Score = 0;
        Player_4_Enemy_Score = 0;

        Player_1_Chest_Score = 0;
        Player_2_Chest_Score = 0;
        Player_3_Chest_Score = 0;
        Player_4_Chest_Score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
