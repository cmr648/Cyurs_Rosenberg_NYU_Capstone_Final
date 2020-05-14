using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Debug_Set_High_Score : MonoBehaviour
{
    public int High_Score;

    private void Awake()
    {
        Gameplay_Variables.Team_Score = High_Score;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

