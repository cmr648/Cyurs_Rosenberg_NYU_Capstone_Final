using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Portal_Behavior : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] Enemies; // a list of all of our enemy types

    [Header("Stats")]
    public float Spawn_Wait_Time; // creating a float for our time between spawns
    public int Amount_Of_Enemies; // a float for how many enemies we want it to spawn

  

    public float Enemy_Health;

    // Start is called before the first frame update
    void Start()
    {


        StartCoroutine("Spawn_Enemies"); // begin and spawn our enemies


    }

    // Update is called once per frame
    void Update()
    {
        //Portal_Death();
       
    }

    IEnumerator Spawn_Enemies() // creating a coroutine to spawn enemies
    {
        for(int i = 0; i < Amount_Of_Enemies; i++)
        {
            yield return new WaitForSeconds(Spawn_Wait_Time);

            int Index = Random.Range(0, Enemies.Length); // pick a random enemy

            Instantiate(Enemies[Index], transform.position, Quaternion.identity); // instantiate that enemy



        }

    }

    void Portal_Death()
    {
        if(Enemy_Health <= 0) // if this portal dies
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Bounce_Bullet" || collision.gameObject.tag == "Explode_Bullet" || collision.gameObject.tag == "Slice_Bullet")
        {
            Enemy_Health -= 1;
            Destroy(collision.gameObject);
        }
    }


}
