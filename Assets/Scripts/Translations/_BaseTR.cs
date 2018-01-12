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

    public string PomName =         "Pom";
    public string ShibeName =       "Shibe";
    public string AlmaName =        "Alma";
    public string BernardName =     "Bernard";
    public string BoldName =        "Bold";
    public string ChiName =         "Chi";
    public string CorgName =        "Corg";
    public string CrestName =       "Crest";
    public string DavePointerName = "Dave Pointer";
    public string DogName =         "Dog";
    public string GlishName =       "Glish";
    public string GoldieName =      "Goldie";
    public string HusName =         "Hus";
    public string LabraName =       "Labra";
    public string MaltaName =       "Malta";
    public string PapiName =        "Papi";
    public string PuddleName =      "Puddle";
    public string SharpeiiName =    "Sharpeii";
    public string ShermanName =     "Sherman";
    public string UgName =          "Ug";
    public string WittyFidoName =   "Witty Fido";
    public string YorkName =        "York";

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
