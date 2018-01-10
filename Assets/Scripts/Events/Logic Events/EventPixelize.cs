using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EventPixelize : _BaseLogicEvent {
    public static EventPixelize c
    {
        get
        {
            return new EventPixelize();
        }
    }

    public override IEnumerator Execute()
    {
        Pixelate.instance.StartFading();

        yield return new WaitUntil(() => Pixelate.instance.finishedFading);
    }

}
