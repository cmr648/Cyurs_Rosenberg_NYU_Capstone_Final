using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Assignment : MonoBehaviour {

    public float Player_Assignment_Number; // creatingn a public float for character assignments

	// Use this for initialization
	void Start () {
        Assign_Keys(); // implementinng our assigning of different player keys
        Assign_Arrows(); // implementinng and assignninng
        Assign_Mateirals(); // assigning materials to our players
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Assign_Keys(){ // creating a void to assign sperate keys to our players

        if(Player_Assignment_Number == 1){ // checking to see if our player is player 1

            GetComponent<Add_Force_On_Button>().Button_To_Press = Important_Variables.Player_1_Launch_Key; // assigning payer 1 launcnh key to this player

        } else if(Player_Assignment_Number == 2){ // checking to see if our player is player 1

            GetComponent<Add_Force_On_Button>().Button_To_Press = Important_Variables.Player_2_Launch_Key; // assigning payer 2 launcnh key to this player

        } else if(Player_Assignment_Number == 3){ // checking to see if our player is player 1

            GetComponent<Add_Force_On_Button>().Button_To_Press = Important_Variables.Player_3_Launch_Key; // assigning payer 3 launcnh key to this player

        } else if(Player_Assignment_Number == 4){ // checking to see if our player is player 1

            GetComponent<Add_Force_On_Button>().Button_To_Press = Important_Variables.Player_4_Launch_Key; // assigning payer 4 launcnh key to this player

        } 


    }

    void Assign_Arrows(){ // creating a void to assign arrows

        if(Player_Assignment_Number == 1){ // if our player assignmennt number = 1
            GetComponentInChildren<Rotate_Arrow>().Left_Arrow = Important_Variables.Player_1_Left;
            GetComponentInChildren<Rotate_Arrow>().Right_Arrow = Important_Variables.Player_1_Right;

        


        } else if (Player_Assignment_Number == 2) { // if our player assignmennt number = 1

            GetComponentInChildren<Rotate_Arrow>().Left_Arrow = Important_Variables.Player_2_Left;
            GetComponentInChildren<Rotate_Arrow>().Right_Arrow = Important_Variables.Player_2_Right;


        } else if (Player_Assignment_Number == 3)  { // if our player assignmennt number = 1

            GetComponentInChildren<Rotate_Arrow>().Left_Arrow = Important_Variables.Player_3_Left;
            GetComponentInChildren<Rotate_Arrow>().Right_Arrow = Important_Variables.Player_3_Right;


        } else if (Player_Assignment_Number == 4) { // if our player assignmennt number = 1

           
            GetComponentInChildren<Rotate_Arrow>().Left_Arrow = Important_Variables.Player_4_Left;
            GetComponentInChildren<Rotate_Arrow>().Right_Arrow = Important_Variables.Player_4_Right;



        }



    }

    void Assign_Mateirals(){

        if (Player_Assignment_Number == 1)
        { // if our player assignmennt number = 1

            GetComponent<Renderer>().material = Important_Variables.Material_Player_1;


        }
        else if (Player_Assignment_Number == 2)
        { // if our player assignmennt number = 1

            GetComponent<Renderer>().material = Important_Variables.Material_Player_2;



        }
        else if (Player_Assignment_Number == 3)
        { // if our player assignmennt number = 1
           
            GetComponent<Renderer>().material = Important_Variables.Material_Player_3;



        }
        else if (Player_Assignment_Number == 4)
        { // if our player assignmennt number = 1

            GetComponent<Renderer>().material = Important_Variables.Material_Player_4;



        }


    }

}
