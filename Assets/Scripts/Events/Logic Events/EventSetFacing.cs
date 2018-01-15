using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSetFacing : _BaseLogicEvent {
    NPC npc;
    SpriteDir dir;

    public static EventSetFacing c(NPC npc, SpriteDir direction)
    {
        return new EventSetFacing() { npc = npc, dir = direction };
    }

    public override IEnumerator Execute()
    {
        NPCList.GetNPC(npc).SetFacingDirection(dir);

        yield return null;
    }
}