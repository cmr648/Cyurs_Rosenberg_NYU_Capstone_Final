using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Object : MonoBehaviour
{
    public bool X;
    public bool Y;
    public bool Z;

    public float Rotate_Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(X == true)
        {
            transform.Rotate(Vector3.right * Rotate_Speed * Time.deltaTime);
        }

        if (Y == true)
        {
            transform.Rotate(Vector3.up * Rotate_Speed * Time.deltaTime);
        }

        if (Z == true)
        {
            transform.Rotate(Vector3.forward * Rotate_Speed * Time.deltaTime);
        }

    }
}
