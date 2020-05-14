using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Portal_Tweening : MonoBehaviour
{
    [Header("Tweening")]
    public float Portal_Tween_Scale;
    public float Portal_Tween_Speed;
    public float Down_Scale_Wait;
    public LeanTweenType Portal_Tween_Type;
    public Vector3 Portal_Object_Original_Scale;

    // Start is called before the first frame update
    void Start()
    {
        Portal_Object_Original_Scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator Scale_Up_Down_Portal() // a coroutine that will scale up and down our portal using LeanTween
    {
        gameObject.LeanScale(gameObject.transform.localScale * Portal_Tween_Scale, Portal_Tween_Speed).setEase(Portal_Tween_Type);
        yield return new WaitForSeconds(Portal_Tween_Speed + Down_Scale_Wait);
        gameObject.LeanScale(Portal_Object_Original_Scale, Portal_Tween_Speed).setEase(Portal_Tween_Type);
    }
}
