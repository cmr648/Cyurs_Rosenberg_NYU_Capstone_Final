using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Bounce : MonoBehaviour
{
    [Header("Bounce Tween")] 
    public float Bounce_Speed;
    public LeanTweenType TweenType;
    public Transform Bounce_Floor;

    [Header("Death Tween")]
    public float Death_Speed;
    public LeanTweenType Death_Tween_Type;
    public Canvas UI_Canvas;

    // Start is called before the first frame update
    void Start()
    {
        Lean_Bounce(); // implementing our lean bounce function at the start of the game
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Lean_Bounce() // a function to make whatever object we want to bounce up and down
    {

        gameObject.LeanMove(Bounce_Floor.position, Bounce_Speed).setEase(TweenType).setLoopType(LeanTweenType.pingPong); 
    }

    public void Lean_Die() // a function that scales our text down untill it reaches zero then calls our destory function
    {
        gameObject.LeanScale(new Vector3(0, 0, 0), Death_Speed).setEase(Death_Tween_Type).setOnComplete(Kill);
    }

    void Kill() // a function to destroy our entire UI canvas
    {
        Destroy(UI_Canvas.gameObject);
    }
}
