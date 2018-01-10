using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EventUnPixelize : _BaseLogicEvent {
    public static EventUnPixelize c
    {
        get
        {
            return new EventUnPixelize();
        }
    }

    public override IEnumerator Execute()
    {
        Pixelate.instance.StartUnfading();

        yield return new WaitUntil(() => Pixelate.instance.finishedFading);
    }

}
