using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

    public float zoom;
    public float normal;
    public int smooth;
    public float rotationSpeed;
    private bool isZoomed = false;
    private GameObject[] healthbars;
    private Enemy boss;

    /* The update method is called every frame to see if there are game objects with health bars */
    private void Update () {
        healthbars = GameObject.FindGameObjectsWithTag ("Health Bar");
    }
    /* A method that rotates the camera slowly */
    public void longRotateCamera () {
        transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
    }

    /* A method that rotates the camera 45 degrees */
    public void rotateCamera () {
        transform.Rotate (0, rotationSpeed * Time.deltaTime * 45f, 0);
    }

    /* A method that zooms the camera to a certain field of view degrees */
    public void zoomCamera () {
        float myView = GetComponentInChildren<Camera> ().fieldOfView;
        if (!isZoomed) {
            LerpView (zoom);
            isZoomed = true;

        } else {
            LerpView (normal);
            isZoomed = false;

        }
    }

    /* A method that zooms the camera to a certain field of view degrees over the zoomAmount time */
    private void LerpView (float zoomAmount) {

        while (Mathf.Abs (GetComponentInChildren<Camera> ().fieldOfView - zoomAmount) > 0.15f) {
            GetComponentInChildren<Camera> ().fieldOfView = Mathf.Lerp (GetComponentInChildren<Camera> ().fieldOfView, zoomAmount, smooth * Time.deltaTime);
        }

    }
}