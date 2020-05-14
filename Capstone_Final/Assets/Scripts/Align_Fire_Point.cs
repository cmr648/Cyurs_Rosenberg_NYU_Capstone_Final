using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align_Fire_Point : MonoBehaviour
{
    [Header("Fire Point Vectors")]
    public Vector2 Pistol_Fire_Point;
    public Vector2 Machine_Gun_Fire_Point;
    public Vector2 Shotgun_Fire_Point;
    public Vector2 Laser_Fire_Point;
    public Vector2 Sniper_Fire_Point;

    [Header("Prefabs")]
    public Transform Fire_Point_Object;

    Create_Weapon Weapon_Object;

    // Start is called before the first frame update
    void Start()
    {
        Weapon_Object = GetComponent<Create_Weapon>(); // assigning our weapon attributes

        Align_Weapon_Fire_Point(); // implementing our align fire point object
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Align_Weapon_Fire_Point()
    {
        if(Weapon_Object.Pistol == true)
        {
            Fire_Point_Object.localPosition = Pistol_Fire_Point;
        }

        if (Weapon_Object.Shotgun == true)
        {
            Fire_Point_Object.localPosition = Shotgun_Fire_Point;
        }

        if (Weapon_Object.Machine_Gun == true)
        {
            Fire_Point_Object.localPosition = Machine_Gun_Fire_Point;
        }

        if (Weapon_Object.Laser == true)
        {
            Fire_Point_Object.localPosition = Laser_Fire_Point;
        }

        if (Weapon_Object.Sniper == true)
        {
            Fire_Point_Object.localPosition = Sniper_Fire_Point;
        }
    }
}
