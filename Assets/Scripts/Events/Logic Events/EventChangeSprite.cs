using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EventChangeSprite : _BaseLogicEvent
{
    PlayerSprite spriteIndex = 0;

    public static EventChangeSprite c(PlayerSprite newSprite)
    {
        return new EventChangeSprite() { spriteIndex = newSprite };
    }

    public override IEnumerator Execute()
    {
        Player.playerInstance.anim.spriteSetIndex = (int)spriteIndex;
        Global.s.PlayerSprite.value = (int)spriteIndex;

        yield return null;
    }
}

public enum PlayerSprite
{
    Pillow = 0,
    PillowAndLaptop,
    Normal,
    Small,
    OnFire,
    None
}
