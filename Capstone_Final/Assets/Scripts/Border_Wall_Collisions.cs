using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border_Wall_Collisions : MonoBehaviour
{

    [Header("Explosion Bools")]
    public bool Hit_Player_1; // Bools to check if we are bieng hit by an exploding laser
    public bool Hit_Player_2;
    public bool Hit_Player_3;
    public bool Hit_Player_4;


    public bool Laser_Sound_1; // bools to check if a sound has already played
    public bool Laser_Sound_2;
    public bool Laser_Sound_3;
    public bool Laser_Sound_4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Laser_Explode_Sound_Effect();
        Hit_Player_1 = false;
        Hit_Player_2 = false;
        Hit_Player_3 = false;
        Hit_Player_4 = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) // if the wall collides with something
    {
        if (collision.gameObject.tag == "Weapon" || collision.gameObject.tag == "Health_Pack" || collision.gameObject.tag == "Explode_Weapon" || collision.gameObject.tag == "Slice_Weapon" ||collision.gameObject.tag == "Ammo" || collision.gameObject.tag == "Coin") // if this wall collides with one of our objects
        {

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); // set the objects velocity to 0
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        }

        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Slice_Bullet" || collision.gameObject.tag == "Explode_Bullet") // if our outer walls collide with any of the bulelts destroy them
        {
            Destroy(collision.gameObject); 
        }
    }

    private void OnTriggerStay2D(Collider2D collision) // if we collide with a trigger
    {
        if(collision.gameObject.tag == "Slice_Bullet") // if it is a slice bullet
        {
            Destroy(collision.gameObject); // destroy the bullet
        }
    }

    void Laser_Explode_Sound_Effect() // these are the sounds that will play if our wall is hit by an exploding laser
    {
        if (Hit_Player_1 == true)
        {
            if (Laser_Sound_1 == false)
            {

                FindObjectOfType<Audio_Manager>().Play_Sound("Laser Explosion Player 1");
                Laser_Sound_1 = true;
            }
        }
        else
        {
            Laser_Sound_1 = false;
        }


        if (Hit_Player_2 == true)
        {
            if (Laser_Sound_2 == false)
            {

                FindObjectOfType<Audio_Manager>().Play_Sound("Laser Explosion Player 2");
                Laser_Sound_2 = true;
            }
        }
        else
        {
            Laser_Sound_2 = false;
        }

        if (Hit_Player_3 == true)
        {
            if (Laser_Sound_3 == false)
            {

                FindObjectOfType<Audio_Manager>().Play_Sound("Laser Explosion Player 3");
                Laser_Sound_3 = true;
            }
        }
        else
        {
            Laser_Sound_3 = false;
        }

        if (Hit_Player_4 == true)
        {
            if (Laser_Sound_4 == false)
            {

                FindObjectOfType<Audio_Manager>().Play_Sound("Laser Explosion Player 4");
                Laser_Sound_4 = true;
            }
        }
        else
        {
            Laser_Sound_4 = false;
        }
    }




}
