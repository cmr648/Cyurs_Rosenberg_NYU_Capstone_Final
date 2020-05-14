using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class High_Score_Manager : MonoBehaviour
{
    [Header("Title")]
    public Text Title_Text;

    [Header("Team Names")]
    public Text Team_1;
    public Text Team_2;
    public Text Team_3;
    public Text Team_4;
    public Text Team_5;
    public Text Team_6;
    public Text Team_7;
    public Text Team_8;
    public Text Team_9;
    public Text Team_10;


    [Header("Score")]
    public Text Score_1;
    public Text Score_2;
    public Text Score_3;
    public Text Score_4;
    public Text Score_5;
    public Text Score_6;
    public Text Score_7;
    public Text Score_8;
    public Text Score_9;
    public Text Score_10;

    [Header("High_Score_Name")]
    public High_Score_Name_Editor High_Score_Controller;
    public string High_Score_Name;
    public Color[] High_Score_Name_Colors; // the potential colors our high score name text can be



    public KeyCode Confirm;

    [Header("Tweening")]
    public float Score_Text_Tween_Scale;
    public float Title_Text_Tween_Scale;
    public float Letter_Tween_Scale;
    public float Enter_Name_Tween_Scale;

    [Header("Tween Arrays")]
    public GameObject[] High_Score_Letters;
    public GameObject Enter_Name_Letters;

    [Header ("Time Stamps")]
    public float Tween_Time; // time it takes to tween
    public float Start_Wait_Time; // the time before starting
    public float Time_Between_Title_And_Rest;
    public float Time_Between_Enter_Name_and_Rest;
    public float Text_Wait_Time; // time in between text shoging
    [Header ("Ease Type")]
    public LeanTweenType Ease_Type;


    [Header ("Glow Variables")]
    public float Glow_Text_Min_Scale;
    public float Glow_Text_Max_Scale;
    public LeanTweenType Glow_Ease_Type;
    public float Glow_Speed;
   

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        Set_Start_Player_Prefs();
    }

    // Start is called before the first frame update
    void Start()
    {
        // setting high score text color if we get high score
        Set_Naming_Text_Color(High_Score_Letters[0].GetComponent<Text>());
        Set_Naming_Text_Color(High_Score_Letters[1].GetComponent<Text>());
        Set_Naming_Text_Color(High_Score_Letters[2].GetComponent<Text>());
        Set_Naming_Text_Color(High_Score_Letters[3].GetComponent<Text>());
        Set_Naming_Text_Color(Enter_Name_Letters.GetComponent<Text>());


        FindObjectOfType<Audio_Manager>().Play_Sound("Background Music"); // starting our background music from our audio manager

        Start_High_Score();

        Set_Score_Texts();
        Set_Team_Texts_Default();

        StartCoroutine("Text_Animation");


    }

    // Update is called once per frame
    void Update()
    {

        High_Score_Name = High_Score_Controller.High_Score_Text;
        Set_Score_Texts_Winner();

       

    }

    void Set_Score_Texts() // a function to set the high score texts
    {
        Score_1.text  += " " + PlayerPrefs.GetInt("Team_1_Score").ToString();

        Score_2.text += " " + PlayerPrefs.GetInt("Team_2_Score").ToString();

        Score_3.text += " " + PlayerPrefs.GetInt("Team_3_Score").ToString();

        Score_4.text += " " + PlayerPrefs.GetInt("Team_4_Score").ToString();

        Score_5.text += " " + PlayerPrefs.GetInt("Team_5_Score").ToString();

        Score_6.text += " " + PlayerPrefs.GetInt("Team_6_Score").ToString();

        Score_7.text += " " + PlayerPrefs.GetInt("Team_7_Score").ToString();

        Score_8.text += " " + PlayerPrefs.GetInt("Team_8_Score").ToString();

        Score_9.text += " " + PlayerPrefs.GetInt("Team_9_Score").ToString();

        Score_10.text += " " + PlayerPrefs.GetInt("Team_10_Score").ToString();
    }

    void Set_Start_Player_Prefs() // a function to set the high score if our player prefs have never been set before
    {
        if (!PlayerPrefs.HasKey("Team_1_Score")) // if we have never played the game before
        {
            PlayerPrefs.SetInt("Team_1_Score", 100); // default the team score to an int
        }

        if (!PlayerPrefs.HasKey("Team_2_Score"))
        {
            PlayerPrefs.SetInt("Team_2_Score", 90);
        }

        if (!PlayerPrefs.HasKey("Team_3_Score"))
        {
            PlayerPrefs.SetInt("Team_3_Score", 80);
        }

        if (!PlayerPrefs.HasKey("Team_4_Score"))
        {
            PlayerPrefs.SetInt("Team_4_Score", 70);
        }

        if (!PlayerPrefs.HasKey("Team_5_Score"))
        {
            PlayerPrefs.SetInt("Team_5_Score", 60);
        }

        if (!PlayerPrefs.HasKey("Team_6_Score"))
        {
            PlayerPrefs.SetInt("Team_6_Score", 50);
        }

        if (!PlayerPrefs.HasKey("Team_7_Score"))
        {
            PlayerPrefs.SetInt("Team_7_Score", 40);
        }

        if (!PlayerPrefs.HasKey("Team_8_Score"))
        {
            PlayerPrefs.SetInt("Team_8_Score", 30);
        }

        if (!PlayerPrefs.HasKey("Team_9_Score"))
        {
            PlayerPrefs.SetInt("Team_9_Score", 20);
        }

        if (!PlayerPrefs.HasKey("Team_10_Score"))
        {
            PlayerPrefs.SetInt("Team_10_Score", 10);
        }

       
    }

    void Set_Team_Texts_Default() // a function to set the defaults for the team texts
    {
         Team_1.text += " " + PlayerPrefs.GetString("Team_1_Name", "AJAX");


        Team_2.text += " " + PlayerPrefs.GetString("Team_2_Name", "AJAX");

        Team_3.text += " " + PlayerPrefs.GetString("Team_3_Name", "AJAX");

        Team_4.text += " " + PlayerPrefs.GetString("Team_4_Name", "AJAX");

        Team_5.text += " " + PlayerPrefs.GetString("Team_5_Name", "AJAX");

        Team_6.text += " " + PlayerPrefs.GetString("Team_6_Name", "AJAX");

        Team_7.text += " " + PlayerPrefs.GetString("Team_7_Name", "AJAX");

        Team_8.text += " " + PlayerPrefs.GetString("Team_8_Name", "AJAX");

        Team_9.text += " " + PlayerPrefs.GetString("Team_9_Name", "AJAX");

        Team_10.text += " " + PlayerPrefs.GetString("Team_10_Name", "AJAX");
    }

    void Set_Score_Texts_Winner()
    {
        if(Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_1_Score"))
        {
            Score_1.text = "Team Score: " + Gameplay_Variables.Team_Score.ToString();

            Team_1.text = High_Score_Controller.High_Score_Text;

            if (High_Score_Controller.Letter_Index >= 4) 
            {
                PlayerPrefs.SetString("Team_1_Name",High_Score_Name);
                PlayerPrefs.SetInt("Team_1_Score", Gameplay_Variables.Team_Score);
            }

        }


        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_1_Score")  &&  Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_2_Score"))
        {
            Score_2.text = "Team Score: " + Gameplay_Variables.Team_Score.ToString();

            Team_2.text = High_Score_Controller.High_Score_Text;

            if (High_Score_Controller.Letter_Index >= 4)
            {
                PlayerPrefs.SetString("Team_2_Name", High_Score_Name);
                PlayerPrefs.SetInt("Team_2_Score", Gameplay_Variables.Team_Score);
            }
        }


        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_2_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_3_Score"))
        {
            Score_3.text = "Team Score: " + Gameplay_Variables.Team_Score.ToString();

            Team_3.text = High_Score_Controller.High_Score_Text;

            if (High_Score_Controller.Letter_Index >= 4)
            {
                PlayerPrefs.SetString("Team_3_Name", High_Score_Name);
                PlayerPrefs.SetInt("Team_3_Score", Gameplay_Variables.Team_Score);
            }
        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_3_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_4_Score"))
        {
            Score_4.text = "Team Score: " + Gameplay_Variables.Team_Score.ToString();

            Team_4.text = High_Score_Controller.High_Score_Text;

            if (High_Score_Controller.Letter_Index >= 4)
            {
                PlayerPrefs.SetString("Team_4_Name", High_Score_Name);
                PlayerPrefs.SetInt("Team_4_Score", Gameplay_Variables.Team_Score);
            }
        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_4_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_5_Score"))
        {
            Score_5.text = "Team Score: " + Gameplay_Variables.Team_Score.ToString();

            Team_5.text = High_Score_Controller.High_Score_Text;

            if (High_Score_Controller.Letter_Index >= 4)
            {
                PlayerPrefs.SetString("Team_5_Name", High_Score_Name);
                PlayerPrefs.SetInt("Team_5_Score", Gameplay_Variables.Team_Score);
            }
        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_5_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_6_Score"))
        {
            Score_6.text = "Team Score: " + Gameplay_Variables.Team_Score.ToString();

            Team_6.text = High_Score_Controller.High_Score_Text;

            if (High_Score_Controller.Letter_Index >= 4)
            {
                PlayerPrefs.SetString("Team_6_Name", High_Score_Name);
                PlayerPrefs.SetInt("Team_6_Score", Gameplay_Variables.Team_Score);
            }
        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_6_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_7_Score"))
        {
            Score_7.text = "Team Score: " + Gameplay_Variables.Team_Score.ToString();

            Team_7.text = High_Score_Controller.High_Score_Text;

            if (High_Score_Controller.Letter_Index >= 4)
            {
                PlayerPrefs.SetString("Team_7_Name", High_Score_Name);
                PlayerPrefs.SetInt("Team_7_Score", Gameplay_Variables.Team_Score);
            }
        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_7_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_8_Score"))
        {
            Score_8.text = "Team Score: " + Gameplay_Variables.Team_Score.ToString();

            Team_8.text = High_Score_Controller.High_Score_Text;

            if (High_Score_Controller.Letter_Index >= 4)
            {
                PlayerPrefs.SetString("Team_8_Name", High_Score_Name);
                PlayerPrefs.SetInt("Team_8_Score", Gameplay_Variables.Team_Score);
            }
        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_8_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_9_Score"))
        {
            Score_9.text = "Team Score: " + Gameplay_Variables.Team_Score.ToString();

            Team_9.text = High_Score_Controller.High_Score_Text;

            if (High_Score_Controller.Letter_Index >= 4)
            {
                PlayerPrefs.SetString("Team_9_Name", High_Score_Name);
                PlayerPrefs.SetInt("Team_9_Score", Gameplay_Variables.Team_Score);
            }
        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_9_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_10_Score"))
        {
            Score_10.text = "Team Score: " + Gameplay_Variables.Team_Score.ToString();

            Team_10.text = High_Score_Controller.High_Score_Text;

            if (High_Score_Controller.Letter_Index >= 4)
            {
                PlayerPrefs.SetString("Team_10_Name", High_Score_Name);
                PlayerPrefs.SetInt("Team_10_Score", Gameplay_Variables.Team_Score);
            }
        }
    }

    void Start_High_Score()
    {
        if(Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_10_Score"))
        {
           //High_Score_Controller.gameObject.SetActive(true);

            Title_Text.text = "You Got A High Score!";
        }
        else
        {
          // High_Score_Controller.gameObject.SetActive(false);

            Title_Text.text = "High Scores: ";
        }

        
    }

   
    IEnumerator Text_Animation() // WORK IN PROGRESS
    {

        yield return new WaitForSeconds(Start_Wait_Time);
        Title_Text.gameObject.LeanScale(new Vector3(Title_Text_Tween_Scale, Title_Text_Tween_Scale, Title_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);


        yield return new WaitForSeconds(Time_Between_Title_And_Rest);

        if (Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_10_Score")) // if it is equal to the lowest score
        { 
            //INSERT TEXT COLORING HERE


            

            foreach(GameObject Letter in High_Score_Letters)
            {
                Letter.gameObject.LeanScale(new Vector3(Letter_Tween_Scale, Letter_Tween_Scale, Letter_Tween_Scale), Tween_Time).setEase(Ease_Type);
            }

            Enter_Name_Letters.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
           

            yield return new WaitForSeconds(Time_Between_Enter_Name_and_Rest);
        }


        Team_1.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        Score_1.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        yield return new WaitForSeconds(Text_Wait_Time);
        Team_2.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        Score_2.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        yield return new WaitForSeconds(Text_Wait_Time);
        Team_3.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        Score_3.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        yield return new WaitForSeconds(Text_Wait_Time);
        Team_4.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        Score_4.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        yield return new WaitForSeconds(Text_Wait_Time);
        Team_5.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        Score_5.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        yield return new WaitForSeconds(Text_Wait_Time);
        Team_6.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        Score_6.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        yield return new WaitForSeconds(Text_Wait_Time);
        Team_7.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        Score_7.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        yield return new WaitForSeconds(Text_Wait_Time);
        Team_8.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        Score_8.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        yield return new WaitForSeconds(Text_Wait_Time);
        Team_9.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        Score_9.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        yield return new WaitForSeconds(Text_Wait_Time);
        Team_10.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        Score_10.gameObject.LeanScale(new Vector3(Score_Text_Tween_Scale, Score_Text_Tween_Scale, Score_Text_Tween_Scale), Tween_Time).setEase(Ease_Type);
        yield return new WaitForSeconds(Text_Wait_Time);

        Bouncings_Score();
    }

    void Bouncings_Score()
    {
        if (Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_1_Score"))
        {
            Score_1.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale,Glow_Text_Max_Scale,Glow_Text_Max_Scale),Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);


            Team_1.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);


        }


        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_1_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_2_Score"))
        {
            Score_2.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);


            Team_2.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);

        }


        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_2_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_3_Score"))
        {
            Score_3.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);


            Team_3.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);

        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_3_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_4_Score"))
        {
            Score_4.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);


            Team_4.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);

        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_4_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_5_Score"))
        {
            Score_5.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);


            Team_5.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);

        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_5_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_6_Score"))
        {
            Score_6.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);


            Team_6.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);

        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_6_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_7_Score"))
        {
            Score_7.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);


            Team_7.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);

        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_7_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_8_Score"))
        {
            Score_8.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);


            Team_8.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);

        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_8_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_9_Score"))
        {
            Score_9.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);


            Team_9.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);

        }

        if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_9_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_10_Score"))
        {
            Score_10.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);


            Team_10.gameObject.LeanScale(new Vector3(Glow_Text_Max_Scale, Glow_Text_Max_Scale, Glow_Text_Max_Scale), Glow_Speed).setEase(Glow_Ease_Type).setLoopType(LeanTweenType.pingPong);

        }
    }


    void Set_Naming_Text_Color(Text Name_Text) // setting a color for text based on what our high score is
    {

            if (Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_1_Score")) // if our score is higher than a certain score
            {

                Name_Text.color = High_Score_Name_Colors[0]; // set the text to a color from our array
            }


            if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_1_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_2_Score"))
            {
                Name_Text.color = High_Score_Name_Colors[1];

            }


            if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_2_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_3_Score"))
            {
                Name_Text.color = High_Score_Name_Colors[2];

            }

            if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_3_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_4_Score"))
            {
                Name_Text.color = High_Score_Name_Colors[3];

            }

            if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_4_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_5_Score"))
            {
                Name_Text.color = High_Score_Name_Colors[4];

            }

            if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_5_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_6_Score"))
            {
                Name_Text.color = High_Score_Name_Colors[5];

            }

            if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_6_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_7_Score"))
            {
                Name_Text.color = High_Score_Name_Colors[6];

            }

            if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_7_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_8_Score"))
            {
                Name_Text.color = High_Score_Name_Colors[7];

            }

            if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_8_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_9_Score"))
            {
                Name_Text.color = High_Score_Name_Colors[8];

            }

            if (Gameplay_Variables.Team_Score < PlayerPrefs.GetInt("Team_9_Score") && Gameplay_Variables.Team_Score >= PlayerPrefs.GetInt("Team_10_Score"))
            {
                Name_Text.color = High_Score_Name_Colors[9];

            }
        
    }
}
