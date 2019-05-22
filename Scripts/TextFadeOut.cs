     using System.Collections;
     using UnityEngine;
     using UnityEngine.UI;
     class TextFadeOut : MonoBehaviour
     {
         //Fade time in seconds
         public float fadeOutTime = 5.0f;

         public void Faded(){

             Text text = GetComponent<Text>();
             text.CrossFadeAlpha(0.0f, fadeOutTime,false);
         }
     }