using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Level_Select_Manager : MonoBehaviour
{
    [Header("Level Selection")]
    public int Level_Selection;

    [Header("Controls")]
    public KeyCode Player_1_Controls;

    public KeyCode Player_2_Contorls;

    public KeyCode Player_3_Controls;

    public KeyCode Player_4_Controls;

    public KeyCode Player_1_Start;
    public KeyCode Player_2_Start;
    public KeyCode Player_3_Start;
    public KeyCode Player_4_Start;


    [Header("Transition")]
    public Pokemon_Shader_Transtion Transition;


    [Header("Background")]
    public SpriteRenderer Background_Object;
    public Sprite Grass_Sprite;
    public Sprite Beach_Sprite;
    public Sprite Snow_Sprite;
    public Sprite Lava_Sprite;
    public float Background_Wait_Time;

    [Header("Arrows")]
    public GameObject Selection_Arrow;
    public float Arrow_Speed;

    [Header("Arrow_Locations")]
    public Transform Grass_Arrow_Location;
    public Transform Beach_Arow_Location;
    public Transform Snow_Arrow_Location;
    public Transform Lava_Arrow_Location;

    [Header("Arrow_Colors")]
    public Color Grass_Arrow_Color;
    public Color Beach_Arrow_Color;
    public Color Snow_Arrow_Color;
    public Color Lava_Arrow_Color;

    [Header("Videos")]
    public VideoPlayer Grass_Player;
    public VideoPlayer Beach_Player;
    public VideoPlayer Snow_Player;
    public VideoPlayer Lava_Player;

    [Header("UI Text")]
    public Text[] Level_Selection_Text;
    public Text Level_Name_Text;
    public Color Grass_Text_Color;
    public Color Beach_Text_Color;
    public Color Snow_Text_Color;
    public Color Lava_Text_Color;
    public float Color_Change_Speed;
    public string Grass_Stage_Name;
    public string Beach_Stage_Name;
    public string Snow_Stage_Name;
    public string Lava_Stage_Name;

    [Header("Frames")]
    public GameObject Grassy_Frame;
    public GameObject Beach_Frame;
    public GameObject Snowy_Frame;
    public GameObject Lava_Frame;

    [Header("Frame Scaling")]
    public float Grass_Max_Scale; // the multiple we should be scaling our frames by
    public float Beach_Max_Scale;
    public float Snow_Max_Scale;
    public float Lava_Max_Scale;
    Vector3 Grass_Scale;
    Vector3 Beach_Scale;
    Vector3 Snow_Scale;
    Vector3 Lava_Scale;
    public float Frame_Scale_Speed;


    [Header("Arcade Controls")]
    public Arcade_Controls Player_1_Arcade_Controls;
    public Arcade_Controls Player_2_Arcade_Controls;
    public Arcade_Controls Player_3_Arcade_Controls;
    public Arcade_Controls Player_4_Arcade_Controls;



    // Start is called before the first frame update
    void Start()
    {
        Select_Music(); // seleecting music

        // assigining the scales of oall of our frames
        Grass_Scale = Grassy_Frame.transform.localScale;
        Beach_Scale = Beach_Frame.transform.localScale;
        Snow_Scale = Snowy_Frame.transform.localScale;
        Lava_Scale = Lava_Frame.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        Gameplay_Variables.Level_Art_Set = Level_Selection;
       
        Level_Limits();
        Controls();

        Next_Level();

        Change_Background();


        Set_Arrows();

        Set_Videos();

        Change_UI_Text_Color();

        Change_Frame_Scale();


        Arcade_Controls(); // calling our controller support methood

    }

    void Level_Limits()
    {
        if (Level_Selection > 3)
        {
            Level_Selection = 0;
        }

        if (Level_Selection < 0)
        {
            Level_Selection = 3;
        }
    }

    void Controls()
    {
        if (Gameplay_Variables.Player_1_In_Game == true)
        {
            if (Input.GetKeyDown(Player_1_Controls))
            {

                Level_Selection += 1;

                Select_Music(); // selecitn muisc

                FindObjectOfType<Audio_Manager>().Play_Sound("Menu Select"); // Playing our menu slect sound
            }
        }

        if (Gameplay_Variables.Player_2_In_Game == true)
        {
            if (Input.GetKeyDown(Player_2_Contorls))
            {
                Level_Selection += 1;
            }
        }

        if (Gameplay_Variables.Player_3_In_Game == true)
        {
            if (Input.GetKeyDown(Player_3_Controls))
            {
                Level_Selection += 1;
            }
        }

        if (Gameplay_Variables.Player_4_In_Game == true)
        {
            if (Input.GetKeyDown(Player_4_Controls))
            {
                Level_Selection += 1;
            }
        }


    }

    void Arcade_Controls() // A FUNCTION FOR OUR ARCADE CONTROLLER CONTROLS
    {
        #region Player_1_Controls
        //PLAYER 1 CONTROLS
        if (Gameplay_Variables.Player_1_In_Game == true)
        {

            if (Input.GetAxis(Player_1_Arcade_Controls.Player_Axis_X) == 1)
            {
                if (Player_1_Arcade_Controls.Player_X_In_Use == false)
                {
                    Level_Selection += 1;

                    Select_Music(); // selecitn muisc

                    FindObjectOfType<Audio_Manager>().Play_Sound("Menu Select"); // Playing our menu slect sound

                }
            }

            if (Input.GetAxis(Player_1_Arcade_Controls.Player_Axis_X) == -1)
            {
                if (Player_1_Arcade_Controls.Player_X_In_Use == false)
                {
                    Level_Selection -= 1;

                    Select_Music(); // selecitn muisc

                    FindObjectOfType<Audio_Manager>().Play_Sound("Menu Select"); // Playing our menu slect sound


                }
            }
        }

        Change_Background_Arcade_Controls();// chaging our background

        if (Input.GetAxis(Player_1_Arcade_Controls.Player_Axis_X) == 0) // if our controller is at rest
        {
            Player_1_Arcade_Controls.Player_X_In_Use = false; // we are not using it
        }
        else
        {
            Player_1_Arcade_Controls.Player_X_In_Use = true; // we are using it
        }

        #endregion

        #region Player_2_Controls
        //PLAYER 1 CONTROLS
        if (Gameplay_Variables.Player_2_In_Game == true)
        {

            if (Input.GetAxis(Player_2_Arcade_Controls.Player_Axis_X) == 1)
            {
                if (Player_2_Arcade_Controls.Player_X_In_Use == false)
                {
                    Level_Selection += 1;

                    Select_Music(); // selecitn muisc

                    FindObjectOfType<Audio_Manager>().Play_Sound("Menu Select"); // Playing our menu slect sound


                }
            }

            if (Input.GetAxis(Player_2_Arcade_Controls.Player_Axis_X) == -1)
            {
                if (Player_2_Arcade_Controls.Player_X_In_Use == false)
                {
                    Level_Selection -= 1;

                    Select_Music(); // selecitn muisc

                    FindObjectOfType<Audio_Manager>().Play_Sound("Menu Select"); // Playing our menu slect sound


                }
            }
        }

        Change_Background_Arcade_Controls();// chaging our background


        if (Input.GetAxis(Player_2_Arcade_Controls.Player_Axis_X) == 0) // if our controller is at rest
        {
            Player_2_Arcade_Controls.Player_X_In_Use = false; // we are not using it
        }
        else
        {
            Player_2_Arcade_Controls.Player_X_In_Use = true; // we are using it
        }

        #endregion

        #region Player_3_Controls
        //PLAYER 1 CONTROLS
        if (Gameplay_Variables.Player_3_In_Game == true)
        {

            if (Input.GetAxis(Player_3_Arcade_Controls.Player_Axis_X) == 1)
            {
                if (Player_3_Arcade_Controls.Player_X_In_Use == false)
                {
                    Level_Selection += 1;

                    Select_Music(); // selecitn muisc

                    FindObjectOfType<Audio_Manager>().Play_Sound("Menu Select"); // Playing our menu slect sound


                }
            }

            if (Input.GetAxis(Player_3_Arcade_Controls.Player_Axis_X) == -1)
            {
                if (Player_3_Arcade_Controls.Player_X_In_Use == false)
                {
                    Level_Selection -= 1;

                    Select_Music(); // selecitn muisc

                    FindObjectOfType<Audio_Manager>().Play_Sound("Menu Select"); // Playing our menu slect sound


                }
            }
        }

        Change_Background_Arcade_Controls();// chaging our background


        if (Input.GetAxis(Player_3_Arcade_Controls.Player_Axis_X) == 0) // if our controller is at rest
        {
            Player_3_Arcade_Controls.Player_X_In_Use = false; // we are not using it
        }
        else
        {
            Player_3_Arcade_Controls.Player_X_In_Use = true; // we are using it
        }

        #endregion

        #region Player_4_Controls
        //PLAYER 1 CONTROLS
        if (Gameplay_Variables.Player_4_In_Game == true)
        {

            if (Input.GetAxis(Player_4_Arcade_Controls.Player_Axis_X) == 1)
            {
                if (Player_4_Arcade_Controls.Player_X_In_Use == false)
                {
                    Level_Selection += 1;

                    Select_Music(); // selecitn muisc

                    FindObjectOfType<Audio_Manager>().Play_Sound("Menu Select"); // Playing our menu slect sound


                }
            }

            if (Input.GetAxis(Player_4_Arcade_Controls.Player_Axis_X) == -1)
            {
                if (Player_4_Arcade_Controls.Player_X_In_Use == false)
                {
                    Level_Selection -= 1;

                    Select_Music(); // selecitn muisc

                    FindObjectOfType<Audio_Manager>().Play_Sound("Menu Select"); // Playing our menu slect sound


                }
            }
        }

        Change_Background_Arcade_Controls();// chaging our background

        if (Input.GetAxis(Player_4_Arcade_Controls.Player_Axis_X) == 0) // if our controller is at rest
        {
            Player_4_Arcade_Controls.Player_X_In_Use = false; // we are not using it
        }
        else
        {
            Player_4_Arcade_Controls.Player_X_In_Use = true; // we are using it
        }

        #endregion

       

    }




    void Next_Level()
        {
            if (Gameplay_Variables.Player_1_In_Game == true)
            {
                if (Input.GetKeyDown(Player_1_Start) || Input.GetButtonDown(Player_1_Arcade_Controls.Player_Button_Start)) // ADDED ARCADE CONTROLS
                {
                    
                    Transition.Can_Transition = true;
                }
            }

            if (Gameplay_Variables.Player_2_In_Game == true) // ADDE ARCADE CONTROLS
            {
             if (Input.GetButtonDown(Player_2_Arcade_Controls.Player_Button_Start))
             {
                Transition.Can_Transition = true;
                }

                
            }

        if (Gameplay_Variables.Player_3_In_Game == true) // ADDE ARCADE CONTROLS
        {
            if (Input.GetButtonDown(Player_3_Arcade_Controls.Player_Button_Start))
            {
                Transition.Can_Transition = true;
            }


        }

        if (Gameplay_Variables.Player_4_In_Game == true) // ADDE ARCADE CONTROLS
        {
            if (Input.GetButtonDown(Player_4_Arcade_Controls.Player_Button_Start))
            {
                Transition.Can_Transition = true;
            }


        }
    }



        void Change_Background()
        {
            if (Gameplay_Variables.Player_1_In_Game == true)
            {
                if (Input.GetKeyDown(Player_1_Controls))
                {
                    if (Level_Selection > 3 || Level_Selection == 0)
                    {
                        StartCoroutine(Background_Change(Grass_Sprite));
                    }

                    if (Level_Selection == 1)
                    {
                        StartCoroutine(Background_Change(Beach_Sprite));
                    }

                    if (Level_Selection == 2)
                    {
                        StartCoroutine(Background_Change(Snow_Sprite));
                    }

                    if (Level_Selection == 3 || Level_Selection < 0)
                    {
                        StartCoroutine(Background_Change(Lava_Sprite));
                    }
                }
            }

            if (Gameplay_Variables.Player_2_In_Game == true)
            {
                if (Input.GetKeyDown(Player_2_Contorls))
                {
                    if (Level_Selection > 3 || Level_Selection == 0)
                    {
                        StartCoroutine(Background_Change(Grass_Sprite));
                    }

                    if (Level_Selection == 1)
                    {
                        StartCoroutine(Background_Change(Beach_Sprite));
                    }

                    if (Level_Selection == 2)
                    {
                        StartCoroutine(Background_Change(Snow_Sprite));
                    }

                    if (Level_Selection == 3 || Level_Selection < 0)
                    {
                        StartCoroutine(Background_Change(Lava_Sprite));
                    }
                }
            }

            if (Gameplay_Variables.Player_3_In_Game == true)
            {
                if (Input.GetKeyDown(Player_3_Controls))
                {
                    if (Level_Selection > 3 || Level_Selection == 0)
                    {
                        StartCoroutine(Background_Change(Grass_Sprite));
                    }

                    if (Level_Selection == 1)
                    {
                        StartCoroutine(Background_Change(Beach_Sprite));
                    }

                    if (Level_Selection == 2)
                    {
                        StartCoroutine(Background_Change(Snow_Sprite));
                    }

                    if (Level_Selection == 3 || Level_Selection < 0)
                    {
                        StartCoroutine(Background_Change(Lava_Sprite));
                    }
                }
            }

            if (Gameplay_Variables.Player_4_In_Game == true)
            {
                if (Input.GetKeyDown(Player_4_Controls))
                {
                    if (Level_Selection > 3 || Level_Selection == 0)
                    {
                        StartCoroutine(Background_Change(Grass_Sprite));
                    }

                    if (Level_Selection == 1)
                    {
                        StartCoroutine(Background_Change(Beach_Sprite));
                    }

                    if (Level_Selection == 2)
                    {
                        StartCoroutine(Background_Change(Snow_Sprite));
                    }

                    if (Level_Selection == 3 || Level_Selection < 0)
                    {
                        StartCoroutine(Background_Change(Lava_Sprite));
                    }
                }
            }
        }
        
    void Change_Background_Arcade_Controls() //changing our background using arcade controls
    {

        #region Player_1
        if (Gameplay_Variables.Player_1_In_Game == true) // if player 1 is in game
        {
            if(Player_1_Arcade_Controls.Player_X_In_Use == false)
            {
                if (Input.GetAxis(Player_1_Arcade_Controls.Player_Axis_X) == 1 || Input.GetAxis(Player_1_Arcade_Controls.Player_Axis_X) == -1)
                {
                    if (Level_Selection > 3 || Level_Selection == 0)
                    {
                        StartCoroutine(Background_Change(Grass_Sprite));
                    }

                    if (Level_Selection == 1)
                    {
                        StartCoroutine(Background_Change(Beach_Sprite));
                    }

                    if (Level_Selection == 2)
                    {
                        StartCoroutine(Background_Change(Snow_Sprite));
                    }

                    if (Level_Selection == 3 || Level_Selection < 0)
                    {
                        StartCoroutine(Background_Change(Lava_Sprite));
                    }
                }
            }
        }

        #endregion

        #region Player_2
        if (Gameplay_Variables.Player_2_In_Game == true) // if player 1 is in game
        {
            if (Player_2_Arcade_Controls.Player_X_In_Use == false)
            {
                if (Input.GetAxis(Player_2_Arcade_Controls.Player_Axis_X) == 1 || Input.GetAxis(Player_2_Arcade_Controls.Player_Axis_X) == -1)
                {
                    if (Level_Selection > 3 || Level_Selection == 0)
                    {
                        StartCoroutine(Background_Change(Grass_Sprite));
                    }

                    if (Level_Selection == 1)
                    {
                        StartCoroutine(Background_Change(Beach_Sprite));
                    }

                    if (Level_Selection == 2)
                    {
                        StartCoroutine(Background_Change(Snow_Sprite));
                    }

                    if (Level_Selection == 3 || Level_Selection < 0)
                    {
                        StartCoroutine(Background_Change(Lava_Sprite));
                    }
                }
            }
        }

        #endregion

        #region Player_3
        if (Gameplay_Variables.Player_3_In_Game == true) // if player 1 is in game
        {
            if (Player_3_Arcade_Controls.Player_X_In_Use == false)
            {
                if (Input.GetAxis(Player_3_Arcade_Controls.Player_Axis_X) == 1 || Input.GetAxis(Player_3_Arcade_Controls.Player_Axis_X) == -1)
                {
                    if (Level_Selection > 3 || Level_Selection == 0)
                    {
                        StartCoroutine(Background_Change(Grass_Sprite));
                    }

                    if (Level_Selection == 1)
                    {
                        StartCoroutine(Background_Change(Beach_Sprite));
                    }

                    if (Level_Selection == 2)
                    {
                        StartCoroutine(Background_Change(Snow_Sprite));
                    }

                    if (Level_Selection == 3 || Level_Selection < 0)
                    {
                        StartCoroutine(Background_Change(Lava_Sprite));
                    }
                }
            }
        }

        #endregion

        #region Player_4
        if (Gameplay_Variables.Player_4_In_Game == true) // if player 1 is in game
        {
            if (Player_4_Arcade_Controls.Player_X_In_Use == false)
            {
                if (Input.GetAxis(Player_4_Arcade_Controls.Player_Axis_X) == 1 || Input.GetAxis(Player_4_Arcade_Controls.Player_Axis_X) == -1)
                {
                    if (Level_Selection > 3 || Level_Selection == 0)
                    {
                        StartCoroutine(Background_Change(Grass_Sprite));
                    }

                    if (Level_Selection == 1)
                    {
                        StartCoroutine(Background_Change(Beach_Sprite));
                    }

                    if (Level_Selection == 2)
                    {
                        StartCoroutine(Background_Change(Snow_Sprite));
                    }

                    if (Level_Selection == 3 || Level_Selection < 0)
                    {
                        StartCoroutine(Background_Change(Lava_Sprite));
                    }
                }
            }
        }

        #endregion
    }

    IEnumerator Background_Change(Sprite New_Sprite)
        {
            Background_Object.gameObject.LeanColor(Color.black, Background_Wait_Time);
            yield return new WaitForSeconds(Background_Wait_Time);
            Background_Object.sprite = New_Sprite;
            Background_Object.gameObject.LeanColor(Color.white, Background_Wait_Time);

        }



        void Set_Arrows()
        {
            Transform Lerp_Point = null;
            Color Arrow_Color = new Color(0, 0, 0); // setting a new null color

            if (Level_Selection == 0)
            {
                Lerp_Point = Grass_Arrow_Location;

                Arrow_Color = Grass_Arrow_Color;
            }

            if (Level_Selection == 1)
            {
                Lerp_Point = Beach_Arow_Location;

                Arrow_Color = Beach_Arrow_Color;
            }

            if (Level_Selection == 2)
            {
                Lerp_Point = Snow_Arrow_Location;

                Arrow_Color = Snow_Arrow_Color;
            }

            if (Level_Selection == 3)
            {
                Lerp_Point = Lava_Arrow_Location;

                Arrow_Color = Lava_Arrow_Color;

            }

            if (Lerp_Point != null)
            {
                Selection_Arrow.transform.position = Vector3.Lerp(Selection_Arrow.transform.position, Lerp_Point.position, Time.deltaTime * Arrow_Speed);

            }


            Selection_Arrow.GetComponent<SpriteRenderer>().color = Color.Lerp(Selection_Arrow.GetComponent<SpriteRenderer>().color, Arrow_Color, Time.deltaTime * Arrow_Speed); // seeting our arrow color
        }

        void Set_Videos()
        {
            if (Level_Selection == 0)
            {
                Grass_Player.Play();
            }
            else
            {
                Grass_Player.Pause();
            }
            if (Level_Selection == 1)
            {
                Beach_Player.Play();
            }
            else
            {
                Beach_Player.Pause();
            }

            if (Level_Selection == 2)
            {
                Snow_Player.Play();
            }
            else
            {
                Snow_Player.Pause();
            }

            if (Level_Selection == 3)
            {
                Lava_Player.Play();
            }
            else
            {
                Lava_Player.Pause();
            }
        }

        void Change_UI_Text_Color()
        {
            if (Level_Selection == 0)
            {
                foreach (Text Text_Item in Level_Selection_Text)
                {
                    Text_Item.color = Color.Lerp(Text_Item.color, Grass_Text_Color, Time.deltaTime * Color_Change_Speed);
                }

                Level_Name_Text.text = Grass_Stage_Name;
            }

            if (Level_Selection == 1)
            {
                foreach (Text Text_Item in Level_Selection_Text)
                {
                    Text_Item.color = Color.Lerp(Text_Item.color, Beach_Text_Color, Time.deltaTime * Color_Change_Speed);
                }

                Level_Name_Text.text = Beach_Stage_Name;
            }

            if (Level_Selection == 2)
            {
                foreach (Text Text_Item in Level_Selection_Text)
                {
                    Text_Item.color = Color.Lerp(Text_Item.color, Snow_Text_Color, Time.deltaTime * Color_Change_Speed);
                }

                Level_Name_Text.text = Snow_Stage_Name;
            }

            if (Level_Selection == 3)
            {
                foreach (Text Text_Item in Level_Selection_Text)
                {
                    Text_Item.color = Color.Lerp(Text_Item.color, Lava_Text_Color, Time.deltaTime * Color_Change_Speed);
                }

                Level_Name_Text.text = Lava_Stage_Name;
            }
        }

        void Change_Frame_Scale() // a function to change the scale of each frame WHAT THE FUCK GLITCH
        {
            if (Level_Selection == 0)
            {
                Grassy_Frame.transform.localScale = Vector3.Lerp(Grassy_Frame.transform.localScale, new Vector3(Grass_Max_Scale, Grass_Max_Scale, Grass_Max_Scale), Time.deltaTime * Frame_Scale_Speed);

            }
            else
            {
                Grassy_Frame.transform.localScale = Vector3.Lerp(Grassy_Frame.transform.localScale, Grass_Scale, Time.deltaTime * Frame_Scale_Speed);
            }

            if (Level_Selection == 1)
            {
                Beach_Frame.transform.localScale = Vector3.Lerp(Beach_Frame.transform.localScale, new Vector3(Beach_Max_Scale, Beach_Max_Scale, Beach_Max_Scale), Time.deltaTime * Frame_Scale_Speed);

            }
            else
            {
                Beach_Frame.transform.localScale = Vector3.Lerp(Beach_Frame.transform.localScale, Beach_Scale, Time.deltaTime * Frame_Scale_Speed);

            }

            if (Level_Selection == 2)
            {
                Snowy_Frame.transform.localScale = Vector3.Lerp(Snowy_Frame.transform.localScale, new Vector3(Snow_Max_Scale, Snow_Max_Scale, Snow_Max_Scale), Time.deltaTime * Frame_Scale_Speed);

            }
            else
            {
                Snowy_Frame.transform.localScale = Vector3.Lerp(Snowy_Frame.transform.localScale, Snow_Scale, Time.deltaTime * Frame_Scale_Speed);

            }

            if (Level_Selection == 3)
            {
                Lava_Frame.transform.localScale = Vector3.Lerp(Lava_Frame.transform.localScale, new Vector3(Lava_Max_Scale, Lava_Max_Scale, Lava_Max_Scale), Time.deltaTime * Frame_Scale_Speed);

            }
            else
            {
                Lava_Frame.transform.localScale = Vector3.Lerp(Lava_Frame.transform.localScale, Lava_Scale, Time.deltaTime * Frame_Scale_Speed);

            }
        }

        void Select_Music() // selecting our music
        {
            if (Level_Selection == 0 || Level_Selection == 4)
            {
                FindObjectOfType<Audio_Manager>().Play_Sound("Grass Theme Simple");
                FindObjectOfType<Audio_Manager>().Pause_Sound("Beach Theme Simple");
                FindObjectOfType<Audio_Manager>().Pause_Sound("Snow Theme Simple");
                FindObjectOfType<Audio_Manager>().Pause_Sound("Lava Theme Simple");

            }

            if (Level_Selection == 1)
            {
                FindObjectOfType<Audio_Manager>().Pause_Sound("Grass Theme Simple");
                FindObjectOfType<Audio_Manager>().Play_Sound("Beach Theme Simple");
                FindObjectOfType<Audio_Manager>().Pause_Sound("Snow Theme Simple");
                FindObjectOfType<Audio_Manager>().Pause_Sound("Lava Theme Simple");

            }

            if (Level_Selection == 2)
            {
                FindObjectOfType<Audio_Manager>().Pause_Sound("Grass Theme Simple");
                FindObjectOfType<Audio_Manager>().Pause_Sound("Beach Theme Simple");
                FindObjectOfType<Audio_Manager>().Play_Sound("Snow Theme Simple");
                FindObjectOfType<Audio_Manager>().Pause_Sound("Lava Theme Simple");

            }

            if (Level_Selection == 3 || Level_Selection == -1)
            {
                FindObjectOfType<Audio_Manager>().Pause_Sound("Grass Theme Simple");
                FindObjectOfType<Audio_Manager>().Pause_Sound("Beach Theme Simple");
                FindObjectOfType<Audio_Manager>().Pause_Sound("Snow Theme Simple");
                FindObjectOfType<Audio_Manager>().Play_Sound("Lava Theme Simple");

            }


        }

    }

