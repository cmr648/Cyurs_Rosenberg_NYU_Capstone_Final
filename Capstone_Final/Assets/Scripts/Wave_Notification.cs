using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Notification : MonoBehaviour
{
    [Header("Text Editing")]
    public string Wave_Text_String; // the text we want to display to our player

    Text Wave_Text; // the text object we will be using

    [Header ("Enemy Tracking")]
    public Text Enemy_Notification_Text;
    public string Enemy_Text_String;
    public float Enemy_Number;

    [Header("Wave Tracking")]
    public float Wave_Number; // a number that will show the players what wave they are on

    [Header("Tweening")]
    public float Tween_Scale; // the scale we want our text to grow to
    public float Tween_Speed; // the speed we want it to scale at
    public LeanTweenType Tween_Type_Up; // the tweentype for our up scale
    public LeanTweenType Tween_Type_Down; // the tweentype for our down scale
    public float Down_Scale_Wait; // the wait time once it is up scaled
    public Vector3 Original_Scale; // the vector 3 that will sotre the original scale

    [Header("Text Colors")]
    public Color[] Colors_List;

    // Start is called before the first frame update
    void Start()
    {
        Wave_Number = 0; // our wave number is always 0 at the start
        Wave_Text = GetComponent<Text>();
        gameObject.transform.localScale = Vector3.zero;
        Enemy_Notification_Text.gameObject.transform.localScale = Vector3.zero;
        Original_Scale = gameObject.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        Wave_Text.text = Wave_Text_String + " " + Wave_Number.ToString(); // adding our text

        Enemy_Notification_Text.text = Enemy_Text_String + " " + Enemy_Number.ToString(); // adding our enemy text

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine("Scale_Up_Down_Wave_Text");
        //}
    }

    public IEnumerator Scale_Up_Down_Wave_Text() // a coroutine that will scale up and down our portal using LeanTween
    {
        Pick_Text_Color(); // chaging our text color

        Wave_Number += 1; // adding one to our wave number

        Enemy_Number += 10;

        FindObjectOfType<Audio_Manager>().Play_Sound("Level Up"); // playing our level up sound

        gameObject.LeanScale(new Vector3(Tween_Scale,Tween_Scale,Tween_Scale), Tween_Speed).setEase(Tween_Type_Up);
        Enemy_Notification_Text.gameObject.LeanScale(new Vector3(Tween_Scale, Tween_Scale, Tween_Scale), Tween_Speed).setEase(Tween_Type_Up);
        yield return new WaitForSeconds(Tween_Speed + Down_Scale_Wait);
        gameObject.LeanScale(Original_Scale, Tween_Speed).setEase(Tween_Type_Down);
        Enemy_Notification_Text.gameObject.LeanScale(Original_Scale, Tween_Speed).setEase(Tween_Type_Down);

    }


    public void Pick_Text_Color()
    {
        int index = Random.Range(0, Colors_List.Length);

        Wave_Text.color = Colors_List[index];
        Enemy_Notification_Text.color = Colors_List[index]; 
    }
}
