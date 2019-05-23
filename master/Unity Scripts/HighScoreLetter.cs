using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreLetter : MonoBehaviour {
    private int index;
    private char letter;

    /* A method that is called when this object is created. Sets the default letter to A*/
    void Start () {
        index = 65; // Default Letter is A
        letter = Convert.ToChar (index);
    }
    /* Increments the index of this object and changes the letter displayed */
    public void Increment () {
        index++;
        if (index == 91) {
            //If our index is passed Z, set the index back to A
            index = 65;
        }
        letter = Convert.ToChar (index);
        this.GetComponentInChildren<Text> ().text = letter.ToString ();

    }
    /* Decrements the index of this object and changes the letter displayed */
    public void Decrement () {
        index--;
        if (index == 64) {
            //If our index is passed A, set the index back to Z
            index = 90;
        }
        letter = Convert.ToChar (index);
        this.GetComponentInChildren<Text> ().text = letter.ToString ();
    }

    /* A getter method that returns the current letter of this object */
    public char GetLetter () {

        return letter;
    }
}