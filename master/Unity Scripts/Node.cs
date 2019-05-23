using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour {
    public Color notEnough;
    BuildManager buildManager;
    public Vector3 positionOffset;
    public Color hoverColor;
    private Color stockColor;
    public ParticleSystem hoverEnoughEffect;
    public ParticleSystem hoverNotEnoughEffect;
    private ParticleSystem activeEffect;
    private Renderer cachedRenderer;
    public Canvas upgradeCanvas;
    [HideInInspector]
    public int isUpgraded; // an integer representing the upgrade levels
    [HideInInspector]
    public TurretBluePrint turretBlueprint;
    [Header ("Optional")]
    public GameObject turret;

    [Header ("Camera Rotate")]
    private CameraShake cam;
    private GameObject cameraRot;

    // Start is called before the first frame update
    void Start () {
        cachedRenderer = GetComponent<Renderer> ();
        stockColor = cachedRenderer.material.color;
        buildManager = BuildManager.instance;
        activeEffect = null;
        isUpgraded = 0;
        cameraRot = GameObject.FindGameObjectWithTag ("CameraRotator");
        cam = cameraRot.GetComponent<CameraShake> ();
    }

    /* Called when a user presses the node. */
    private void OnMouseDown () {
        if (EventSystem.current.IsPointerOverGameObject ()) {
            return;
        }
        if (turret != null) {
            buildManager.SelectNode (this);
            return;
        } else {
            BuildTurret (buildManager.GetTurretBluePrint ());
        }
    }

    /* A getter method that grabs the current position of the turret */
    public Vector3 GetBuildPosition () {

        return transform.position + positionOffset;
    }

    public void UpgradeTurret () {
        if (isUpgraded < 2) {
            if (!CanUpgrade (isUpgraded)) {
                return; // User does not have enough money 
            } else {
                PlayerStats.Money -= turretBlueprint.GetUpgradeCost (isUpgraded);
                //Remove money from the user
            }
            Vector3 previousPosition = turret.transform.position; // Grab the previous position of the turret
            Destroy (turret); // Destroy the old turret
            GameObject newTurret = (GameObject) Instantiate (turretBlueprint.GetPrefab (isUpgraded), previousPosition, Quaternion.identity);
            turret = newTurret; //Place the new upgraded turret
            isUpgraded++;
        } else {

            //Max level has been reached for this turret.
        }
    }

    /* Destroys and refunds the user the sellback amount of this selected node */
    public void SellTurret () {
        PlayerStats.Money += turretBlueprint.GetSellAmount ();
        Destroy (turret);
        turretBlueprint = null;
    }
    /* Checks to see if this node can be upgraded */
    public bool CanUpgrade (int upgradeLevel) {
        if (PlayerStats.Money < turretBlueprint.GetUpgradeCost (upgradeLevel)) {
            Debug.Log ("Not enough money to upgrade that!");
            return false;
        } else {
            return true;
        }
    }

    /* A method for building a turret on a node */
    public void BuildTurret (TurretBluePrint blueprint) {
        if (blueprint != null) {
            if (PlayerStats.Money < blueprint.cost) {
                return; // not enough money for the user to build
            } else {
                PlayerStats.Money -= blueprint.cost;
                GameObject newTurret = (GameObject) Instantiate (blueprint.prefab, GetBuildPosition (), Quaternion.identity);
                turret = newTurret;
                turretBlueprint = blueprint;
            }
        }
    }

    /* When a turret is placed on a node, shake the camera */
    private void OnTriggerEnter (Collider other) {

        if (other.CompareTag ("Turret")) {
            other.isTrigger = false;
            StartCoroutine (cam.Shake (0.2f, 0.4f));
        }
    }
}