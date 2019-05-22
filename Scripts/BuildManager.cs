using UnityEngine;

public class BuildManager : MonoBehaviour {

    public Camera myCamera;
    public static BuildManager instance;
    private TurretBluePrint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;
    private GameObject toBuild;
    public bool CanBuild { get { return turretToBuild != null; } } 

    //Creates a build manager
    private void Awake () {
        if (instance != null) {
            Debug.Log ("Build Manager has already been instantiated. ERROR: There should only be one Build Manager within the game.");
        } else {
            instance = this; // Else set the instance of the build manager to this object. 
        }
    }

    //Sets selected turret to build
    public void SelectTurretToBuild (TurretBluePrint turret) {
        turretToBuild = turret;
    }

    void AddMoney () {
        if (turretToBuild.money != 0) {
            PlayerStats.Money += turretToBuild.money;
        }
    }

    //Checks if player has enough money
    public bool hasMoney {
        get {
            if (turretToBuild != null) {
                return PlayerStats.Money >= turretToBuild.cost;
            } else {
                return false;
            }
        }
    }

    //Checks if a turret is selected
    public bool hasSelected {
        get {
            if (turretToBuild != null) {
                return true;
            } else {
                return false;
            }
        }
    }

    //Selects a node tile
    public void SelectNode (Node node) {
        if(selectedNode == node){
            // if the user clicks the current node again close the UI.
            DeselectNode(); 
            return;
        }
        else{
            //else display the UI
            selectedNode = node; 
            turretToBuild = null;
            nodeUI.SetTarget(node);
        }
    }

    //Deselect node
    public void DeselectNode(){
        selectedNode = null;
        nodeUI.Hide();
    }

    //Getter for turret
    public TurretBluePrint GetTurretBluePrint(){
        return turretToBuild;
    }
   

}