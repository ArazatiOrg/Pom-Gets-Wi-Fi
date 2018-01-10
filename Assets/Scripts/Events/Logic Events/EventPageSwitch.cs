using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPageSwitch : _BaseLogicEvent
{
    Global.GlobalInt switchCondition;
    Dictionary<int,EventPage> eps = new Dictionary<int, EventPage>();

    public static EventPageSwitch c(Global.GlobalInt switchCondition)
    {
        return new EventPageSwitch() { switchCondition = switchCondition };
    }

    public EventPageSwitch AddEventPage(int condition, EventPage eventPage)
    {
        eps.Add(condition, eventPage);

        return this;
    }

    public override IEnumerator Execute()
    {
        var val = switchCondition.value;

        if(eps.ContainsKey(val))
        {
            for (int i = 0; i < eps[val].events.Count; i++)
            {
                yield return eps[val].events[i].Execute();
            }
        }

        yield return null;
    }
}
