using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour {

    public Text health;
    // Start is called before the first frame update
    void Start () {
        SetHealthText ();
    }

    /* Check and Set the health of the player every frame */
    private void Update () {
        SetHealthText ();
    }
    
    /* Sets the health of the player */
    void SetHealthText () {
        health.text = "Lives: " + PlayerStats.lives;
    }
}