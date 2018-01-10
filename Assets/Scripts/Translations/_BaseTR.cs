using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BaseTR : MonoBehaviour {
    protected int langRegisterCode = -1;
    protected EventPage ep;

    public Vector2 Up = Vector2.up;
    public Vector2 UpRight = Vector2.up + Vector2.right;
    public Vector2 Right = Vector2.right;
    public Vector2 DownRight = Vector2.down + Vector2.right;
    public Vector2 Down = Vector2.down;
    public Vector2 DownLeft = Vector2.down + Vector2.left;
    public Vector2 Left = Vector2.left;
    public Vector2 UpLeft = Vector2.up + Vector2.left;


    [HideInInspector] public string TranslationName;
    [HideInInspector] public string TranslationCredits;

    public Font font;

    public virtual void Initialize()
    {
        if (langRegisterCode == -1) { Debug.LogError("Translation never registered! Why is this being called.."); return; }
    }

    public EventPage NewEP(string GUID)
    {
        ep = EventPage.GetEventPage(langRegisterCode, GUID);
        return ep;
    }

    public _BaseLogicEvent e
    {
        set
        {
            ep.Add(value);
        }
    }
}
