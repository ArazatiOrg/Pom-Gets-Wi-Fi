using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BaseTR : MonoBehaviour {
    protected int langRegisterCode = -1;
    protected EventPage ep;

    public readonly Vector2 Up = Vector2.up;
    public readonly Vector2 UpRight = Vector2.up + Vector2.right;
    public readonly Vector2 Right = Vector2.right;
    public readonly Vector2 DownRight = Vector2.down + Vector2.right;
    public readonly Vector2 Down = Vector2.down;
    public readonly Vector2 DownLeft = Vector2.down + Vector2.left;
    public readonly Vector2 Left = Vector2.left;
    public readonly Vector2 UpLeft = Vector2.up + Vector2.left;
    
    [HideInInspector] public string TranslationName;
    [HideInInspector] public string TranslationCredits;

    [HideInInspector] public string PomName =         "Pom";
    [HideInInspector] public string ShibeName =       "Shibe";
    [HideInInspector] public string AlmaName =        "Alma";
    [HideInInspector] public string BernardName =     "Bernard";
    [HideInInspector] public string BoldName =        "Bold";
    [HideInInspector] public string ChiName =         "Chi";
    [HideInInspector] public string CorgName =        "Corg";
    [HideInInspector] public string CrestName =       "Crest";
    [HideInInspector] public string DavePointerName = "Dave Pointer";
    [HideInInspector] public string DogName =         "Dog";
    [HideInInspector] public string GlishName =       "Glish";
    [HideInInspector] public string GoldieName =      "Goldie";
    [HideInInspector] public string HusName =         "Hus";
    [HideInInspector] public string LabraName =       "Labra";
    [HideInInspector] public string Malty =       "Malta";
    [HideInInspector] public string PapiName =        "Papi";
    [HideInInspector] public string PuddleName =      "Puddle";
    [HideInInspector] public string SharpeiName =    "Sharpei";
    [HideInInspector] public string ShermanName =     "Sherman";
    [HideInInspector] public string UgName =          "Ug";
    [HideInInspector] public string WittyFidoName =   "Witty Fido";
    [HideInInspector] public string YorkName =        "York";

    [HideInInspector] public float Pitch_PomBark = 1.1f;
    [HideInInspector] public float Pitch_ShibeBark = 1.2f;
    [HideInInspector] public float Pitch_ShibeBarking = 1.2f;
    [HideInInspector] public float Pitch_CrestBark = 1.3f;
    [HideInInspector] public float Pitch_HusBark = .9f;
    [HideInInspector] public float Pitch_PuddleBark = 1.5f;
    [HideInInspector] public float Pitch_Rimshot = 1.1f;

    public Font font;

    public virtual void Initialize()
    {
        if(Application.isEditor && font != null && font.material != null && font.material.mainTexture != null)
            font.material.mainTexture.filterMode = FilterMode.Point;

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
