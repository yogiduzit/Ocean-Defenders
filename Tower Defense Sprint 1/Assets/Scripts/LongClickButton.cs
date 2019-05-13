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
    public void Start () {
        pointerDown = false;
    }
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
    public void OnPointerDown (PointerEventData eventData) {
        pointerDown = true;
        Debug.Log ("Pointer is down");
    }

    public void OnPointerUp (PointerEventData eventData) {
        StartCoroutine (Reset ());
    }

    IEnumerator Reset () {
        pointerDown = false;
        pointerDownTime = 0;
        yield return new WaitForSeconds (0.25f);
        GetComponentInParent<Button> ().interactable = true;

    }
}