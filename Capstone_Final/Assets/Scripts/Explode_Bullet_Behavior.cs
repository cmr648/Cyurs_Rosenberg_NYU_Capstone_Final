using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode_Bullet_Behavior : MonoBehaviour
{
    public bool Can_Explode; // a bool to see if we can explode

    public GameObject Explode_Bullet_Particle_System; // a particle system to instantiate when our bullet hits something

    // Start is called before the first frame update
    void Start()
    {
        Set_Explode_True(); // implementing our set explode bullet
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) // if our bullet hits anything
    {
        if(Can_Explode == true) // if this is indeed an explode bullet
        {
            Instantiate(Explode_Bullet_Particle_System, transform.position, Quaternion.identity); // explode

            FindObjectOfType<Audio_Manager>().Play_Sound("Explosion"); // Playing our explosion sound to acompany our explosion object
        }
    }

    void Set_Explode_True() // a function to set wheather this is an explode bullet or not
    {
        if(gameObject.tag == "Explode_Bullet")
        {
            Can_Explode = true;
        }
        else
        {
            Can_Explode = false;
        }
    }
}
