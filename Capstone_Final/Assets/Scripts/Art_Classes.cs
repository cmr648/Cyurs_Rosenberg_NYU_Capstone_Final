using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Art_Classes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable]
public class Corner_Tileset // creating a class for our list of tile sets
{
    public Sprite Horizontal_Middle;
    public Sprite Vertical_Middle;
    public Sprite Right_Turn;
    public Sprite Left_Turn;
    public Sprite T_Shape;
    public Sprite Cross;
    public Sprite Horizonal_End;
    public Sprite Vertical_End;


}


[System.Serializable]
public class Weapon_Artset // an artset for all of our weapons
{
    [Header ("Pistol")]
    public Sprite Pistol_Gun_Profile;
    public Sprite Pistol_Gun_Top_Down;

    [Header ("Laser Gun")]
    public Sprite Laser_Gun_Profile;
    public Sprite Laser_Gun_Top_Down;

    [Header ("Sniper")]
    public Sprite Sniper_Gun_Profile;
    public Sprite Sniper_Gun_Top_Down;


    [Header("Shotgun")]
    public Sprite Shotgun_Gun_Profiles;
    public Sprite Shotgun_Gun_Top_Down;

    [Header ("Machine Gun")]
    public Sprite Machine_Gun_Profile;
    public Sprite Machine_Gun_Top_Down;
    

}
