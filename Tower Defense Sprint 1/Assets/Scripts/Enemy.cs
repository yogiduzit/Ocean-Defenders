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
    public AudioClip explosionSound;
    private bool isSlowed;

    protected float health;
    public int worth = 50;

    [Header ("Unity Stuff")]
    public Image healthBar;
    // public CameraShake cam;

    // Start is called before the first frame update
    void Start () {
        health = startHealth;
        speed = startSpeed;
        isDead = false;
        isSlowed = false;
    }

    // Update is called once per frame
    void Update () {
        if (enemyType.Equals ("Boss")) {
            //   StartCoroutine(cam.Shake(0.15f, 0.2f));
        }
    }
    public void takeDamage (float amount) {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead) {
            Die ();
        }
    }
    public void Slow (float slowAmount) {

        if (!isSlowed) {
            speed *= 1.0f - slowAmount;
            isSlowed = true;
        }

    }

    protected void Die () {

        AudioSource myDeathSound = this.GetComponent<AudioSource> ();

        if (explosionSound != null) {
            myDeathSound.PlayOneShot (explosionSound, 1.0f);
        } else {
            Debug.Log ("no explosion sound attached");
        }

        isDead = true;
        PlayerStats.Money += worth;

        GameObject effect = (GameObject) Instantiate (deathEffect, transform.position, Quaternion.identity);
        Destroy (effect, 4f);
        Destroy (this.gameObject, 0.25f);
    }

}