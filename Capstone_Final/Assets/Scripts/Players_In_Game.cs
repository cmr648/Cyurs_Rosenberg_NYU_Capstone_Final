using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players_In_Game : MonoBehaviour
{
    public bool Player_1;
    public bool Player_2;
    public bool Player_3;
    public bool Player_4;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Player_1)
        {
            Gameplay_Variables.Player_1_In_Game = true;
        }
        else
        {
            Gameplay_Variables.Player_1_In_Game = false;
        }

        if (Player_2)
        {
            Gameplay_Variables.Player_2_In_Game = true;
        }
        else
        {
            Gameplay_Variables.Player_2_In_Game = false;
        }

        if (Player_3)
        {
            Gameplay_Variables.Player_3_In_Game = true;
        }
        else
        {
            Gameplay_Variables.Player_3_In_Game = false;
        }

        if (Player_4)
        {
            Gameplay_Variables.Player_4_In_Game = true;
        }
        else
        {
            Gameplay_Variables.Player_4_In_Game = false;
        }

    }



    // Update is called once per frame
    void Update()
    {
      
    }
}
