using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTextboxOnlyBG : _BaseLogicEvent {
    public static EventTextboxOnlyBG c { get { return new EventTextboxOnlyBG(); } }

    public override IEnumerator Execute()
    {
        if(TextEngine.instance.bgImage.enabled)
        {
            var bg = TextEngine.instance.bgImage.sprite;

            TextEngine.instance.Clear();

            TextEngine.instance.bgImage.sprite = bg;
            TextEngine.instance.bgImage.enabled = true;
        }

        yield return null;
    }
}

