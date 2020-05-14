using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Design_Functions : MonoBehaviour
{

   public static GameObject Find_Closest_Gameobject(Transform Current_Object, GameObject[] gameObjects) // a function to fund the closest gameobject of a chosen array
    {
        GameObject Closest_Object = null;
        float Minimum_Distance = Mathf.Infinity;
        Vector3 currentPos = Current_Object.transform.position;
        foreach (GameObject Search_Object in gameObjects)
        {
            float Distance = Vector3.Distance(Search_Object.transform.position, currentPos);
            if (Distance < Minimum_Distance)
            {
                Closest_Object = Search_Object;
                Minimum_Distance = Distance;
            }
        }
        return Closest_Object.gameObject;
    }

    public static GameObject Find_Furthest_Gameobject(Transform Current_Object, GameObject[] gameObjects) // function to find the furthest gameobeject of a chosen array
    {
        GameObject Furthest_Object = null;
        float Minimum_Distance = 0;
        Vector3 currentPos = Current_Object.transform.position;
        foreach (GameObject Search_Object in gameObjects)
        {
            float Distance = Vector3.Distance(Search_Object.transform.position, currentPos);
            if (Distance > Minimum_Distance)
            {
                Furthest_Object = Search_Object;
                Minimum_Distance = Distance;
            }
        }
        return Furthest_Object.gameObject;
    }


    public static Quaternion Look_At_Object_2D(GameObject Current_Gameobject, GameObject Object_To_Look_At) // a function to always look at a specific point in 2D
    {
        Vector3 Difference = Current_Gameobject.transform.position - Object_To_Look_At.transform.position;
        float RotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;

        return (Quaternion.Euler(0.0f, 0.0f, RotationZ));

    }

    public static Quaternion Look_At_Object_2D_Y_Forward(GameObject Current_Gameobject, GameObject Object_To_Look_At) // a function to always look at a specific point in 2D with the yellow arrow always facing the player
    {
        Vector3 Difference = Current_Gameobject.transform.position - Object_To_Look_At.transform.position;
        float RotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;

        return (Quaternion.Euler(0.0f, 0.0f, RotationZ + 90));

    }

    public static int Find_Greatest_In_Int_Array(int[] Array) // a function to always find the greatest in an array of ints
    {
        int Greatest = 0;

        for(int i = 0; i < Array.Length; i++)
        {
            if(Array[i] > Greatest)
            {
                Greatest = Array[i];
            }
        }

        return Greatest;
    }


    public static float Find_Greatest_In_Float_Array(float[] Array) // a function to always find the greatest in an array of floats
    {
        float Greatest = 0;

        for (int i = 0; i < Array.Length; i++)
        {
            if (Array[i] > Greatest)
            {
                Greatest = Array[i];
            }
        }

        return Greatest;
    }


}
