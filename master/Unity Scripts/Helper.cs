using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This class is returns the children of a parent as an array */
public static class Helper {
    public static Transform[] FindComponentsInChildWithTag<T> (this GameObject parent, string tag) where T : Component {
        Transform t = parent.transform;

        ArrayList myComponents = new ArrayList ();
        int count = 0;
        foreach (Transform tr in t) {
            if (tr.tag == tag) {
                myComponents.Add (tr.GetComponent<T> ());
                count++;
            }
        }

        if (count != 0) {
            return (Transform[]) myComponents.ToArray();
        } else {
            return null;
        }
    }
}