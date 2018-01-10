using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPageExecute : _BaseLogicEvent
{
    EventPage ep;

    public static EventPageExecute c(EventPage eventPage)
    {
        return new EventPageExecute() { ep = eventPage };
    }

    public override IEnumerator Execute()
    {
        if(ep != null)
        {
            for (int i = 0; i < ep.events.Count; i++)
            {
                yield return ep.events[i].Execute();
            }
        }

        yield return new WaitForEndOfFrame();
    }
}
