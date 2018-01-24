using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPageSwitch : _BaseLogicEvent
{
    Global.GlobalInt switchCondition;
    List<EP2> eps = new List<EP2>();

    public static EventPageSwitch c(Global.GlobalInt switchCondition)
    {
        return new EventPageSwitch() { switchCondition = switchCondition };
    }

    public EventPageSwitch AddEventPage(int condition, EventPage eventPage, SwitchComparator comparator = SwitchComparator.Equal)
    {
        eps.Add(new EP2() { num = condition, page = eventPage, comp = comparator });

        return this;
    }

    public override IEnumerator Execute()
    {
        var val = switchCondition.value;

        foreach (var item in eps)
        {
            var b = false;

            switch(item.comp)
            {
                case SwitchComparator.Equal: { if (item.num == val) b = true; break; }
                case SwitchComparator.Greater: { if (item.num > val) b = true; break; }
                case SwitchComparator.GreaterOrEqual: { if (item.num >= val) b = true; break; }
                case SwitchComparator.Less: { if (item.num < val) b = true; break; }
                case SwitchComparator.LessOrEqual: { if (item.num <= val) b = true; break; }
                case SwitchComparator.NotEqual: { if (item.num != val) b = true; break; }
            }

            if(b)
            {
                for (int i = 0; i < item.page.events.Count; i++)
                {
                    yield return item.page.events[i].Execute();
                }

                //don't check other conditions if this one is true
                break;
            }
        }
    }

    class EP2
    {
        public EventPage page;
        public int num;
        public SwitchComparator comp;
    }
}

public enum SwitchComparator
{
    Less,
    LessOrEqual,
    Equal,
    Greater,
    GreaterOrEqual,
    NotEqual
}
