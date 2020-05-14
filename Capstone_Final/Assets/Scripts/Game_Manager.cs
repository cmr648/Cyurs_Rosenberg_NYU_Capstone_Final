using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Game_Manager : MonoBehaviour
{
    [Header ("Pathfinding")]
    public AstarPath Pathfinding_Grid; // creating a public reference to our pathfinding grid
    public float Scan_Seconds; // the seconds we will scan a grid

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("Find_Path_Every_Seconds"); // starting our path coroutine
        StartCoroutine("Late_Start"); // starting our path coroutine

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Find_Path_Every_Seconds()
    {
        while (true) // while this game object exists
        {
            var graphToScan = AstarPath.active.data.gridGraph; // find the astar grid we are scanning
            AstarPath.active.Scan(graphToScan); // scan the astar path again
            yield return new WaitForSeconds(Scan_Seconds); // wait for a certain amount of seconds
        }
    }

    IEnumerator Late_Start()
    {
        yield return new WaitForSeconds(.2f);
        var graphToScan = AstarPath.active.data.gridGraph; // find the astar grid we are scanning
        AstarPath.active.Scan(graphToScan); // scan the astar path again

    }
}
