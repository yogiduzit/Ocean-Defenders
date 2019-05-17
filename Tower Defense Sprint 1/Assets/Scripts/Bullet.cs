﻿using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Transform target;
    private ArrayList hitTargets;
    public float speed = 70f;
    public string enemyTag = "Enemy";
    public float bounceRange = 5.0f;
    public int damage = 50;
    public GameObject impactEffect;
    public int maxBounces;
    private int bounces;

    public void Start () {
        hitTargets = new ArrayList ();
        bounces = 0;
    }
    public void Seek (Transform myTarget) {
        target = myTarget;
    }

    void Update () {

        if (target == null) {
            Destroy(this.gameObject);
            return;
        } else {
            MoveBullet ();
        }
    }

    void HitTarget () {

        GameObject effect = Instantiate (impactEffect, transform.position, transform.rotation);
        Destroy (effect, 1.0f);
        Destroy (this.gameObject);
        Damage (target);

    }
    void HitTargetAndBounce () {

        GameObject effect = Instantiate (impactEffect, transform.position, transform.rotation);
        Destroy (effect, 1.0f);
        Damage (target);

        if (maxBounces > bounces) {
            FindBounceTarget ();
            bounces++;
        } else {
            Debug.Log("destroyed bullet");
            Destroy (this.gameObject);
        }
    }
    void Damage (Transform enemy) {

        Enemy e = enemy.GetComponent<Enemy> ();

        if (e != null) {

            e.takeDamage (damage);
        }
    }
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

                //target has already been hit
            }
        }
        if (nearestEnemy != null && shortestDistance <= bounceRange) {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }

    }
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