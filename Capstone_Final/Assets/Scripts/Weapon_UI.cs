using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_UI : MonoBehaviour
{
    public Text Weapon_Text; // getting a slot for our weapon text

    public float Lerp_Scale_Min; // our scale minimum
    public float Lerp_Scale_Max; // our scale maximum

    public bool Min;

    [Header("Weapon Text Colors")]
    public Color Standard_Ammo_Color;
    public Color Slice_Ammo_Color;
    public Color Explode_Ammo_Color;
    public Color Bounce_Ammo_Color;
    Create_Weapon Current_Weapon; // a create weapon script for our current weapon

    // Start is called before the first frame update
    void Start()
    {
        Current_Weapon = GetComponent<Create_Weapon>(); // assigingin our current weapon script

        Min = true;

        Weapon_Text.text = transform.root.name;

        Set_Text_Color(); // setting our text color on start
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Min == true)
        {
            Vector3 Scale_Min = new Vector3(Lerp_Scale_Min, Lerp_Scale_Min, Lerp_Scale_Min);

            Weapon_Text.transform.localScale = Vector3.MoveTowards(Weapon_Text.transform.localScale, Scale_Min, Time.deltaTime * 2);
        }
        else 
        {
            Vector3 Scale_Max = new Vector3(Lerp_Scale_Max, Lerp_Scale_Max, Lerp_Scale_Max);

            Weapon_Text.transform.localScale = Vector3.MoveTowards(Weapon_Text.transform.localScale, Scale_Max, Time.deltaTime * 2);

        }

        if(transform.parent != null) // if the weapon is bieng held
        {
            Min = true;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Min = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            Min = true;
        }
    }

    void Set_Text_Color() // a function to set our text color
    {
        if(Current_Weapon.Standard_Ammo == true)
        {
            Weapon_Text.color = Standard_Ammo_Color;
        }

        if (Current_Weapon.Bounce_Ammo == true)
        {
            Weapon_Text.color = Bounce_Ammo_Color;
        }

        if (Current_Weapon.Slice_Ammo == true)
        {
            Weapon_Text.color = Slice_Ammo_Color;
        }

        if (Current_Weapon.Explode_Ammo == true)
        {
            Weapon_Text.color = Explode_Ammo_Color;
        }


    }

}
