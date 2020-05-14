using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Conidtions_New : MonoBehaviour
{
    public bool All_Players_Dead; // a bool that will only return true if all the players are alive

    public List<bool> Players_Alive; // a list of bools that will check if all the players are alive

    public GameObject[] Players_In_Game; // a list of the players in game period

    public float Current_Seconds_Dead; // a floar that says the amount of time all the players are dead
    public float Max_Seconds_Dead; // a float that will tell us the max amount of seconds they can be dead


    [Header("Game Over Notification Settings")]
    public GameObject Game_Over_Text;
    public float Text_Scale;
    public float Time_To_Scale;
    public LeanTweenType Tween_Type;
    public bool Tween_Once;

    // Start is called before the first frame update
    void Start()
    {
        Find_Players(); // implementing our find players void at the beginning of the scene
    }

    // Update is called once per frame
    void Update()
    {


        for (int i = 0; i < Players_In_Game.Length; i++) // for each player in the game
        {
            Players_Alive[i] = !Players_In_Game[i].GetComponent<Player_Stats>().Player_Dead; // check wehather the players in game are alive
        }

        All_Players_Dead = Check_For_All_Players_Dead(); // checkign to see if all players are dead

        Move_To_Next_Scene();

       
    }

    bool Check_For_All_Players_Dead() // this will check if all players are dead
    {
        if (Players_Alive.Contains(true)) // if not all of our players are dead
        {
            return (false); // return false
        }
        else // if all of our players are allive
        {
            return (true); // return true
        }
    }

    void Move_To_Next_Scene()
    {

        if(All_Players_Dead == true) // if all the players are dead
        {
            Current_Seconds_Dead += Time.deltaTime; // add time to current seconds dead

            //TWEENING OUR TEXT
            if(Tween_Once == false) // if we havent set our tween command to happen
            {
                GetComponent<Wave_Spawner>().enabled = false; // disabling the wave spawner component
                Game_Over_Text.LeanScale(new Vector3(Text_Scale, Text_Scale, Text_Scale), Time_To_Scale).setEase(Tween_Type); // tweening our object up
                FindObjectOfType<Audio_Manager>().Play_Sound("Game Over");
                Pause_Background_Music(); // implementing our pause background musci function
                Tween_Once = true; // setting tween once to false
            }
        }
        else
        {
            // Reset Tween Text

            Game_Over_Text.transform.localScale = new Vector3(0, 0, 0); 
            Tween_Once = false;

            Current_Seconds_Dead = 0; // current seconds dead = 0
        }

        if(Current_Seconds_Dead >= Max_Seconds_Dead) // if all players are dead for a certain amount of seconds
        {
            Camera.main.GetComponent<Pokemon_Shader_Transtion>().Can_Transition = true; // transition
        }
        else
        {
            Camera.main.GetComponent<Pokemon_Shader_Transtion>().Can_Transition = false; // dont transition
        }
    }

    void Find_Players() // a function to find all of the players in our scnee and find out how many of them are alive
    {
        Players_Alive.Clear(); // clear the list for players that are currently alive

        Players_In_Game = GameObject.FindGameObjectsWithTag("Player"); // getting all players in the scene 
       
        for (int i = 0; i < Players_In_Game.Length; i++) // for each player in the game
        {
            if (!Players_Alive.Contains(Players_In_Game[i].GetComponent<Player_Stats>().Player_Dead)) // if the list of players alive does not conatain its dead checker
            {
                Players_Alive.Add(Players_In_Game[i]); // add it to the list
            }
        }
    }

    public IEnumerator Introduce_New_Player() // a function to reference when we want to add a player to our scene
    {
        yield return null; // wait for the end of the frame
        Find_Players(); // find all active players in our game
    }

    void Pause_Background_Music() // a function that will pause our level art if we desire
    {
        if(Gameplay_Variables.Level_Art_Set == 0)
        {
            FindObjectOfType<Audio_Manager>().Pause_Sound("Grass Music");
        }

        if (Gameplay_Variables.Level_Art_Set == 1)
        {
            FindObjectOfType<Audio_Manager>().Pause_Sound("Beach Music");
        }

        if (Gameplay_Variables.Level_Art_Set == 2)
        {
            FindObjectOfType<Audio_Manager>().Pause_Sound("Snow Music");
        }

        if (Gameplay_Variables.Level_Art_Set == 3)
        {
            FindObjectOfType<Audio_Manager>().Pause_Sound("Lava Music");
        }
    }
}
