using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EventWait : _BaseLogicEvent {
    float timeToWait = .1f;
    
    public static EventWait c(float time)
    {
        return new EventWait() { timeToWait = time };
    }

    public override IEnumerator Execute()
    {
        if (timeToWait > 0f)
            yield return new WaitForSeconds(timeToWait);
        else
            yield return null;
    }

}
