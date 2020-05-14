using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use_Health_Pack : MonoBehaviour
{
    [Header("Health_Pack_Stats")]
    public float Health_To_Gain; // a public float to decide the units taht will be gained by the health pack

    [Header ("Accessed Scripts")]
    [SerializeField]
    Player_Controls_Manager Player_Controls; // getting the player controls manager
    [SerializeField]
    Player_Stats Player_Root_Stats; // Getting the player stats maanger
    [SerializeField]
    Pickup_Item_New Player_Pickup; // getting the player pickup item script

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent != null) // if we are bieng held
        {
            Player_Controls = gameObject.transform.root.gameObject.GetComponent<Player_Controls_Manager>(); // assiging our player controls manager
            Player_Root_Stats = gameObject.transform.root.gameObject.GetComponent<Player_Stats>(); // assigning our player stats 
            Player_Pickup = gameObject.transform.root.gameObject.GetComponent<Pickup_Item_New>(); // assigining our pickup item script

            if (Input.GetKeyDown(Player_Controls.Use_Item)||Input.GetButtonDown(Player_Controls.Player_Arcade_Controls.Player_Button_B)) // if we click our use item button
            {
                FindObjectOfType<Wave_Spawner>().enabled = true; // reenabling our wave spawner component so if we are the last player alive and we have a health apck we can have a buzzer beater moment

                if(FindObjectOfType<End_Conidtions_New>().All_Players_Dead == true) // if all the players are dead and we are acheiving a second wind
                {
                    FindObjectOfType<Second_Wind>().StartCoroutine("Notify_Second_Wind"); // find our second wind text and notify the players
                }


                Restart_Music(); // implementing our restart music function

                Player_Root_Stats.Player_Current_Health += Health_To_Gain; // adding our health to our player current health
                Player_Pickup.Current_Held_Item = null; // drop our item
                Player_Pickup.Is_Holding_Item = false; // say we are not holding an item

                FindObjectOfType<Audio_Manager>().Play_Sound("Health Pack"); // PLAYING A SOUND WHEN WE USE A HEALTH PACK
                Player_Root_Stats.StartCoroutine("Player_Take_Health_Render"); // having our player change color
                Destroy(gameObject); // get rid of this health pack
            }
        }
        else
        {
            Player_Controls = null; // set the player controls to nothing
            Player_Root_Stats = null; // setting our player stats to nothing
            Player_Pickup = null;
        }

    }

    void Restart_Music() // creating a void to conintue our music if we have a buzzer beater scenario
    {
        if(Gameplay_Variables.Level_Art_Set == 0)
        {
            FindObjectOfType<Audio_Manager>().Play_Loop_Sound("Grass Music");
        }

        if (Gameplay_Variables.Level_Art_Set == 1)
        {
            FindObjectOfType<Audio_Manager>().Play_Loop_Sound("Beach Music");
        }

        if (Gameplay_Variables.Level_Art_Set == 2)
        {
            FindObjectOfType<Audio_Manager>().Play_Loop_Sound("Snow Music");
        }

        if (Gameplay_Variables.Level_Art_Set == 3)
        {
            FindObjectOfType<Audio_Manager>().Play_Loop_Sound("Lava Music");
        }
    }



}
