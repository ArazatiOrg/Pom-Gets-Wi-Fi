using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTextboxClose : _BaseLogicEvent {
    public static EventTextboxClose c
    {
        get
        {
            return new EventTextboxClose();
        }
    }

    public override IEnumerator Execute()
    {
        Player.playerInstance.StallMovement(.3f);
        TextEngine.instance.Hide();

        yield return null;
    }
}
