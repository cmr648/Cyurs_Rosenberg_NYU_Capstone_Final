using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Enemy_Behavior : MonoBehaviour
{
    public float X_Distance; // a public float for the x distance
    public float Y_Distance; // a public float for the y distance

    public Transform Center; // trnasoform that will get our center

    public float Move_Speed;

    Rigidbody2D Enemy_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Center = GameObject.Find("New_Center").transform; // finding the center of the map 
        Enemy_Rigidbody = GetComponent<Rigidbody2D>();
        Set_Direction(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        Move_Enemy();
    }

    void Set_Direction() // setting the direction based on the greatest distance from the center
    {
        X_Distance = Mathf.Abs(transform.position.x) - Center.position.x;
        Y_Distance = Mathf.Abs(transform.position.y) - Center.position.y;

        if(X_Distance > Y_Distance)
        {
            Enemy_Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;

            Enemy_Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

            if (transform.position.x < 0)  // if our transform is in the negative
            {
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }

        }

        if(Y_Distance > X_Distance) 
        {
            Enemy_Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;

            Enemy_Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

            if (transform.position.y < 0)  // if our transform is in the negative
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
    }

    void Move_Enemy() // moving our enemy in our preset direction
    {
        Enemy_Rigidbody.MovePosition(Enemy_Rigidbody.position + (Vector2)transform.up * Move_Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) // if we collide wtih anything
    {
        //if (collision.gameObject.tag == "Player")
        //{

        //    collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //    collision.gameObject.GetComponent<Player_Stats>().Player_Current_Health -= collision.gameObject.GetComponent<Player_Stats>().Health_Loss_Units;
        //    Destroy(gameObject);
        //}
    }
}
