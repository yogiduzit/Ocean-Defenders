using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Text lifeText;
    public Text moneyText;
    public Text wavesText;
    public Text gameOver;
    public Text waveText;
    public static Vector3 gameOverPos = new Vector3();
    public static bool GameIsOver;
    public GameObject gameOverUI;
    private static Transform TEXT_POS;
<<<<<<< HEAD
    

    private void Start()
    {
        GameIsOver = false;
        TEXT_POS = new GameObject().transform;
        TEXT_POS.position = new Vector3(22f, -167f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

=======
    

    private void Start()
    {
        GameIsOver = false;
        TEXT_POS = new GameObject().transform;
        TEXT_POS.position = new Vector3(22f, -167f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

>>>>>>> 7adbca58f6881c416de82c0a12ae6b3901b389fa


        moneyText.text = PlayerStats.Money.ToString();
        wavesText.text = PlayerStats.Waves.ToString();
        lifeText.text = PlayerStats.Health.ToString();
<<<<<<< HEAD

           





=======

           





>>>>>>> 7adbca58f6881c416de82c0a12ae6b3901b389fa
        if (PlayerStats.Health <= 0 && !GameIsOver)
        {
            
            EndGame();
<<<<<<< HEAD
        }
       
    }

    void EndGame ()
    {
        Debug.Log("Hey");
        GameIsOver = true;
        gameOverUI.SetActive(true);

    }



=======
        }
       
    }

    void EndGame ()
    {
        Debug.Log("Hey");
        GameIsOver = true;
        gameOverUI.SetActive(true);

    }



>>>>>>> 7adbca58f6881c416de82c0a12ae6b3901b389fa
}

