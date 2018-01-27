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
        if(myBGM == BGM.none)
        {
            AudioController.instance.bgmSource.Stop();
        }
        else AudioController.instance.PlayBGM((int)myBGM, myVolume);

        yield return null;
    }
}

public enum BGM
{
    none = -1,
    village2 = 0,
    burning,
    memories,
    eternal,
    field4,
    EricSkiff_UnderStars,
    mystery3,
}
