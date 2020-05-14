using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    CircleCollider2D Bomb_Collider;
    public float Death_Seconds;
    public float Radius_Speed;

    // Start is called before the first frame update
    void Start()
    {
        Bomb_Collider = GetComponent<CircleCollider2D>();
        Destroy(gameObject, Death_Seconds);
    }

    // Update is called once per frame
    void Update()
    {
        Bomb_Collider.radius += Radius_Speed * Time.deltaTime;
    }
}
