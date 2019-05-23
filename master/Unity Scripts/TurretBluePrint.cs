using System.Collections;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint {
    public GameObject prefab;
    public int cost;
    public string name;
    public GameObject upgradedPrefab2;
    public int upgradeCost2;
    public GameObject upgradedPrefab3;
    public int upgradeCost3;
    public int money;

    /*Gets the sell amount of this turret */
    public int GetSellAmount () {
        return cost / 2;
    }

    /*Gets the upgrade amount of this turret based on the integer passed in, returns -1 if there is an error */

    public int GetUpgradeCost (int level) {

        switch (level) {
            case 0:
                return upgradeCost2;
            case 1:
                return upgradeCost3;
            case 2:
                Debug.Log ("Turret has been upgraded completely.");
                return 9999;
            default:

                return -1;
        }
    }

    /*Gets the game object based on the level passed in, returns null if turret is maxed out or invalid input */

    public GameObject GetPrefab (int level) {

        switch (level) {
            case 0:
                return upgradedPrefab2;
            case 1:
                return upgradedPrefab3;
            default:
                return null;
        }
    }

}