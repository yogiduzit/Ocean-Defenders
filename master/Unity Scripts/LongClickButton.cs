using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    private bool pointerDown;
    public UnityEvent onLongClick;
    private float pointerDownTime;
    public float requiredHoldTime = 0.75f;

    /* Sets the initial values of pointer down to false */
    public void Start () {
        pointerDown = false;
    }
    /* Checks every frame if the pointer is down, if so it calls the rotate function */
    public void Update () {
        if (pointerDown) {
            pointerDownTime += Time.deltaTime;
            if (pointerDownTime > requiredHoldTime) {
                GetComponentInParent<Button> ().interactable = false;
                if (onLongClick != null) {
                    onLongClick.Invoke ();
                }
            }
        }
    }
    /* When the user mouses down on the button, set the pointerDown variable to true */
    public void OnPointerDown (PointerEventData eventData) {
        pointerDown = true;
    }
    /* When the user removes the mouse from the button, reset the interactivity of the button */
    public void OnPointerUp (PointerEventData eventData) {
        StartCoroutine (Reset ());
    }
    /* A method that resets the interactivity of the button if it is currently pressed down */
    IEnumerator Reset () {
        pointerDown = false;
        pointerDownTime = 0;
        yield return new WaitForSeconds (0.25f);
        GetComponentInParent<Button> ().interactable = true;

    }
}