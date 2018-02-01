using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBGM : _BaseLogicEvent {
    BGM myBGM;
    float myVolume = .5f;

    public static EventBGM c(BGM bgm, float volume = .5f)
    {
        return new EventBGM() { myBGM = bgm, myVolume = volume };
    }

    public override IEnumerator Execute()
    {
        if(myBGM == BGM.NONE)
        {
            AudioController.instance.bgmSource.Stop();
        }
        else AudioController.instance.PlayBGM((int)myBGM, myVolume);

        yield return null;
    }
}

public enum BGM
{
    NONE = -1,
    Village2 = 0,
    Burning,
    Memories,
    Eternal,
    Field4,
    EricSkiff_UnderStars,
    Mystery3,
    Castle3,
    Ending3,
    Interlude,
    MechaBase,
    Sadness,
    Shop3,
    Solace3,
    GymnopedieNo1,
    ForgiveMeGreatSpirit,
    Rain
}
