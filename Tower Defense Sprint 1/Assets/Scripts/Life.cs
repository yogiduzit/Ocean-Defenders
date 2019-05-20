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
    public static Vector3 gameOverPos = new Vector3();
    public static bool GameIsOver;
    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {



        moneyText.text = PlayerStats.Money.ToString();
        wavesText.text = PlayerStats.Waves.ToString();
        lifeText.text = PlayerStats.Health.ToString();

       


     
        if (PlayerStats.Health <= 0 && !GameIsOver)
        {
            
            EndGame();
        }
       /* if (GameIsOver)
        {
            Debug.Log("return");
            return;
        }*/
    }

    void EndGame ()
    {
        Debug.Log("Hey");
        GameIsOver = true;
        gameOverUI.SetActive(true);

    }
    
    
}

