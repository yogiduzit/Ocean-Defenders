using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text roundsText;
    public GameObject leaderBoard;

    /* When this object is enabled, this method is called and shows rounds survived on game over screen */
    void OnEnable () {
        roundsText.text = PlayerStats.Waves.ToString ();
    }

    /* A method that loads the high scores and moves the scene to the Submit Score Scene */
    public void LoadHighScoreScene () {

        leaderBoard.GetComponent<Leaderboard> ().PullScores (); //Pull the high scores

        if (StaticEndGame.LowestHighScore.Score < PlayerStats.Waves) {

            //If the player's score is greater than the smallest high score load the next scene

            SceneManager.LoadScene ("Submit Score");
            StaticEndGame.Waves = PlayerStats.Waves; // Sets the high score of the player to this.
        } else {
            SceneManager.LoadScene("FactsEnd");
            //Do nothing as the current player's score is not a high score. 
        }
    }
}