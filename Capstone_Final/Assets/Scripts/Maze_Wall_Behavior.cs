using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze_Wall_Behavior : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision) // if we collide with anything
    {
        if(collision.gameObject.tag == "Bullet") // if we collide with a normal bullet
        {
            Destroy(collision.gameObject); // destroy the bullet
        }

        if(collision.gameObject.tag == "Explode_Bullet") // if we collide with an explode bullet
        {
            Destroy(collision.gameObject); // destroy the bullet
        }

        if(collision.gameObject.tag == "Bounce_Bullet") // if we collide with a bouncing bullet
        {
          
        }


    }


    void Laser_Explode_Sound_Effect() // the sound effects of an explosion will play if our laser is an explosion laser
    {
        if(Hit_Player_1 == true)
        {
           if(Laser_Sound_1 == false)
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





