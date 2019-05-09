using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{

    public float speed = 10f;
    private Transform target;
    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {

        /*
         * A vector from the initial position of the enemy
         * to the position of the waypoint
         */
        //if (gameObject != null)

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
    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            /* Need to find some other way around destroy
             * Right now, As the first enemy gets destroyed
             * the rest of them cannot access its prefab. */

            Destroy(gameObject);
            return;
        }

      waypointIndex++;
      target = Waypoints.waypoints[waypointIndex];

    }
}
