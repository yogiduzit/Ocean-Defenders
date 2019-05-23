using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour {
    public GameObject ui;
    public Text upgradeCost;
    public Button upgradeButton;
    private Node target;
    /*Sets the selected node of this object to the node passed in */
    public void SetTarget (Node myTarget) {
        target = myTarget;
        ui.SetActive (true);
    }
    /* Hides the selected node's user interface */
    public void Hide () {
        ui.SetActive (false);
    }
    /* Upgrades the selected node's turret */
    public void Upgrade () {
        target.UpgradeTurret ();
    }
    /*Sells the selected node's turret */
    public void Sell () {
        target.SellTurret ();
        BuildManager.instance.DeselectNode ();
    }
}