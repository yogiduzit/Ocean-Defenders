using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public float startSpeed = 10.0f;
    public GameObject deathEffect;
    private bool isDead;
    public string enemyType;

    [HideInInspector]
    public float speed;
    public float startHealth;

    private float health;
    public int worth = 50;


    [Header ("Unity Stuff")]
    public Image healthBar;

    // Start is called before the first frame update
    void Start () {
        health = startHealth;
        speed = startSpeed;
        isDead = false;
    }

    // Update is called once per frame
    void Update () {

    }
    public void takeDamage (float amount) {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead) {
            Die ();
        }
    }
    public void Slow (float slowAmount) {
        speed *= 1.0f - slowAmount;
    }
 
    private void Die () {

        isDead = true;
        PlayerStats.Money += worth;

        GameObject effect = (GameObject) Instantiate (deathEffect, transform.position, Quaternion.identity);
        Destroy (effect, 5f);
        Destroy (this.gameObject);
    }
}