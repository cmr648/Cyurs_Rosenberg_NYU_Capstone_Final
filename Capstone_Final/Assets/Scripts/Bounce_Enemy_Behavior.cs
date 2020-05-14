using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_Enemy_Behavior : MonoBehaviour
{
    [Header("Enemy Velocity")]
    public Vector2 Current_Enemy_Velocity; // creating a public vector 2 for current enemy velocity
    public Vector2 Max_Enemy_Velocity; // creating a public vector 2 for max enemy velocity
    public float Max_Enemy_Speed; // creating a public float for the enemy speed

    float Index_X;
    float Index_Y;
    float Speed_Index;

    Rigidbody2D Enemy_Rigidbody; // creating a reference slot to our enemy rigidbody

    // Start is called before the first frame update
    void Start()
    {
        Index_X = Random.Range(-Max_Enemy_Velocity.x, Max_Enemy_Velocity.x); // setting our indexes to be random
        Index_Y = Random.Range(-Max_Enemy_Velocity.y, Max_Enemy_Velocity.y);
        Speed_Index = Random.Range(5, Max_Enemy_Speed);


        Enemy_Rigidbody = GetComponent<Rigidbody2D>();

        Current_Enemy_Velocity = new Vector2(Index_X * Speed_Index, Index_Y * Speed_Index);

        Enemy_Rigidbody.velocity = Current_Enemy_Velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Rigidbody.velocity = Current_Enemy_Velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        Current_Enemy_Velocity = Vector3.Reflect(Current_Enemy_Velocity, collision.contacts[0].normal);


    }
}
