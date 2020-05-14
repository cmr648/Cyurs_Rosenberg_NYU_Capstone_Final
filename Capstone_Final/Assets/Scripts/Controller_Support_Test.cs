using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller_Support_Test : MonoBehaviour
{
    public int Player_Number; // helps decide the player number

    public SpriteRenderer Up_D_Pad;
    public SpriteRenderer Down_D_Pad;
    public SpriteRenderer Left_D_Pad;
    public SpriteRenderer Right_D_Pad;
    public SpriteRenderer A_Button;
    public SpriteRenderer B_Button;
    public SpriteRenderer X_Button;
    public SpriteRenderer Start_Button;



    public Arcade_Controls Controls;



    //IMPORTANT INFORMATION: USE JOYSTICK MAPPER TO FIND OUT THE BUTTON MAPS ON USB CONTROLLER

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move_Player();
        
    }

    void Move_Player()
    {


        if(Input.GetAxis(Controls.Player_Axis_Y)== 1) //UP!
            {
                Up_D_Pad.color = Color.green;

            }
            else
            {
                Up_D_Pad.color = Color.red;
            }

            if (Input.GetAxis(Controls.Player_Axis_Y) == -1) //DOWN
            {
                Down_D_Pad.color = Color.green;

            }
            else
            {
                Down_D_Pad.color = Color.red;
            }

            if (Input.GetAxis(Controls.Player_Axis_X) == 1) //Right
            {
                Right_D_Pad.color = Color.green;

            }
            else
            {
                Right_D_Pad.color = Color.red;
            }


            if (Input.GetAxis(Controls.Player_Axis_X) == -1) //Right
            {
                Left_D_Pad.color = Color.green;

            }
            else
            {
                Left_D_Pad.color = Color.red;
            }


            if (Input.GetButton(Controls.Player_Button_Start))
            {
                Start_Button.color = Color.green;
            }
            else
            {
                Start_Button.color = Color.red;
            }

            if (Input.GetButton(Controls.Player_Button_X))
            {
                X_Button.color = Color.green;
            }
            else
            {
                X_Button.color = Color.red;
            }


            if (Input.GetButton(Controls.Player_Button_A))
            {
                A_Button.color = Color.green;
            }
            else
            {
                A_Button.color = Color.red;
            }

            if (Input.GetButton(Controls.Player_Button_B))
            {
                B_Button.color = Color.green;
            }
            else
            {
                B_Button.color = Color.red;
            }
            

    }

}


[System.Serializable]
public class Arcade_Controls
{
    public bool Player_X_In_Use;
    public bool Player_Y_In_Use;

    [Header("Joystick Axes")]
    public string Player_Axis_X;
    public string Player_Axis_Y;

    [Header ("Buttons")]
    public string Player_Button_Start;
    public string Player_Button_A;
    public string Player_Button_B;
    public string Player_Button_X; 

    
}

