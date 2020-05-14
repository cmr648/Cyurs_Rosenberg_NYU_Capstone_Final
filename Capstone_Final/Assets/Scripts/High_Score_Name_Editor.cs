using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class High_Score_Name_Editor : MonoBehaviour
{
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Accept;

    public int Alphabet_Index;
    public int Letter_Index;

    public Text[] High_Score_Letters;

    public string Index_Letter;

    public float Blink_Time;

    public GameObject Blinking_Letter;

    public string High_Score_Text;

    [Header("Player_Controls")]
    public Arcade_Controls Player_1_Controls;
    public Arcade_Controls Player_2_Controls;
    public Arcade_Controls Player_3_Controls;
    public Arcade_Controls Player_4_Controls;




    // Start is called before the first frame update
    void Start()
    {
        Letter_Index = 0;


    }

    // Update is called once per frame
    void Update()
    {
        Move_Index();
        Move_Index_Arcade_Controls(); // using our arcade controls to move indx as well
        Assign_Index_Letter();
        Letter_Selection();
           
        High_Score_Text = High_Score_Letters[0].text + High_Score_Letters[1].text + High_Score_Letters[2].text + High_Score_Letters[3].text;
    }

    void Move_Index() // replace with arcade controls
    {
        if (Input.GetKeyDown(Up))
        {
            Alphabet_Index += 1;
        }

        if (Input.GetKeyDown(Down))
        {
            Alphabet_Index -= 1;
        }

        if(Alphabet_Index > 26)
        {
            Alphabet_Index = 0;
        } 

        if (Alphabet_Index < 0)
        {
            Alphabet_Index = 26;
        }

        if (Input.GetKeyDown(Accept))
        {
            Letter_Index += 1;
            Alphabet_Index = 0; // setting the letter back to bieng A

        }
    }

    void Move_Index_Arcade_Controls()
    {
        #region Player_1_Controls
        //PLAYER 1 CONTROLS
        if (Gameplay_Variables.Player_1_In_Game == true)
        {

            if (Input.GetAxis(Player_1_Controls.Player_Axis_Y) == 1)
            {
                if (Player_1_Controls.Player_Y_In_Use == false)
                {

                    Alphabet_Index += 1;
                }
            }

            if (Input.GetAxis(Player_1_Controls.Player_Axis_Y) == -1)
            {
                if (Player_1_Controls.Player_Y_In_Use == false)
                {

                    Alphabet_Index -= 1;

                }
            }
        }

        if (Input.GetButtonDown(Player_1_Controls.Player_Button_A)) // if we press our a button
        {
            Letter_Index += 1; // ACCEPT
            Alphabet_Index = 0; // setting the letter back to bieng A
        }

        if (Input.GetAxis(Player_1_Controls.Player_Axis_Y) == 0) // if our controller is at rest
        {
            Player_1_Controls.Player_Y_In_Use = false; // we are not using it
        }
        else
        {
            Player_1_Controls.Player_Y_In_Use = true; // we are using it
        }

        #endregion

        #region Player_2_Controls
        //PLAYER 1 CONTROLS
        if (Gameplay_Variables.Player_2_In_Game == true)
        {

            if (Input.GetAxis(Player_2_Controls.Player_Axis_Y) == 1)
            {
                if (Player_2_Controls.Player_Y_In_Use == false)
                {

                    Alphabet_Index += 1;
                }
            }

            if (Input.GetAxis(Player_2_Controls.Player_Axis_Y) == -1)
            {
                if (Player_2_Controls.Player_Y_In_Use == false)
                {

                    Alphabet_Index -= 1;

                }
            }
        }

        if (Input.GetButtonDown(Player_2_Controls.Player_Button_A)) // if we press our a button
        {
            Letter_Index += 1; // ACCEPT
            Alphabet_Index = 0; // setting the letter back to bieng A
        }

        if (Input.GetAxis(Player_2_Controls.Player_Axis_Y) == 0) // if our controller is at rest
        {
            Player_2_Controls.Player_Y_In_Use = false; // we are not using it
        }
        else
        {
            Player_2_Controls.Player_Y_In_Use = true; // we are using it
        }

        #endregion

        #region Player_3_Controls
        //PLAYER 1 CONTROLS
        if (Gameplay_Variables.Player_3_In_Game == true)
        {

            if (Input.GetAxis(Player_3_Controls.Player_Axis_Y) == 1)
            {
                if (Player_3_Controls.Player_Y_In_Use == false)
                {

                    Alphabet_Index += 1;
                }
            }

            if (Input.GetAxis(Player_3_Controls.Player_Axis_Y) == -1)
            {
                if (Player_3_Controls.Player_Y_In_Use == false)
                {

                    Alphabet_Index -= 1;

                }
            }
        }

        if (Input.GetButtonDown(Player_3_Controls.Player_Button_A)) // if we press our a button
        {
            Letter_Index += 1; // ACCEPT
            Alphabet_Index = 0; // setting the letter back to bieng A
        }

        if (Input.GetAxis(Player_3_Controls.Player_Axis_Y) == 0) // if our controller is at rest
        {
            Player_3_Controls.Player_Y_In_Use = false; // we are not using it
        }
        else
        {
            Player_3_Controls.Player_Y_In_Use = true; // we are using it
        }

        #endregion

        #region Player_4_Controls
        //PLAYER 1 CONTROLS
        if (Gameplay_Variables.Player_4_In_Game == true)
        {

            if (Input.GetAxis(Player_4_Controls.Player_Axis_Y) == 1)
            {
                if (Player_4_Controls.Player_Y_In_Use == false)
                {

                    Alphabet_Index += 1;
                }
            }

            if (Input.GetAxis(Player_4_Controls.Player_Axis_Y) == -1)
            {
                if (Player_4_Controls.Player_Y_In_Use == false)
                {

                    Alphabet_Index -= 1;

                }
            }
        }

        if (Input.GetButtonDown(Player_4_Controls.Player_Button_A)) // if we press our a button
        {
            Letter_Index += 1; // ACCEPT
            Alphabet_Index = 0; // setting the letter back to bieng A
        }

        if (Input.GetAxis(Player_4_Controls.Player_Axis_Y) == 0) // if our controller is at rest
        {
            Player_4_Controls.Player_Y_In_Use = false; // we are not using it
        }
        else
        {
            Player_4_Controls.Player_Y_In_Use = true; // we are using it
        }

        #endregion



    }



    void Letter_Selection()
    {
        for(int i = 0; i < High_Score_Letters.Length; i++) // for every hihg score letter
        { 
            if (i == Letter_Index)
            {
                High_Score_Letters[i].text = Index_Letter;
                Blinking_Letter = High_Score_Letters[i].gameObject;


                float J = Mathf.PingPong(Time.time, .5f);

                if(J > .25f)
                {
                    High_Score_Letters[i].enabled = false;
                }
                else
                {
                    High_Score_Letters[i].enabled = true;
                }
            }
            else
            {
                High_Score_Letters[i].enabled = true;
            }

        }

       
    }



    IEnumerator Blink(GameObject Object)
    {

        while (true)
        {
          
                Object.GetComponent<Text>().enabled = false;
                yield return new WaitForSeconds(Blink_Time);
                Object.GetComponent<Text>().enabled = true;
                yield return new WaitForSeconds(Blink_Time);
            
        }


    }



    void Assign_Index_Letter()
    {
        if(Alphabet_Index == 0)
        {
            Index_Letter = "A";
        }

        if (Alphabet_Index == 1)
        {
            Index_Letter = "B";
        }

        if (Alphabet_Index == 2)
        {
            Index_Letter = "C";
        }

        if (Alphabet_Index == 3)
        {
            Index_Letter = "D";
        }

        if (Alphabet_Index == 4)
        {
            Index_Letter = "D";
        }

        if (Alphabet_Index == 5)
        {
            Index_Letter = "E";
        }

        if (Alphabet_Index == 6)
        {
            Index_Letter = "F";
        }

        if (Alphabet_Index == 7)
        {
            Index_Letter = "G";
        }

        if (Alphabet_Index == 8)
        {
            Index_Letter = "H";
        }

        if (Alphabet_Index == 9)
        {
            Index_Letter = "I";
        }

        if (Alphabet_Index == 10)
        {
            Index_Letter = "J";
        }

        if (Alphabet_Index == 11)
        {
            Index_Letter = "K";
        }

        if (Alphabet_Index == 12)
        {
            Index_Letter = "L";
        }

        if (Alphabet_Index == 13)
        {
            Index_Letter = "M";
        }

        if (Alphabet_Index == 14)
        {
            Index_Letter = "N";
        }

        if (Alphabet_Index == 15)
        {
            Index_Letter = "O";
        }

        if (Alphabet_Index == 16)
        {
            Index_Letter = "P";
        }

        if (Alphabet_Index == 17)
        {
            Index_Letter = "Q";
        }

        if (Alphabet_Index == 18)
        {
            Index_Letter = "R";
        }

        if (Alphabet_Index == 19)
        {
            Index_Letter = "S";
        }

        if (Alphabet_Index == 20)
        {
            Index_Letter = "T";
        }

        if (Alphabet_Index == 21)
        {
            Index_Letter = "U";
        }

        if (Alphabet_Index == 22)
        {
            Index_Letter = "V";
        }

        if (Alphabet_Index == 23)
        {
            Index_Letter = "W";
        }

        if (Alphabet_Index == 24)
        {
            Index_Letter = "X";
        }

        if (Alphabet_Index == 25)
        {
            Index_Letter = "Y";
        }

        if (Alphabet_Index == 26)
        {
            Index_Letter = "Z";
        }
    }
}
