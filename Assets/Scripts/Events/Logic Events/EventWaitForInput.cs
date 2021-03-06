﻿using System.Collections;
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
            if (InputController.JustPressed(Action.Confirm))
            {
                break;
            }

            yield return null;
        }

        yield return null;
    }
}