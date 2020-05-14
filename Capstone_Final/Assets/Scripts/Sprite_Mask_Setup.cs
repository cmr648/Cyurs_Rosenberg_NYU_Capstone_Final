using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Mask_Setup : MonoBehaviour
{
    public bool Trigger_Entered;

    GameObject[] Splat_Points;

    public float Max_Distance;

    // Start is called before the first frame update
    void Start()
    {
        Trigger_Entered = false;
        Splat_Points = GameObject.FindGameObjectsWithTag("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject Wall in Splat_Points)
        {
            if(Vector3.Distance(transform.position,Wall.transform.position) < Max_Distance)
            {
                if(Wall.GetComponent<SpriteMask>() == null)
                {

                   SpriteMask Wall_Spritemask =  Wall.gameObject.AddComponent<SpriteMask>();

                    Wall_Spritemask.sprite = Wall.gameObject.GetComponent<SpriteRenderer>().sprite;
                }
            }
            else
            {
                if (Wall.GetComponent<SpriteMask>() != null)
                {

                   Destroy(Wall.gameObject.AddComponent<SpriteMask>());
                }
            }
        }
    }


}
