using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assign_Layer : MonoBehaviour
{
    public int Original_Layer;

    // Start is called before the first frame update
    void Start()
    {
        Original_Layer = gameObject.layer; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
