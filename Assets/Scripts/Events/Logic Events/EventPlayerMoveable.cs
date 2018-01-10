using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayerMoveable : _BaseLogicEvent {
    public bool moveable;

    public EventPlayerMoveable(bool moveable)
    {
        this.moveable = moveable;
    }

    public static EventPlayerMoveable c(bool moveable)
    {
        return new EventPlayerMoveable(moveable);
    }

    public override IEnumerator Execute()
    {
        Player.playerInstance.AllowMovement = moveable;

        yield return null;
    }
}
