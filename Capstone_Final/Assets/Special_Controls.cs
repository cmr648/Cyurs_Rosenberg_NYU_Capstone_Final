using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Controls : MonoBehaviour
{
    public KeyCode Reset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Reset))
        {
            FindObjectOfType<Pokemon_Shader_Transtion>().Can_Transition = true;
        }
    }
}
