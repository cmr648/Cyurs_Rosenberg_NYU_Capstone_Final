using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Location_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Wave_Spawner>().Potential_Enemy_Portal_Locations.Add(transform); // add transform to wave spawner

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
