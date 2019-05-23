using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterSelector : MonoBehaviour {
    public GameObject[] letters;
    public GameObject selectedLetter;
    public Text score = null;
    public Leaderboard leaderBoard;

    void Awake () {
        if (letters.Length > 0) {

            selectedLetter = letters[0];
            selectedLetter.GetComponentInChildren<Text> ().color = new Color (255f, 255f, 0, 100f);

        }
    }

    public void IncrementLetter () {

        selectedLetter.GetComponent<HighScoreLetter> ().Increment ();
    }

    public void DecrementLetter () {

        selectedLetter.GetComponent<HighScoreLetter> ().Decrement ();
    }

    public void SelectLetter (GameObject letter) {
        selectedLetter.GetComponentInChildren<Text> ().color = new Color (255f, 255f, 255f, 255f); //change back to white

        selectedLetter = letter; // select the new letter
        selectedLetter.GetComponentInChildren<Text> ().color = new Color (255f, 221f, 0, 255f); // change to yellow
    }

    public void PushServer () {
        if (score != null) {

            int number;
            bool success = int.TryParse (score.text.ToString(), out number);

            if (success) {


                Debug.Log(success);
                string myString = System.String.Empty;

                if (letters.Length > 0) {

                    foreach (GameObject l in letters) {

                        myString += l.GetComponent<HighScoreLetter> ().GetLetter ();
                    }
                }
                leaderBoard.AddScore (myString, number); //change so this pushes to the server and then closes the canvas.
                Debug.Log("hi");  
            }

        }

    }
}