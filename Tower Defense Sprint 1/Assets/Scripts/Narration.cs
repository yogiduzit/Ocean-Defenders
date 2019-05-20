using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Narration : MonoBehaviour {

    public GameObject gameMaster;
    public GameObject skipButton;
    private ArrayList myTextObjects;
    private Queue<Transform> myTextObjectsQueue;
    private Transform currentNode;
    private TypeWriterEffect currentEffect;
    // Start is called before the first frame update
    void Start () {
        //Grabs the game object texts that are within the parent node
        myTextObjects = new ArrayList ();
        myTextObjectsQueue = new Queue<Transform> ();

        foreach (Transform child in transform) {

            myTextObjects.Add (child);
            myTextObjectsQueue.Enqueue (child);
        }

        GetNextText ();

    }

    public void Narrate () {

        StartCoroutine ("WaitAndNarrate", 3.5f); // Tries to narrate after 3 seconds 
        skipButton.SetActive(true);
        // int count = 0;
        // if (currentNode != null) {
        //     currentNode.gameObject.SetActive (true); //set the first object to be active
        // }

        // while (count < 1000) { //currentNode != null

        //     if (currentEffect.fullyShown) {

        //         currentNode.gameObject.SetActive (false); // disable the node 
        //         GetNextText (); //move on to the next node
        //         currentNode.gameObject.SetActive (true);
        //         count++;
        //         Debug.Log ("Never called?");

        //     } else {

        //         Debug.Log (currentNode + currentNode.GetComponent<Text> ().text);
        //         //wait until the animation has completed
        //         count++;
        //         Debug.Log(currentEffect.fullyShown);
        //     }

        // }

    }
    public void GetNextText () {

        Transform myObject = null;

        if (myTextObjectsQueue.Count != 0) { //Change the current node
            myObject = myTextObjectsQueue.Dequeue ();
        }
        currentNode = myObject;

        if (myObject != null) { //Change the current effect

            currentEffect = null;
            currentEffect = currentNode.gameObject.GetComponent<TypeWriterEffect> ();
        }
    }

    IEnumerator NarrateRoutine () {

        while (currentNode != null) {

            if (currentNode != null) {
                currentNode.gameObject.SetActive (true);
            }

            if (currentEffect.fullyShown) {
                //currentNode.gameObject.SetActive (false); // disable the node 
                GetNextText (); //move on to the next node

                if (currentNode != null) {
                    currentNode.gameObject.SetActive (true);
                }

            } else { }

            yield return new WaitForSeconds (3.5f); //checks to see if the current node has been fully shown yet.

        }

        //after the narrate routine has been completed. start the game scene. 
        gameMaster.GetComponent<MainMenu>().PlayGame();

    }

    IEnumerator WaitAndNarrate (float time) {

        //Do nothing and wait. 
        yield return new WaitForSeconds (time);
        //Then call the function passed

        StartCoroutine ("NarrateRoutine");
    }
}