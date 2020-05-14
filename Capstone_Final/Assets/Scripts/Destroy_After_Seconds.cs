using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_After_Seconds : MonoBehaviour
{
    public float Seconds; // destroy after these seconds
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
