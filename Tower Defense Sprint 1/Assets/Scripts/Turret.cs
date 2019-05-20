using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour {
    private Transform target; // Reference to the Enemy GameObject
    private Enemy targetEnemy; // The Enemy Script Reference 

    [Header ("Attributes")]
    public float range = 12.5f;

    [Header ("Unity Fields")]
    public string enemyTag = "Enemy";
    public string enemyType;
    public float waitTime = 0.0f;
    public float seekRate = 0.5f;
    public float turnSpeed = 10.0f;
    public Transform[] firePoints;
    public Transform partToRotate;

    [Header ("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 30;
    public bool useSlow = false;
    public float slowAmount = .5f;
    public ParticleSystem[] lasers;
    public Light impactLight;

    [Header ("Use Bullets (Default)")]
    public float fireRate = 1.0f;
    private float fireCountDown = 0.0f;
    public GameObject bulletPrefab;
    public ParticleSystem impactEffect;



    // Start is called before the first frame update
    public void Start () {
        InvokeRepeating ("UpdateTarget", waitTime, seekRate);

        for (int i = 0; lasers.Length > i && lasers != null; i++) {
            //All firepoints should have a particle attached to it unless toggle particle system is not to be used. 
            lasers[i].Play ();
        }


    }
    public void UpdateTarget () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies) {

            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }
        if (nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy> ();
        } else {
            target = null;
        }
    }
    public void OnDrawGizmosSelected () {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, range);
    }
    public void Update () {
        if (target == null) {

            for (int i = 0; lasers.Length > i; i++) {

                lasers[i].Stop ();
            }
            return;
        }
        LockOnTarget ();
        if (useLaser) {
            Laser ();
        } else {
            if (fireCountDown <= 0.0f) {
                Shoot ();

                if (useSlow) {
                    targetEnemy.Slow (slowAmount);
                }
                fireCountDown = 1.0f / fireRate;
            }
            fireCountDown -= Time.deltaTime;
        }
    }
    public void Shoot () {

        for (int i = 0; firePoints.Length > i; i++) {
            GameObject bulletGameObject = (GameObject) Instantiate (bulletPrefab, firePoints[i].position, firePoints[i].rotation);
            Bullet bullet = bulletGameObject.GetComponent<Bullet> ();

            if (bullet != null) {
                bullet.Seek (target);
            }

        }

    }
    public void Laser () {

        for (int i = 0; lasers.Length > i; i++) {
            if (targetEnemy != null) {

                if (!lasers[i].isPlaying) {

                    lasers[i].Play ();
                }

                targetEnemy.takeDamage (damageOverTime * Time.deltaTime);
                if (useSlow) {

                    targetEnemy.Slow (slowAmount);

                }

            } else {
                lasers[i].Stop();

            }

        }

        // if (!lineRenderer.enabled) {
        //     lineRenderer.enabled = true;
        // }
        // targetEnemy.takeDamage (damageOverTime * Time.deltaTime);

        // if (!lineRenderer.enabled) {
        //     lineRenderer.enabled = true;
        //     impactEffect.Play ();
        //     impactLight.enabled = true;
        // }

        // lineRenderer.SetPosition (0, firePoint.position);
        // lineRenderer.SetPosition (1, target.position);

        //Vector3 dir = firePoint.position - target.position;

        //        impactEffect.transform.position = target.position + dir.normalized;

        //      impactEffect.transform.rotation = Quaternion.LookRotation (dir);
    }

    public void LockOnTarget () {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation (dir);
        Vector3 rotation = Quaternion.Lerp (partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler (0.0f, rotation.y, 0.0f);
    }

    public void SellTurret () {
        Destroy (this.gameObject);
    }
   /* public void OnTriggerEnter(Collider other)
    {
       
    }*/

}