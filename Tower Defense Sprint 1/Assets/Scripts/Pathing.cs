using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pathing : MonoBehaviour
{

    public float speed = 10f;
    private Transform target;
    private int waypointIndex;
    Enemy enemy;
    private float t;
    private bool OutOfBounds;
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.waypoints[0];
        enemy = gameObject.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemy.enemyType)
        {
            case "Cloud":
                PathCloud();
                break;
            case "Trash":
                PathTrash();
                break;
        }

       /* if ()
        {
            PlayerStats.lives--;
        }
        */
    } 
    void GetNextWaypoint()
        {
            if (waypointIndex >= Waypoints.waypoints.Length - 1)
            {
            /* Need to find some other way around destroy
             * Right now, As the first enemy gets destroyed
             * the rest of them cannot access its prefab. */
            PlayerStats.lives--;
            Destroy(gameObject);


            t += Time.deltaTime;

            Vector3 dirCloud = new Vector3(target.position.x, target.position.y + 8 - (2 * Mathf.Sin(t * Mathf.PI)), target.position.z);
            Vector3 dir = dirCloud - transform.position;

            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, target.position) <= 8.1f)
            {
                GetNextWaypoint();
            }
        }
        void PathTrash()
        {
            /*
             * A vector from the initial position of the enemy
             * to the position of the waypoint
             */


            Vector3 dir = target.position - transform.position;


            /*
             * Dir normalized converts it into a unit vector
             * Time.deltaTime makes sure that movement is not dependent on
             * the frame rate.
             * Space.World tells it to move relative to the world.       
             */
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }

        }
}
