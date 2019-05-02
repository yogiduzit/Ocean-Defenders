using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 positionOffset;
    public Color hoverColor;
    private Color stockColor;
    private Renderer cachedRenderer;
    private GameObject turret;


    // Start is called before the first frame update
    void Start()
    {
        cachedRenderer = GetComponent<Renderer>();
        stockColor = cachedRenderer.material.color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        cachedRenderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        cachedRenderer.material.color = stockColor;
    }


    private void OnMouseDown()
    {

        if(turret != null)
        {

            /* There already is a turret on this tile. */
            /* Functionality to be implemented later:
                1. Option to upgrade turret
                2. Option to sell turret
                3. Some sort of way to let user know they cannot build on here */

            Debug.Log("Cannot build there"); // for testing purposes. 
            return;
        }
        else
        {
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

        }

    }


}
