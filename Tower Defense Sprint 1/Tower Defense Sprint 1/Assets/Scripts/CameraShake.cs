using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    
    
    public IEnumerator Shake(float duration, float magnitude){

        Vector3 originalPosition = transform.localPosition;

        float timeElapsed = 0.0f;

        while(timeElapsed < duration ){

            float x = Random.Range(-1f,1f) * magnitude;
            float y = Random.Range(-1f,1f) * magnitude;

            transform.localPosition = new Vector3(x,y, originalPosition.z);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        //Put our camera back to its default position
        transform.localPosition = originalPosition;
    }
}
