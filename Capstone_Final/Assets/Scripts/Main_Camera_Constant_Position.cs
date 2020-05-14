using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera_Constant_Position : MonoBehaviour
{
    public Transform Coordinates;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Coordinates.position.x,Coordinates.position.y,transform.position.z);
    }
}
