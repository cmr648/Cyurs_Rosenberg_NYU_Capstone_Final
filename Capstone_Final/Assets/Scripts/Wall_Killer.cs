using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Wall_Killer : MonoBehaviour
{

    public AIPath Enemy_Path; // finding enemy path

    public GameObject Player_To_Find; // finding a player to lock onto

    List<GraphNode> GetNodes; // a list of all nodes

    public bool Can_Travel; //a bool to see if there is an avalible path


    // Start is called before the first frame update
    void Start()
    {

        Player_To_Find = Game_Design_Functions.Find_Closest_Gameobject(transform, GameObject.FindGameObjectsWithTag("Player")); // finding the closest player
        GetComponent<AIDestinationSetter>().target = Player_To_Find.transform; // setting our player to find up




    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PathUtilities.IsPathPossible(AstarPath.active.GetNearest(transform.position).node, AstarPath.active.GetNearest(Player_To_Find.transform.position).node)){ // if there is an avalible path to our gameobjecr

            Can_Travel = true; // set our can travel bool to false

        }
        else if(PathUtilities.IsPathPossible(AstarPath.active.GetNearest(transform.position).node, AstarPath.active.GetNearest(Player_To_Find.transform.position).node) == false) // if there is no avalible path to our gameobject
        {

           

            Can_Travel = false; // set our can travel bool to false
        }



        if(Can_Travel == false) // if the path is blocked
        {
            Destroy(Game_Design_Functions.Find_Closest_Gameobject(transform, GameObject.FindGameObjectsWithTag("Wall"))); //find the closest wall, kill it

        }
        else if(Can_Travel == true)
        {
            GetComponent<Wall_Killer>().enabled = false;
        }





    }




}
