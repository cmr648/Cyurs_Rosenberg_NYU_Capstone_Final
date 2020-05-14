using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Default_Enemy_Behavior : MonoBehaviour
{
    public GameObject Player_Target; // a gameobejct for the player target

    public float Speed;

    GameObject[] Active_Players;

    public List<GameObject> Current_Active_Players;

    // Start is called before the first frame update
    void Start()
    {
        Active_Players = GameObject.FindGameObjectsWithTag("Player"); //setting up our active players script

        Current_Active_Players.AddRange(Active_Players); // adding all players to our active players list

        for(int i = 0; i < Current_Active_Players.Count; i++) // for each player in ou rplayer list
        {
            if(Current_Active_Players[i].GetComponent<Player_Stats>().Player_Dead == true) // if the player is dead
            {
                Current_Active_Players.Remove(Current_Active_Players[i]); // remove him from the list of current active players
            }
        }


        Find_Player_Target(); // implementing our player target gameobejct
        GetComponent<AIPath>().maxSpeed = Speed;
        GetComponent<AILerp>().speed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        Active_Players = GameObject.FindGameObjectsWithTag("Player"); //setting up our active players script

        Reset_Player_Target(); // resetting the player target if a player dies
    }

    void Find_Player_Target() // find the player target at the start of the game
    {
        GetComponent<AIPath>().target = Game_Design_Functions.Find_Closest_Gameobject(transform, Current_Active_Players.ToArray()).GetComponent<Transform>();
        Player_Target = GetComponent<AIPath>().target.gameObject; // getting our targer
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag == "Player")
        //{
        //    collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //    collision.gameObject.GetComponent<Player_Stats>().Player_Current_Health -= collision.gameObject.GetComponent<Player_Stats>().Health_Loss_Units;
        //    Destroy(gameObject);
        //}
    }

    void Reset_Player_Target() // a function to find a new player target if the player dies
    {
        if(Player_Target.GetComponent<Player_Stats>().Player_Dead == true) // if a player is ever dead
        {
            Find_Player_Target(); // find another player target and run it again if the player that we were going towards is dead
        }

        if(GetComponent<AIPath>().target.GetComponent<Player_Stats>().Player_Dead == true)
        {
            Find_Player_Target();
        }
    }



}
