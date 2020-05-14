using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Behavior : MonoBehaviour
{
    [Header("Items To Spawn")]
    public Item[] Items_To_Spawn; // Creating a public array of the items we want to spawn

    [Header("Animation")]
    Animator Chest_Animator; // creating a reference to our chest animator

    [Header("Chest Location")]
    public Transform Chest_Location; // the chest location we are setting from our wave spawner script to keep track of the enemy location it is at

    public bool Chest_Sound_Played = false;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

        Chest_Animator = GetComponent<Animator>(); // assiging our chest animator

       
    }

    // Update is called once per frame
    void Update()
    {
        Chest_Check(); // implementing our chest check to make sure it doesnt spawn on a portal

    }

    public void Spawn_Item() // a function to spawn the item from a chest
    {
        int Item_Number = Random.Range(0, 100); // a random percent value

        for(int i = 0; i < Items_To_Spawn.Length; i++) //run through each item 1-100 
        {
            if(Item_Number >= Items_To_Spawn[i].Min_Probability_Percent && Item_Number <= Items_To_Spawn[i].Max_Probability_Percent) // if our random number is in the proper percent range
            {
                Instantiate(Items_To_Spawn[i].Item_Object, transform.position, Quaternion.identity); // instantiate the item we want
                break;

            }


        }

        StartCoroutine("Close_Chest"); // after an item is spawned we can clsoe our chest


    }

    private void OnTriggerEnter2D(Collider2D collision) // if something is in our trigger
    {
        if (collision.gameObject.tag == ("Player")) //if the thing in our trigger is a player
        {
            if(Chest_Sound_Played == false) // making sure our chest sound can only play once
            {
                FindObjectOfType<Audio_Manager>().Play_Sound("Chest Open"); // playing chest sound
                Chest_Sound_Played = true;

            }

            Chest_Animator.SetBool("Chest_Opening", true); // setting our chest animations to begin

            Chest_Score_Player(collision.gameObject); // scoring the collision gameobject



         
          
        }
    }

     void Chest_Score_Player(GameObject Player) // creating a score player
    {
        if(Player.gameObject.name == "Player_1")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_1_Score.Chest_Opened_Score += 1;
        }

        if (Player.gameObject.name == "Player_2")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_2_Score.Chest_Opened_Score += 1;
        }

        if (Player.gameObject.name == "Player_3")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_3_Score.Chest_Opened_Score += 1;
        }

        if (Player.gameObject.name == "Player_4")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_4_Score.Chest_Opened_Score += 1;
        }
    }

    public void Spawn_New_Chest(GameObject Collision_Object)
    {
        Wave_Spawner Game_Manager = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Wave_Spawner>(); // look for our wave spawner script

        Game_Manager.Spawn_Chest(); // spawn a new chest somewhere else

        GameObject New = Game_Design_Functions.Find_Closest_Gameobject(transform, GameObject.FindGameObjectsWithTag("Enemy_Location")); // find our closest enemy location

        if(Chest_Location != null)
        {
            Game_Manager.Potential_Enemy_Portal_Locations.Add(Chest_Location); // add that to our potential locations list
        }

    }


    IEnumerator Close_Chest() // setting our chest to close after a certian amount of seconds
    {
        yield return new WaitForSeconds(.5f); // waiting an amount of seconds
        Chest_Animator.SetBool("Chest_Opening", false); // setting the cehst to not open
        Chest_Animator.SetBool("Chest_Closing", true); // setting the chest to close
    }

    public void Destroy_Chest() // a function to destroy our chest
    {
        Destroy(gameObject); // destroying our chest
    }

    public void Chest_Check() // a function to make sure our chest does not spawn on top of any portals 
    {
    

        GameObject Closest_Coin_Portal = Game_Design_Functions.Find_Closest_Gameobject(transform, GameObject.FindGameObjectsWithTag("Coin_Portal")); // find the closest coin portal
        GameObject Closest_Enemy_Portal = Game_Design_Functions.Find_Closest_Gameobject(transform, GameObject.FindGameObjectsWithTag("Enemy_Portal")); // find the closest enemy portal


        //Debug.Log(Vector3.Distance(transform.position, Closest_Coin_Portal.transform.position));

        //Debug.Log(Vector3.Distance(transform.position, Closest_Enemy_Portal.transform.position));

        if (Vector3.Distance(transform.position,Closest_Coin_Portal.transform.position) < .5) // if we are ever within a certain distance of a portal
        {
            Wave_Spawner Game_Manager = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Wave_Spawner>(); // look for our wave spawner script // recheck that portal

            Game_Manager.Spawn_Chest(); // spawn a new chest somewhere else
            Destroy(gameObject); // destroy this chest
        }

        if (Vector3.Distance(transform.position, Closest_Enemy_Portal.transform.position) < .5) // if we are ever within a certain distance of a portal
        {
            Wave_Spawner Game_Manager = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Wave_Spawner>(); // look for our wave spawner script

            Game_Manager.Spawn_Chest(); // spawn a new chest somewhere else
            Destroy(gameObject); // destroy this chest
        }


    }
}




[System.Serializable]
public class Item // creating a class for what an item is
{
    public GameObject Item_Object; // a public gameobject for the item
    public int Min_Probability_Percent = 0; // an int for the minimum percentage
    public int Max_Probability_Percent = 0; // an int for the max percentage
}
