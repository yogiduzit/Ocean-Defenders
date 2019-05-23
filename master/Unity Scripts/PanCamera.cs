using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamera : MonoBehaviour {
    public float rotationSpeed;
    public float moveSpeed;
    public Transform endPoint;
    public Transform startPoint;
    public Narration narrationText;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private bool rotated;

    /* Sets starting values of this object */
    public void Start () {

        endRotation = CalculateEndRotation (this.transform, endPoint);
        rotated = false;
    }

    /*Called every frame, this will rotate the camera every frame. */
    public void Update () {
        Rotate ();
    }
    /* A method that slowly pans the camera around the scene*/
    private void Rotate () {
        if (!rotated) {
            if (Quaternion.Angle (this.transform.rotation, endRotation) <= 1.00f) {
                rotated = true;
                endRotation = CalculateEndRotation (this.transform, startPoint);
            } else {
                this.transform.rotation = Quaternion.Lerp (this.transform.rotation, endRotation, Time.deltaTime * rotationSpeed);
            }
        } else {
            if (Quaternion.Angle (this.transform.rotation, endRotation) <= 1.00f) {
                rotated = false;
                endRotation = CalculateEndRotation (this.transform, endPoint);
            } else {
                this.transform.rotation = Quaternion.Lerp (this.transform.rotation, endRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
    /* A method that calculates the rotation amount based on the starting position and end position */
    public Quaternion CalculateEndRotation (Transform startPosition, Transform endPosition) {
        Vector3 relativePos = endPosition.position - startPosition.position;
        Quaternion rotation = Quaternion.LookRotation (relativePos, Vector3.up);
        return rotation;
    }
    /* A method that moves the camera to a new location within the scene */
    public void MoveTo (Transform newPosition) {
        float step = moveSpeed * Time.deltaTime; // calculate distance to move
        while (Vector3.Distance (transform.position, newPosition.position) >= 1.00f) {
            transform.position = Vector3.MoveTowards (transform.position, newPosition.position, step);
        }
        narrationText.Narrate ();
    }
}