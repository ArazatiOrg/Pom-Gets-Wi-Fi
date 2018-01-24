using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSaveScreen : _BaseLogicEvent {

    public static EventSaveScreen c
    {
        get
        {
            return new EventSaveScreen();
        }
    }

    public override IEnumerator Execute()
    {
        Global.ActiveSavefile.Save(0);

        yield return null;
    }
}
