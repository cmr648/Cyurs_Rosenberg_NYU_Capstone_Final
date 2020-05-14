using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Camera))]
public class Main_Game_Camera : MonoBehaviour
{
    [Header ("Camera Targets")]
    public List<Transform> Targets; // creating a list of all of our camera targets

    [Header ("Camera Offset")]
    public Vector3 Offset; // in case we want to offset our camera

    [Header("Camera_Speed Variables")]
    public float Smooth_Time; // creating a float for our smooth time

    [Header ("Camera Zoom Variables")]
    public float Minimum_Zoom; //the minimum zoom that the camera can be
    public float Maximum_Zoom; // the maximum zoom that the camera can be
    public float Zoom_Limit; // a float to get the maximum zoom limit that can be
    public float Zoom_Speed; // a float to get the maximum zoom speed

    Vector3 Velocity; // creating a vector for camera movement velocity

    Camera Gameobject_Camera; // creating a variable for our the camera that this script is on

    [Header("Camera Bounds")]
    public Transform Right_Bound;
    public Transform Left_Bound;
    public Transform Up_Bound;
    public Transform Down_Bound;
    public float Camera_Wide_Screen_Offset;

    // Start is called before the first frame update
    void Start()
    {
        Gameobject_Camera = GetComponent<Camera>(); // assiginging our camera
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() // only runs afet eveythign else has run
    {
        if (Targets.Count == 0) // if we have no targets
        {
            return; // end this script
        }

        Move_Camera(); // implementing our camera move function
        Zoom_Camera(); // implementing our camera zoom function
    }

    void Move_Camera() // creating a seperate function to move our camera
    {

        Vector3 CenterPoint = Get_Center_Point(); // setting our center point for all objects

        Vector3 New_Position = CenterPoint + Offset; // creating a new position for the camera to go to 

        //transform.position = Vector3.SmoothDamp(transform.position, New_Position, ref Velocity, Smooth_Time); // setting our camera position to our new position 
        transform.position = New_Position;  //FOR NOW
        //transform.position = Vector3.Lerp(transform.position, New_Position, Time.deltaTime * 2);
    }

    void Zoom_Camera() // a seperate function to make our camera zoom in and out
    {
        float New_Zoom = Mathf.Lerp(Maximum_Zoom, Minimum_Zoom, Get_Greatest_Distance()/Zoom_Limit); // create a new zoom baseed on the greatest distance between two game objects

        Gameobject_Camera.orthographicSize = Mathf.Lerp(Gameobject_Camera.orthographicSize,New_Zoom,Time.deltaTime * Zoom_Speed); // setting our actual camera size to the new zoom

    }

    float Get_Greatest_Distance() // a function to get the greatest distance between any two of our targets
    {
        var Bounds = new Bounds(Targets[0].position, Vector3.zero); // creating a bounds for all gameobnjects
       
        for (int i = 0; i < Targets.Count; i++) // for each item in all of our targets
        {
            Bounds.Encapsulate(Targets[i].position); // add the targets position to our bounds

        }
        if(Bounds.size.x > Bounds.size.y)
        {
            return Bounds.size.x; // return the width of the bounding box that encapsulates all of our targets
        }
        else
        {
            return Bounds.size.y; // return the height
        }



    }


    Vector3 Get_Center_Point() // a function to get the center of all the targets 
   {
        if (Targets.Count == 1) //if we only have one target
        {
            return Targets[0].transform.position; // return only the position of the first target
        }

        var Bounds = new Bounds(Targets[0].position, Vector3.zero); // creting an ew bounds

        for(int i = 0; i< Targets.Count; i++) // for each item in all of our targets
        {
            Bounds.Encapsulate(Targets[i].position); // add the targets position to our bounds

        }

        //  return Bounds.center; // return the center of the bounds

        return new Vector3(Mathf.Clamp(Bounds.center.x, Left_Bound.position.x + Gameobject_Camera.orthographicSize *Camera_Wide_Screen_Offset, Right_Bound.position.x - Gameobject_Camera.orthographicSize * Camera_Wide_Screen_Offset), Mathf.Clamp(Bounds.center.y, Down_Bound.position.y + Gameobject_Camera.orthographicSize, Up_Bound.position.y - Gameobject_Camera.orthographicSize), Bounds.center.z); // returning a center within the bounds of our level
    }


}
