using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    [Header("Player Start Statistics")]
    public float Player_Start_Health; //Creating a variable for the player start health at beginning
    public float Player_Start_Ammo; // creating a variable for the player Ammo at Start
    public float Health_Loss_Units; // Creating a float for the units of health that the player can lose
    public float Ammo_Loss_Units; //Creating a float for the units of ammo the player loses
    public float Laser_Lost_Speed; // creating a float for the amount of ammo we want to lose when firing a laser

    [Header("Player Live Statistics")]
    public float Player_Current_Health; // Creating a variable for the players current health
    public float Player_Current_Ammo; // Creatinga a variable for the players current ammo

    Keyboard_Character_Movement Player_Movement; // creating a slot to get our keyboard player movement TO BE CHANGED FOR JOYSTICKS
    Rigidbody2D Player_Rigidbody; // creating a slot for our player rigidbody

    [Header("Player Damage")]
    public float Damage_Render_Time; // the amount of time our player should turn a color once they are damaged
    public Color Player_Damage_Color; // the color our player should turn
    public bool Player_Dead;
    SpriteRenderer Player_Renderer;

    [Header ("Player_Health_Pack")]
    public Color Health_Pack_Color;
    public float Health_Render_Time;



    // Start is called before the first frame update
    void Start()
    {
        Player_Movement = GetComponent<Keyboard_Character_Movement>(); // assigining our player movement
        Player_Rigidbody = GetComponent<Rigidbody2D>(); //assigining our player rigidbody
        Player_Current_Health = Player_Start_Health; // setting the player current health to player start health
        Player_Current_Ammo = Player_Start_Ammo; // setting the player current ammo to the player start ammo

        Player_Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player_Current_Health <= 0) // if the player runs out of health
        {
            Player_Current_Health = 0;
            Player_Movement.enabled = false; // the player cant move

            Player_Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll; // freezing the position of the player so they are uneffected by physics

            Player_Dead = true;

        }
        else
        {
            Player_Rigidbody.constraints = RigidbodyConstraints2D.None; // unfreezing the position
            Player_Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation; // freezing the rotation on the same frame

            Player_Movement.enabled = true; // the player can move
            Player_Dead = false;
        }

        if(Player_Current_Ammo <= 0) // if our player ammo goes below 0
        {
            Player_Current_Ammo = 0; // set our player current ammo to get back to 0
        }

        if (Input.GetKey(KeyCode.H))
        {
            Lose_Ammo_Laser(Ammo_Loss_Units);
        }

        if(Player_Current_Health >= Player_Start_Health) // setting a max player health
        {
            Player_Current_Health = Player_Start_Health;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // if we hit anything
    {
        if(collision.gameObject.tag == "Bounce_Bullet")
        {
            Player_Rigidbody.velocity = new Vector2(0, 0); // setting our player velocity to 0
            Destroy(collision.gameObject); // destroy the bullet
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Player_Rigidbody.velocity = new Vector2(0, 0); // setting our player velocity to 0
            Destroy(collision.gameObject); // destroy the bullet
        }

        if (collision.gameObject.tag == "Explode_Bullet")
        {
            Player_Rigidbody.velocity = new Vector2(0, 0); // setting our player velocity to 0
            Destroy(collision.gameObject); // destroying the bullet
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Player_Current_Health -= Health_Loss_Units;
            collision.gameObject.GetComponent<Enemy_Health>().Enemy_Current_Health = 0;

            StartCoroutine("Player_Take_Damage_Render");

        }
    }

    public void Lose_Ammo(float Ammo_Lost) // a function to lose ammo when fired a weapon
    {
        Player_Current_Ammo -= Ammo_Lost; // lose the amount of ammo that we specify 
    }

    public void Lose_Ammo_Laser(float Ammo_Lost) // a function to lose ammo when holding a laser
    {
        Player_Current_Ammo -= Ammo_Lost * Time.deltaTime * Laser_Lost_Speed; // subtract ammo lost every second
    }

    private void OnTriggerEnter2D(Collider2D collision) // if we enter a trigger
    {
        if(collision.gameObject.tag == "Explosion") // if we collide with an explosiotn
        {
            Player_Current_Health -= Health_Loss_Units * 2; // lose some units for an explosion
        }
    }

    IEnumerator Player_Take_Damage_Render() // a courotine to make our player look as though they have lost health
    {
        FindObjectOfType<Audio_Manager>().Play_Sound("Player Damage"); // adding a player damage sound when we are injured

        Player_Renderer.color = Player_Damage_Color; // coloring our player the damage color
        yield return new WaitForSeconds(Damage_Render_Time); // waiting a little bit
        Player_Renderer.color = Color.white; // coloring them back to white
    }

    public IEnumerator Player_Take_Health_Render() // a couroutine to have the player change color when using a health pack
    {
        Player_Renderer.color = Health_Pack_Color;
        yield return new WaitForSeconds(Health_Render_Time);
        Player_Renderer.color = Color.white;
    }



}
