using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use_Ammo_Pickup : MonoBehaviour
{
    [Header("Ammo Pack Stats")]
    public float Ammo_To_Gain; // the amount of ammo a player will gain by using this health pack

    [Header ("Accessed Scripts")]
    [SerializeField]
    Player_Controls_Manager Player_Controls; // getting the player controls manager
    [SerializeField]
    Player_Stats Player_Stats; // Getting the player stats maanger
    [SerializeField]
    Pickup_Item_New Player_Pickup; // getting the player pickup item script


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null) // if we are bieng held
        {
            Player_Controls = gameObject.transform.root.gameObject.GetComponent<Player_Controls_Manager>(); // assiging our player controls manager
            Player_Stats = gameObject.transform.root.gameObject.GetComponent<Player_Stats>(); // assigning our player stats 
            Player_Pickup = gameObject.transform.root.gameObject.GetComponent<Pickup_Item_New>(); // assigining our pickup item script
           

            if (Input.GetKeyDown(Player_Controls.Use_Item)) // if we click our use item button
            {
                Player_Stats.Player_Current_Ammo += Ammo_To_Gain; // adding our health to our player current health
                Player_Pickup.Current_Held_Item = null; // drop our item
                Player_Pickup.Is_Holding_Item = false; // say we are not holding an item
                Destroy(gameObject); // get rid of this health pack
            }
        }
        else
        {
            Player_Controls = null; // set the player controls to nothing
            Player_Stats = null; // setting our player stats to nothing
            Player_Pickup = null;
        }
    }
}
