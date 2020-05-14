using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Kill_Walls : MonoBehaviour
{
    public GameObject[] Enemy_Locations; // assigning our enemy locations

    public GameObject Player_To_Find; // creating a slot for a random player

    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, 5); // destroying the gameobject after 5 seconds

    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Locations = GameObject.FindGameObjectsWithTag("Enemy_Location"); // assigning our enemy locations

        Player_To_Find = GameObject.FindGameObjectWithTag("Player"); // selecting a player

        Look_Open_Paths(); // implementing our look for open paths script

    }

    void Look_Open_Paths() // creating a function to look for open paths
    {
        foreach(GameObject Location in Enemy_Locations) // for every enemy location
        {
            if(Location != null)
            {
                GraphNode Location_Node = AstarPath.active.GetNearest(transform.position).node; // finding the closest node to each enemy location
                GraphNode Player_Node = AstarPath.active.GetNearest(Location.transform.position).node; // finding the closest node to a playe rof our choice

                if (PathUtilities.IsPathPossible(Location_Node, Player_Node) == false) // if no path is possible between an enemy location and a player
                {
                    FindObjectOfType<Wave_Spawner>().Potential_Enemy_Portal_Locations.Remove(Game_Design_Functions.Find_Closest_Gameobject(Location.transform, GameObject.FindGameObjectsWithTag("Wall")).transform); // removing it from potential enemy locations potential CHANGE

                    Destroy(Game_Design_Functions.Find_Closest_Gameobject(Location.transform, GameObject.FindGameObjectsWithTag("Wall"))); // destroy a wal;


                    FindObjectOfType<AstarPath>().Scan(); // rescan
                }
            }
    

        }

    }
}
