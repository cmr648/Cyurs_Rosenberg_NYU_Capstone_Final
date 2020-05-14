using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Second_Wind : MonoBehaviour
{
    [Header ("Text Colors")]
    public Color[] Text_Colors;

    [Header("Tweening")]
    public float Scale_Size;
    public float Scale_Time;
    public float Notification_Wait_Time;
    public LeanTweenType Up_Scale_Tween_Type;
    public LeanTweenType Down_Scale_Tween_Type;

    [Header("Second Wind Variables")]
    public float Health_To_Gain;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine("Notify_Second_Wind");
        //}
    }

    public IEnumerator Notify_Second_Wind()
    {
        foreach(Player_Stats Player in FindObjectsOfType<Player_Stats>()) // finding all players in scene
        {
            Player.Player_Current_Health += Health_To_Gain; // giving them extra health
            Player.gameObject.GetComponent<Player_Stats>().StartCoroutine("Player_Take_Health_Render"); // making our players change color as they gain health
        }

        int Color_Index = Random.Range(0, Text_Colors.Length); // picking a random color

        GetComponent<Text>().color = Text_Colors[Color_Index]; // assiging that random color to our text

        gameObject.LeanScale(new Vector3(Scale_Size, Scale_Size, Scale_Size), Scale_Time).setEase(Up_Scale_Tween_Type);
        yield return new WaitForSeconds(Scale_Time + Notification_Wait_Time);
        gameObject.LeanScale(new Vector3(0, 0, 0), Scale_Time).setEase(Down_Scale_Tween_Type);

    }
}
