using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Setup : MonoBehaviour
{
    [Header("Player_Objects")]
    public GameObject[] Player_1_Objects;
    public GameObject[] Player_2_Objects;
    public GameObject[] Player_3_Objects;
    public GameObject[] Player_4_Objects;


    private void Awake()
    {
        Setup_Players(); // setting up players before our game manager can find them
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Setup_Players();
    }

    void Setup_Players()
    {
        if(Gameplay_Variables.Player_1_In_Game == true)
        {
            foreach(GameObject Player_Object in Player_1_Objects)
            {
                Player_Object.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject Player_Object in Player_1_Objects)
            {
                Player_Object.SetActive(false);
            }
        }

        if (Gameplay_Variables.Player_2_In_Game == true)
        {
            foreach (GameObject Player_Object in Player_2_Objects)
            {
                Player_Object.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject Player_Object in Player_2_Objects)
            {
                Player_Object.SetActive(false);
            }
        }

        if (Gameplay_Variables.Player_3_In_Game == true)
        {
            foreach (GameObject Player_Object in Player_3_Objects)
            {
                Player_Object.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject Player_Object in Player_3_Objects)
            {
                Player_Object.SetActive(false);
            }
        }

        if (Gameplay_Variables.Player_4_In_Game == true)
        {
            foreach (GameObject Player_Object in Player_4_Objects)
            {
                Player_Object.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject Player_Object in Player_4_Objects)
            {
                Player_Object.SetActive(false);
            }
        }
    }
}
