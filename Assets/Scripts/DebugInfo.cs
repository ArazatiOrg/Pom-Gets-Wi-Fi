using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInfo : MonoBehaviour {
    //string text = "Last Built: " + BuildtimeInfo.DateTimeString();
    string text = "";
    
    void Start()
    {
        if (string.IsNullOrEmpty(text))
        {
            text = "v" + Application.version + " - Last Built: " + BuildtimeInfo.DateTimeString();
        }
    }

    private void OnGUI()
    {
        if (Global.devMode)
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(2, 3, 400, 400), text);
            GUI.Label(new Rect(4, 3, 400, 400), text);
            GUI.Label(new Rect(3, 2, 400, 400), text);
            GUI.Label(new Rect(3, 4, 400, 400), text);

            GUI.color = Color.white;
            GUI.Label(new Rect(3, 3, 400, 400), text);
        }
    }
}
