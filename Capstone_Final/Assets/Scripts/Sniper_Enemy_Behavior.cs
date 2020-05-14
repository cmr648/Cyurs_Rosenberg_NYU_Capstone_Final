using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Sniper_Enemy_Behavior : MonoBehaviour
{
    [Header("Scene_Data")]
    public GameObject[] Active_Players; // a list for all of the active players

    AIDestinationSetter Enemy_Destination_Setter;
    public AIPath Enmey_Path;

    [Header("Shooting")]
    public bool Can_Rotate;


    [Header("Stats")]
    public float Rotate_Speed;

    public List<GameObject> Spawner;

    // Start is called before the first frame update
    void Start()
    {
        Can_Rotate = true;
       
        Enmey_Path = GetComponent<AIPath>();
        Enemy_Destination_Setter = GetComponent<AIDestinationSetter>(); // assigning our ai destination setter
        StartCoroutine("Set_Position");
    }

    // Update is called once per frame
    void Update()
    {
       
        Active_Players = GameObject.FindGameObjectsWithTag("Player"); // adding all active players to our list


        Look_At_Player();
        Stop_Player();

    }

    void Look_At_Player() //a function to always look at the closest player
    {
        if (Can_Rotate == true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Game_Design_Functions.Look_At_Object_2D_Y_Forward(gameObject, Game_Design_Functions.Find_Furthest_Gameobject(transform, Active_Players)), Time.deltaTime * Rotate_Speed); // look at the closest player
        }
    }

    IEnumerator Set_Position()
    {
        yield return new WaitForSeconds(1);

        GameObject Furthest_Player = Game_Design_Functions.Find_Furthest_Gameobject(transform, Active_Players);


        GameObject Furthest_Enemy_Point = Game_Design_Functions.Find_Furthest_Gameobject(Furthest_Player.transform, Spawner.ToArray());

     

        Enemy_Destination_Setter.target = Furthest_Enemy_Point.transform;
    }

    void Stop_Player()
    {
            if(Enemy_Destination_Setter.target != null)
            {

                Debug.Log(Vector2.Distance(transform.position, Enemy_Destination_Setter.target.position));
                if (Vector2.Distance(transform.position, Enemy_Destination_Setter.target.position) <= 3)
                {
                    Enmey_Path.canMove = false;
                }
            }

        



    }

}





