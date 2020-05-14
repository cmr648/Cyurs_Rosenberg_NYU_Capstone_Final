using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manage_UI : MonoBehaviour
{
    [Header ("Coin Portal")]
    public Portal_Behavior Coin_Portal;

    [Header("UI Labels")]
    public Text Score_Text;

    [Header("Stats")]
    public float Lerp_Speed; // the speed for our text to change at

    float Current_Score = 0;

    float Portal_Score; 

    // Start is called before the first frame update
    void Start()
    {
        Current_Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Gameplay_Variables.Team_Score = Mathf.RoundToInt(Current_Score); //setting it to be our current score

        if(Coin_Portal == null) 
        {

            Coin_Portal = GameObject.FindObjectOfType<Portal_Behavior>();



        }
        else // if we have tracked out coin portal
        {
            Portal_Score = Coin_Portal.Coins_Dropped * 10; //possibly chaging when we have an actual score

            Current_Score = Mathf.MoveTowards(Current_Score, Portal_Score, Time.deltaTime * Lerp_Speed); // lerp our actual score

            Score_Text.text = "Score: " + Current_Score.ToString("0"); // setting our text to be our score STRING FORMAT
        }


    }
}
