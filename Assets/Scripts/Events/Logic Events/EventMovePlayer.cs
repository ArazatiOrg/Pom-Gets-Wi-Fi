using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMovePlayer : _BaseLogicEvent {
    private Vector2 directDir;
    NPC npc = NPC.Pom;
    Speed speed = Speed.Normal;
    int times = 1;
    bool noWait = false;

    public EventMovePlayer(Vector2 directDirection, NPC npc = NPC.Pom)
    {
        directDir = directDirection;
        this.npc = npc;
    }

    public static EventMovePlayer c(Vector2 directDirection, NPC npc = NPC.Pom, Speed speed = Speed.Normal, int times = 1)
    {
        return new EventMovePlayer(directDirection, npc) { speed = speed, times = times };
    }

    public EventMovePlayer NoWait
    {
        get
        {
            noWait = true;
            return this;
        }
    }

    public override IEnumerator Execute()
    {
        var controller = NPCList.GetNPC(npc);
        var before = controller.AllowMovement;
        var beforeSpeed = controller.moveSpeed;

        switch (speed)
        {
            case Speed.OneEighthNormal: controller.moveSpeed = 1f; break;
            case Speed.OneFourthNormal: controller.moveSpeed = 2f; break;
            case Speed.HalfNormal: controller.moveSpeed = 4f; break;
            case Speed.Normal: controller.moveSpeed = 8f; break;
            case Speed.TwiceNormal: controller.moveSpeed = 16f; break;
            case Speed.FourTimesNormal: controller.moveSpeed = 32f; break;
        }
        
        for (int i = 0; i < times; i++)
        {
            controller.AllowMovement = true;
            controller.SetFacingDirection(controller.DirFromVector(directDir));
            controller.ForceMove(directDir);
            controller.AllowMovement = false;

            if(!noWait) yield return new WaitUntil(() => controller.stoppedOnTile);
        }

        if (!noWait)
        {
            controller.moveSpeed = beforeSpeed;
            controller.AllowMovement = before;
        }

        yield return null;
    }
}

public enum Speed
{
    OneEighthNormal,
    OneFourthNormal,
    HalfNormal,
    Normal,
    TwiceNormal,
    FourTimesNormal
}

