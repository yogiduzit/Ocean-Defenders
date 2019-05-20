using UnityEngine;

public class BuildManager : MonoBehaviour {
    public Camera myCamera;
    public static BuildManager instance;
    private TurretBluePrint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    //B
    private GameObject toBuild;

    public bool CanBuild { get { return turretToBuild != null; } } // A C# Property 

    private void Start () 
    { 

    }
    private void Awake () {
        if (instance != null) {
            Debug.Log ("Build Manager has already been instantiated. ERROR: There should only be one Build Manager within the game.");
        } else {

            instance = this; // Else set the instance of the build manager to this object. 
        }
    }

    public void SelectTurretToBuild (TurretBluePrint turret) {
        turretToBuild = turret;
    }
    void AddMoney () {
        if (turretToBuild.money != 0) {
            PlayerStats.Money += turretToBuild.money;
        }
    }

    public bool hasMoney {
        get {
            if (turretToBuild != null) {
                return PlayerStats.Money >= turretToBuild.cost;
            } else {
                return false;
            }
        }

    }
    public bool hasSelected {
        get {
            if (turretToBuild != null) {
                return true;
            } else {
                return false;
            }
        }
    }

    public void SelectNode (Node node) {
        if(selectedNode == node){

            DeselectNode(); // if the user clicks the current node again close the UI.
            return;
        }
        else{
            //else display the UI
            selectedNode = node; 
            turretToBuild = null;
            nodeUI.SetTarget(node);
        }
    }

    public void DeselectNode(){
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBluePrint GetTurretBluePrint(){

        return turretToBuild;
    }
   

}