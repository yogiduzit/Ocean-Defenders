using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTurret : MonoBehaviour
{
    public bool generate;
    public int money;
    public int timeForMoney;
    // Start is called before the first frame update
    void Start()
    {
        //When tree is planted adds money every set amount of seconds
        InvokeRepeating("AddMoney", 2.0f, timeForMoney);
    }

    // Update is called once per frame
    void Update()
    {
        //If the wave is running generate money if not stop
        if (GameObject.Find("GameMaster").GetComponent<WaveSpawner>().waveIsComplete)
        {
            generate = false;
        }
        else
        {
            generate = true;
        }
    }

    //Adds money if generate is true
    void AddMoney()
    {
        if (generate) {
            PlayerStats.Money += money;
        }
            
    }
}
