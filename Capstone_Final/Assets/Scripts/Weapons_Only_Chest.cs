using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Only_Chest : MonoBehaviour
{
    public GameObject Weapon; // a public void for the items we would like to spawn

    public Animator Chest_Animatior; // the animator we will use for our chest opening

    public bool Chest_Opened; // a bool to check if our chest has been opened

    private void Awake() // on the first availblie frame of the game
    {
        Chest_Opened = false; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) // if anything enters our trigger
    {

        if(collision.gameObject.tag == "Player") // if the thing entering our trigger is the player
        {
            if(Chest_Opened == false) // if we have not already opened our chest
            {
                FindObjectOfType<Audio_Manager>().Play_Sound("Chest Open"); // play the chest open sound

                Chest_Animatior.SetBool("Chest_Opening", true); // set our chest opening bool to be true

                StartCoroutine("Close_Chest"); // star our close chest coroutine

                Chest_Opened = true; // open the chest
            }

          

            
        }
    }

    public void Spawn_Weapon() // spawning a weapon
    {
        Instantiate(Weapon, transform.position, Quaternion.identity); // spawn a new procedural weapon

    }

    public void Destroy_Chest() // a function to destroy our chest
    {
        Destroy(gameObject); // destroying our chest
    }

    IEnumerator Close_Chest() // a coroutine to close our chest
    {
        yield return new WaitForSeconds(.5f); // waiting half a second
        Close_Animation(); // closing our cehst
    }



    public void Close_Animation() // a function to play our closing animation
    {
        Chest_Animatior.SetBool("Chest_Closing", true); // setting the bool for our chest to close
    }
}
