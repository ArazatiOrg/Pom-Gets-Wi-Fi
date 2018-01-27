using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EventBlinds : _BaseLogicEvent {
    bool noYield = false;

    public static EventBlinds c
    {
        get { return new EventBlinds(); }
    }

    public EventBlinds NoYield { get { noYield = true; return this; } }

    public override IEnumerator Execute()
    {
        var cameraBlinds = Camera.main.GetComponentInChildren<CameraBlinds>();

        cameraBlinds.StartBlinds();

        if (!noYield)
            yield return new WaitUntil(() => cameraBlinds.finished);
        else
            yield return null;
    }

}
