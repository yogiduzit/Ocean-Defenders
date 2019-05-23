using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticEndGame {

    private static int waves; // your high score
    private static HighScoreInfo lowestHighScore;

    public static int Waves {
        get {
            return waves;
        }
        set {
            waves = value;
        }
    }

    public static HighScoreInfo LowestHighScore {
        get {
            return lowestHighScore;
        }
        set {
            lowestHighScore = value;
        }
    }

}