using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Behavior : MonoBehaviour
{
    [Header ("Portal Statistics")]
    public int Coins_Dropped; // an int that will measure how many coins have been dropped in

    [Header("Portal UI")]
    public GameObject Portal_Score_Text;
    public LeanTweenType Portal_Tween_Type;
    public float Portal_Tween_Scale;
    public float Portal_Tween_Speed;
    public float Down_Scale_Wait;
    Vector3 Score_Text_Original_Scale; // getting orignal text scale
    Vector3 Portal_Object_Original_Scale;

    // Start is called before the first frame update
    void Start()
    {
        Portal_Score_Text = GameObject.FindGameObjectWithTag("Score_Text"); // getting our score text
        Score_Text_Original_Scale = Portal_Score_Text.transform.localScale; // getting and assigning the local scale

        Portal_Object_Original_Scale = transform.localScale;

        Coins_Dropped = 0; // setting our coins dropped to be 0 at the start of the game

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) // if something enters our trigger
    {
        if(collision.gameObject.tag == "Coin") { // if the obeject in the portal is a coin
        
            if(collision.gameObject.transform.parent != null) // if the coin is bieng held by a player
            {
                First_Coin_Scored(); // implementing our first coin scored function that will allow us to get rid of ui if we have never dropped a coin before

                Score_Coin(collision.gameObject.transform.root.gameObject); // scoring the player

                GameObject Holding_Player; // creating a gameobejct slot for the player holding the item

                Holding_Player = collision.gameObject.transform.root.gameObject; // assigingin the player gameobject
                Coins_Dropped += 1; // add a coin dropped to our statistics
                Destroy(collision.gameObject); // destroy the gameobject
                Holding_Player.GetComponent<Pickup_Item_New>().Current_Held_Item = null; // set the players picked up item to be nothing
                Holding_Player.GetComponent<Pickup_Item_New>().Is_Holding_Item = false; // say that the player is not holding an item

                FindObjectOfType<Audio_Manager>().Play_Sound("Coin Portal"); // PLAYING OUR COIN PORTAL SOUND

            }
        }
    }

    void Score_Coin(GameObject Player)
    {
        if (Player.gameObject.name == "Player_1")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_1_Score.Coin_Score += 1;
        }

        if (Player.gameObject.name == "Player_2")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_2_Score.Coin_Score += 1;
        }

        if (Player.gameObject.name == "Player_3")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_3_Score.Coin_Score += 1;
        }

        if (Player.gameObject.name == "Player_4")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_4_Score.Coin_Score += 1;
        }


        StartCoroutine("Scale_Up_Down_Text");
        StartCoroutine("Scale_Up_Down_Portal");
    }

    IEnumerator Scale_Up_Down_Text()
    {
        Portal_Score_Text.LeanScale(Portal_Score_Text.transform.localScale* Portal_Tween_Scale, Portal_Tween_Speed).setEase(Portal_Tween_Type);
        yield return new WaitForSeconds(Portal_Tween_Speed + Down_Scale_Wait);
        Portal_Score_Text.LeanScale(Score_Text_Original_Scale, Portal_Tween_Speed).setEase(Portal_Tween_Type);
    }

    IEnumerator Scale_Up_Down_Portal()
    {
        gameObject.LeanScale(gameObject.transform.localScale * Portal_Tween_Scale, Portal_Tween_Speed).setEase(Portal_Tween_Type);
        yield return new WaitForSeconds(Portal_Tween_Speed + Down_Scale_Wait);
        gameObject.LeanScale(Portal_Object_Original_Scale, Portal_Tween_Speed).setEase(Portal_Tween_Type);
    }


    void First_Coin_Scored() // a fucntion to get rid of some UI if the players have figirued out how to score coins
    {
        if(Coins_Dropped == 0) // if this is our first coin dropped
        {
            gameObject.GetComponentInChildren<UI_Bounce>().Lean_Die(); // kill our ui
        }
    }


}
