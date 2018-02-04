using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventShake : _BaseLogicEvent {
    float time = .4f;
    float strength = 5f;
    float speed = 5f;

    bool wait = false;

    public static EventShake c(float time = .2f)
    {
        return new EventShake() { time = time };
    }

    public static EventShake c(float strength = 5f, float speed = 5f, float time = .4f)
    {
        return new EventShake() { strength = strength, time = time };
    }

    public EventShake Wait { get { wait = true; return this; } }

    public override IEnumerator Execute()
    {
        KeepCameraInBounds.instance.StartShake(strength / 8f, speed, time);

        if(wait) yield return new WaitUntil(() => KeepCameraInBounds.instance.curShakeStrength == 0f);
        else yield return null;
    }
}