using System;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class HighScoreInfo : IComparable {
    public string Name;
    public int Score;

    public HighScoreInfo () {

        this.Name = "ERROR";
        this.Score = 99999;
    }
    public HighScoreInfo (string name, int score) {

        this.Name = name;
        this.Score = score;
    }

    public override string ToString () {

        return ("Name: " + this.Name + " Score: " + this.Score);
    }

    public int CompareTo (object other) {
        if (other == null) {
            return -1;
        }
        HighScoreInfo myOther = other as HighScoreInfo;
        if (this.Score > myOther.Score) {

            return -1;
        } 
        
        else if (this.Score == myOther.Score){
            
            return 0;
        }
        else{
            return this.Score;

        }
    }
}