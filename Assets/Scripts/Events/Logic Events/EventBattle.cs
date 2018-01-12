using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBattle : _BaseLogicEvent {
    Battles battle;

    public static EventBattle c(Battles battle)
    {
        return new EventBattle() { battle = battle };
    }

    public override IEnumerator Execute()
    {
        //TODO: Battle scene stuff
        yield return EventFlashScreen.c(.2f).Execute();
        yield return EventTextbox.c(Faces.None, "TODO: Battle scene - " + battle).DontSlide.Execute();
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
    Hus_and_Shibe_Test
}