using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_Score_Tracker : MonoBehaviour {

    public Text Player_1_Text;
    public Text Player_2_Text;
    public Text Player_3_Text;
    public Text Player_4_Text;




	// Use this for initialization
	void Start () {

        Important_Variables.Player_1_Score = 0;
        Important_Variables.Player_2_Score = 0;
        Important_Variables.Player_3_Score = 0;
        Important_Variables.Player_4_Score = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

        Player_1_Text.text = "Player 1 Score: " + Important_Variables.Player_1_Score;
        Player_2_Text.text = "Player 2 Score: " + Important_Variables.Player_2_Score;
        Player_3_Text.text = "Player 3 Score: " + Important_Variables.Player_3_Score;
        Player_4_Text.text = "Player 4 Score: " + Important_Variables.Player_4_Score;




	}
}
