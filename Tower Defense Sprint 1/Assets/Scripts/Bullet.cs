using UnityEngine;

public class Bullet : MonoBehaviour {
    private Transform target;
    public float speed = 70f;
    public int damage = 50;
    public GameObject impactEffect;
    public void Seek (Transform myTarget) {
        target = myTarget;
    }

    void Update () {

        if (target == null) {

            Destroy (this.gameObject);
            return;
        } else {

            Vector3 direction = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (direction.magnitude <= distanceThisFrame) {
                HitTarget ();
                return;
            }
            transform.Translate (direction.normalized * distanceThisFrame, Space.World);
        }
    }

    void HitTarget () {

        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 1.0f);
        Destroy (this.gameObject);


        Damage(target);

    }

    void Damage (Transform enemy){

        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null){

            e.takeDamage(damage);
        }
    }
}