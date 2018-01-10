using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSetBackground : _BaseLogicEvent {
    Background background;

    public static EventSetBackground c(Background background)
    {
        return new EventSetBackground() { background = background };
    }

    public override IEnumerator Execute()
    {
        TextEngine.instance.SetBG(background);

        yield return null;
    }
}