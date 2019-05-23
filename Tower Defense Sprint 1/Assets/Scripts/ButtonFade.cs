using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonFade : MonoBehaviour {

    public float delay;
    // Start is called before the first frame update

    // Update is called once per frame

    public void callFadeIn(){

        StartCoroutine("FadeIn");
    }
    IEnumerator FadeIn () {

        while (this.gameObject.GetComponent<Image> ().color.a < 1) {
            this.gameObject.GetComponent<Image> ().color += new Color32(0,0,0,10);
            this.gameObject.GetComponentInChildren<Text> ().color += new Color32(0,0,0,10);
            yield return new WaitForSeconds (delay); 

        }
    }
}