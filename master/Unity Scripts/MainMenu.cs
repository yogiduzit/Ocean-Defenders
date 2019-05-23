using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    /* Starts the game and loads the game scene */
    public void PlayGame () {
        SceneManager.LoadScene ("Game");
    }
}