using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonFade : MonoBehaviour {

    public float delay;


    /* This method starts the coroutine so that buttons are faded in */
    public void callFadeIn(){

        StartCoroutine("FadeIn");
    }

    /* A method that fades in a button's text and its image and then waits for a delayed amount of time */
    IEnumerator FadeIn () {

        while (this.gameObject.GetComponent<Image> ().color.a < 1) {
            this.gameObject.GetComponent<Image> ().color += new Color32(0,0,0,10);
            this.gameObject.GetComponentInChildren<Text> ().color += new Color32(0,0,0,10);
            yield return new WaitForSeconds (delay); 

        }
    }
}