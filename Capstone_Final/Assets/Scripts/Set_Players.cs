using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_Players : MonoBehaviour
{
    public GameObject[] Player_1_Objects;
    public GameObject[] Player_2_Objects;
    public GameObject[] Player_3_Objects;
    public GameObject[] Player_4_Objects;

    public Start_Level_Controls Controls;

    public KeyCode Begin_Gameplay_Player_1;
    public KeyCode Begin_Gameplay_Player_2;
    public KeyCode Begin_Gameplay_Player_3;
    public KeyCode Begin_Gameplay_Player_4;

    public bool Player_1;
    public bool Player_2;
    public bool Player_3;
    public bool Player_4;

    public bool Can_Start;

    public int How_Many_Players;

    public Pokemon_Shader_Transtion Transition; // a slot for transition script

    [Header("Player Text")] // keeping track of our player text objects
    public Text Player_1_Text;
    public Text Player_2_Text;
    public Text Player_3_Text;
    public Text Player_4_Text;

    [Header("Arcade Controls")]
    public Arcade_Controls Player_1_Controls;
    public Arcade_Controls Player_2_Controls;
    public Arcade_Controls Player_3_Controls;
    public Arcade_Controls Player_4_Controls;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Audio_Manager>().Play_Sound("Player In Game"); // assuming that a single player is in game we have to play our player sound at start

    }

    // Update is called once per frame
    void Update()
    {
        Player_Text_Activate(); // implementing our player text activate

        Set_Objects();
        Show_Objects();

        Start_Game(); // implementing start game


    }

    void Set_Objects()
    {

        if (Input.GetKeyDown(Controls.Player_1_Start) || Input.GetButtonDown(Player_1_Controls.Player_Button_Start)) // TO BE CHANGED TO ARCADE CONTROLS
        {
            Gameplay_Variables.Player_1_In_Game = true;

            FindObjectOfType<Audio_Manager>().Play_Sound("Player In Game");
        }

        if (Input.GetKeyDown(Controls.Player_2_Start) || Input.GetButtonDown(Player_2_Controls.Player_Button_Start)) // TO BE CHANGED TO ARCADE CONTROLS
        {
            Gameplay_Variables.Player_2_In_Game = true;
            FindObjectOfType<Audio_Manager>().Play_Sound("Player In Game");
        }

        if (Input.GetKeyDown(Controls.Player_3_Start) || Input.GetButtonDown(Player_3_Controls.Player_Button_Start)) // TO BE CHANGED TO ARCADE CONTROLS
        {
            Gameplay_Variables.Player_3_In_Game = true;
            FindObjectOfType<Audio_Manager>().Play_Sound("Player In Game");
        }

        if (Input.GetKeyDown(Controls.Player_4_Start) || Input.GetButtonDown(Player_4_Controls.Player_Button_Start)) // TO BE CHANGED TO ARCADE CONTROLS
        {
            Gameplay_Variables.Player_4_In_Game = true;
            FindObjectOfType<Audio_Manager>().Play_Sound("Player In Game");
        }

    }

    void Show_Objects()
    {

        if (Gameplay_Variables.Player_1_In_Game == true)
        {
            foreach (GameObject Player_Object in Player_1_Objects)
            {
                Player_Object.SetActive(true);
            }

            if(Player_1 == false)
            {
                How_Many_Players += 1;
                Player_1 = true;
            }
        }
        else
        {
            foreach (GameObject Player_Object in Player_1_Objects)
            {
                Player_Object.SetActive(false);
            }


        }


        if (Gameplay_Variables.Player_2_In_Game == true)
        {
            foreach (GameObject Player_Object in Player_2_Objects)
            {
                Player_Object.SetActive(true);
            }

            if (Player_2 == false)
            {
                How_Many_Players += 1;
                Player_2 = true;
            }
        }
        else
        {
            foreach (GameObject Player_Object in Player_2_Objects)
            {
                Player_Object.SetActive(false);
            }
        }

        if (Gameplay_Variables.Player_3_In_Game == true)
        {
            foreach (GameObject Player_Object in Player_3_Objects)
            {
                Player_Object.SetActive(true);
            }

            if (Player_3 == false)
            {
                How_Many_Players += 1;
                Player_3 = true;
            }
        }
        else
        {
            foreach (GameObject Player_Object in Player_3_Objects)
            {
                Player_Object.SetActive(false);
            }
        }

        if (Gameplay_Variables.Player_4_In_Game == true)
        {
            foreach (GameObject Player_Object in Player_4_Objects)
            {
                Player_Object.SetActive(true);
            }

            if (Player_4 == false)
            {
                How_Many_Players += 1;
                Player_4 = true;
            }
        }
        else
        {
            foreach (GameObject Player_Object in Player_4_Objects)
            {
                Player_Object.SetActive(false);
            }
        }
    }

    public void Start_Game()
    {
      

        if (How_Many_Players > 0) // if at least one player is in our game
        {
            Can_Start = true;
        }
        else
        {
            Can_Start = false;
        }

        if(Can_Start == true) // if we can start our game
        {
            if(Gameplay_Variables.Player_1_In_Game == true)
            {
                if (Input.GetKeyDown(Begin_Gameplay_Player_1) || Input.GetButtonDown(Player_1_Controls.Player_Button_A) || Input.GetButtonDown(Player_1_Controls.Player_Button_X) || Input.GetButtonDown(Player_1_Controls.Player_Button_B))
                {
                    Transition.Can_Transition = true;
                }
            }

            if (Gameplay_Variables.Player_2_In_Game == true)
            {
                if (Input.GetKeyDown(Begin_Gameplay_Player_2) || Input.GetButtonDown(Player_2_Controls.Player_Button_A) || Input.GetButtonDown(Player_2_Controls.Player_Button_X) || Input.GetButtonDown(Player_2_Controls.Player_Button_B))
                {
                    Transition.Can_Transition = true;
                }
            }


            if (Gameplay_Variables.Player_3_In_Game == true)
            {
                if (Input.GetKeyDown(Begin_Gameplay_Player_3) || Input.GetButtonDown(Player_3_Controls.Player_Button_A) || Input.GetButtonDown(Player_3_Controls.Player_Button_X) || Input.GetButtonDown(Player_3_Controls.Player_Button_B))
                {
                    Transition.Can_Transition = true;
                }
            }

            if (Gameplay_Variables.Player_4_In_Game == true)
            {
                if (Input.GetKeyDown(Begin_Gameplay_Player_4) || Input.GetButtonDown(Player_4_Controls.Player_Button_A) || Input.GetButtonDown(Player_4_Controls.Player_Button_X) || Input.GetButtonDown(Player_4_Controls.Player_Button_B))
                {
                    Transition.Can_Transition = true;
                }
            }

        }

    }

    void Player_Text_Activate() // a function for our player text activate
    {
        if(Gameplay_Variables.Player_1_In_Game == true) // if our player is in the game
        {
            Player_1_Text.text = "Player 1"; // have our player text be player one
            Player_1_Text.gameObject.GetComponent<Text_Blink>().StopCoroutine("Blink_Text"); // deactivate our text blinking
            Player_1_Text.enabled = true; // enable our text
        }
        else // if a player is not in game
        {
            Player_1_Text.text = "Press Start"; // give them the press start option
           

        }


        if (Gameplay_Variables.Player_2_In_Game == true)
        {
            Player_2_Text.text = "Player 2";
            Player_2_Text.gameObject.GetComponent<Text_Blink>().StopCoroutine("Blink_Text");
            Player_2_Text.enabled = true;
        }
        else
        {
            Player_2_Text.text = "Press Start";


        }

        if (Gameplay_Variables.Player_3_In_Game == true)
        {
            Player_3_Text.text = "Player 3";
            Player_3_Text.gameObject.GetComponent<Text_Blink>().StopCoroutine("Blink_Text");
            Player_3_Text.enabled = true;
        }
        else
        {
            Player_3_Text.text = "Press Start";


        }


        if (Gameplay_Variables.Player_4_In_Game == true)
        {
            Player_4_Text.text = "Player 4";
            Player_4_Text.gameObject.GetComponent<Text_Blink>().StopCoroutine("Blink_Text");
            Player_4_Text.enabled = true;
        }
        else
        {
            Player_4_Text.text = "Press Start";


        }
    }
}
