using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreCompare : IComparer {

    public int Compare (object x, object y) {
        HighScoreInfo myX = (HighScoreInfo) x;
        HighScoreInfo myY = (HighScoreInfo) y;
        if (myX.Score > myY.Score) {
            return 0;
        } else {
            return 1;
        }
    }
}