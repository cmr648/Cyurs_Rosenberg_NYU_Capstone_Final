using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_Item : MonoBehaviour
{
    public float Throw_Force; // the force in which we want to throw our item at

    Pickup_Item_New Item_Sript; // our playes pickup item script


    public GameObject Throw_Object; // the object we are going to throw

    Player_Controls_Manager Player_Controls; // creating a slot for player cotnrols

    Pickup_Item_New Pickup_Item_Player;

    [Header("Physics")]
    public PhysicsMaterial2D Bouncy_Material;

    [Header("Throw Stats")]
    public float Weapon_Throw_Dead_Time;

    // Start is called before the first frame update
    void Start()
    {
        Item_Sript = GetComponent<Pickup_Item_New>(); //getting our pickup_item_New Script
        Player_Controls = GetComponent<Player_Controls_Manager>(); // assiginging our player controls
        Pickup_Item_Player = GetComponent<Pickup_Item_New>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Throw_The_Item();

    }

    void Throw_The_Item()
    {
        if(Item_Sript.Current_Held_Item != null) // if we have an item in our hands
        {
            if (Item_Sript.Current_Held_Item.GetComponent<Rigidbody2D>() != null) // if the current held item has a rigidbody 
            {
                Destroy(Item_Sript.Current_Held_Item.GetComponent<Rigidbody2D>()); // delete it
            }

        }

       
       if (Input.GetKeyDown(Player_Controls.Throw_Item) || Input.GetButtonDown(Player_Controls.Player_Arcade_Controls.Player_Button_X)) // if we hit our throw item key from our player controls script
        {
            Create_Item_Rigidbody(Item_Sript.Current_Held_Item); // creat a rigidbody on the item we are throwing
            if(Throw_Object != null) // if we have a throw object
            {
                Throw_Score_Player(gameObject); // adding one to our throw score

                GetComponent<Pickup_Item_New>().Down_Scale_UI(GetComponent<Pickup_Item_New>().UI_Image); // downscaling our UI in the event that we throw anything 

                //SOUND
                Stop_Weapon_Sound(); // implementing our stop weapon sound function
                //THROWING OUR OBJECT
                // Throw_Object.layer = 10;

                // Throw_Object.gameObject.layer = Throw_Object.GetComponent<Assign_Layer>().Original_Layer;

                StartCoroutine(Reassign_Layer(Throw_Object)); // reassiging our thrown item to its original layer

                Throw_Object.GetComponent<Rigidbody2D>().AddForce(transform.up * Throw_Force); // throw the item in the direction we are pointing
                Throw_Object = null; // set our throw object slot to be empty

                Throw_Audio(); // doing our throw audio script
            }

        }
    }

    void Create_Item_Rigidbody(GameObject Rigidbody_Assigned_Item) // a function for adding a rigidbody to an item
    {
        if(Item_Sript.Current_Held_Item != null) // if we are currently holding an item
        {
            Item_Sript.Current_Held_Item.transform.parent = null; // drop the item
            Item_Sript.Current_Held_Item.GetComponent<PolygonCollider2D>().isTrigger = false; // reset the item to be a trigger
            Item_Sript.Is_Holding_Item = false; // say we are not holdin an item
            Throw_Object = Item_Sript.Current_Held_Item; // add the item to our throw script
            Item_Sript.Current_Held_Item = null; // set the current held item to nothing
            Rigidbody_Assigned_Item.AddComponent<Rigidbody2D>(); // add a rigidbody to the item
            Rigidbody_Assigned_Item.GetComponent<Rigidbody2D>().gravityScale = 0; // set 0 gravity to the item
            Rigidbody_Assigned_Item.GetComponent<Rigidbody2D>().sharedMaterial = Bouncy_Material; // setting our material to be bouncy
        }
       
    }

   

    void Throw_Score_Player(GameObject Player) 
    {
        if (Player.gameObject.name == "Player_1")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_1_Score.Throw_Score += 1;
        }

        if (Player.gameObject.name == "Player_2")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_2_Score.Throw_Score += 1;
        }

        if (Player.gameObject.name == "Player_3")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_3_Score.Throw_Score += 1;
        }

        if (Player.gameObject.name == "Player_4")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_4_Score.Throw_Score += 1;
        }
    }


    void Throw_Audio() // setting up throwing a random audio clip
    {
        //string[] Throw_Clips = { "Throw1", "Throw2", "Throw3" };
        //int Index = Random.Range(0, Throw_Clips.Length);

        FindObjectOfType<Audio_Manager>().Play_Sound("Throw");

    }

    IEnumerator Reassign_Layer(GameObject Layer_Object) // reassiging the original layer to a specific gameobject
    {
        yield return null; // FOR NOW WAIT UNTILL THE END OF THE FRAME
       // yield return new WaitForSeconds(Weapon_Throw_Dead_Time); // waiting a certain amount of time
        Layer_Object.gameObject.layer = Layer_Object.GetComponent<Assign_Layer>().Original_Layer; // reassignign the layer
    }

    void Stop_Weapon_Sound() // a function to stop our weapon sound
    {
        if(Throw_Object.gameObject.tag != "Coin" && Throw_Object.gameObject.tag != "Health_Pack") // making sure the object that we are throwing is a weapon
        {
            if (Throw_Object.GetComponent<Fire_Weapon>().enabled == true) // if this is a standard weapon
            {
                Throw_Object.GetComponent<Fire_Weapon>().StopCoroutine("Fire_Gun"); // stop the fire gun coroutine
            }

            if (Throw_Object.GetComponent<laser>().enabled == true) // if this weapon is a laser
            {
                if (gameObject.name == "Player_1") // if our player is 1
                {
                    FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 1"); // pause laser fire 1
                }

                if (gameObject.name == "Player_2") // if our player is 2 
                {
                    FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 2"); // pause our laser sound
                }
                if (gameObject.name == "Player_3") // if our player is 3
                {
                    FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 3"); // pause our laser sound
                }
                if (gameObject.name == "Player_4") // if our player is 4
                {
                    FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 4"); // pause our laser sound
                }
            }
        }
    }

}
