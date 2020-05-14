using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Ammo : MonoBehaviour
{
    [Header ("Ammo Tracking")]
    public float Current_Ammo;
    public float Ammo_Loss_Units;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Current_Ammo <= 0) // if we run out of ammo
        {
            if(transform.parent != null) // if we are bieng held
            {
                GameObject Player_Object = gameObject.transform.root.gameObject; // getting our player gameobject

                Player_Object.GetComponent<Pickup_Item_New>().Current_Held_Item = null;
                Player_Object.GetComponent<Pickup_Item_New>().Is_Holding_Item = false;

                FindObjectOfType<Audio_Manager>().Play_Sound("Weapon Break"); // playing audio

                if (GetComponent<laser>().isActiveAndEnabled)
                {
                    if(transform.root.gameObject.name == "Player_1") // if our player is 1
                    {
                        FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 1"); // stopping our laser sound

                    }

                    if (transform.root.gameObject.name == "Player_2") // if our player is 1
                    {
                        FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 2"); // stopping our laser sound

                    }

                    if (transform.root.gameObject.name == "Player_3") // if our player is 1
                    {
                        FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 3"); // stopping our laser sound

                    }

                    if (transform.root.gameObject.name == "Player_4") // if our player is 1
                    {
                        FindObjectOfType<Audio_Manager>().Pause_Sound("Laser Fire 4"); // stopping our laser sound

                    }


                }

                Destroy(gameObject);
            }
        }
    }
}
