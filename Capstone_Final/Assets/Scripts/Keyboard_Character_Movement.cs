using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard_Character_Movement : MonoBehaviour
{
  
    bool Can_Move;

    bool Lock_Rotation; // can lock rotation

    Rigidbody2D Player_Rigidbody;

    public float Player_Speed;
    public float Player_Rotation_Speed;

    Vector2 Player_Input = new Vector2(0,0);

    Player_Controls_Manager Player_Controls; // getting our player controls from the player

    Quaternion Rotate_Point;

    public float Rotate_Speed;

    [Header("Arcade Controls")] 
    Arcade_Controls Player_Arcade_Controls; // creating an arcade controls reference

    // Start is called before the first frame update
    void Start()
    {
        Player_Rigidbody = GetComponent<Rigidbody2D>();

        Player_Controls = GetComponent<Player_Controls_Manager>(); // assigning our player controls manager

        Player_Arcade_Controls = Player_Controls.Player_Arcade_Controls;
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard_Rotation();
        Move_Player();
        Rotate_Player();
    }


    void Move_Player()
    {


        Player_Input.Normalize(); // normalizing our player input so moving diagonally wont make the player go faster
        Player_Rigidbody.MovePosition(Player_Rigidbody.position + Player_Input * Time.deltaTime * Player_Speed);
        Player_Input = new Vector2(0, 0);

        if (Input.GetKey(Player_Controls.Forward) || Input.GetAxis(Player_Arcade_Controls.Player_Axis_Y) == -1)
            {

            //Player_Rigidbody.MovePosition(Player_Rigidbody.position + (Vector2)transform.up * Time.deltaTime * Player_Speed);

            Player_Input += new Vector2(0, 1);



        }
        if (Input.GetKey(Player_Controls.Backward) || Input.GetAxis(Player_Arcade_Controls.Player_Axis_Y) == 1)
            {
            Player_Input += new Vector2(0, -1);

            //Player_Rigidbody.MovePosition(Player_Rigidbody.position - (Vector2)transform.up * Time.deltaTime * Player_Speed);

           


        }
        if (Input.GetKey(Player_Controls.Left) || Input.GetAxis(Player_Arcade_Controls.Player_Axis_X) == -1)
            {

            Player_Input += new Vector2(-1, 0);

            //transform.Rotate(transform.forward * Player_Rotation_Speed * Time.deltaTime);

           


        }
        if (Input.GetKey(Player_Controls.Right) || Input.GetAxis(Player_Arcade_Controls.Player_Axis_X) == 1)
            {
            Player_Input += new Vector2(1, 0);

            //transform.Rotate(transform.forward * -Player_Rotation_Speed * Time.deltaTime);

        }


        if (Input.GetKey(Player_Controls.Use_Item) || Input.GetButton(Player_Arcade_Controls.Player_Button_B)) // if we are using an item // A BUTTON PICKS UP WEAPONS
        {
            Lock_Rotation = true; // lock our rotaion
        }
        else
        {
            Lock_Rotation = false; // unlock our rotation
        }



    }

    void Rotate_Player()
    {
    

        if(Lock_Rotation == false)
        {
            Player_Input = new Vector2(0, 0);
            if (Input.GetKey(Player_Controls.Forward) || Input.GetAxis(Player_Arcade_Controls.Player_Axis_Y) == -1)
            {

                //Player_Rigidbody.MovePosition(Player_Rigidbody.position + (Vector2)transform.up * Time.deltaTime * Player_Speed);

                Player_Input += new Vector2(0, 1);



            }
            if (Input.GetKey(Player_Controls.Backward) || Input.GetAxis(Player_Arcade_Controls.Player_Axis_Y) == 1)
            {
                Player_Input += new Vector2(0, -1);

                //Player_Rigidbody.MovePosition(Player_Rigidbody.position - (Vector2)transform.up * Time.deltaTime * Player_Speed);




            }
            if (Input.GetKey(Player_Controls.Left) || Input.GetAxis(Player_Arcade_Controls.Player_Axis_X) == -1)
            {

                Player_Input += new Vector2(-1, 0);

                //transform.Rotate(transform.forward * Player_Rotation_Speed * Time.deltaTime);




            }
            if (Input.GetKey(Player_Controls.Right) || Input.GetAxis(Player_Arcade_Controls.Player_Axis_X) == 1)
            {
                Player_Input += new Vector2(1, 0);

                //transform.Rotate(transform.forward * -Player_Rotation_Speed * Time.deltaTime);

            }

            if(Mathf.Abs(Input.GetAxis(Player_Arcade_Controls.Player_Axis_X)) > Mathf.Abs(Input.GetAxis(Player_Arcade_Controls.Player_Axis_Y)))
            {

                if(Input.GetAxis(Player_Arcade_Controls.Player_Axis_X)> 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 270);
                }

                if (Input.GetAxis(Player_Arcade_Controls.Player_Axis_X) < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }


            if (Mathf.Abs(Input.GetAxis(Player_Arcade_Controls.Player_Axis_Y)) > Mathf.Abs(Input.GetAxis(Player_Arcade_Controls.Player_Axis_X)))
            {
               
                if (Input.GetAxis(Player_Arcade_Controls.Player_Axis_Y) > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                }

                if (Input.GetAxis(Player_Arcade_Controls.Player_Axis_Y) < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }

    }

    void Keyboard_Rotation() // possibly be deleted just need to rotate with keyboard
    {
        if (Input.GetKeyDown(Player_Controls.Forward))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(Player_Controls.Backward))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetKeyDown(Player_Controls.Left))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (Input.GetKeyDown(Player_Controls.Right))
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }




}
