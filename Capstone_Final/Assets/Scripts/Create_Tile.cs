using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Tile : MonoBehaviour
{
    public GameObject[] Tiles;
    GameObject Tile;

    // Start is called before the first frame update
    void Start()
    {
        Make_Tile();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Destroy(Tile);
        //    Make_Tile();
        //}
       
    }


    void Make_Tile()
    {
        
        int Index = Random.Range(0, Tiles.Length);
        Tile = Instantiate(Tiles[Index], transform.position, Quaternion.identity,gameObject.transform);
    }

    

}
