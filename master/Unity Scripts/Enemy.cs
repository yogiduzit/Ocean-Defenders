using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    /* distance covered per second */
    public float startSpeed;

    public GameObject deathEffect;
    public bool isDead;
    public string enemyType;
    [HideInInspector]
    public float speed;
    public float startHealth;
    public AudioClip explosionSound;
    private bool isSlowed;
    protected float health;
    public int worth = 50;
    [Header ("Unity Stuff")]
    public Image healthBar;
    private Pathing enemyPath;

    /* Start is called before the first frame update and sets the starting values of this object */
    void Start () {
        health = startHealth;
        speed = startSpeed * Pathing.acceleration;
        isDead = false;
        isSlowed = false;
        enemyPath = this.GetComponent<Pathing>();
    }

    /* A method that damages the enemy's health */
    public void takeDamage (float amount) {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead) {
            Die ();
        }
    }

    /* A method that slows the enemy movement speed */
    public void Slow (float slowAmount) {
        if (!isSlowed) {
            speed *= 1.0f - slowAmount;
            isSlowed = true;
        }
    }

    /* A method that destroys the enemy */
    protected void Die () {
        AudioSource myDeathSound = this.GetComponent<AudioSource> ();
        if (explosionSound != null) {
            myDeathSound.PlayOneShot (explosionSound, 1.0f);
        }
        isDead = true;
        PlayerStats.Money += worth;
        GameObject effect = (GameObject) Instantiate (deathEffect, transform.position, Quaternion.identity);
        Destroy (effect, 4f);
        Destroy (this.gameObject, 0.25f);
    }

}
