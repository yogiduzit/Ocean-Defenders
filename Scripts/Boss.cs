using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Camera control for boss shake and rotation
    private float timeInvoked;
    private float timeDelay = 0.6f;
    private GameObject cameraRotator;
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
