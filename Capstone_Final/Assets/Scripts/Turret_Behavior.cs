using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turret_Behavior : MonoBehaviour
{
    [Header("States")]
    public bool Patroling; // a bool for our patroling state
    public bool Look_At; // a bool for our lookat state
    public bool Shooting; // a bool for our shooting state

    [Header("Stats")]
    public float Max_Sight_Distance; // a float for the max distance the turret can see
    public float Rotation_Speed; // a float for the rotation speed
    public float Amount_Of_Bullets; // a float for the amount of bullets we want fired in a sequence
    public float Time_Between_Bullets; // a float for the amount of time in between fired bullets
    public float Bullet_Force; // amount of force we want applied to each shot bullet
    public float Move_Speed; // the speed we want the turret to move between points
    public float Time_Between_Move; // the hesitation time before the player moves

    [Header("Prefabs")]
    public GameObject Enemy_Bullet; // a prefab for the fired bullet
    public GameObject Target; // a prefab for the sprite of our next target position
    
    [Header ("Locations")]
    public GameObject[] Enemy_Locations; // a gameobject array of all of the enemy positions
    public GameObject[] Players_In_Scene; // a gameobject array of all players currently in scene
    public Transform Bullet_Holder; // a tranform for where we want a bulelt to fire from

    SpriteRenderer Enemy_Renderer; // a slot for our enemy renderer
    PolygonCollider2D Enemy_Collider; // a slot for our enemy collider

    int Location_Index;

    // Start is called before the first frame update
    void Start()
    {
        Enemy_Renderer = GetComponent<SpriteRenderer>(); // assigning the enemy renderer
        Enemy_Collider = GetComponent<PolygonCollider2D>(); // assigning the enemy collider
        StartCoroutine("Shoot_Player"); // starting our shoot player coroutine
        Enemy_Locations = GameObject.FindGameObjectsWithTag("Enemy_Location"); // getting and assigning all enemy locations
        Reset_Index(); // reset the location we want to trabel to
    
           //Patroling = true; // set our patroling state to be true at start

    }

    // Update is called once per frame
    void Update()
    {
        Players_In_Scene = GameObject.FindGameObjectsWithTag("Player");  // finding all objects in scene that are a player


        if(Patroling == true) // if we are patroling
        {
            Patrol(); // use the patrol fucntion
        }

        if(Look_At == true) // if we are looking
        {
            Look_At_Player(); // use the lookat player function
        }

        Set_Target(); // set our new target


        float Distance = Closest_Enemy_Distance(); // find the closest enemy to us
    }

    void Patrol() // a function for when we want to patrol
    {
        //Enemy_Collider.isTrigger = true; // set our collider to be not solid
        Enemy_Renderer.color = Color.Lerp(Enemy_Renderer.color, Color.black,Time.deltaTime *10); // REPLACE WITH ANIMATION
        transform.position = Vector3.MoveTowards(transform.position, Enemy_Locations[Location_Index].transform.position, Time.deltaTime * Move_Speed); // move our player to the new target position

        GameObject Lookat = Target; // create an object out of the target to look at

        // LOOK at the target code (next three lines)
        Vector3 difference = Lookat.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, rotationZ), Time.deltaTime * 2);



        if (transform.position == Enemy_Locations[Location_Index].transform.position) // if we have reached our destination
        {
            // Move to the next state
            Patroling = false;
            Look_At = true;
            Shooting = true;

        }
    }

    void Look_At_Player() //a function for still behavior
    {
       // Enemy_Collider.isTrigger = false; // set our enemy to be solid

        Enemy_Renderer.color = Color.Lerp(Enemy_Renderer.color, Color.yellow, Time.deltaTime * 10); // REPLACE WITH ANIMATION

        float ClosestDistance = Closest_Enemy_Distance(); // set our closest player distance

        transform.Rotate(transform.forward * Time.deltaTime * Rotation_Speed); // rotate our player * rotation speed


        //if(ClosestDistance < Max_Sight_Distance)
        //{
        //    GameObject Player = Closest_Enemy();

        //    Vector3 difference = Player.transform.position - transform.position;
        //    float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        //}
        //else
        //{
        //    transform.Rotate(transform.forward * Time.deltaTime * Rotation_Speed); // rotate * rotation speed
        //}

    }

    IEnumerator Shoot_Player() // a function for shooting at a player
    {
        int Bullets_Shot = 0; // create an int slot for our bullets
        while (true) // forever
        {
            if(Shooting == true) // if we want to be shooting
            {
                GameObject Enemy_Projectile = Instantiate(Enemy_Bullet, Bullet_Holder.position, Quaternion.identity); // create a bullet
                Enemy_Projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * Bullet_Force * 100 * Time.deltaTime); // add a force to the bullet
                Bullets_Shot += 1; // add one to our bullet count
               
            }
            yield return new WaitForSeconds(Time_Between_Bullets); // wait for our hesitation time

            if(Bullets_Shot == Amount_Of_Bullets) // if we shoot the max amount of bulletts
            {
                // move to the next staet
                Reset_Index();
                Look_At = false;
                Shooting = false;
                yield return new WaitForSeconds(Time_Between_Move);
                Patroling = true;

                Bullets_Shot = 0;
            }
        }
    }



    void Reset_Index() // a function to reset our index location
    {
        Location_Index = Random.Range(0, Enemy_Locations.Length); // set our location to a random purple dot
    }

    float Closest_Enemy_Distance() // getting the closest tenmy position
    {

        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject potentialTarget in Players_In_Scene)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }
        return closestDistanceSqr;
    }

    GameObject Closest_Enemy() // a function to find the closest enemy
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        GameObject Closest_Enemy_Gameobject = null;

        foreach (GameObject potentialTarget in Players_In_Scene) // for each player in the players in scene array []
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
                Closest_Enemy_Gameobject = potentialTarget.gameObject;
            }
        }
        return Closest_Enemy_Gameobject;
    }

    void Set_Target() // settig our target
    {
        Target.transform.position = Enemy_Locations[Location_Index].transform.position; // find where are target postion is and set our target gameobject on top

        if(Patroling == true) // if we are patroling
        {
            SpriteRenderer Target_Renderer = Target.GetComponent<SpriteRenderer>(); //find the target sprite renderer

            Target_Renderer.color = Color.Lerp(Target_Renderer.color, new Color(Target_Renderer.color.r,Target_Renderer.color.g,Target_Renderer.color.b,1),Time.deltaTime); // set the opacity of our sprite renderer to be 100%
        }
        if(Patroling == false)
        {
            SpriteRenderer Target_Renderer = Target.GetComponent<SpriteRenderer>(); //find the target sprite renderer

            Target_Renderer.color = Color.Lerp(Target_Renderer.color, new Color(Target_Renderer.color.r, Target_Renderer.color.g, Target_Renderer.color.b, 0), Time.deltaTime); // set the opacity of our sprite renderer to be 100%

        }
    }
}
