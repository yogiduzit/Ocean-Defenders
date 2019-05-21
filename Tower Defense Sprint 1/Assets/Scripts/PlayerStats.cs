using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public static int Money; // The player's money
    public int startMoney = 400; // The player's starting money
    public static int Health; // The player's health
    public int startHealth = 500; // The player's starting health
    public static int Waves; // The number of waves that the player has survived.
    public static int lives = 50;

    private void Start () {
        Money = startMoney;
        Health = startHealth;
        Waves = 2019;
    }
    private void Update()
    {

    }


}