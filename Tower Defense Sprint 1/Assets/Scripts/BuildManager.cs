
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    private GameObject turretToBuild;

    public GameObject standardTurretPrefab;

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

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

}
