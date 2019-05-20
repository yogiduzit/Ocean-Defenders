using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
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

}
