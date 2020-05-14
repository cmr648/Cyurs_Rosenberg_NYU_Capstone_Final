using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; // we will be using the path finding extiension

public class Shoot_Enemy_Behavior : MonoBehaviour
{
    [Header("Attributes")]
    public float Max_Sight_Distance; // creating a float for the max sight distance we can get from our player
    public float Max_Speed; // creating a float for our max speed;
    public float Shoot_Hesitate_Seconds; // creating a float for the time in between shooting bullets
    public float Bullet_Force; // creating a float for how fast we want our bullet to shoot

    [Header("Object Tracking")]
    public GameObject Closest_Player; // a slot to find the closest player and assign

    [Header("Inventory")]
    public GameObject Enemy_Bullet; // a slot for the enemy bullet
    public GameObject Bullet_Pos; // creating a slot for our bullet position

    [Header("Rules")]
    public bool Can_Shoot; // creating a bool for if the Enemy can shoot

    AIDestinationSetter Enemy_Destination_Setter; // creating a slot for our ai destination setter
    AIPath Enemy_AI_PAth; // creating a slot for our ai path
    GameObject[] Players; // creating a slot for an array for all players

    // Start is called before the first frame update
    void Start()
    {
        Enemy_Destination_Setter = GetComponent<AIDestinationSetter>(); // assigning our ai destination setter
        Players = GameObject.FindGameObjectsWithTag("Player");
        Enemy_AI_PAth = GetComponent<AIPath>(); // assiging our ai path
        Can_Shoot = false; // the enemy cannot shoot
        StartCoroutine("Shoot_Player"); // start the shoot player coroutine
    }

    // Update is called once per frame
    void Update()
    {
        Get_Closest_Player(); // get the closest player
        Assign_Destination(); // assiging our destination;
        See_Player();
    }

    void Assign_Destination() // creating a function to assign our desintaion
    {
        if(Closest_Player != null) // if we have a closest player
        {
            Enemy_Destination_Setter.target = Closest_Player.transform; // finding our closest gameobject and making that our destination
        }
    
    }

    void See_Player() // a void for if the enemy sees a player
    {
        if(Vector3.Distance(transform.position,Closest_Player.transform.position) < Max_Sight_Distance) // if we are close enough to the player
        {
            Quaternion New_Rotation = Game_Design_Functions.Look_At_Object_2D_Y_Forward(gameObject, Closest_Player); //if we are close enough look at our closest player
            transform.rotation = New_Rotation; // look at the player gameobject
            Enemy_AI_PAth.enableRotation = false; // disabling AI_Path_Rotation
            Enemy_AI_PAth.maxSpeed = Mathf.Lerp(Enemy_AI_PAth.maxSpeed, 0,Time.deltaTime);
            Can_Shoot = true; // setting can shoot to be true

        }
        else
        {
            Enemy_AI_PAth.enableRotation = true; // Enabling AI_Path_Rotation
            Enemy_AI_PAth.maxSpeed = Mathf.Lerp(Enemy_AI_PAth.maxSpeed, Max_Speed,Time.deltaTime); // lerp the enemy speed down
            Can_Shoot = false; // setting can shoot to be false
        }
    }

    void Get_Closest_Player() // a function to get the closest player
    {
        Closest_Player = Game_Design_Functions.Find_Closest_Gameobject(transform, Players); // returning the closest player to the enemy
    }

    IEnumerator Shoot_Player() // creating a courutine for shooting the player
    {
        while (true) // durring this objects existance
        {
            if(Can_Shoot == true) // if we are allowed to shoot
            {
                GameObject Shoot_Bullet = Instantiate(Enemy_Bullet, Bullet_Pos.transform.position, Quaternion.identity); // instantiating a shoot bullet
                Shoot_Bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * Bullet_Force * 100 * Time.deltaTime); // add a force to the bullet

            }
            yield return new WaitForSeconds(Shoot_Hesitate_Seconds); // shoot hesitate seconds
        }
    }

}
