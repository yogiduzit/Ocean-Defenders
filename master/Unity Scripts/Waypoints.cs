using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Positions where the enemis have to turn
    public static Transform[] waypoints;


    /* Gets called once when the game start */ 
    void Awake()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

    /* Update is called once per frame */
    void Update()
    {

    }
}
