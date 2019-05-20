using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {
    //B
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

    [Header("Camera Rotate")]
    private CameraShake cam;
    private GameObject cameraRot;

    // Start is called before the first frame update
    void Start () {
        cachedRenderer = GetComponent<Renderer> ();
        stockColor = cachedRenderer.material.color;
        //B
        buildManager = BuildManager.instance;
        activeEffect = null;
        isUpgraded = 0;

        cameraRot = GameObject.FindGameObjectWithTag("CameraRotator");
        cam = cameraRot.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnMouseEnter () {
        if (buildManager.hasMoney && turret == null) {
            //cachedRenderer.material.color = hoverColor;
            //activeEffect = (ParticleSystem) Instantiate (hoverEnoughEffect, transform.position, Quaternion.identity);
        } else if (turret != null || !buildManager.hasSelected) {
            // do nothing
            // there is already a turret on this node.
        } else {
            //activeEffect = (ParticleSystem) Instantiate (hoverNotEnoughEffect, transform.position, Quaternion.identity);
        }

    }

    private void OnMouseExit () {
        cachedRenderer.material.color = stockColor;
        if (activeEffect != null) {
            //there is an activeEffect
            Destroy (activeEffect);
            activeEffect = null;
        }
    }

    private void OnMouseDown () {

        if (EventSystem.current.IsPointerOverGameObject ()) {
            return;
        }

        if (turret != null) {

            buildManager.SelectNode (this);
            /* There already is a turret on this tile. */
            /* Functionality to be implemented later:
                1. Option to upgrade turret
                2. Option to sell turret
                3. Some sort of way to let user know they cannot build on here */

            return;
        } else {

            BuildTurret (buildManager.GetTurretBluePrint ());
        }

    }

    public Vector3 GetBuildPosition () {

        return transform.position + positionOffset;
    }

    public void UpgradeTurret () {
        if (isUpgraded < 2) {
            if (!CanUpgrade (isUpgraded)) {
                return; // user does not have enough money 
            } else {
                PlayerStats.Money -= turretBlueprint.GetUpgradeCost (isUpgraded);
                //else remove the money needed to upgrade
            }
            Vector3 previousPosition = turret.transform.position; // grab the previous position of the turret
            Destroy (turret); // destroy the old turret

            GameObject newTurret = (GameObject) Instantiate (turretBlueprint.GetPrefab (isUpgraded), previousPosition, Quaternion.identity);
            turret = newTurret;

            isUpgraded++;
            Debug.Log ("Turret upgraded!");

        } else {

            Debug.Log ("max level reached!!!!!1111");
        }

    }

    public void SellTurret () {

        PlayerStats.Money += turretBlueprint.GetSellAmount ();
        //to do: add ability for the user to sell for his upgraded cost amount later

        //add a sell effect later 
        //GameObject effect = (GameObject) Instantiate (buildManager.sellEffect, GetBuildPosition (), Quaternion.identity);
        //Destroy (effect, 5f);

        Destroy (turret);
        turretBlueprint = null;

    }
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

        if (PlayerStats.Money < blueprint.cost) {
            return; // not enough money for the user to build
        } else {
            PlayerStats.Money -= blueprint.cost;

            GameObject newTurret = (GameObject) Instantiate (blueprint.prefab, GetBuildPosition (), Quaternion.identity);
            turret = newTurret;

            turretBlueprint = blueprint;
            //Game effect code
            //GameObject effect = (GameObject) Instantiate (buildManager.buildEffect, GetBuildPosition (), Quaternion.identity);
            //Destroy (effect, 5f);

            Debug.Log ("Turret build!");


            

        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Turret"))
        {
            Debug.Log("Collision");
            other.isTrigger = false;
            StartCoroutine(cam.Shake(0.2f, 0.4f));
            
        }
    }

}