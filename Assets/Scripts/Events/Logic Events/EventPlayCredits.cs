using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayCredits : _BaseLogicEvent
{
    public static EventPlayCredits c
    {
        get
        {
            return new EventPlayCredits();
        }
    }

    public override IEnumerator Execute()
    {
        yield return EventFade.c(3f).Execute();
        Credits.StartPlaying();
        yield return EventFade.c(-.4f).Execute();

        yield return new WaitUntil(() => Credits.Finished);

        yield return EventWait.c(1f).Execute();

        Global.ResetLevel();
    }
}
