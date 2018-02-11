using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSFX : _BaseLogicEvent {
    SFX mySFX;
    float myVolume = 1f;
    float pitch = 1f;

    public static EventSFX c(SFX sfx, float volume = 1f, float pitch = 1f)
    {
        return new EventSFX() { mySFX = sfx, myVolume = volume, pitch = pitch };
    }

    public override IEnumerator Execute()
    {
        AudioController.instance.PlaySFX((int)mySFX, myVolume, pitch);

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
    Medium_Dog2,
    Cursor,
    Choice,
    Cancel,
    Buzzer,
    crunching1,
    Rimshot,
    damage1,
    close1,
    punch6,
    punch1,
    cameraShutter,
    breath,
    vanish,
    quake2,
    flash2,
    punch3,
    decrease,
    fire2,
    fire3,
    explode1,
    heal4
}
