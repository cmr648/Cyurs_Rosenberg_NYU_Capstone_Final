using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Set_Level_Art : MonoBehaviour
{

    public int Level;

    private void Awake()
    {
        Gameplay_Variables.Level_Art_Set = Level;
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
