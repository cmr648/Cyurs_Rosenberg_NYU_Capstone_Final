using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner : MonoBehaviour
{
    [Header ("Main Tileset")]
    public Corner_Tileset Main_Tileset;

    [Header("Tileset Collections")]
    public Corner_Tileset Grass_Tileset;
    public Corner_Tileset Beach_Tileset;
    public Corner_Tileset Lava_Tileset;
    public Corner_Tileset Snow_Tileset;

    [Header("Raycasting")]
    public float Raycast_Distance;
    RaycastHit2D Left_Hit;
    RaycastHit2D Right_Hit;
    RaycastHit2D Up_Hit;
    RaycastHit2D Down_Hit;

    public GameObject Left_Hit_Object;
    public GameObject Right_Hit_Object;
    public GameObject Up_Hit_Gameobject;
    public GameObject Down_Hit_Object;

    SpriteRenderer Corner_Renderer;
    BoxCollider2D Corner_Collider;

    [Header ("Scales")]
    public Vector2 Horizontal_Middle_Scale;
    public Vector2 Vertical_Middle_Scale;
    public Vector2 Corner_Scale;

    [Header ("Layer Mask")]
    public LayerMask Ray_Mask;


    private void Awake()
    {
        Set_Art_Sets(); // setting our art
    }

    // Start is called before the first frame update
    void Start()
    {
        Corner_Renderer = GetComponent<SpriteRenderer>();
        Corner_Collider = GetComponent<BoxCollider2D>();

        StartCoroutine("Late_Start");
    }

    // Update is called once per frame
    void Update()
    {
        Begin_Raycast();
        Set_Sprite();
    }



    void Set_Sprite()
    {
        if(Left_Hit_Object == null && Right_Hit_Object == null && Up_Hit_Gameobject == null && Down_Hit_Object == null)
        {

            Destroy(gameObject);
        }


        //COMBINATIONS OF 1
        if (Left_Hit_Object != null && Right_Hit_Object == null && Up_Hit_Gameobject == null && Down_Hit_Object == null) // JUST LEFT
        {
            Corner_Renderer.sprite = Main_Tileset.Horizonal_End;

            transform.localRotation = Quaternion.Euler(0, 0, 180); //ROTATING

            transform.localScale = Horizontal_Middle_Scale;
        }

        if (Left_Hit_Object == null && Right_Hit_Object != null && Up_Hit_Gameobject == null && Down_Hit_Object == null) // JUST Right
        {
            Corner_Renderer.sprite = Main_Tileset.Horizonal_End;

            transform.localRotation = Quaternion.Euler(0, 0, 0); //ROTATING

            transform.localScale = Horizontal_Middle_Scale;
        }

        if (Left_Hit_Object == null && Right_Hit_Object == null && Up_Hit_Gameobject != null && Down_Hit_Object == null) // JUST Up
        {
            Corner_Renderer.sprite = Main_Tileset.Vertical_End;
           
            transform.localScale = Vertical_Middle_Scale;

            transform.localRotation = Quaternion.Euler(0, 0, 180); //ROTATING
        }

        if (Left_Hit_Object == null && Right_Hit_Object == null && Up_Hit_Gameobject == null && Down_Hit_Object != null) // JUST Down
        {
            Corner_Renderer.sprite = Main_Tileset.Vertical_End;

            transform.localScale = Vertical_Middle_Scale;

            transform.localRotation = Quaternion.Euler(0, 0, 0); //ROTATING
        }



        if (Left_Hit_Object != null && Right_Hit_Object != null && Up_Hit_Gameobject == null && Down_Hit_Object == null) // left righ
        {
            Corner_Renderer.sprite = Main_Tileset.Horizontal_Middle;

            transform.localScale = Horizontal_Middle_Scale;
        }

        if (Left_Hit_Object != null && Right_Hit_Object == null && Up_Hit_Gameobject != null && Down_Hit_Object == null) // left up
        {
            Corner_Renderer.sprite = Main_Tileset.Left_Turn;

            transform.localRotation = Quaternion.Euler(0, 0, -90); //ROTATING


            transform.localScale = Corner_Scale;
            //ROTATE
        }

        if (Left_Hit_Object != null && Right_Hit_Object == null && Up_Hit_Gameobject == null && Down_Hit_Object != null) // left down
        {
            Corner_Renderer.sprite = Main_Tileset.Right_Turn;

            transform.localRotation = Quaternion.Euler(0, 0, -90); //ROTATING

            transform.localScale = Corner_Scale;
            //ROTATE
        }

        if (Left_Hit_Object == null && Right_Hit_Object != null && Up_Hit_Gameobject != null && Down_Hit_Object == null) // right up
        {
            Corner_Renderer.sprite = Main_Tileset.Right_Turn;

            transform.localRotation = Quaternion.Euler(0, 0, 90); //ROTATING


            transform.localScale = Corner_Scale;

            //ROTATE
        }

        if (Left_Hit_Object == null && Right_Hit_Object != null && Up_Hit_Gameobject == null && Down_Hit_Object != null) // right down
        {
            Corner_Renderer.sprite = Main_Tileset.Left_Turn;

            transform.localRotation = Quaternion.Euler(0, 0, 90); //ROTATING

            transform.localScale = Corner_Scale;

            //ROTATE
        }

        if (Left_Hit_Object == null && Right_Hit_Object == null && Up_Hit_Gameobject != null && Down_Hit_Object != null) // up down
        {
            Corner_Renderer.sprite = Main_Tileset.Vertical_Middle;

            transform.localRotation = Quaternion.Euler(0, 0, 0); //ROTATING

            transform.localScale = Vertical_Middle_Scale;




        }




        if (Left_Hit_Object != null && Right_Hit_Object != null && Up_Hit_Gameobject != null && Down_Hit_Object == null) // left right up
        {
            Corner_Renderer.sprite = Main_Tileset.T_Shape;

            transform.localRotation = Quaternion.Euler(0, 0, 180); //ROTATING

            transform.localScale = Corner_Scale;

            //ROTATE
        }

        if (Left_Hit_Object != null && Right_Hit_Object != null && Up_Hit_Gameobject == null && Down_Hit_Object != null) // left right down
        {
            Corner_Renderer.sprite = Main_Tileset.T_Shape;

            transform.localRotation = Quaternion.Euler(0, 0, 0); //ROTATING

            transform.localScale = Corner_Scale;

            //ROTATE
        }

        if (Left_Hit_Object != null && Right_Hit_Object == null && Up_Hit_Gameobject != null && Down_Hit_Object != null) // left up down
        {
            Corner_Renderer.sprite = Main_Tileset.T_Shape;

            transform.localRotation = Quaternion.Euler(0, 0, -90); //ROTATING

            transform.localScale = Corner_Scale;

            //ROTATE
        }

        if (Left_Hit_Object == null && Right_Hit_Object != null && Up_Hit_Gameobject != null && Down_Hit_Object != null) // right up down
        {
            Corner_Renderer.sprite = Main_Tileset.T_Shape;

            transform.localRotation = Quaternion.Euler(0, 0, 90); //ROTATING

            transform.localScale = Corner_Scale;

            //ROTATE
        }






        if (Left_Hit_Object != null && Right_Hit_Object != null && Up_Hit_Gameobject != null && Down_Hit_Object != null) // ALL
        {
            Corner_Renderer.sprite = Main_Tileset.Cross;

            Corner_Renderer.sortingOrder = 12; // Draw it on top so we can trick the player somehow

            transform.localScale = Corner_Scale;

            //ROTATE
        }







    }


    void Begin_Raycast()
    {
        Left_Hit = Physics2D.Raycast(transform.position, Vector2.left, Raycast_Distance,Ray_Mask);
        Debug.DrawRay(transform.position, Vector2.left * Raycast_Distance, Color.green);

        Right_Hit = Physics2D.Raycast(transform.position, Vector2.right, Raycast_Distance,Ray_Mask);
        Debug.DrawRay(transform.position, Vector2.right * Raycast_Distance, Color.green);

        Up_Hit = Physics2D.Raycast(transform.position, Vector2.up, Raycast_Distance,Ray_Mask);
        Debug.DrawRay(transform.position, Vector2.up * Raycast_Distance, Color.green);

        Down_Hit = Physics2D.Raycast(transform.position, Vector2.down, Raycast_Distance,Ray_Mask);
        Debug.DrawRay(transform.position, Vector2.down * Raycast_Distance, Color.green);


        if(Left_Hit == true)
        {
            if(Left_Hit.transform.gameObject.tag == "Wall")
            {

                Left_Hit_Object = Left_Hit.transform.gameObject;

               
            }

        }
        else
        {
            Left_Hit_Object = null;
        }

        if (Right_Hit == true)
        {
            if(Right_Hit.transform.gameObject.tag == "Wall")
            {
                Right_Hit_Object = Right_Hit.transform.gameObject;
            }

        }
        else
        {
            Right_Hit_Object = null;
        }

        if (Up_Hit == true)
        {
            if(Up_Hit.transform.gameObject.tag == "Wall")
            {
                Up_Hit_Gameobject = Up_Hit.transform.gameObject;
            }


        }
        else
        {
            Up_Hit_Gameobject = null;
        }

        if (Down_Hit == true)
        {
            if(Down_Hit.transform.gameObject.tag == "Wall")
            {
                Down_Hit_Object = Down_Hit.transform.gameObject;
            }

        }
        else
        {
            Down_Hit_Object = null;
        }

    }

 

    IEnumerator Late_Start() 
    {
        yield return new WaitForSeconds(.1f);

        Corner_Collider.enabled = true;
    }

    void Set_Art_Sets() // setting which tileset to draw from
    {
        if(Gameplay_Variables.Level_Art_Set == 0)
        {
            Main_Tileset.Horizontal_Middle = Grass_Tileset.Horizontal_Middle;
            Main_Tileset.Vertical_Middle = Grass_Tileset.Vertical_Middle;
            Main_Tileset.Left_Turn = Grass_Tileset.Left_Turn;
            Main_Tileset.Right_Turn = Grass_Tileset.Right_Turn;
            Main_Tileset.T_Shape = Grass_Tileset.T_Shape;
            Main_Tileset.Cross = Grass_Tileset.Cross;
            Main_Tileset.Vertical_End = Grass_Tileset.Vertical_End;
            Main_Tileset.Horizonal_End = Grass_Tileset.Horizonal_End;
        }


        if (Gameplay_Variables.Level_Art_Set == 1)
        {
            Main_Tileset.Horizontal_Middle = Beach_Tileset.Horizontal_Middle;
            Main_Tileset.Vertical_Middle = Beach_Tileset.Vertical_Middle;
            Main_Tileset.Left_Turn = Beach_Tileset.Left_Turn;
            Main_Tileset.Right_Turn = Beach_Tileset.Right_Turn;
            Main_Tileset.T_Shape = Beach_Tileset.T_Shape;
            Main_Tileset.Cross = Beach_Tileset.Cross;
            Main_Tileset.Vertical_End = Beach_Tileset.Vertical_End;
            Main_Tileset.Horizonal_End = Beach_Tileset.Horizonal_End;
        }

        if (Gameplay_Variables.Level_Art_Set == 2)
        {
            Main_Tileset.Horizontal_Middle = Snow_Tileset.Horizontal_Middle;
            Main_Tileset.Vertical_Middle = Snow_Tileset.Vertical_Middle;
            Main_Tileset.Left_Turn = Snow_Tileset.Left_Turn;
            Main_Tileset.Right_Turn = Snow_Tileset.Right_Turn;
            Main_Tileset.T_Shape = Snow_Tileset.T_Shape;
            Main_Tileset.Cross = Snow_Tileset.Cross;
            Main_Tileset.Vertical_End = Snow_Tileset.Vertical_End;
            Main_Tileset.Horizonal_End = Snow_Tileset.Horizonal_End;
        }

        if (Gameplay_Variables.Level_Art_Set == 3)
        {
            Main_Tileset.Horizontal_Middle = Lava_Tileset.Horizontal_Middle;
            Main_Tileset.Vertical_Middle = Lava_Tileset.Vertical_Middle;
            Main_Tileset.Left_Turn = Lava_Tileset.Left_Turn;
            Main_Tileset.Right_Turn = Lava_Tileset.Right_Turn;
            Main_Tileset.T_Shape = Lava_Tileset.T_Shape;
            Main_Tileset.Cross = Lava_Tileset.Cross;
            Main_Tileset.Vertical_End = Lava_Tileset.Vertical_End;
            Main_Tileset.Horizonal_End = Lava_Tileset.Horizonal_End;
        }
    }


}

