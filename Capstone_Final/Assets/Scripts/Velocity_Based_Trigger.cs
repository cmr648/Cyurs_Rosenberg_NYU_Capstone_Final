using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity_Based_Trigger : MonoBehaviour
{
    Rigidbody2D Item_Rigidbody; // Creating a slot for our Item's Rigidbody

    PolygonCollider2D Item_Box_Collider; // TO BE CHANGED TO POLYGONAL COLLIDER

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Item_Rigidbody = GetComponent<Rigidbody2D>(); // get our item rigidbody
        Item_Box_Collider = GetComponent<PolygonCollider2D>(); // get our items collider

        if(transform.parent == null)
        {
            if (gameObject.tag != "Bounce_Weapon")
            {
                if (Item_Rigidbody != null) // if we have a current item rigidbody
                {
                    if (Item_Rigidbody.velocity.x == 0 && Item_Rigidbody.velocity.y == 0) // if our item is completely still
                    {
                        Item_Box_Collider.isTrigger = true; // make its collider a trigger

                       //transform.localRotation = Quaternion.Euler(0, 0, 0); // resetting our rotation FOR NOW NO NEED NOW THAT WE HAVE SET WEAPON ART

                    }
                    else
                    {
                        Item_Box_Collider.isTrigger = false; // make its collider solild

                    }
                }
            }

        }

    }
}
