using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSFX : _BaseLogicEvent {
    SFX mySFX;
    float myVolume = 1f;

    public static EventSFX c(SFX sfx, float volume = 1f)
    {
        return new EventSFX() { mySFX = sfx, myVolume = volume };
    }

    public override IEnumerator Execute()
    {
        AudioController.instance.PlaySFX((int)mySFX, myVolume);

        yield return null;
    }
}

public enum SFX
{
    Pom_bark = 0,
    Shibe_barking,
    bump1,
    fire8,
    earth08,
    Medium_Dog1,
    Medium_Dog2
}
