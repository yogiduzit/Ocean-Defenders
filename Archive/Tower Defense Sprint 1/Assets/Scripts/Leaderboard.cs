using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Leaderboard : MonoBehaviour {

    private ArrayList myScores;
    public GameObject highScoreCanvas = null;
    public GameObject leaderBoardCanvas = null;
    private HighScoreInfo lowestScore;
    private int size;

    public bool isActive = false;
    void Start () {

        size = 0;
        myScores = new ArrayList ();
        //StartCoroutine (AddNewHighScore ());
    }

    void OnEnable () {
        StartCoroutine (GetHighScores ());
    }

    public void PullScores () {
        StartCoroutine (GetHighScores ());
    }

    public void AddScore (string name, int score) {

        StartCoroutine (AddNewHighScore (name, score));

    }
    IEnumerator AddNewHighScore (string name, int score) {

        //https://forum.unity.com/threads/unitywebrequest-post-url-jsondata-sending-broken-json.414708/
        WWWForm form = new WWWForm ();

        HighScoreInfo myHighScore = new HighScoreInfo (name, score);
        string json = JsonUtility.ToJson (myHighScore);
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes (json);

        Debug.Log (json);
        using (UnityWebRequest www = new UnityWebRequest ("https://ocean-defenders.firebaseio.com/highscores.json", "POST")) {

            www.uploadHandler = (UploadHandler) new UploadHandlerRaw (bodyRaw);
            www.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer ();
            www.SetRequestHeader ("Content-Type", "application/json");

            yield return www.SendWebRequest ();
            if (www.isNetworkError || www.isHttpError) {
                Debug.Log (www.error);
            } else {
                Debug.Log ("Form upload complete!");
            }
        }

    }
    IEnumerator GetHighScores () {

        myScores = null;
        myScores = new ArrayList ();
        size = 0;

        using (UnityWebRequest webRequest = UnityWebRequest.Get ("https://ocean-defenders.firebaseio.com/highscores.json")) {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest ();

            if (webRequest.isNetworkError) {
                Debug.Log (": Error: " + webRequest.error);
            } else {
                string jsonString = webRequest.downloadHandler.text;
                var node = JSONNode.Parse (jsonString);
                if (node.Tag == JSONNodeType.Object) {
                    foreach (KeyValuePair<string, JSONNode> kvp in (JSONObject) node) {
                        //Debug.Log (string.Format ("{0}: {1} {2}",kvp.Key, kvp.Value["Name"].Value, kvp.Value["Score"].Value));
                        myScores.Add (new HighScoreInfo (kvp.Value["Name"].Value, System.Int32.Parse (kvp.Value["Score"].Value)));
                        size++;
                    }
                }

            }

            myScores.Sort ();

            if (size < 7) {
                lowestScore = (HighScoreInfo) myScores[myScores.Count - 1];
            } else {
                lowestScore = (HighScoreInfo) myScores[6];
            }
            StaticEndGame.LowestHighScore = lowestScore; // Stores the lowest high score in a static class
            LoadHighScores ();

        }
    }
    public void LoadHighScores () {

        if (highScoreCanvas != null) {
            Text[] texts = highScoreCanvas.GetComponentsInChildren<Text> (); // Get all the text components

            for (int i = 0; texts.Length - 1 > i && myScores.Count > i; i++) {

                texts[i + 1].text = myScores[i].ToString ();

            }

        }

    }
    public void Display () {

        if (leaderBoardCanvas != null) {
            leaderBoardCanvas.SetActive (!isActive);
            isActive = !isActive;

        }
    }

}