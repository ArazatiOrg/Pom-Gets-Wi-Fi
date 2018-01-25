using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventWaitForInput : _BaseLogicEvent {
    public static EventWaitForInput c
    {
        get { return new EventWaitForInput(); }
    }
    public override IEnumerator Execute()
    {
        while(true)
        {
            //TODO: Proper input this event too
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z))
            {
                break;
            }

            yield return null;
        }

        yield return null;
    }
}