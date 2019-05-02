
using UnityEngine;

public class BuildManager : MonoBehaviour
{   
    public CameraShake camerashake;
    public Vector3 positionOffset;
    public static BuildManager instance;
    private TurretBluePrint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } } // A C# Property 

    private void Awake()
    {
        if(instance != null)
        {

            Debug.Log("Build Manager has already been instantiated. ERROR: There should only be one Build Manager within the game.");
        }
        else
        {

            instance = this; // Else set the instance of the build manager to this object. 
        }
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build, you only have " + PlayerStats.Money);
            return;
        }
        else
        {
            PlayerStats.Money -= turretToBuild.cost;
            GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
            node.turret = turret;
            Debug.Log("you spent: " + turretToBuild.cost + " and have " + PlayerStats.Money + " left");
            turretToBuild = null; // Once you have purchased a turret you have to press the correct button to rebuild. 
            StartCoroutine (camerashake.Shake(0.10f, 0.35f));
        }

    }

   
}
