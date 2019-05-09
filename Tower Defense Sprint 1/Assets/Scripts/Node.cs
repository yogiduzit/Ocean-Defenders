using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header ("Optional")]
    public GameObject turret;

    // Start is called before the first frame update
    void Start () {
        cachedRenderer = GetComponent<Renderer> ();
        stockColor = cachedRenderer.material.color;
        //B
        buildManager = BuildManager.instance;
        activeEffect = null;
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnMouseEnter () {
        if (buildManager.hasMoney && turret == null) {
            //cachedRenderer.material.color = hoverColor;
            activeEffect = (ParticleSystem) Instantiate (hoverEnoughEffect, transform.position, Quaternion.identity);
        } else if (turret != null || !buildManager.hasSelected) {
            // do nothing
            // there is already a turret on this node.
        } else {
            activeEffect = (ParticleSystem) Instantiate (hoverNotEnoughEffect, transform.position, Quaternion.identity);
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

        Debug.Log("clicked");
        if (!BuildManager.instance.CanBuild) { //If we cannot build we should exit this function.
            Debug.Log ("cannot build because turret has not been selected");
            return;
        }

        if (turret = null) {

            /* There already is a turret on this tile. */
            /* Functionality to be implemented later:
                1. Option to upgrade turret
                2. Option to sell turret
                3. Some sort of way to let user know they cannot build on here */

            Debug.Log ("Cannot build there"); // for testing purposes. 
            return;
        } else {
            BuildManager.instance.BuildTurretOn (this);
            Debug.Log(this);
        }

    }

    public Vector3 GetBuildPosition () {

        return transform.position + positionOffset;
    }
}