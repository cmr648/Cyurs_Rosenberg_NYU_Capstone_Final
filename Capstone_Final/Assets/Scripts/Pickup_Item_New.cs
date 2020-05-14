using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup_Item_New : MonoBehaviour
{
    public bool Is_Holding_Item; // a bool to tell us if we are holding the item
    public bool Colliding_With_Item; // a bool to see if we are touching an item
    public GameObject Current_Held_Item; // a slot for our most current held item

    public Transform Weapon_Holder; // a tranform for our weapon holder

    Player_Controls_Manager Player_Controls; // creating a slot for our player controls

    [Header("Tweening")]
    public LeanTweenType Down_Type; // creating a tween type for our ui image that shows us what weapon we haeve
    public LeanTweenType Up_Type; // creating a tween type for our ui image that shows us what weapon we haeve
    public float Tween_Time; // creating teh amount of time it will take to tween
    public Vector3 Original_Size; // creating a vector 3 for the original size of our UI image
    public Image UI_Image; // creating a reference to the image we want for our items
    public GameObject Weapon_Text; // creating a gameobject reference for our ammo text
    public bool Not_Holding_Weapon_UI_Bool; // creating a boolean to check if we are not holding a weapon

    // Start is called before the first frame update
    void Start()
    {
        Player_Controls = GetComponent<Player_Controls_Manager>(); // assiging our player controls

        Down_Scale_UI(UI_Image); // having no ui at the start of our game
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Drop_The_Item();

        if(Current_Held_Item!= null)
        {
            Current_Held_Item.transform.localPosition = new Vector3(0, 0, 0);
        }

        Not_Holding_Weapon_UI(); // checking at all times if we are not holding a weapon and therefore need to downscale our ui

    }

    void Pickup_The_Item(GameObject Pickup_Item) // a function to pickup the item
    {
        if (Is_Holding_Item == false) // if we are not holding an item
        {
            if (Input.GetKeyDown(Player_Controls.Pickup_Drop_Item) || Input.GetButtonDown(Player_Controls.Player_Arcade_Controls.Player_Button_A)) // TO BE CHANGED TO JOYSTICK CONTROL
            {
                Is_Holding_Item = true;
                Current_Held_Item = Pickup_Item; // setting our currently held item slot to be the item we pickup 
                Pickup_Item.transform.parent = Weapon_Holder; // set the parent to our weapon holder
                Pickup_Item.transform.localPosition = new Vector3(0, 0, 0); // set our local position to be the same as the weapon holder
                Pickup_Item.transform.localRotation = Quaternion.Euler(0, 0, 0); // reset the rotatio of our item
                Pickup_Item.gameObject.layer = 9; // PLAYER
                Pickup_Item.GetComponent <PolygonCollider2D>().isTrigger = false; // turn off the idea that it is a trigger TO BE CHANGED TO POLYGONAL COLLIDER

                FindObjectOfType<Audio_Manager>().Play_Sound("Weapon Switch");
                StartCoroutine(Change_Weapon(UI_Image, Current_Held_Item.GetComponent<SpriteRenderer>().sprite)); // chaging the sprite of our wepaon ui image and tweening it
            }

        } else //if we are already holding an item
        {
            if (Input.GetKeyDown(Player_Controls.Pickup_Drop_Item) || Input.GetButtonDown(Player_Controls.Player_Arcade_Controls.Player_Button_A)) // if we press our pickup item key
            {

                Switch_Items(Current_Held_Item, Pickup_Item);
                StartCoroutine(Change_Weapon(UI_Image, Pickup_Item.GetComponent<SpriteRenderer>().sprite)); // chagnign the sprite of our weapon ui image and tweening it
            }

        }
    }

    void Drop_The_Item() // creating a function to drop the item
    {
        if (Input.GetKeyDown(Player_Controls.Pickup_Drop_Item) || Input.GetButtonDown(Player_Controls.Player_Arcade_Controls.Player_Button_A)) // if we press our pickup keycode
        {
            if(Colliding_With_Item == false) // if we are not colliding with items
            {
                if(Is_Holding_Item == true) // if we are holding an item
                {
                    Laser_Sound_Drop(Current_Held_Item); // dropping our sound in the event that our item is a lser
                    Stop_Weapon_Fire(Current_Held_Item); // if our weapon is a standard weapon stop firing

                    Current_Held_Item.transform.parent = null; // drop the item
                    Current_Held_Item.GetComponent<PolygonCollider2D>().isTrigger = true; // reset the box collider to be a trigger
                    Current_Held_Item.gameObject.layer = 10; // ITEMS

                    Current_Held_Item.gameObject.layer = Current_Held_Item.GetComponent<Assign_Layer>().Original_Layer;

                    Current_Held_Item = null; // set the current held item to be nothing
                    Is_Holding_Item = false; // say we are not holding an item

                    Down_Scale_UI(UI_Image);

                }
            }
        }
    }

    void Switch_Items(GameObject Held_Item, GameObject New_Item) // a function for switching items
    {
        Laser_Sound_Drop(Current_Held_Item); // if our item is a laser stop the sound
        Stop_Weapon_Fire(Current_Held_Item); // if our item is a standard weapon stop firing
        Current_Held_Item = null; // set our current held item to none
        Is_Holding_Item = true; // continue to say we are holding an item
        Current_Held_Item = New_Item; // set our current held item to the new item
        Held_Item.transform.parent = null; // set the held items transform to null
        Held_Item.gameObject.layer = 10; // ITEMS

        Held_Item.gameObject.layer = Held_Item.GetComponent<Assign_Layer>().Original_Layer;

        Held_Item.GetComponent<PolygonCollider2D>().isTrigger = true; // return the item to bieng a trigger
        New_Item.transform.parent = Weapon_Holder; // set the transform parent of the new item to our weapon holder
        New_Item.transform.localPosition = new Vector3(0, 0, 0); // set the local position of our new item to our new holder
        New_Item.transform.localRotation = Quaternion.Euler(0, 0, 0); // reset the rotatio of our item
        New_Item.gameObject.layer = 9; // ITEMS
        New_Item.GetComponent<PolygonCollider2D>().isTrigger = false; // set the collider of our new pickedup item to be solid

        FindObjectOfType<Audio_Manager>().Play_Sound("Weapon Switch");



    }


    private void OnTriggerStay2D(Collider2D collision) // if we enter the a trigger
    {
        if(collision.gameObject.tag == "Weapon" || collision.gameObject.tag == "Health_Pack" || collision.gameObject.tag == "Coin" || collision.gameObject.tag == "Bounce_Weapon" || collision.gameObject.tag == "Slice_Weapon" || collision.gameObject.tag == "Explode_Weapon" ||collision.gameObject.tag == "Ammo") // if the item is one of our tagged pickupable items
        {
            Pickup_The_Item(collision.gameObject); // pickup the collision item 
            Colliding_With_Item = true; // we are touching an item
        }

    }

    private void OnTriggerExit2D(Collider2D collision) // if we leave a trigger
    {
        Colliding_With_Item = false; // we not touching an item
    }

    private void OnCollisionEnter2D(Collision2D collision) // if a weapon is thrown at us with a solid collider
    {
        if(collision.gameObject.tag == "Weapon" || collision.gameObject.tag == "Health_Pack" || collision.gameObject.tag == "Coin" || collision.gameObject.tag == "Bounce_Weapon" || collision.gameObject.tag == "Slice_Weapon" || collision.gameObject.tag == "Explode_Weapon" ||collision.gameObject.tag == "Ammo")
        {
            Score_Player_Catch(gameObject); // scoring our player

            if (Is_Holding_Item == false) // if we are not already holding an item
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); // set our velcoity to not take the force of the gameobject that has been thrown
                Is_Holding_Item = true;
                Current_Held_Item = collision.gameObject; // setting our currently held item slot to be the item we pickup 
                collision.gameObject.transform.parent = Weapon_Holder; // set the parent to our weapon holder
                collision.gameObject.transform.localPosition = new Vector3(0, 0, 0); // set our local position to be the same as the weapon holder
                collision.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0); // reset the rotatio of our item
                collision.gameObject.layer = 9; // PLAYER
                collision.gameObject.GetComponent<PolygonCollider2D>().isTrigger = false; // turn off the idea that it is a trigger TO BE CHANGED TO POLYGONAL COLLIDER

                StartCoroutine(Change_Weapon(UI_Image, Current_Held_Item.GetComponent<SpriteRenderer>().sprite)); // chagnign the sprite of our weapon ui image and tweening it

            }

            if (Is_Holding_Item == true) // if we are already holding a weapon
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); // set the velocity to not take the force of the gameobject that has been thrown
                Switch_Items(Current_Held_Item, collision.gameObject); // switch the item for the item we already have
                StartCoroutine(Change_Weapon(UI_Image, Current_Held_Item.GetComponent<SpriteRenderer>().sprite)); // chagnign the sprite of our weapon ui image and tweening it


            }
        }
    }

    void Score_Player_Catch(GameObject Player) // scoring our player
    {
        if (Player.gameObject.name == "Player_1")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_1_Score.Catch_Score += 1;
        }

        if (Player.gameObject.name == "Player_2")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_2_Score.Catch_Score += 1;
        }

        if (Player.gameObject.name == "Player_3")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_3_Score.Catch_Score += 1;
        }

        if (Player.gameObject.name == "Player_4")
        {
            GameObject.FindObjectOfType<Scoring_System>().Player_4_Score.Catch_Score += 1;
        }
    }


    void Laser_Sound_Drop(GameObject Laser) // creating a function for stopping sound if we drop the item and it is our laser
    {
        if(Laser != null)
        {
            if(Laser.GetComponent<laser>() != null)
            {
                if (Laser.GetComponent<laser>().enabled == true) // if this weapon is a laser
                {
                    if (gameObject.name == "Player_1") // if our player is 1
                    {
                        FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 1"); // pause laser fire 1
                    }

                    if (gameObject.name == "Player_2")
                    {
                        FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 2");
                    }
                    if (gameObject.name == "Player_3")
                    {
                        FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 3");
                    }
                    if (gameObject.name == "Player_4")
                    {
                        FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 4");
                    }
                }
            }
        }

    }

    void Stop_Weapon_Fire(GameObject Weapon) // a function to stop our weapon from firing if it is a standard weapon
    {
        if(Weapon != null) // if our weapon exists
        {
            if (Weapon.GetComponent<Fire_Weapon>() != null) // if this weapon contains a fire weapon script
            {
                if (Weapon.GetComponent<Fire_Weapon>().enabled == true) // if this is a standard weapon
                {
                    Weapon.GetComponent<Fire_Weapon>().StopCoroutine("Fire_Gun"); // stop the fire gun coroutine
                }
            }
        }

      
    }
    #region UI
    public IEnumerator Change_Weapon(Image Weapon_Image, Sprite New_Sprite) // this is a coroutine for changign the image associated with each object in our player UI
    {
        //tweening down our object ui
        Weapon_Image.gameObject.LeanScale(Vector3.zero, Tween_Time).setEase(Down_Type);
        Weapon_Text.gameObject.LeanScale(Vector3.zero, Tween_Time).setEase(Down_Type);
        yield return new WaitForSeconds(Tween_Time);
        // Switching Sprites
        Weapon_Image.sprite = New_Sprite;
        //Tweening Back our weapon ui
        Weapon_Image.gameObject.LeanScale(Original_Size, Tween_Time).setEase(Up_Type);
        Weapon_Text.gameObject.LeanScale(Original_Size, Tween_Time).setEase(Up_Type);

    }

    public void Down_Scale_UI(Image Weapon_Image) // a public void made exlsively for downscaling our ui
    {
        Weapon_Image.gameObject.LeanScale(Vector3.zero, Tween_Time).setEase(Down_Type);
        Weapon_Text.gameObject.LeanScale(Vector3.zero, Tween_Time).setEase(Down_Type);
    }

    public void Not_Holding_Weapon_UI() // a void to constantly check if we are not holding anything and therefore need to downscale our ui
    {
        if(Is_Holding_Item == false)
        {
            if(Not_Holding_Weapon_UI_Bool == false)
            {
                Down_Scale_UI(UI_Image);
                Not_Holding_Weapon_UI_Bool = true;
            }
        }
        else
        {
            Not_Holding_Weapon_UI_Bool = false;
        }
    }

    #endregion
}
