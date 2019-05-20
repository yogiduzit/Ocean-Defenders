using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    //Shows rounds survived on game over screen
    void OnEnable()
    {
        roundsText.text = PlayerStats.Waves.ToString();
    }

    //Enables retry button to restart current scene/ level
    public void Retry ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Life.GameIsOver = false;
    }

    //Enabes menu button to go back to menu 
    public void Menu ()
    {
        SceneManager.LoadScene(0);
    }

}
