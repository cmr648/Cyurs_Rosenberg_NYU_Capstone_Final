using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Behavior : MonoBehaviour
{
    public float Death_Seconds;

    [Header("Tweening")]
    public float Down_Scale_Time;
    public LeanTweenType Ease_Type;

    PolygonCollider2D Coin_Collider;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, Death_Seconds); // destroy the coin after a certain amount of seconds
        Coin_Collider = GetComponent<PolygonCollider2D>(); // getting and assigning our polygon collider
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent == null) // if the coin is not bieng held
        {
            Death_Seconds -= Time.deltaTime; // subtract time from death seconds;
        }

        if(Death_Seconds <= 0) // if we run out of time
        {
            Coin_Collider.enabled = false; // disabling our collider making the coin unable to be picked up
            gameObject.LeanScale(Vector3.zero, Down_Scale_Time).setEase(Ease_Type).setOnComplete(DestroyMe);

        }


    }

    void DestroyMe() // a function to destroy our gameobjects
    {
        Destroy(gameObject);
    }
}
