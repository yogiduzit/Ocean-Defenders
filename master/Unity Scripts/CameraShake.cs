using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    /* A coroutine that moves the camera in a random position to mimic camera shaking */
    public IEnumerator Shake (float duration, float magnitude) {
        Vector3 originalPos = transform.position;
        float elapsed = 0.0f;
        while (elapsed < duration) {
            float x = Random.Range (-1f, 1f) * magnitude;
            float y = Random.Range (-1f, 1f) * magnitude;
            transform.position += new Vector3 (x, y, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPos;
    }
}