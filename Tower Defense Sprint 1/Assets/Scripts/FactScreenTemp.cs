using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FactScreenTemp : MonoBehaviour
{
    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    }

    public void MainMenu()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
