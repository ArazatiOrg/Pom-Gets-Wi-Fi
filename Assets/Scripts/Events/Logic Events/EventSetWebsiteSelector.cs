using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSetWebsiteSelector : _BaseLogicEvent {

    public static EventSetWebsiteSelector c
    {
        get
        {
            return new EventSetWebsiteSelector();
        }
    }

    public override IEnumerator Execute()
    {
        if (!Global.s.Intro_Facewoof.value) Global.s.Intro_LastWebsiteSelector.value = 0;
        else if (!Global.s.Intro_Reddig.value) Global.s.Intro_LastWebsiteSelector.value = 1;
        else if (!Global.s.Intro_gTail.value) Global.s.Intro_LastWebsiteSelector.value = 2;
        else if (!Global.s.Intro_Tumfur.value) Global.s.Intro_LastWebsiteSelector.value = 3;

        yield return null;
    }
}
