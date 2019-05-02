using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint slowTurret;
    public TurretBluePrint posionTurret;

    public void Update () {
        if (Input.GetKeyDown ("1")) {
            Debug.Log ("selected default tower");

            BuildManager.instance.SelectTurretToBuild (standardTurret);
        }

        if (Input.GetKeyDown ("2")) {

            Debug.Log ("selected second tower");

            BuildManager.instance.SelectTurretToBuild (missileLauncher);

        }

        if (Input.GetKeyDown ("3")) {

            Debug.Log ("selected second tower");

            BuildManager.instance.SelectTurretToBuild (slowTurret);

        }
        if (Input.GetKeyDown ("4")) {

            Debug.Log ("selected second tower");

            BuildManager.instance.SelectTurretToBuild (posionTurret);

        }
    }
}