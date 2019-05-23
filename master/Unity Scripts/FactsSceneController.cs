using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FactsSceneController : MonoBehaviour
{
    /* Reloads the game */
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");

    }

    /* Loads the main menu */
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
