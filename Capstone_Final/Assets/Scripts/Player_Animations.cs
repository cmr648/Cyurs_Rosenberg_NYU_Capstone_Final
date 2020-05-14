using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    Player_Controls_Manager Player_Controls; // creating a slot for player control manager

    Animator Player_Animator;

    Player_Stats Player_Health;


    public bool Walking;
    public bool Dead;



    // Start is called before the first frame update
    void Start()
    {
        Player_Controls = GetComponent<Player_Controls_Manager>(); // assigning player controls manager

        Player_Animator = GetComponent<Animator>();

        Player_Health = GetComponent<Player_Stats>();



    }

    // Update is called once per frame
    void Update()
    {
        Animate_Player();

        Dead = Player_Health.Player_Dead;
    }

    void Animate_Player()
    {
        if (Input.GetKey(Player_Controls.Forward) || Input.GetAxis(Player_Controls.Player_Arcade_Controls.Player_Axis_Y) == 1)
        {
            Walking = true;
        }

        else if (Input.GetKey(Player_Controls.Backward) || Input.GetAxis(Player_Controls.Player_Arcade_Controls.Player_Axis_Y) == -1)
        {
            Walking = true;
        }
        else if (Input.GetKey(Player_Controls.Left) || Input.GetAxis(Player_Controls.Player_Arcade_Controls.Player_Axis_X) == -1)
        {
            Walking = true;
        }

        else if (Input.GetKey(Player_Controls.Right) || Input.GetAxis(Player_Controls.Player_Arcade_Controls.Player_Axis_X) == 1)
        {
            Walking = true;
        }

        else
        {
            Walking = false;
        }

        if(Walking == true)
        {
            Player_Animator.SetBool("Walking", true);

        }
        else
        {
            Player_Animator.SetBool("Walking", false);

        }


        if(Dead == true)
        {
            Player_Animator.SetBool("Dead", true);

        }
        else
        {
            Player_Animator.SetBool("Dead", false);

        }

    }
}
