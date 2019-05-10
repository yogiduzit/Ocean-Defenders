using UnityEngine;

public class BuildManager : MonoBehaviour {
    public Camera myCamera;
    public Vector3 positionOffset;
    public static BuildManager instance;
    private TurretBluePrint turretToBuild;

    //B
    private GameObject toBuild;

    public bool CanBuild { get { return turretToBuild != null; } } // A C# Property 

    private void Start () { }
    private void Awake () {
        if (instance != null) {

            Debug.Log ("Build Manager has already been instantiated. ERROR: There should only be one Build Manager within the game.");
        } else {

            instance = this; // Else set the instance of the build manager to this object. 
        }
    }

    public void SelectTurretToBuild (TurretBluePrint turret) {

        Debug.Log (turret.cost);
        Debug.Log (turret.prefab);
        turretToBuild = turret;
    }

    public void BuildTurretOn (Node node) {
        if (PlayerStats.Money < turretToBuild.cost) {
            Debug.Log ("Not enough money to build, you only have " + PlayerStats.Money);
            return;
        } else {

            PlayerStats.Money -= turretToBuild.cost;

            Debug.Log("wtf" + node.GetBuildPosition());
            GameObject turret = (GameObject) Instantiate (turretToBuild.prefab, node.GetBuildPosition() + positionOffset, Quaternion.identity);
            turret.name = turretToBuild.name; // Set the name of the created game object to the blueprint name
            node.turret = turret;
            Debug.Log ("you spent: " + turretToBuild.cost + " and have " + PlayerStats.Money + " left");
            turretToBuild = null; // Once you have purchased a turret you have to press the correct button to rebuild. 
            //StartCoroutine (myCamera.GetComponent<CamControl>().Shake (0.10f, 0.35f));
        }

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

}