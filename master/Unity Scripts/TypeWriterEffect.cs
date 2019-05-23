using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour {
    public float delay = 0.1f;
    public string fullText;
    private string currentText;
    public bool fullyShown;
    // Start is called before the first frame update
    void Start () {
        fullyShown = false;
        currentText = "";
        StartCoroutine (ShowText ()); // calls the coroutine to display the text
    }

    //Displays the intro text letter by letter
    IEnumerator ShowText () {
        for (int i = 0; i <= fullText.Length; i++) {
            currentText = fullText.Substring (0, i);
            this.GetComponent<Text> ().text = currentText;
            if (i == fullText.Length) {
                fullyShown = true;
            }
            yield return new WaitForSeconds (delay);
        }
        this.GetComponent<AudioSource> ().Stop ();
        this.GetComponent<TextFadeOut> ().Faded ();
    }

}