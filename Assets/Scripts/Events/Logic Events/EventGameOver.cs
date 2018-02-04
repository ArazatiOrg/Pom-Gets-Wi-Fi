using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGameOver : _BaseLogicEvent {

    public static EventGameOver c
    {
        get
        {
            return new EventGameOver();
        }
    }

    public override IEnumerator Execute()
    {
        GameOver.StartPlaying();

        yield return null;
    }
}
