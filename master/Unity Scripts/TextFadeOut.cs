     using System.Collections;
     using UnityEngine.UI;
     using UnityEngine;
     class TextFadeOut : MonoBehaviour {
         //Fade time in seconds
         public float fadeOutTime = 5.0f;

         /* Fades in the text of this object */
         public void Faded () {
             Text text = GetComponent<Text> ();
             text.CrossFadeAlpha (0.0f, fadeOutTime, false);
         }
     }