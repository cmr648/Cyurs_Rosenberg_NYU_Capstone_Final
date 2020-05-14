using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Framerate : MonoBehaviour
{
    public int Framerate;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = Framerate;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
