using System;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class HighScoreInfo : IComparable {
    public string Name;
    public int Score;

    /* A default constructor for this class. */
    public HighScoreInfo () {

        this.Name = "ERROR";
        this.Score = 99999;
    }
    /* An overloaded constructor that accepts an argument of name and score */
    public HighScoreInfo (string name, int score) {

        this.Name = name;
        this.Score = score;
    }
    /* An overloaded toString method that returns the name and score*/

    public override string ToString () {

        return ("Name: " + this.Name + " Score: " + this.Score);
    }

    /* A method that compares high score info */
    public int CompareTo (object other) {
        if (other == null) {
            return -1;
        }
        HighScoreInfo myOther = other as HighScoreInfo;
        if (this.Score > myOther.Score) {

            return -1;
        } else if (this.Score == myOther.Score) {

            return 0;
        } else {
            return this.Score;

        }
    }
}