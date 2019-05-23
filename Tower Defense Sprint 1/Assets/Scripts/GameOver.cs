using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text roundsText;
    public GameObject leaderBoard;

    //Shows rounds survived on game over screen
    void OnEnable () {
        roundsText.text = PlayerStats.Waves.ToString ();
    }

    public void LoadHighScoreScene () {

        leaderBoard.GetComponent<Leaderboard> ().PullScores (); //pull the high scores

        if (StaticEndGame.LowestHighScore.Score < PlayerStats.Waves) {

            //if the player's score is greater than the smallest high score 
            SceneManager.LoadScene ("Submit Score");

            StaticEndGame.Waves = PlayerStats.Waves; // sets the high score of the player to this.
            Debug.Log (StaticEndGame.LowestHighScore.Score);
            Debug.Log (PlayerStats.Waves);
        } else {

            //Do nothing
            Debug.Log (StaticEndGame.LowestHighScore.Score);
            Debug.Log (PlayerStats.Waves);

        }

    }

}