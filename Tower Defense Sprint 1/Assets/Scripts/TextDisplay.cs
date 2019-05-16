using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{

    public Text health; 
    // Start is called before the first frame update
    void Start()
    {
        SetHealthText();
    }
    private void Update()
    {
        SetHealthText();
    }
    void SetHealthText()
    {

        health.text = "Lives: " + PlayerStats.lives;

    }
}
