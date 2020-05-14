using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Spawner : MonoBehaviour
{
    [Header ("Gameobjects To Instantiate")]
    public GameObject Enemy_Portal; // the portal that will spawn enemies
    public GameObject Chest; // the cehst gameobject
    public GameObject Coin_Portal; // creating a public gameobject for our coin portal

    [Header ("Object Location Tracking")]
    public List<Transform> Current_Enemy_Portal_Locations; // all locations that an enemy portal is currently at

    public List<Transform> Potential_Enemy_Portal_Locations; // all locations that an enemy poratl can apepar

    public List<GameObject> Portal_Object_Locations; // all locations with an actual portal object

    [Header("Coin Portal Location")]
    public Transform Coin_Portal_Location;

    [Header ("Enemies")]
    public GameObject[] Enemies_To_Spawn;

    public int Enemies_To_Spawn_Per_Portal;

    public int Enemy_Progress_Count;

    public int Enemies_Defeated;

    public float Wait_Seconds;

    bool Can_Start_Again;

    [Header("Wave Notifictaion")]
    public Wave_Notification Wave_Notification_Text; // creating a reference to our wave notification text


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Late_Start");
        Can_Start_Again = false; // set our game to not start
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Can_Start_Again == true) // if our game is bieng started
        {
            Start_Again(); // start again
        }

      
        for (int i = 0; i < Potential_Enemy_Portal_Locations.Count; i++) // ALWAYS USE A FOR LOOP FOR LISTS NEVER FOR EACH, CANNOT ENUMERTAE
        {
            if (Potential_Enemy_Portal_Locations[i] == null) // if there is an empty slot
            {
                Potential_Enemy_Portal_Locations.Remove(Potential_Enemy_Portal_Locations[i]); // delete it
            }
        }

        for (int i = 0; i < Current_Enemy_Portal_Locations.Count; i++) // ALWAYS USE A FOR LOOP FOR LISTS NEVER FOR EACH, CANNOT ENUMERTAE
        {
            if (Current_Enemy_Portal_Locations[i] == null) // if there is an empty slot
            {
                Current_Enemy_Portal_Locations.Remove(Current_Enemy_Portal_Locations[i]); // delete it
            }
        }


        for (int i = 0; i < Potential_Enemy_Portal_Locations.Count; i++) // for every object in potential enemy portal locations
        {
            foreach(Transform Object in Current_Enemy_Portal_Locations) // for every portal locaiton on map
            {
                if (Potential_Enemy_Portal_Locations.Contains(Object)) // if it cointains enemy portal
                {
                    Potential_Enemy_Portal_Locations.Remove(Object); // remove enemy portal
                }
            }
        }

        if(Coin_Portal_Location != null) // removing coin portal location
        {
            if (Potential_Enemy_Portal_Locations.Contains(Coin_Portal_Location)) // removing coin poratl location from our potential enemy locations
            {
                Potential_Enemy_Portal_Locations.Remove(Coin_Portal_Location);
            }
        }

      
    }


    void Spawn_Single_Portal()
    {
        int index = Random.Range(0, Potential_Enemy_Portal_Locations.Count);

        GameObject New_Portal = Instantiate(Enemy_Portal, Potential_Enemy_Portal_Locations[index].position, Quaternion.identity); // creating a gameobejct for a new portal and instantiating it

        Portal_Object_Locations.Add(New_Portal); // adding the new portal to our list of portal tracking objects

        Current_Enemy_Portal_Locations.Add(Potential_Enemy_Portal_Locations[index]); // adding the enemy location to our list of current enemy portal locations

        Potential_Enemy_Portal_Locations.Remove(Potential_Enemy_Portal_Locations[index]); // removing the portal from potential locations that new portals can spawn

        Enemy_Progress_Count += Enemies_To_Spawn_Per_Portal;
    }


    IEnumerator Late_Start()
    {
        yield return new WaitForSeconds(.01f); // THE WAIT SECONDS FOR STARTING OUR GAME SHOULD BE .3f IF DOESNT WORK CORRECTLY

        Spawn_Chest(); // add a chest into our world
        Spawn_Coin_Portal(); // add a coin portal into our world
        Can_Start_Again = true; // seting up our enemy portal beginnign

    }

    IEnumerator Start_Portals()
    {
        yield return new WaitForSeconds (.5f);

        for(int i = 0; i < Enemies_To_Spawn_Per_Portal; i++)
        {
            yield return new WaitForSeconds(Wait_Seconds);

            foreach (Transform Portal_Transform in Current_Enemy_Portal_Locations)
            {
                    Instantiate(Enemies_To_Spawn[Random.Range(0, Enemies_To_Spawn.Length)], Portal_Transform.position, Quaternion.identity); // instantiate an enemy


            }

            foreach(GameObject Portal_Object in Portal_Object_Locations) // For Each portal object that exists
            {
                Portal_Object.gameObject.GetComponent<Enemy_Portal_Tweening>().StartCoroutine("Scale_Up_Down_Portal"); // tween it using its portal tweening script
            }

        }
    }

    void Start_Again()
    {
        if(Enemy_Progress_Count == Enemies_Defeated) // if enoguh enemies have been defeated
        {
            Wave_Notification_Text.StartCoroutine("Scale_Up_Down_Wave_Text"); // Starting the wave notification text showing

            Enemies_Defeated = 0;
            Spawn_Single_Portal();
            StartCoroutine("Start_Portals");
        }
    }

    public void Spawn_Chest()
    {
        int index = Random.Range(0, Potential_Enemy_Portal_Locations.Count);

       GameObject New_Chest = Instantiate(Chest, Potential_Enemy_Portal_Locations[index].position, Quaternion.identity);

        New_Chest.GetComponent<Chest_Behavior>().Chest_Location = Potential_Enemy_Portal_Locations[index]; // add this as the chest location

        Potential_Enemy_Portal_Locations.Remove(Potential_Enemy_Portal_Locations[index]);

       



    }

    public void Spawn_Coin_Portal()
    {
        int index = Random.Range(0, Potential_Enemy_Portal_Locations.Count);

        Instantiate(Coin_Portal, Potential_Enemy_Portal_Locations[index].position, Quaternion.identity);

        Coin_Portal_Location = Potential_Enemy_Portal_Locations[index];

        Potential_Enemy_Portal_Locations.Remove(Potential_Enemy_Portal_Locations[index]);
    }
}
