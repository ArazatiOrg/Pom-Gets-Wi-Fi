using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTextboxClearText : _BaseLogicEvent {
    public static EventTextboxClearText c
    {
        get
        {
            return new EventTextboxClearText();
        }
    }

    public override IEnumerator Execute()
    {
        TextEngine.instance.text.text = "";
        TextEngine.instance.cursorEnabled = false;

        yield return null;
    }
}
