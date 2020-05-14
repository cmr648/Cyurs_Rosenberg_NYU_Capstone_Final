using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Weapon : MonoBehaviour
{
    [Header("Weapon Type")]
    public bool Pistol;
    public bool Shotgun;
    public bool Laser;
    public bool Sniper;
    public bool Machine_Gun;

    [Header("Bullet Attributes")]
    public bool Slice_Ammo;
    public bool Standard_Ammo;
    public bool Bounce_Ammo;
    public bool Explode_Ammo;

    [Header("Weapon_Attributes")]
    public bool Bounce_Weapon;
    public bool Slice_Weapon;
    public bool Standard_Weapon;
    public bool Exploding_Weapon;


    string Weapon_Type;
    string Bullet_Atribute;
    string Weapon_Attribute;

    [Header ("Weapon Sprites")]
    public Sprite Pistol_Sprite;
    public Sprite Shotgun_Sprite;
    public Sprite Laser_Sprite;
    public Sprite Sniper_Sprite;
    public Sprite Machine_Gun_Sprite;

    [Header ("Weapon Name")]
    public string Weapon_Name;



    private void Awake()
    {
        Build_Weapon();
        Name_Weapon();
        Draw_Weapon();
        Assign_Tag();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Build_Weapon()
    {
        int Weapon_Type_Index = Random.Range(0,5);
        int Bullet_Type_Index = Random.Range(0,4);
        int Weapon_Atribute_Index = Random.Range(0,4);

        //WEAPON TYPE
        if(Weapon_Type_Index == 0)
        {
            Pistol = true;
        }
        if (Weapon_Type_Index == 1)
        {
            Shotgun = true;
        }
        if (Weapon_Type_Index == 2)
        {
            Laser = true;
        }
        if (Weapon_Type_Index == 3)
        {
            Sniper = true;
        }
        if (Weapon_Type_Index == 4)
        {
            Machine_Gun = true;
        }

        //BULLET_TYPE
        if(Bullet_Type_Index == 0)
        {
            Bounce_Ammo = true;
        }
        if (Bullet_Type_Index == 1)
        {
            Slice_Ammo = true;
        }
        if (Bullet_Type_Index == 2)
        {
            Standard_Ammo = true;
        }
        if (Bullet_Type_Index == 3)
        {
            Explode_Ammo = true;
        }

        //WEAPON ATTRUBUTE
        if(Weapon_Atribute_Index == 0)
        {
            Bounce_Weapon = true;
        }
        if (Weapon_Atribute_Index == 1)
        {
            Slice_Weapon = true;
        }
        if (Weapon_Atribute_Index == 2)
        {
            Standard_Weapon = true;
        }
        if (Weapon_Atribute_Index == 3)
        {
            Exploding_Weapon = true;
        }

    }

    void Name_Weapon()
    {
        //WEAPON
        if(Pistol == true)
        {
            Weapon_Type = "Pistol";

        }
        if(Shotgun == true)
        {
            Weapon_Type = "Shotgun";

        }
        if(Laser == true)
        {
            Weapon_Type = "Laser";
        }
        if(Sniper == true)
        {
            Weapon_Type = "Sniper";
        }
        if(Machine_Gun == true)
        {
            Weapon_Type = "Machine Gun";
        }

        //AMMO
        if (Slice_Ammo == true)
        {
            Bullet_Atribute = "Slicing Ammo";
        }
        if (Standard_Ammo == true)
        {
            Bullet_Atribute = "Standard Ammo";
        }
        if (Explode_Ammo == true)
        {
            Bullet_Atribute = "Explode Ammo";
        }
        if (Bounce_Ammo == true)
        {
            Bullet_Atribute = "Bounce Ammo";
        }

        //WEAPON ATTRIBUTE
        if (Slice_Weapon == true)
        {
            Weapon_Attribute = "Slicing";
        }

        if (Standard_Weapon == true)
        {
            Weapon_Attribute = "Standard";
        }
        if (Exploding_Weapon == true)
        {
            Weapon_Attribute = "Exploding";
        }
        if (Bounce_Weapon == true)
        {
            Weapon_Attribute = "Bouncing";
        }

        Weapon_Name = Bullet_Atribute + " " + Weapon_Attribute + " " + Weapon_Type;
        gameObject.name = Weapon_Name;
    }

    void Draw_Weapon() // function that applise the sprite to the weapon
    {
        if (Pistol == true)
        {
            GetComponent<SpriteRenderer>().sprite = Pistol_Sprite;
            gameObject.AddComponent<PolygonCollider2D>();
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }
        if (Shotgun == true)
        {
            GetComponent<SpriteRenderer>().sprite = Shotgun_Sprite;
            gameObject.AddComponent<PolygonCollider2D>();
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }
        if (Laser == true)
        {
            GetComponent<SpriteRenderer>().sprite = Laser_Sprite;
            gameObject.AddComponent<PolygonCollider2D>();
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }
        if (Sniper == true)
        {
            GetComponent<SpriteRenderer>().sprite = Sniper_Sprite;
            gameObject.AddComponent<PolygonCollider2D>();
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }
        if (Machine_Gun == true)
        {
            GetComponent<SpriteRenderer>().sprite = Machine_Gun_Sprite;
            gameObject.AddComponent<PolygonCollider2D>();
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }

    }

    void Assign_Tag()
    {
        if(Standard_Weapon == true)
        {
            gameObject.tag = "Weapon";
        }

        if (Bounce_Weapon == true)
        {
            gameObject.tag = "Bounce_Weapon";
            gameObject.layer = 12;
        }

        if (Slice_Weapon == true)
        {
            gameObject.tag = "Slice_Weapon";
        }
        if(Exploding_Weapon == true)
        {
            gameObject.tag = "Explode_Weapon";
        }
    }
}
