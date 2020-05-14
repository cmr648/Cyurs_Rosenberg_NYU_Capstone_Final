using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reset_Start_Scene : MonoBehaviour
{

    public Material Transition_material;

    [Range(0, 1)]
    public float Cuttoff;

    public string Start_Level;

    public float Max_Time;
    public float Time_Alotted;

    public float Transition_Speed;
    
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        Transition_material.SetFloat("_Cutoff", Cuttoff);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float index = 0;
            index += Time.deltaTime;

            if (index >= 1)
            {
                Cuttoff = Mathf.MoveTowards(Cuttoff, 0, Time.deltaTime * Transition_Speed);
            }
            else
            {
                Cuttoff = Mathf.MoveTowards(Cuttoff, 1, Time.deltaTime * Transition_Speed);

            }

        }
    }



}
