using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Single_Art : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite Grass;
    public Sprite Lava;
    public Sprite Snow;
    public Sprite Beach;

    SpriteRenderer Object_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        Object_Renderer = GetComponent<SpriteRenderer>();
        Set_Art();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Set_Art()
    {
        if(Gameplay_Variables.Level_Art_Set == 0)
        {
            Object_Renderer.sprite = Grass;
        }

        if (Gameplay_Variables.Level_Art_Set == 1)
        {
            Object_Renderer.sprite = Beach;
        }

        if (Gameplay_Variables.Level_Art_Set == 2)
        {
            Object_Renderer.sprite = Snow;
        }

        if (Gameplay_Variables.Level_Art_Set == 3)
        {
            Object_Renderer.sprite = Lava;
        }
    }
}
