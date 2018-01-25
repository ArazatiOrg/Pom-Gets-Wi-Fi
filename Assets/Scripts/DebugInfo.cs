using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInfo : MonoBehaviour {
    string text = "";
    public static string debugText = "";

    void Start()
    {
        if (string.IsNullOrEmpty(text))
        {
            text = "v" + Application.version + " - Last Built: " + BuildtimeInfo.DateTimeString();
        }
    }

    private void OnGUI()
    {
        var offset = 0;
        if (Global.devMode)
        {
            DrawText(new Vector2(3, 3), text);
            offset = 23;
        }

        DrawText(new Vector2(3, 3 + offset), debugText);
    }

    void DrawText(Vector2 pos, string text)
    {
        var sizeX = Screen.width - pos.x - 5;

        GUI.color = Color.black;
        GUI.Label(new Rect(pos.x-1, pos.y, sizeX, 4000), text);
        GUI.Label(new Rect(pos.x+1, pos.y, sizeX, 4000), text);
        GUI.Label(new Rect(pos.x, pos.y-1, sizeX, 4000), text);
        GUI.Label(new Rect(pos.x, pos.y+1, sizeX, 4000), text);

        GUI.color = Color.white;
        GUI.Label(new Rect(pos.x, pos.y, sizeX, 4000), text);
    }
}
