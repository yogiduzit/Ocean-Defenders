using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    // The player's money
    public static int Money;
    // The player's starting money
    public int startMoney = 400;
    // The player's health
    public static int Health;
    // The player's starting health
    public int startHealth = 50;
    // The number of waves that the player has survived.
    public static int Waves; 
    // The year the players start on
    public static int lives = 2019;

    //Assign starting values
    private void Start () {
        Money = startMoney;
        Health = startHealth;
        Waves = lives;
    }
}