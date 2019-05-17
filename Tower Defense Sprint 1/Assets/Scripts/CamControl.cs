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

    private void Update()
    {
        healthbars = GameObject.FindGameObjectsWithTag("Enemy");
    }
    public IEnumerator Shake (float duration, float magnitude) {

        Vector3 originalPosition = transform.localPosition;

        float timeElapsed = 0.0f;

        while (timeElapsed < duration) {

            float x = Random.Range (-1f, 1f) * magnitude;
            float y = Random.Range (-1f, 1f) * magnitude;

            transform.localPosition = new Vector3 (x, y, originalPosition.z);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        //Put our camera back to its default position
        transform.localPosition = originalPosition;
    }
    public void longRotateCamera () {

        Debug.Log ("long rotated camera");
        //Debug.Log(healthbars.Length);
        transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
        for (int i = 0; i < healthbars.Length; i++)
        {
            if (healthbars[i] != null)
            {
                healthbars[i].transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

            }
        }

    }

    public void rotateCamera () {

        Debug.Log ("short rotated camera");
        transform.Rotate (0, rotationSpeed * Time.deltaTime * 45f, 0); // simulate 45 degree angle rotate
        for (int i = 0; i < healthbars.Length; i++)
        {
            if (healthbars[i] != null)
            {
                healthbars[i].transform.Rotate(0, rotationSpeed * Time.deltaTime * 45f, 0);

            }
        }

    }

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

    private void LerpView (float zoomAmount) {

        while (Mathf.Abs (GetComponentInChildren<Camera> ().fieldOfView - zoomAmount) > 0.15f) {
            GetComponentInChildren<Camera> ().fieldOfView = Mathf.Lerp (GetComponentInChildren<Camera> ().fieldOfView, zoomAmount, smooth * Time.deltaTime);
            Debug.Log ("called while loop");
        }

    }

}