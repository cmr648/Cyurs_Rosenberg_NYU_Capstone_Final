using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Bullet_Art : MonoBehaviour
{
    // SPRITE REFERENECS FOR ALL 4 Player Bullet Sprites
    public Sprite Player_1_Bullet_Sprite; 
    public Sprite Player_2_Bullet_Sprite;
    public Sprite Player_3_Bullet_Sprite;
    public Sprite Player_4_Bullet_Sprite;

    Bullet_Health Current_Bullet_Health;
    SpriteRenderer Bullet_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        Current_Bullet_Health = GetComponent<Bullet_Health>();
        Bullet_Renderer = GetComponent<SpriteRenderer>();

        Bullet_Art();
    }

    // Update is called once per frame
    void Update()
    {
       
        
         
    }

    void Bullet_Art() // a function to set our bullet art
    {
        if(Current_Bullet_Health.Player_Fired.name == "Player_1")
        {
            Bullet_Renderer.sprite = Player_1_Bullet_Sprite;
        }

        if (Current_Bullet_Health.Player_Fired.name == "Player_2")
        {
            Bullet_Renderer.sprite = Player_2_Bullet_Sprite;
        }

        if (Current_Bullet_Health.Player_Fired.name == "Player_3")
        {
            Bullet_Renderer.sprite = Player_3_Bullet_Sprite;
        }

        if (Current_Bullet_Health.Player_Fired.name == "Player_4")
        {
            Bullet_Renderer.sprite = Player_4_Bullet_Sprite;
        }
    }
}
