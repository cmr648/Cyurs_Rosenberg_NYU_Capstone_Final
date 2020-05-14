using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Art : MonoBehaviour
{
    public Weapon_Artset Weapon_Art_Holders; // creating a weapon artset

    [Header("Weapon Sprites")]
    public Sprite Profile;
    public Sprite Top_Down;

    Create_Weapon This_Weapon; // creating a slot for this weapon

    SpriteRenderer Weapon_Renderer; // creating a slot for our sprite renderer

    [Header("Weapon_UI_Text")]
    public GameObject Weapon_Description_Text; // creating a reference to our weapon description text


    // Start is called before the first frame update
    void Start()
    {

        This_Weapon = GetComponent<Create_Weapon>(); // assigning our create weapon script
        Weapon_Renderer = GetComponent<SpriteRenderer>();

        Choose_Weapon();
    }

    // Update is called once per frame
    void Update()
    {
        Weapon_Special_Rotations(); // implementing our wepaon rotations script
        Set_Weapon_Art();
      
    }

    void Choose_Weapon() // a function to choos eweapon 
    {
        if (This_Weapon.Pistol == true)
        {
            Profile = Weapon_Art_Holders.Pistol_Gun_Profile;
            Top_Down = Weapon_Art_Holders.Pistol_Gun_Top_Down;
        }

        if (This_Weapon.Shotgun == true)
        {
            Profile = Weapon_Art_Holders.Shotgun_Gun_Profiles;
            Top_Down = Weapon_Art_Holders.Shotgun_Gun_Top_Down;
        }

        if (This_Weapon.Machine_Gun == true)
        {
            Profile = Weapon_Art_Holders.Machine_Gun_Profile;
            Top_Down = Weapon_Art_Holders.Machine_Gun_Top_Down;
        }

        if (This_Weapon.Laser == true)
        {
            Profile = Weapon_Art_Holders.Laser_Gun_Profile;
            Top_Down = Weapon_Art_Holders.Laser_Gun_Top_Down;

        }

        if (This_Weapon.Sniper == true)
        {
            Profile = Weapon_Art_Holders.Sniper_Gun_Profile;
            Top_Down = Weapon_Art_Holders.Sniper_Gun_Top_Down;
        }

    }

    void Set_Weapon_Art()
    {
        if (transform.parent != null) // if we are bieng held
        {
            Weapon_Renderer.sprite = Top_Down; // top down

            gameObject.transform.localScale = new Vector3(.5f, .5f, .5f); // set scale to be smaller when bieng held
        }
        else
        {
            Weapon_Renderer.sprite = Profile; // top down

            gameObject.transform.localScale = new Vector3(3, 3, 3); // set scale to bieng larger so guns are seen when not bieng held

        }
    }

    void Weapon_Special_Rotations() // special rotations for readability
    {
        if (transform.parent != null) // if we ARE bieng held by any player
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0); // make our local rotation 0 0 0 
           
        }

        if (transform.eulerAngles == new Vector3(0, 0, 180)) // if our weapon is ever upside down
        {
            if (transform.parent == null) // if we are not bieng held by the player
            {
                Weapon_Renderer.flipY = true; // flip the y sprie renderer
                Weapon_Description_Text.transform.localPosition = new Vector3(Weapon_Description_Text.transform.localPosition.x, Mathf.Abs(Weapon_Description_Text.transform.localPosition.y) * -1, Weapon_Description_Text.transform.localPosition.z); // change the position of our text to be at the top of the gun
                Weapon_Description_Text.transform.localRotation = Quaternion.Euler(0, 0, 180); // rotate the local position of our text to always be readable
            }

            else // if we are bieng held by the player
            {
                Weapon_Renderer.flipY = false; // dont flip the y spriet renedeerer

                Weapon_Description_Text.transform.localPosition = new Vector3(Weapon_Description_Text.transform.localPosition.x, Mathf.Abs(Weapon_Description_Text.transform.localPosition.y), Weapon_Description_Text.transform.localPosition.z); // change the position of our text to be at the top of the gun

                Weapon_Description_Text.transform.localRotation = Quaternion.Euler(0, 0, 0); // rotate the local position fo our text to always be readable

            }

        }
        else // if our weapon is not upside down
        {
            Weapon_Renderer.flipY = false; // dont flip the y spriet renedeerer

            Weapon_Description_Text.transform.localPosition = new Vector3(Weapon_Description_Text.transform.localPosition.x, Mathf.Abs(Weapon_Description_Text.transform.localPosition.y), Weapon_Description_Text.transform.localPosition.z); // change the position of our text to be at the top of the gun

            Weapon_Description_Text.transform.localRotation = Quaternion.Euler(0, 0, 0); // rotate the local position fo our text to always be readable

        }

       

    }
}