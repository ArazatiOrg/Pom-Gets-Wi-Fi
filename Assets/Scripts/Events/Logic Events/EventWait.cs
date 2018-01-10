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
        yield return new WaitForSeconds(timeToWait);
    }

}
