using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Time elapsed before the previous camera shake.
    private float timeInvoked;

    // Delay between each time the camera is shaked.
    private float timeDelay = 0.6f;

    // Rotates the camera.
    private GameObject cameraRotator;


    // Shakes the camera.
    private CameraShake cam;

    // Start is called before the first frame update
    void Start()
    {
        timeInvoked = Time.time;
        cameraRotator =  GameObject.FindGameObjectWithTag("CameraRotator");
        cam = cameraRotator.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeInvoked + timeDelay)
        {
            timeInvoked = Time.time;
            StartCoroutine(cam.Shake(0.2f, 0.4f));
        }

    }
}
