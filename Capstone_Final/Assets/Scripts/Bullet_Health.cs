using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Health : MonoBehaviour
{
    public int Start_Bullet_Health; // the start health of every bullet

    public GameObject Player_Fired; // a gameobject referecne for the player that fired

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Start_Bullet_Health < 0) // if we lose all of our health
        {
            Destroy(gameObject); // destroy the bullet
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // if we collide with anything
    {
        Start_Bullet_Health -= 1; // subtract health from our bullet

        Play_Bullet_Sounds(); // playing a bullet sound
    }

    void Play_Bullet_Sounds()
    {
        if(gameObject.tag == "Bounce_Bullet")
        {
            FindObjectOfType<Audio_Manager>().Play_Sound("Bounce Sound");
        }
    }
}
