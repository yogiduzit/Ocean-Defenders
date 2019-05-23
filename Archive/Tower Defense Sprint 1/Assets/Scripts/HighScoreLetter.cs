using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreLetter : MonoBehaviour {

    private int index;
    private char letter;
    //65 is A
    //66 is B
    //67 is C
    //90 is Z
    void Start () {
        index = 65; // Default Letter is A
        letter = Convert.ToChar (index);
    }

    public void Increment () {

        index++;
        if (index == 91) {

            index = 65;
        }
        letter = Convert.ToChar (index);
        this.GetComponentInChildren<Text> ().text = letter.ToString ();

    }
    public void Decrement () {


        index--;
        if (index == 64) {

            index = 90;
        }
        letter = Convert.ToChar (index);
        this.GetComponentInChildren<Text> ().text = letter.ToString ();
    }


    public char GetLetter(){

        return letter;
    }
}