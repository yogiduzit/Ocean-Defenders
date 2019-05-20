using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTurret : MonoBehaviour
{
    public int money;
    public int timeForMoney;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AddMoney", 2.0f, timeForMoney);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddMoney()
    {
        PlayerStats.Money += money;
      
    }
}
