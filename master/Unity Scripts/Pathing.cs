using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pathing : MonoBehaviour
{

    public float speed;
    public static float acceleration = 1;
    private Transform target;
    private Transform nextTarget;
    private int waypointIndex;
    Enemy enemy;
    private float t;
    public bool OutOfBounds;


    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.waypoints[0];
        enemy = gameObject.GetComponent<Enemy>();
        nextTarget = Waypoints.waypoints[1];
        OutOfBounds = false;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        switch (enemy.enemyType)
        {
            case "Cloud":
                PathCloud();
                break;
            case "Trash":
                PathTrash();
                break;
            case "Dump":
                PathDump();
                break;
            case "Trash Can":
                PathTrashCan();
                break;
            case "Boss":
                PathBoss();
                break;
        }
       
    //Finds the next point to move to
    } 
    IEnumerator GetNextWaypoint()
        {
        OutOfBounds = false;
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
            {
            /* Need to find some other way around destroy
             * Right now, As the first enemy gets destroyed
             * the rest of them cannot access its prefab. */
            OutOfBounds = true;
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
            DecreaseLives();
            yield return null;
            }
            waypointIndex++;
            target = Waypoints.waypoints[waypointIndex];
            if (waypointIndex <= Waypoints.waypoints.Length - 2)
            {
            nextTarget = Waypoints.waypoints[waypointIndex + 1];
            }
    }


        void PathCloud()
        {
            Vector3 dirCloud = new Vector3(target.position.x, target.position.y + 8 - (2 * Mathf.Sin(t * Mathf.PI)), target.position.z);
            Vector3 dir = dirCloud - transform.position;

            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, target.position) <= 8.1f)
            {
                StartCoroutine(GetNextWaypoint());
            }
        }
        void PathTrash()
        {
        /*
         * A vector from the initial position of the enemy
         * to the position of the waypoint
         */


        Vector3 dirTrash = new Vector3(target.position.x - 2, target.position.y - 1 + (0.5f * Mathf.Sin(2 * Mathf.PI * t)), target.position.z);
        Vector3 dir = dirTrash - transform.position;

            /*
             * Dir normalized converts it into a unit vector
             * Time.deltaTime makes sure that movement is not dependent on
             * the frame rate.
             * Space.World tells it to move relative to the world.       
             */
            transform.Translate(dir.normalized * enemy.speed * acceleration * Time.deltaTime, Space.World);


            if (Vector3.Distance(transform.position, target.position) <= 2.4f)
            {

            StartCoroutine(GetNextWaypoint());
        }

        }

    //
    void PathDump()
    {
        Vector3 dirDump = new Vector3(target.position.x, target.position.y - 1 + (0.5f * Mathf.Sin(2 * Mathf.PI * t)), target.position.z);
        Vector3 dir = dirDump - transform.position;
        transform.Translate(dir.normalized * enemy.speed * acceleration * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 1.7f)
        {
            StartCoroutine(GetNextWaypoint());
        }
    }

    //
    void PathTrashCan()
        {
        Vector3 dirTrashCan = new Vector3(target.position.x + (0.5f * Mathf.Sin(2 * Mathf.PI * t)), target.position.y - 1, target.position.z);
        Vector3 dir = dirTrashCan - transform.position;
        transform.Translate(dir.normalized * enemy.speed * acceleration * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 1.7f)
        {
            StartCoroutine(GetNextWaypoint());
        }
    }

    //
    void PathBoss()
    {
        Vector3 dirBoss = new Vector3(target.position.x, target.position.y + - 2, target.position.z);
        Vector3 dir = dirBoss - transform.position;
        transform.Translate(dir.normalized * enemy.speed * acceleration * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 2.2f )
        {
            transform.eulerAngles = target.rotation.eulerAngles;
            StartCoroutine(GetNextWaypoint());
        }
    }

    void RotateBoss()
    {
    } 

    //Decreases health based on enemy type that makes it to the ocean
    void DecreaseLives()
    {
        switch (enemy.enemyType)
        {
            case "Trash":
                PlayerStats.Health--;
                break;
            case "Dump":
                PlayerStats.Health -= 10;
                break;
            case "Cloud":
                PlayerStats.Health -= 4;
                break;
            case "Trash Can":
                PlayerStats.Health -= 5;
                break;
            case "Boss":
                PlayerStats.Health -= 50;
                break;
        }
    }

}
