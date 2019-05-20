using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject ui;
    public Text upgradeCost;
    public Button upgradeButton;
    private Node target;

    public void SetTarget(Node myTarget){

        target = myTarget;
        ui.SetActive(true);
    }

    public void Hide(){
        ui.SetActive(false);
    }

    public void Upgrade(){
        target.UpgradeTurret();
    }
    public void Sell(){
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}