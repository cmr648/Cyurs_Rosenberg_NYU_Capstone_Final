using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Bomb_Enemy_Behavior : MonoBehaviour
{
    [Header ("Stats")]
    public Transform Closest_Player; // creating a public transform slot for our closest player 
    public float Max_Explode_Distance; // creaitng a sight for how far away the bomb needs to be before it explodes
    public float Explode_Iterations; // creating a float for explode seconds
    public float Radius_Speed;
    public float Red_Seconds;

    public bool Can_Explode;

    AIDestinationSetter AI_Destintation; // making a slot for our ai destiantion setter

    public GameObject Explosion; // making a slot for an explosion

    Color Standard_Color;

    // Start is called before the first frame update
    void Start()
    {
        AI_Destintation = GetComponent<AIDestinationSetter>(); // assigining our ai destination setter 

        Can_Explode = false;
    }

    // Update is called once per frame
    void Update()
    {
        Closest_Player = Get_Closest_Player(GameObject.FindGameObjectsWithTag("Player")).transform; // getting the transform of our closest player
        Assign_Cloest_Player_Destitnation(); // implementing our assign closest player destination
        Implement_Explode();


        if (GetComponent<Enemy_Health>().Hit_By_Laser == true || GetComponent<Enemy_Health>().Hit_By_Explode_Laser == true)
        {
            Standard_Color = Color.red;
        }
        else
        {
            Standard_Color = GetComponent<Enemy_Health>().Original_Color;
        }
    }



    GameObject Get_Closest_Player(GameObject[] Players) // a function to get the closest player Gameobject
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in Players)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;

    }



    void Assign_Cloest_Player_Destitnation() // creating a functon to assign our ai destination to be our closest player
    {
        AI_Destintation.target = Closest_Player.transform; // assigning our target to always be our closest player
    }


    void Implement_Explode()
    {
        if (Vector3.Distance(transform.position, Closest_Player.transform.position) < Max_Explode_Distance)
        {

            if(Can_Explode == false)
            {
                GetComponent<AIPath>().maxSpeed = 0; // set the speed to be 0 so it cannot move
                StartCoroutine("Explode");
                Can_Explode = true;
            }


        }


    }

    IEnumerator Explode()
    {


        for (int i = 0; i < Explode_Iterations; i++)
        {
            GetComponentInChildren<Enemy_Rendering>().Current_Color = GetComponentInChildren<Enemy_Rendering>().Start_Color;
            yield return new WaitForSeconds(Red_Seconds);
            Red_Seconds = Red_Seconds * .8f;
            GetComponentInChildren<Enemy_Rendering>().Current_Color = Color.red;
            yield return new WaitForSeconds(Red_Seconds);
            GetComponentInChildren<Enemy_Rendering>().Current_Color = GetComponentInChildren<Enemy_Rendering>().Start_Color;
        }

        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }




}



