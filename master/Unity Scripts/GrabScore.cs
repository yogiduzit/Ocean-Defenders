using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabScore : MonoBehaviour
{
    // Start is called before the first frame update, this method grabs the high score.
    void Start()
    {
        this.gameObject.GetComponent<Text>().text =  StaticEndGame.Waves.ToString();
    }

    
}
