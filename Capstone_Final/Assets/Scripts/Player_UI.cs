using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // using UI
using TMPro;


public class Player_UI : MonoBehaviour
{
    [Header("Player Objects")]
    public GameObject Player_1;
    public GameObject Player_2;
    public GameObject Player_3;
    public GameObject Player_4;

    [Header ("Health Bars")]
    public Image Player_1_Health_Bar;
    public Image Player_2_Health_Bar;
    public Image Player_3_Health_Bar;
    public Image Player_4_Health_Bar;
    public float Ammo_Loss_Speed; // the speed at which the player loses health as shown by the UI

    [Header("Ammo Text")]
    public Text Player_1_Ammo_Text;
    public Text Player_2_Ammo_Text;
    public Text Player_3_Ammo_Text;
    public Text Player_4_Ammo_Text;

    public TMP_Text Text_Player_1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Health_Bar_Control();
        Ammo_Text_Control();
    }

    void Health_Bar_Control()
    {

        // Lerping player health on health bar
        Player_1_Health_Bar.fillAmount = Mathf.MoveTowards(Player_1_Health_Bar.fillAmount, Player_1.GetComponent<Player_Stats>().Player_Current_Health / Player_1.GetComponent<Player_Stats>().Player_Start_Health,Time.deltaTime * Ammo_Loss_Speed);

        Player_2_Health_Bar.fillAmount = Mathf.MoveTowards(Player_2_Health_Bar.fillAmount, Player_2.GetComponent<Player_Stats>().Player_Current_Health / Player_2.GetComponent<Player_Stats>().Player_Start_Health, Time.deltaTime * Ammo_Loss_Speed);

        Player_3_Health_Bar.fillAmount = Mathf.MoveTowards(Player_3_Health_Bar.fillAmount, Player_3.GetComponent<Player_Stats>().Player_Current_Health / Player_3.GetComponent<Player_Stats>().Player_Start_Health, Time.deltaTime * Ammo_Loss_Speed);


        Player_4_Health_Bar.fillAmount = Mathf.MoveTowards(Player_4_Health_Bar.fillAmount, Player_4.GetComponent<Player_Stats>().Player_Current_Health / Player_4.GetComponent<Player_Stats>().Player_Start_Health, Time.deltaTime * Ammo_Loss_Speed);


    }


    void Ammo_Text_Control()
    {
        if(Player_1.GetComponentInChildren<Fire_Weapon>() != null)
        {


            Player_1_Ammo_Text.text = "x" + Player_1.GetComponentInChildren<Weapon_Ammo>().Current_Ammo.ToString("00");

          
        }
        else
        {
            Player_1_Ammo_Text.text = " ";
           
        }

        if (Player_2.GetComponentInChildren<Fire_Weapon>() != null)
        {
            Player_2_Ammo_Text.text = "x" + Player_2.GetComponentInChildren<Weapon_Ammo>().Current_Ammo.ToString("00");
        }
        else
        {
            Player_2_Ammo_Text.text = " ";
        }

        if (Player_3.GetComponentInChildren<Fire_Weapon>() != null)
        {
            Player_3_Ammo_Text.text = "x" + Player_3.GetComponentInChildren<Weapon_Ammo>().Current_Ammo.ToString("00");
        }
        else
        {
            Player_3_Ammo_Text.text = " ";
        }

        if (Player_4.GetComponentInChildren<Fire_Weapon>() != null)
        {
            Player_4_Ammo_Text.text = "x" + Player_4.GetComponentInChildren<Weapon_Ammo>().Current_Ammo.ToString("00"); //STRING FORMAT
        }
        else
        {
            Player_4_Ammo_Text.text = " ";
        }
    }
}
