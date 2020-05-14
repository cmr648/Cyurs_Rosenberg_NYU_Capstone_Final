using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy_Rendering))] // add an enemy rendering component to our game object

public class Enemy_Health : MonoBehaviour
{
   

    [Header("Enemy Health Data")]
    public float Enemy_Start_Health;
    public float Enemy_Current_Health;

    [Header("Damage Data")]
    public float Base_Damage_Unit;

    [Header("Special Cases")]
    public bool Hit_By_Laser;
    public bool Hit_By_Explode_Laser;
    public float Laser_Damage_Speed;

    [Header ("Enemy Death Drops")]
    public GameObject Gold_Piece; // to be changed to an array for now

    public Color Original_Color; // a slot for our original color

    Rigidbody2D Enemy_Rigidbody;

    [Header("Effects")]
    public GameObject Damamge_Splat; // creating a damage splat
    public GameObject Death_Splat; // creating death splat

    [Header("Last Player Hunted")]
    public GameObject Player_Killer; // creating a gameobject reference for the player who kills me

    [Header("Scale Variables")]
    public float Opening_Scale;
    public float Tween_Time;
    public LeanTweenType Enemy_Intro_Type;

    [Header("Explosion")]
    public GameObject Explosion_Effect;

    [Header("Enemy Sound Types")] // creating bools for checking what type of enemy sounds to play
    public bool Crab;
    public bool Witch;
    public bool UFO;


    bool Hit_By_Laser_Sound;// a bool that will activated if we are hit by laser
    bool Hit_By_Explode_Laser_Sound; // a bool that will be activiated if we are hit by an explode laser

    // Start is called before the first frame update
    void Awake()
    {
        Enemy_Current_Health = Enemy_Start_Health; // setting our enemies current health to our enemy start health
        Original_Color = GetComponent<SpriteRenderer>().color; // assiging our original color
        Enemy_Rigidbody = GetComponent<Rigidbody2D>(); 



    }

    private void Start()
    {
        Up_Scale_Enemy(); // scaling our enemy up at the start
    }

    // Update is called once per frame
    void Update()
    {
        Play_Laser_Sound(); // implementing our checking laser sound bool

        Take_Explode_Laser_Damage(); // implementing our explode laser damage
        Take_Laser_Damage(); // implemnenting our laser damage script
        Hit_By_Laser = false; // setting our hit by laser to be false
        Hit_By_Explode_Laser = false;
        Kill_Enemy(); // implementing our kill enemy script   
        Slice_Weapon_Behavior(); // implementing our slice weapon behavior



    }


    void Kill_Enemy() // a void that will destroy our enemy when its health reaches 0
    {
        if(Enemy_Current_Health <= 0) //if our enemy dies
        {
            Instantiate(Gold_Piece, transform.position, Quaternion.identity);

            GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Wave_Spawner>().Enemies_Defeated += 1;

            if(Player_Killer != null) // if our enemy dies from a player killer
            {
                Score_Player_Enemy_Death(Player_Killer); // score the last player who killed me
            }

           
            if(Death_Splat != null)
            {
                Instantiate(Death_Splat, transform.position, Quaternion.identity);
            }

            Destroy(gameObject); // destroy our enemy
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // if a solid collider hits our game object
    {
        if(collision.gameObject.tag == "Bullet") // if a standard bullet hits us
        {
            Player_Killer = collision.gameObject.GetComponent<Bullet_Health>().Player_Fired;

            Enemy_Current_Health -= Base_Damage_Unit; // subtract our base damage from our enemy unit
            Destroy(collision.gameObject); // get rid of the bullet
           
            StartCoroutine("Take_Damage_Visual");

            Enemy_Rigidbody.velocity = new Vector2(0, 0);
            transform.rotation = transform.rotation;

        }

        if(collision.gameObject.tag == "Explode_Bullet") // if an exploding bullet hits us
        {
            Player_Killer = collision.gameObject.GetComponent<Bullet_Health>().Player_Fired;


            Enemy_Current_Health -= Base_Damage_Unit * 3; // subtract double base damage from our health
            Destroy(collision.gameObject); //destroy the bullet

            StartCoroutine("Take_Damage_Visual");

            Enemy_Rigidbody.velocity = new Vector2(0, 0);
            transform.rotation = transform.rotation;

        }

        if (collision.gameObject.tag == "Slice_Bullet") // if we enter a slice bullet
        {
            Player_Killer = collision.gameObject.GetComponent<Bullet_Health>().Player_Fired;


            Enemy_Current_Health -= Base_Damage_Unit; // subtract our base damage from our enemy

            StartCoroutine("Take_Damage_Visual");

            Enemy_Rigidbody.velocity = new Vector2(0, 0);
            transform.rotation = transform.rotation;


        }

        if (collision.gameObject.tag == "Bounce_Bullet") // if we collide with a bouncing bullet
        {
            Player_Killer = collision.gameObject.GetComponent<Bullet_Health>().Player_Fired;


            Enemy_Current_Health -= Base_Damage_Unit; // subtract double base damage from our health

            StartCoroutine("Take_Damage_Visual");

            Enemy_Rigidbody.velocity = new Vector2(0, 0);
            transform.rotation = transform.rotation;


        }

        if (collision.gameObject.tag == "Weapon")
        {
            if(collision.transform.parent == null) // if the transform does not have a parent
            {

                Enemy_Current_Health -= Base_Damage_Unit; // subtract double base damage from our health

                StartCoroutine("Take_Damage_Visual");

                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); // set its velocity to nothing

                transform.rotation = transform.rotation;

                Enemy_Rigidbody.velocity = new Vector2(0, 0);
                transform.rotation = transform.rotation;

            }

        }

        if (collision.gameObject.tag == "Bounce_Weapon")
        {
            if(collision.transform.parent == null) // if the transform does not have a parent
            {

                Enemy_Current_Health -= Base_Damage_Unit; // subtract double base damage from our health

                StartCoroutine("Take_Damage_Visual");

                Enemy_Rigidbody.velocity = new Vector2(0, 0);
                transform.rotation = transform.rotation;

            }



        }

        if (collision.gameObject.tag == "Explode_Weapon")
        {
            if(collision.transform.parent == null) // if the transform does not have a parent
            {
                Enemy_Current_Health -= Base_Damage_Unit * 2; // subtract double base damage from our health

                GameObject Explosion =  Instantiate(Explosion_Effect, transform.position, Quaternion.identity); // instantiating an explode effect form explode weapon

                Explosion.transform.parent = transform; // setting the parent of our explosion to our transform so that it will always be on top of our enemy

                StartCoroutine("Take_Damage_Visual");

                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); // set its velocity to nothing

                transform.rotation = transform.rotation;

                Enemy_Rigidbody.velocity = new Vector2(0, 0);
                transform.rotation = transform.rotation;

            }

        }




    }

    private void OnTriggerEnter2D(Collider2D other) // if a trigger hits our game object
    {
        if (other.gameObject.tag == "Slice_Bullet") // if we enter a slice bullet
        {
            Player_Killer = other.gameObject.GetComponent<Bullet_Health>().Player_Fired;


            Enemy_Current_Health -= Base_Damage_Unit; // subtract our base damage from our enemy

            StartCoroutine("Take_Damage_Visual");

        }

        if (other.gameObject.tag == "Bullet") // if a standard bullet hits us
        {
            Player_Killer = other.gameObject.GetComponent<Bullet_Health>().Player_Fired;


            Enemy_Current_Health -= Base_Damage_Unit; // subtract our base damage from our enemy unit
            Destroy(other.gameObject); // get rid of the bullet

            StartCoroutine("Take_Damage_Visual");
        }

        if (other.gameObject.tag == "Explode_Bullet") // if an exploding bullet hits us
        {
            Player_Killer = other.gameObject.GetComponent<Bullet_Health>().Player_Fired;


            Enemy_Current_Health -= Base_Damage_Unit * 3; // subtract double base damage from our health
            Destroy(other.gameObject); //destroy the bullet

            StartCoroutine("Take_Damage_Visual");
        }

        if (other.gameObject.tag == "Bounce_Bullet") // if we collide with a bouncing bullet
        {
            Player_Killer = other.gameObject.GetComponent<Bullet_Health>().Player_Fired;


            Enemy_Current_Health -= Base_Damage_Unit; // subtract double base damage from our health
            Destroy(other.gameObject); //destroy the bullet

            StartCoroutine("Take_Damage_Visual");
        }


       

    }



    public void Take_Laser_Damage() // a function to register if we are taking laser damage
    {
        if(Hit_By_Laser == true) // if we are hit by a laser
        {
            StartCoroutine("Take_Damage_Visual");
            Enemy_Current_Health -= Base_Damage_Unit * Time.deltaTime * Laser_Damage_Speed; // lose health at a constant and rapid pace
            GetComponent<SpriteRenderer>().color = GetComponent<Enemy_Rendering>().Damage_Color; // setting our sprite renderer to be a our damage color taking the damage out of the renderes hands


        }
        else
        {

            GetComponent<SpriteRenderer>().color = GetComponent<Enemy_Rendering>().Current_Color; // changing our color back

        }
    }

    public void Take_Explode_Laser_Damage()
    {
        if (Hit_By_Explode_Laser == true) // if we are hit by a laser
        {
            StartCoroutine("Take_Damage_Visual");

            Enemy_Current_Health -= Base_Damage_Unit * 3 * Time.deltaTime * Laser_Damage_Speed; // lose health at a constant and rapid pace

            GameObject Explosion =  Instantiate(Explosion_Effect, transform.position, Quaternion.identity);  // getting hit by laser

            Explosion.transform.parent = transform; // setting the parent to be the enemy gameobject so that way the explodion will always be on the enemy gameobject



        }
        else
        {

        }
    }

    IEnumerator Take_Damage_Visual() // a function for visualising damage
    {
        Enemy_Sounds(); // implementing our enemy sounds function

        if (Damamge_Splat != null)
        {
            Instantiate(Damamge_Splat, transform.position, Quaternion.identity);
        }

        GetComponentInChildren<Enemy_Rendering>().Current_Color = GetComponentInChildren<Enemy_Rendering>().Damage_Color; // turn the sprite red
        yield return new WaitForSeconds(0.3f); // wait a little
        GetComponentInChildren<Enemy_Rendering>().Current_Color = GetComponentInChildren<Enemy_Rendering>().Start_Color; // turn it back

       
      
    }

    void Slice_Weapon_Behavior() // a function for what happens when we hit a slice weapon
    {
       
            foreach (GameObject Slice in GameObject.FindGameObjectsWithTag("Slice_Weapon")) // take every slice weapon in the game every frame
            {

                if (Slice.transform.parent == null) // if it is NOT bieng held
                {
                    Physics2D.IgnoreCollision(Slice.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>(), true); // ignore collisions

                    if (Vector3.Distance(Slice.transform.position, transform.position) < .6 && Vector3.Distance(Slice.transform.position, transform.position) > .4) // if it is at a colliding position
                    {
                        Enemy_Current_Health -= Base_Damage_Unit; // subtract double base damage from our health

                        StartCoroutine("Take_Damage_Visual"); // show us taking health

                    }

                }
                else
                {
                    Physics2D.IgnoreCollision(Slice.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>(), false); // ignore collisions

                }


            }
        


    }

    void Score_Player_Enemy_Death(GameObject Player)
    {
        if (Player.gameObject.name == "Player_1")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_1_Score.Enemies_Killed_Score += 1;
        }

        if (Player.gameObject.name == "Player_2")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_2_Score.Enemies_Killed_Score += 1;
        }

        if (Player.gameObject.name == "Player_3")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_3_Score.Enemies_Killed_Score += 1;
        }

        if (Player.gameObject.name == "Player_4")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_4_Score.Enemies_Killed_Score += 1;
        }
    }

    void Up_Scale_Enemy() // a function to have the enmy scale out o fhte portal
    {
        transform.localScale = new Vector3(0, 0, 0); // starting our enemy at a scale of nothing

        transform.LeanScale(new Vector3(Opening_Scale, Opening_Scale, Opening_Scale), Tween_Time).setEase(Enemy_Intro_Type); // tweening them up using lean tween
    }

   
    void Enemy_Sounds() // our enemy sound script
    {

        if (Hit_By_Laser == false && Hit_By_Explode_Laser == false) // if we are not hit by any type o flaser
        {
            if (Crab == true)
            {
                FindObjectOfType<Audio_Manager>().Play_Sound("Crab Damage");
            }

            if (Witch == true)
            {
                FindObjectOfType<Audio_Manager>().Play_Sound("Witch Damage");

            }

            if (UFO == true)
            {
                FindObjectOfType<Audio_Manager>().Play_Sound("UFO Damage");

            }
        }

    }

    void Play_Laser_Sound() // a function to play our laser sound
    {
        if(Hit_By_Laser == true) // if the enemy is getting hit by a laser
        {
            if (Hit_By_Laser_Sound == false) // and it has not played the sound before
            {
                if(Crab == true)
                {
                    FindObjectOfType<Audio_Manager>().Play_Sound("Crab Damage"); // play a sepcidfied sound
                }

                if (Witch == true)
                {
                    FindObjectOfType<Audio_Manager>().Play_Sound("Witch Damage"); // play a sepcidfied sound
                }

                if (UFO == true)
                {
                    FindObjectOfType<Audio_Manager>().Play_Sound("UFO Damage"); // play a sepcidfied sound
                }


                Hit_By_Laser_Sound = true; // show that we have already played the soud
            }
        }
        else // if we are no longer getting hit by a lser
        { 
            Hit_By_Laser_Sound = false; // set the sound boolean back to false
        }


        if (Hit_By_Explode_Laser == true) // if the enemy is getting hit by a laser
        {
            if (Hit_By_Explode_Laser_Sound == false) // and it has not played the sound before
            {
                FindObjectOfType<Audio_Manager>().Play_Sound("Explosion"); // play a sepcidfied sound
                Hit_By_Explode_Laser_Sound = true; // show that we have already played the soud
            }
        }
        else // if we are no longer getting hit by a lser
        {
            Hit_By_Explode_Laser_Sound = false; // set the sound boolean back to false
        }

    }



}

