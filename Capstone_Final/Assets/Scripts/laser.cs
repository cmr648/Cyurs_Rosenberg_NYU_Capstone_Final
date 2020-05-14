using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class laser : MonoBehaviour
{

    LineRenderer Laser_Line_Renderer; // getting our laser line renderer

    [Header("Laser Properties")]
    public bool Normal;
    public bool Slice;
    public bool Exlpode;
    public bool Bounce;

    RaycastHit2D Laser_Hit; // creating a racast hit for our laser
    Ray2D Laser_Ray; // creatnig a ray for our laser

    [Header("Laser Max Distance")]
    public float Laser_Distance; // creating  a public flaot for our laser distanec
    float Current_Distance; // creating a float to gauge our current laser distance

    [Header("Laser_Startup_Time")]
    public float Laser_Time;

    [Header("Laser_Origin_Point")]
    public Transform Laser_Origin_Point;

    Player_Controls_Manager Player_Controls; // creating a slot for our player controls
    Player_Stats Player_Stats; // creating a slot for our player stats

    [Header("Laser Colors")] // the colors that our lasers can be
    public Material Player_1_Color;
    public Material Player_2_Color;
    public Material Player_3_Color;
    public Material Player_4_Color;

    [Header("Explode Laser Objects")] // creating a section for our explode laser attribute
    public GameObject Laser_Explosion; // the laser explosion particle effect gameobject

    [Header("Layer Mask")]
    public LayerMask Standard_Laser_Layer_Mask; // creating the laser layer mask so our raycast can ignore specific objects

    // Start is called before the first frame update
    void Start()
    {
        Laser_Line_Renderer = GetComponent<LineRenderer>();
        Laser_Line_Renderer.enabled = true;
        Current_Distance = 0; // setting our crurent laser distance to equal zero


    }

    // Update is called once per frame
    void Update()
    {
       

        Assign_Laser_Color(); // asssging the color of our laser

        if (gameObject.transform.parent != null) // if we are bieng held
        {
            Player_Controls = GetComponentInParent<Player_Controls_Manager>(); // assiging our player controls if we
            Player_Stats = GetComponentInParent<Player_Stats>(); // assigining our player stats



            if (Normal == true) // if our weapon is standard
            {
                Laser_Line_Renderer.positionCount = 2; // set our laser positions to be a straight line
                Laser_Line_Renderer.SetPosition(0, Laser_Origin_Point.position); // setting our first postition to be our gameobject
                Laser_Hit = Physics2D.Raycast(Laser_Origin_Point.position, Laser_Origin_Point.right, Current_Distance,Standard_Laser_Layer_Mask); // raycasting for a hit

                if (Laser_Hit.collider != null) // if we have hit something
                {
                    Laser_Line_Renderer.SetPosition(Laser_Line_Renderer.positionCount - 1, Laser_Hit.point); // set the line renderer point to our hit point

                    if (Laser_Hit.collider.tag == "Enemy") // if our laser hits an enemy
                    {
                        Laser_Hit.collider.gameObject.GetComponent<Enemy_Health>().Hit_By_Laser = true; // set our enemy to be hit by laser

                        Laser_Hit.collider.gameObject.GetComponent<Enemy_Health>().Player_Killer = gameObject.transform.root.gameObject; // setting the last hit to be this laser

                       
                    }
                }
                else
                {
                    Laser_Line_Renderer.SetPosition(1, Laser_Origin_Point.position + Laser_Origin_Point.right * Current_Distance); // set point to be the max distance

                }


                if (Input.GetKey(Player_Controls.Use_Item)||Input.GetButton(Player_Controls.Player_Arcade_Controls.Player_Button_B)) // if we press our laser button
                {
                    Current_Distance = Mathf.MoveTowards(Current_Distance, Laser_Distance, Time.deltaTime * Laser_Time); // fire the laser
                    Player_Stats.Lose_Ammo_Laser(Player_Stats.Ammo_Loss_Units); // lose ammo to our laser

                     GetComponent<Weapon_Ammo>().Current_Ammo -= GetComponent<Weapon_Ammo>().Ammo_Loss_Units * Time.deltaTime*2;


                    // FindObjectOfType<Audio_Manager>().Play_Loop_Sound("Laser Fire");

                    Play_Laser_Sound(); // playing our laser sound
                }

                if (Input.GetKeyUp(Player_Controls.Use_Item) || Input.GetButtonUp(Player_Controls.Player_Arcade_Controls.Player_Button_B)) // if we lift our laser button
                {
                     Current_Distance = 0; // reset our laser

                    // FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire");
                    Pause_Laser_Sound(); // pausing our laser sound

                }
            }





            if (Bounce == true) // if bounce is set to true
            {

                Laser_Ray = new Ray2D(Laser_Origin_Point.position, Laser_Origin_Point.right); // Create a ray

                Laser_Line_Renderer.positionCount = 1; // set our position count to 1

                Laser_Line_Renderer.SetPosition(0, Laser_Origin_Point.position); // set our position 0 to our tranformpostiion

                float Remaining_Length = Current_Distance; // set our remaining length to our laser distance

                for (int i = 0; i < 10; i++) // set our max amount of collisions to infinity
                {

                    if (Laser_Hit = Physics2D.Raycast(Laser_Ray.origin, Laser_Ray.direction, Remaining_Length)) // create a hit for that raycast
                    {
                        Laser_Line_Renderer.positionCount += 1; // add a position
                        Laser_Line_Renderer.SetPosition(Laser_Line_Renderer.positionCount - 1, Laser_Hit.point); // set our laser hit point

                        Remaining_Length -= Vector2.Distance(Laser_Ray.origin, Laser_Hit.point);

                        Vector2 newDirection = Vector2.Reflect(Laser_Ray.direction, Laser_Hit.normal); // create a new direction for our ray to go in
                        Laser_Ray = new Ray2D(Laser_Hit.point + (newDirection * 0.001f), newDirection); // create a ray from a point that is a littel bit away from the original 

                        if (Laser_Hit.collider.tag == "Enemy") // if our laser hits an enemy
                        {
                            Laser_Hit.collider.gameObject.GetComponent<Enemy_Health>().Hit_By_Laser = true; // set our enemy to be hit by laser

                            Laser_Hit.collider.gameObject.GetComponent<Enemy_Health>().Player_Killer = gameObject.transform.root.gameObject; // setting the last hit to be this laser

                        }

                        // REMEMBER IF WE WANT TO STOP LASER ON ANYTHING
                        //if (Laser_Hit.collider.tag != "Wall") // if we are not hitting a wall 
                        //{
                        //    break; // we break
                        //}




                    }
                    else
                    {
                        Laser_Line_Renderer.positionCount += 1; // add a position to the laser line
                        Laser_Line_Renderer.SetPosition(Laser_Line_Renderer.positionCount - 1, Laser_Ray.origin + Laser_Ray.direction * Remaining_Length); // set that postiion to be the end of the laser
                    }

                }


                if (Input.GetKey(Player_Controls.Use_Item) || Input.GetButton(Player_Controls.Player_Arcade_Controls.Player_Button_B)) // if we press our laser button
                {
                    Current_Distance = Mathf.MoveTowards(Current_Distance, Laser_Distance, Time.deltaTime * Laser_Time); // fire the laser on the laser button
                    Player_Stats.Lose_Ammo_Laser(Player_Stats.Ammo_Loss_Units); // lose ammo to laser

                    GetComponent<Weapon_Ammo>().Current_Ammo -= GetComponent<Weapon_Ammo>().Ammo_Loss_Units * Time.deltaTime*2;

                    //FindObjectOfType<Audio_Manager>().Play_Loop_Sound("Laser Fire");
                    Play_Laser_Sound(); // playing our laser sound
                }

                if (Input.GetKeyUp(Player_Controls.Use_Item) || Input.GetButtonUp(Player_Controls.Player_Arcade_Controls.Player_Button_B)) // if we lift our laser button
                {
                    Current_Distance = 0; // reset our laser wehen we lift laser button

                    //FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire");

                    Pause_Laser_Sound(); // pausing our laser sound
                }





            }

            if (Slice == true) // if our laser is a slice laser
            {
                RaycastHit2D[] Laser_Hits; // creating an array of all the objects we hit


                Laser_Line_Renderer.positionCount = 2; // set our laser positions to be a straight line
                Laser_Line_Renderer.SetPosition(0, Laser_Origin_Point.position); // setting our first postition to be our gameobject
                Laser_Hits = Physics2D.RaycastAll(Laser_Origin_Point.position, Laser_Origin_Point.right, Current_Distance); // raycasting for a hit


                Laser_Line_Renderer.SetPosition(1, Laser_Origin_Point.position + Laser_Origin_Point.right * Current_Distance); // set point to be the max distance

                foreach (RaycastHit2D Enemy in Laser_Hits) // checking everything in laser hits
                {
                    if (Enemy.collider.tag == "Enemy") // if the tag is indeed enemy
                    {
                        Enemy.collider.gameObject.GetComponent<Enemy_Health>().Hit_By_Laser = true; // set our enemy to be hit by laser

                        //Laser_Hit.collider.gameObject.GetComponent<Enemy_Health>().Player_Killer = gameObject.transform.root.gameObject; // setting the last hit to be this laser

                        Enemy.collider.gameObject.GetComponent<Enemy_Health>().Player_Killer = gameObject.transform.root.gameObject; // setting the last hit to be this laser player in order to effectively socre

                    }
                }


                if (Input.GetKey(Player_Controls.Use_Item) || Input.GetButton(Player_Controls.Player_Arcade_Controls.Player_Button_B)) // if we press our laser button
                {
                    Current_Distance = Mathf.MoveTowards(Current_Distance, Laser_Distance, Time.deltaTime * Laser_Time); // fire the laser
                    Player_Stats.Lose_Ammo_Laser(Player_Stats.Ammo_Loss_Units);

                    GetComponent<Weapon_Ammo>().Current_Ammo -= GetComponent<Weapon_Ammo>().Ammo_Loss_Units * Time.deltaTime*2;

                    //FindObjectOfType<Audio_Manager>().Play_Loop_Sound("Laser Fire");
                    Play_Laser_Sound(); // playing our laser sound

                }

                if (Input.GetKeyUp(Player_Controls.Use_Item) || Input.GetButtonUp(Player_Controls.Player_Arcade_Controls.Player_Button_B)) // if we lift our laser button
                {
                    Current_Distance = 0; // reset our laser

                    //FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire");
                    Pause_Laser_Sound(); // Pausing our laser sound

                }




            }

            if (Exlpode == true)
            {

                Laser_Line_Renderer.positionCount = 2; // set our laser positions to be a straight line
                Laser_Line_Renderer.SetPosition(0, Laser_Origin_Point.position); // setting our first postition to be our gameobject
                Laser_Hit = Physics2D.Raycast(Laser_Origin_Point.position, Laser_Origin_Point.right, Current_Distance,Standard_Laser_Layer_Mask); // raycasting for a hit

                if (Laser_Hit.collider != null) // if we have hit something
                {

                    Laser_Line_Renderer.SetPosition(Laser_Line_Renderer.positionCount - 1, Laser_Hit.point); // set the line renderer point to our hit point

                    if (Laser_Hit.collider.tag == "Enemy") // if our laser hits an enemy
                    {
                        Laser_Hit.collider.gameObject.GetComponent<Enemy_Health>().Hit_By_Explode_Laser = true; // set our enemy to be hit by laser

                        Laser_Hit.collider.gameObject.GetComponent<Enemy_Health>().Player_Killer = gameObject.transform.root.gameObject; // setting the last hit to be this laser

                    }
                }
                else
                {
                    Laser_Line_Renderer.SetPosition(1, Laser_Origin_Point.position + Laser_Origin_Point.right * Current_Distance); // set point to be the max distance

                }



                if (Input.GetKey(Player_Controls.Use_Item) || Input.GetButton(Player_Controls.Player_Arcade_Controls.Player_Button_B)) // if we press our laser button
                {
                    Current_Distance = Mathf.MoveTowards(Current_Distance, Laser_Distance, Time.deltaTime * Laser_Time); // fire the laser
                    Player_Stats.Lose_Ammo_Laser(Player_Stats.Ammo_Loss_Units); // lose ammo to laser

                    GetComponent<Weapon_Ammo>().Current_Ammo -= GetComponent<Weapon_Ammo>().Ammo_Loss_Units * Time.deltaTime*2; // losing ammo with our laser

                    if(Laser_Hit.collider != null) // if the laser hit collider exists
                    {
                        if(Laser_Hit.collider.tag == "Wall" || Laser_Hit.collider.tag == "End_Wall") // if we clollide with any type of wall
                        {
                             Instantiate(Laser_Explosion, Laser_Hit.point, Quaternion.identity); // instantiating our explosion object if the explode laser hits anything

                            #region Stadard Wall Sounds
                            if (Laser_Hit.collider.gameObject.GetComponent<Maze_Wall_Behavior>() != null) // if we have a maze wall behavior script these sounds will play
                            {
                                if(gameObject.transform.root.name == "Player_1")
                                {
                                    Laser_Hit.collider.GetComponent<Maze_Wall_Behavior>().Hit_Player_1 = true;
                                }

                                if (gameObject.transform.root.name == "Player_2")
                                {
                                    Laser_Hit.collider.GetComponent<Maze_Wall_Behavior>().Hit_Player_2 = true;
                                }

                                if (gameObject.transform.root.name == "Player_3")
                                {
                                    Laser_Hit.collider.GetComponent<Maze_Wall_Behavior>().Hit_Player_3 = true;
                                }

                                if (gameObject.transform.root.name == "Player_4")
                                {
                                    Laser_Hit.collider.GetComponent<Maze_Wall_Behavior>().Hit_Player_4 = true;
                                }
                            }

                            #endregion 

                            #region End Wall Sounds
                            if (Laser_Hit.collider.gameObject.GetComponent<Border_Wall_Collisions>() != null) // if we have a maze wall behavior script these sounds will play
                            {
                                if (gameObject.transform.root.name == "Player_1")
                                {
                                    Laser_Hit.collider.GetComponent<Border_Wall_Collisions>().Hit_Player_1 = true;
                                }

                                if (gameObject.transform.root.name == "Player_2")
                                {
                                    Laser_Hit.collider.GetComponent<Border_Wall_Collisions>().Hit_Player_2 = true;
                                }

                                if (gameObject.transform.root.name == "Player_3")
                                {
                                    Laser_Hit.collider.GetComponent<Border_Wall_Collisions>().Hit_Player_3 = true;
                                }

                                if (gameObject.transform.root.name == "Player_4")
                                {
                                    Laser_Hit.collider.GetComponent<Border_Wall_Collisions>().Hit_Player_4 = true;
                                }
                            }

                            #endregion
                        }

                    }

                    //FindObjectOfType<Audio_Manager>().Play_Loop_Sound("Laser Fire");
                    Play_Laser_Sound(); // playing our laser sound
                }

                if (Input.GetKeyUp(Player_Controls.Use_Item) || Input.GetButtonUp(Player_Controls.Player_Arcade_Controls.Player_Button_B)) // if we lift our laser button
                {
                    Current_Distance = 0; // reset our laser

                    //FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire");
                    Pause_Laser_Sound(); // pausing our laser sound

                }





            }

        }
        else
        {
            Current_Distance = 0; // reset our laser to not be firing
            Laser_Line_Renderer.positionCount = 0; // reset our line renderer to not show laser firing
            Player_Controls = null; // setting our player contorls to mean nothing
            Player_Stats = null; // setting our player stats to mean nothing

        }


        


    }

    void Assign_Laser_Color() // a function to assign the color of our laser
    {
        if(transform.parent != null) // if we are bieng held reassign laser colors
        {
            if(transform.root.gameObject.name == "Player_1")
            {
                Laser_Line_Renderer.material = Player_1_Color;
            }

            if (transform.root.gameObject.name == "Player_2")
            {
                Laser_Line_Renderer.material = Player_2_Color;
            }
            if (transform.root.gameObject.name == "Player_3")
            {
                Laser_Line_Renderer.material = Player_3_Color;
            }
            if (transform.root.gameObject.name == "Player_4")
            {
                Laser_Line_Renderer.material = Player_4_Color;
            }
        }
    }

    void Play_Laser_Sound() // a function for playing sound when we use our laser
    {
        if (transform.root.gameObject.name == "Player_1")
        {
            FindObjectOfType<Audio_Manager>().Play_Loop_Sound("Laser Fire 1");
        }

        if (transform.root.gameObject.name == "Player_2")
        {
            FindObjectOfType<Audio_Manager>().Play_Loop_Sound("Laser Fire 2");
        }
        if (transform.root.gameObject.name == "Player_3")
        {
            FindObjectOfType<Audio_Manager>().Play_Loop_Sound("Laser Fire 3");
        }
        if (transform.root.gameObject.name == "Player_4")
        {
            FindObjectOfType<Audio_Manager>().Play_Loop_Sound("Laser Fire 4");
        }
    }
     
    void Pause_Laser_Sound() // a function for pausing sound when we are not using our laser 
    {
        if (transform.root.gameObject.name == "Player_1")
        {
            FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 1");
        }

        if (transform.root.gameObject.name == "Player_2")
        {
            FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 2");
        }
        if (transform.root.gameObject.name == "Player_3")
        {
            FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 3");
        }
        if (transform.root.gameObject.name == "Player_4")
        {
            FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 4");
        }
    }



}




