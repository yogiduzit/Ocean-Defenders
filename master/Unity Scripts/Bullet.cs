using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    private ArrayList hitTargets;
    public float speed = 70f * Pathing.acceleration;
    public string enemyTag = "Shootable";
    public float bounceRange = 5.0f;
    public int damage = 50;
    public GameObject impactEffect;
    public int maxBounces;
    private int bounces;

    /* A method that is called when the object is created and sets the default variables */
    public void Start () {
        hitTargets = new ArrayList ();
        bounces = 0;
    }
    /* A setter method that sets this bullet's target */
    public void Seek (Transform myTarget) {
        target = myTarget;
    }

    /* A method that is called every frame, this method destroys the bullet if there is no target or moves the bullet */
    void Update () {
        if (target == null) {
            Destroy (this.gameObject);
            return;
        } else {
            MoveBullet ();
        }
    }

    /* A method that controls what happens when a bullet hits it's target */
    void HitTarget () {
        GameObject effect = Instantiate (impactEffect, transform.position, transform.rotation);
        Destroy (effect, 1.0f);
        Destroy (this.gameObject);
        Damage (target);
    }

    /* A method that controls what happens when a bullet hits it's target and is supposed to bounce*/
    void HitTargetAndBounce () {

        GameObject effect = Instantiate (impactEffect, transform.position, transform.rotation);
        Destroy (effect, 1.0f);
        Damage (target);

        if (maxBounces > bounces) {
            FindBounceTarget ();
            bounces++;
        } else {
            Destroy (this.gameObject);
        }
    }
    /* A method that damages the enemy */
    void Damage (Transform enemy) {
        Enemy e = enemy.GetComponent<Enemy> ();
        if (e != null) {
            e.takeDamage (damage);
        }
    }
    /* A method that finds the next target to bounce to */
    void FindBounceTarget () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies) {
            if (hitTargets.IndexOf (enemy) == -1) {
                float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance) {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            } else {
                //Target was hit.
            }
        }
        if (nearestEnemy != null && shortestDistance <= bounceRange) {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }
    }

    /* A method that moves the bullet towards its target */
    void MoveBullet () {
        if (target != null) {
            Vector3 direction = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (direction.magnitude <= distanceThisFrame) {

                if (maxBounces != 0) {
                    hitTargets.Add (target.gameObject);
                    HitTargetAndBounce ();

                } else {
                    HitTarget ();
                }
                return;
            }
            transform.Translate (direction.normalized * distanceThisFrame, Space.World);

        }
    }
}