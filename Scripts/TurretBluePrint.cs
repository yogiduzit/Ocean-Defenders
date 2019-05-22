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

    public int GetSellAmount () {
        return cost / 2;
    }

    public int GetUpgradeCost (int level) {

        switch (level) {
            case 0:
                return upgradeCost2;
            case 1:
                return upgradeCost3;
            case 2:
                Debug.Log ("turretblueprint - GetUpgradeCost called and turret is maxed");
                return 9999;
            default:
                Debug.Log ("turretblueprint - GetUpgradeCost called but unexpected behaviour");
                return -1;
        }
    }

    public GameObject GetPrefab (int level) {

        switch (level) {
            case 0:
                return upgradedPrefab2;
            case 1:
                return upgradedPrefab3;
            case 2:
                Debug.Log ("turretblueprint - GetUpgradeCost called and turret is maxed");
                return null;
            default:
                Debug.Log ("turretblueprint - GetUpgradeCost called but unexpected behaviour");
                return null;
        }
    }

}