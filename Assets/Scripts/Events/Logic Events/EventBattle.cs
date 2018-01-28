using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBattle : _BaseLogicEvent {
    Battles battle;

    public static EventBattle c(Battles battle)
    {
        return new EventBattle() { battle = battle };
    }

    int oldMusic = -1;
    float oldVolume = 0f;
    public override IEnumerator Execute()
    {
        yield return EventFlashScreen.c(.15f).Execute();
        yield return EventFlashScreen.c(.15f).Execute();
        oldMusic = Global.s.ActiveBGM;
        oldVolume = Global.s.ActiveBGMVolume;
        AudioController.instance.PlayBGM((int)BGM.NONE, .4f);
        yield return EventBlinds.c.Execute();
        BattleController.instance.InitBattle(battle);
        yield return EventWait.c(1f).Execute();
        yield return EventFade.c(-1f, Color.black).NoYield.Execute();
        CameraBlinds.instance.HideBlinds();
        yield return EventWait.c(1f).Execute();
        BattleController.instance.StartBattle();
        yield return new WaitUntil(() => BattleController.instance.curBattle == Battles.None);
        yield return EventFade.c(1f).Execute();
        BattleController.instance.FinishedBattle();
        yield return EventFade.c(-1f).Execute();
        AudioController.instance.PlayBGM(oldMusic, oldVolume);
    }
}

public enum Battles
{
    Shibe,
    Puddle,
    Bernard,
    Hus_and_Shibe,
    York,
    Dog,
    Shibe_final,
    Hus_and_Shibe_Test,
    None
}