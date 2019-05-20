using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pathing : MonoBehaviour
{

    public float speed;
    private Transform target;
    private Transform nextTarget;
    private int waypointIndex;
    Enemy enemy;
    private float t;
    private bool OutOfBounds;


    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.waypoints[0];
        enemy = gameObject.GetComponent<Enemy>();
        nextTarget = Waypoints.waypoints[1];




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
        /*if (waypointIndex != 0)
        {
            Vector3 rotationVec = new Vector3(0, -180 + FindAngle(transform, nextTarget) / Mathf.Deg2Rad, 0);

            transform.eulerAngles = rotationVec;
        }*/

       
    } 
    void GetNextWaypoint()
        {
            if (waypointIndex >= Waypoints.waypoints.Length - 1)
            {
            /* Need to find some other way around destroy
             * Right now, As the first enemy gets destroyed
             * the rest of them cannot access its prefab. */
            
            Destroy(gameObject);
            DecreaseLives();
            return;
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
                GetNextWaypoint();
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
            transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);


            if (Vector3.Distance(transform.position, target.position) <= 2.4f)
            {

            GetNextWaypoint();
            }

        }
    void PathDump()
    {
        Vector3 dirDump = new Vector3(target.position.x, target.position.y - 1 + (0.5f * Mathf.Sin(2 * Mathf.PI * t)), target.position.z);
        Vector3 dir = dirDump - transform.position;

        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 1.7f)
        {
            GetNextWaypoint();
        }
    }
    void PathTrashCan()
        {
        Vector3 dirTrashCan = new Vector3(target.position.x + (0.5f * Mathf.Sin(2 * Mathf.PI * t)), target.position.y - 1, target.position.z);
        Vector3 dir = dirTrashCan - transform.position;

        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 1.7f)
        {
        GetNextWaypoint();
        }

            

    }
    void PathBoss()
    {
        Vector3 dirBoss = new Vector3(target.position.x, target.position.y + - 2, target.position.z);
        Vector3 dir = dirBoss - transform.position;

        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
       

        if (Vector3.Distance(transform.position, target.position) <= 2.2f )
        {
            transform.eulerAngles = target.rotation.eulerAngles;
            GetNextWaypoint();




        }
    }
  /*  float FindAngle(Transform x, Transform y) 
    {
        float angle = 0;
        if (waypointIndex <= Waypoints.waypoints.Length - 2)
        {
            Debug.Log(x.position);
            Debug.Log(y.position);
            angle = Mathf.Atan((y.position.x - x.position.x) / (y.position.z - x.position.z));
            Debug.Log(angle / Mathf.Deg2Rad);

        }
        return angle;

    }
    */  
    void RotateBoss()
    {


            //Vector3 rotationVec = new Vector3(0, - 180 + FindAngle(nextTarget, target) / Mathf.Deg2Rad, 0);

            


    } 
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
