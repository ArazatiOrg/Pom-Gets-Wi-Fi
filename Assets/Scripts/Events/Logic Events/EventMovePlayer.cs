using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMovePlayer : _BaseLogicEvent {
    private Vector2 directDir;
    NPC npc = NPC.Pom;
    Speed speed = Speed.Normal;

    public EventMovePlayer(Vector2 directDirection, NPC npc = NPC.Pom)
    {
        directDir = directDirection;
        this.npc = npc;
    }

    public static EventMovePlayer c(Vector2 directDirection, NPC npc = NPC.Pom, Speed speed = Speed.Normal)
    {
        return new EventMovePlayer(directDirection, npc) { speed = speed };
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

        //controller.moveSpeed = (float)speed;
        controller.AllowMovement = true;
        controller.ForceMove(directDir);
        controller.AllowMovement = false;

        yield return new WaitUntil(() => controller.stoppedOnTile);

        controller.moveSpeed = beforeSpeed;
        controller.AllowMovement = before;

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

