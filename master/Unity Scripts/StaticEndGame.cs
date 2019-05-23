using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticEndGame {

    private static int waves; // your high score
    private static HighScoreInfo lowestHighScore;

    /* Stores information about the player's wave progression within this game. */
    public static int Waves {
        get {
            return waves;
        }
        set {
            waves = value;
        }
    }

    /* Stores information about the lowest highscore from our database */
    public static HighScoreInfo LowestHighScore {
        get {
            return lowestHighScore;
        }
        set {
            lowestHighScore = value;
        }
    }

}