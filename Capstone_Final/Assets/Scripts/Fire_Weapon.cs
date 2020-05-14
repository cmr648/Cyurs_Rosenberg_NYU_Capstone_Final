using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Weapon : MonoBehaviour
{
    Create_Weapon This_Weapon; // getting a script to get all of the data about our weapon

    [Header ("Ammo Prefabs")]
    public GameObject Pistol_Ammo;
    public GameObject Shotgun_Ammo;
    public GameObject Laser_Ammo;
    public GameObject Machine_Gun_Ammo;
    public GameObject Sniper_Ammo;

    [Header ("Fire Point Transform")]
    public Transform Fire_Point;

    [Header ("Bullet Fire Speed")]
    public float Bullet_Force;

    [Header("Weapon Fire Times")]
    public float Pistol_Wait_Time;
    public float Shotgun_Wait_Time;
    public float Laser_Wait_Time;
    public float Machine_Gun_Wait_Time;
    public float Sniper_Wait_Time;

    [Header("Fire_Button")]
    public KeyCode Fire_Button; // creating a public fire button


    laser This_Laser; // making a slot for our laer
    LineRenderer Laser_Line_Renderer; // creating a slot for our laser line rendeer

    Player_Controls_Manager Player_Controls; // creating a slot for our player controls to be determiend within the gameobject
    Player_Stats Player_Stats; // creating a slot for our player stats
    Weapon_Ammo Weapon_Ammunition; // creating a slot for weapon ammunition

    // Start is called before the first frame update
    void Start()
    {

        This_Weapon = GetComponent<Create_Weapon>(); // getting our create weapon component
        This_Laser = GetComponent<laser>(); // getting oour laser
        Laser_Line_Renderer = GetComponent<LineRenderer>(); // assiging our laser line renderer


        Weapon_Ammunition = GetComponent<Weapon_Ammo>(); // assigning our weapon ammpo
    }

    // Update is called once per frame
    void Update()
    {
        Check_For_Laser(); // checking for our laser
        if(gameObject.transform.parent != null) // if we are bieng held by a player
        {
            Player_Controls = GetComponentInParent<Player_Controls_Manager>(); // assigining our player controls manager
            Player_Stats = GetComponentInParent<Player_Stats>(); // assiging our player stats



                //TOO BE CHANGED LATER
                if (Input.GetKeyDown(Player_Controls.Use_Item) || Input.GetButtonDown(Player_Controls.Player_Arcade_Controls.Player_Button_B)) // TO BE CHANGED TO JOYSTICK CONTROLS
                {
                    StartCoroutine("Fire_Gun");


                }
                if (Input.GetKeyUp(Player_Controls.Use_Item)||Input.GetButtonUp(Player_Controls.Player_Arcade_Controls.Player_Button_B)) // TO BE CHANGED TO JOYSTICK CONTROLS
                {
                    StopCoroutine("Fire_Gun");
                }
            
            //else
            //{
            //    StopCoroutine("Fire_Gun");
            //}


        }
        else
        {
            Player_Controls = null;
            Player_Stats = null;
        }

    }


    public IEnumerator Fire_Gun()
    {
        if (This_Weapon.Pistol == true) // if our weapon is a pistol
        {
            while (true)
            {
                GameObject Pistol_Bullet = Instantiate(Pistol_Ammo, Fire_Point.position, Quaternion.Euler(0, 0, 0)); // create a bullet
                Pistol_Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * Bullet_Force * 100 * Time.deltaTime); // send the bulelt

                Weapon_Ammunition.Current_Ammo -= Weapon_Ammunition.Ammo_Loss_Units;

                // TAG THE BULLETS
                if (This_Weapon.Standard_Ammo == true)
                {
                    Pistol_Bullet.gameObject.tag = "Bullet";
                }

                if (This_Weapon.Bounce_Ammo == true)
                {
                    Pistol_Bullet.gameObject.tag = "Bounce_Bullet";
                }
                if (This_Weapon.Slice_Ammo == true)
                {
                    Pistol_Bullet.gameObject.tag = "Slice_Bullet";
                    Pistol_Bullet.gameObject.GetComponent<PolygonCollider2D>().isTrigger = true; // set our slice bullet to be a trigger
                }
                if (This_Weapon.Explode_Ammo == true)
                {
                    Pistol_Bullet.gameObject.tag = "Explode_Bullet";
                }


                FindObjectOfType<Audio_Manager>().Play_Sound("Pistol Shoot");

                Pistol_Bullet.GetComponent<Bullet_Health>().Player_Fired = gameObject.transform.root.gameObject;

                yield return new WaitForSeconds(Pistol_Wait_Time); // wait an alloted time
            }

        }

        if (This_Weapon.Shotgun == true)
        {

            while (true)
            {
                Weapon_Ammunition.Current_Ammo -= Weapon_Ammunition.Ammo_Loss_Units*3;

                Vector3 Shotgun_Bullet_2_Direction = Quaternion.AngleAxis(45, transform.forward) * transform.right; // creating an anlge for shotugun bullet 2 to fire at
                Vector3 Shotgun_Bullet_3_Direction = Quaternion.AngleAxis(-45, transform.forward) * transform.right; // creating an anlge for shotugun bullet 3 to fire at


                GameObject Shotgun_Bullet_1 = Instantiate(Shotgun_Ammo, Fire_Point.position, Quaternion.Euler(0, 0, 0)); // create a bullet
                GameObject Shotgun_Bullet_2 = Instantiate(Shotgun_Ammo, Fire_Point.position, Quaternion.Euler(0, 0, 45)); // create an angled bulelt
                GameObject Shotgun_Bullet_3 = Instantiate(Shotgun_Ammo, Fire_Point.position, Quaternion.Euler(0, 0, -45)); // create an angled bullet
                Shotgun_Bullet_1.GetComponent<Rigidbody2D>().AddForce(transform.right * Bullet_Force * 2 * 100 * Time.deltaTime); // fire the middle bullet
                Shotgun_Bullet_2.GetComponent<Rigidbody2D>().AddForce(Shotgun_Bullet_2_Direction * Bullet_Force * 100 * Time.deltaTime); // fire angled bullet at shotgun 2 direction
                Shotgun_Bullet_3.GetComponent<Rigidbody2D>().AddForce(Shotgun_Bullet_3_Direction * Bullet_Force * 100 * Time.deltaTime); // fire angled bullet at shotgun 3 direction


                //TAG THE BULLETS
                if (This_Weapon.Standard_Ammo == true)
                {
                    Shotgun_Bullet_1.gameObject.tag = "Bullet";
                    Shotgun_Bullet_2.gameObject.tag = "Bullet";
                    Shotgun_Bullet_3.gameObject.tag = "Bullet";
                }

                if (This_Weapon.Bounce_Ammo == true)
                {
                    Shotgun_Bullet_1.gameObject.tag = "Bounce_Bullet";
                    Shotgun_Bullet_2.gameObject.tag = "Bounce_Bullet";
                    Shotgun_Bullet_3.gameObject.tag = "Bounce_Bullet";
                }
                if (This_Weapon.Slice_Ammo == true)
                {
                    Shotgun_Bullet_1.gameObject.tag = "Slice_Bullet";
                    Shotgun_Bullet_2.gameObject.tag = "Slice_Bullet";
                    Shotgun_Bullet_3.gameObject.tag = "Slice_Bullet";

                    Shotgun_Bullet_1.gameObject.GetComponent<PolygonCollider2D>().isTrigger = true; // set our slice bullet to be a trigger
                    Shotgun_Bullet_2.gameObject.GetComponent<PolygonCollider2D>().isTrigger = true; // set our slice bullet to be a trigger
                    Shotgun_Bullet_3.gameObject.GetComponent<PolygonCollider2D>().isTrigger = true; // set our slice bullet to be a trigger

                }
                if (This_Weapon.Explode_Ammo == true)
                {
                    Shotgun_Bullet_1.gameObject.tag = "Explode_Bullet";
                    Shotgun_Bullet_2.gameObject.tag = "Explode_Bullet";
                    Shotgun_Bullet_3.gameObject.tag = "Explode_Bullet";
                }

                Shotgun_Bullet_1.GetComponent<Bullet_Health>().Player_Fired = gameObject.transform.root.gameObject;
                Shotgun_Bullet_2.GetComponent<Bullet_Health>().Player_Fired = gameObject.transform.root.gameObject;
                Shotgun_Bullet_3.GetComponent<Bullet_Health>().Player_Fired = gameObject.transform.root.gameObject;

                FindObjectOfType<Audio_Manager>().Play_Sound("Shotgun Shoot");

                yield return new WaitForSeconds(Shotgun_Wait_Time);

            }

        }

        if (This_Weapon.Machine_Gun == true) // if our weapon is a pistol
        {
            while (true)
            {
                Weapon_Ammunition.Current_Ammo -= Weapon_Ammunition.Ammo_Loss_Units;

                GameObject Machine_Gun_Bullet = Instantiate(Machine_Gun_Ammo, Fire_Point.position, Quaternion.Euler(0, 0, 0)); // create a bullet
                Machine_Gun_Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * Bullet_Force * 100 * Time.deltaTime); // send the bulelt




                // TAG THE BULLETS
                if (This_Weapon.Standard_Ammo == true)
                {
                    Machine_Gun_Bullet.gameObject.tag = "Bullet";
                }

                if (This_Weapon.Bounce_Ammo == true)
                {
                    Machine_Gun_Bullet.gameObject.tag = "Bounce_Bullet";
                }
                if (This_Weapon.Slice_Ammo == true)
                {
                    Machine_Gun_Bullet.gameObject.tag = "Slice_Bullet";
                    Machine_Gun_Bullet.gameObject.GetComponent<PolygonCollider2D>().isTrigger = true; // set our slice bullet to be a trigger

                }
                if (This_Weapon.Explode_Ammo == true)
                {
                    Machine_Gun_Bullet.gameObject.tag = "Explode_Bullet";
                }

                Machine_Gun_Bullet.GetComponent<Bullet_Health>().Player_Fired = gameObject.transform.root.gameObject;

                FindObjectOfType<Audio_Manager>().Play_Sound("Machinegun Shoot");

                yield return new WaitForSeconds(Machine_Gun_Wait_Time); // wait an alloted time
            }

        }

        if (This_Weapon.Laser == true) // if our weapon is a pistol
        {
            while (true)
            {
                GameObject Laser_Bullet = Instantiate(Laser_Ammo, Fire_Point.position, Quaternion.Euler(0, 0, 0)); // create a bullet
                Laser_Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * Bullet_Force * 100 * Time.deltaTime); // send the bulelt

                // TAG THE BULLETS
                if (This_Weapon.Standard_Ammo == true)
                {
                    Laser_Bullet.gameObject.tag = "Bullet";
                }

                if (This_Weapon.Bounce_Ammo == true)
                {
                    Laser_Bullet.gameObject.tag = "Bounce_Bullet";
                }
                if (This_Weapon.Slice_Ammo == true)
                {
                    Laser_Bullet.gameObject.tag = "Slice_Bullet";
                }
                if (This_Weapon.Explode_Ammo == true)
                {
                    Laser_Bullet.gameObject.tag = "Explode_Bullet";
                }


                yield return new WaitForSeconds(Laser_Wait_Time); // wait an alloted time
            }

        }

        if (This_Weapon.Sniper == true) // if our weapon is a pistol
        {
            while (true)
            {
                GameObject Sniper_Bullet = Instantiate(Sniper_Ammo, Fire_Point.position, Quaternion.Euler(0, 0, 0)); // create a bullet
                Sniper_Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * Bullet_Force * 100 * Time.deltaTime); // send the bulelt

                Weapon_Ammunition.Current_Ammo -= Weapon_Ammunition.Ammo_Loss_Units;

                // TAG THE BULLETS
                if (This_Weapon.Standard_Ammo == true)
                {
                    Sniper_Bullet.gameObject.tag = "Bullet";
                }

                if (This_Weapon.Bounce_Ammo == true)
                {
                    Sniper_Bullet.gameObject.tag = "Bounce_Bullet";
                }
                if (This_Weapon.Slice_Ammo == true)
                {
                    Sniper_Bullet.gameObject.tag = "Slice_Bullet";
                    Sniper_Bullet.gameObject.GetComponent<PolygonCollider2D>().isTrigger = true; // set our slice bullet to be a trigger

                }
                if (This_Weapon.Explode_Ammo == true)
                {
                    Sniper_Bullet.gameObject.tag = "Explode_Bullet";
                }

                Sniper_Bullet.GetComponent<Bullet_Health>().Player_Fired = gameObject.transform.root.gameObject;

                FindObjectOfType<Audio_Manager>().Play_Sound("Sniper Shoot");

                yield return new WaitForSeconds(Sniper_Wait_Time); // wait an alloted time
            }

        }

    }

    void Check_For_Laser() // a void to check if we have the laser
    {
        if(This_Weapon.Laser == true) // if this weapon generates as a laser
        {
            This_Laser.enabled = true; // enable our laser
            This_Laser.Laser_Origin_Point = Fire_Point; // set our laser point to our fire point
            Laser_Line_Renderer.enabled = true; // set our linrendere to be enabler

            //SET Laser Atributes
            if (This_Weapon.Standard_Ammo == true)
            {
                This_Laser.Normal = true;
            }

            if (This_Weapon.Bounce_Ammo == true)
            {
                This_Laser.Bounce = true;
            }
            if (This_Weapon.Slice_Ammo == true)
            {
                This_Laser.Slice = true;
            }
            if (This_Weapon.Explode_Ammo == true)
            {
                This_Laser.Exlpode = true;
            }


            GetComponent<Fire_Weapon>().enabled = false; // turn off htis script
        }
    }

}
