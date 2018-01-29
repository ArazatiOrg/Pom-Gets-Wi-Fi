using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTPPlayer : _BaseLogicEvent {
    public Vector2 TeleportPosition;
    public SpriteDir facingDirection = SpriteDir.None;
    bool instantTP = false;
    NPC npc;

    public EventTPPlayer instantTeleport
    {
        get
        {
            instantTP = true;
            return this;
        }
    }

    public static EventTPPlayer c(Vector2 teleportTo, SpriteDir facingDir = SpriteDir.None, NPC npc = NPC.Pom)
    {
        return new EventTPPlayer() { TeleportPosition = teleportTo, facingDirection = facingDir, npc = npc};
    }

    public override IEnumerator Execute()
    {
        var before = Player.playerInstance.AllowMovement;
        var controller = NPCList.GetNPC(npc);

        Player.playerInstance.AllowMovement = false;

        var cameraFader = Camera.main.GetComponentInChildren<CameraFader>();

        if (!instantTP)
        {
            cameraFader.StartFading();

            yield return new WaitUntil(() => cameraFader.finishedFading);
        }

        var telePos = (Vector3)TeleportPosition;

        controller.transform.position = telePos + new Vector3(0f, .5f, 0f);
        Player.playerInstance.StallMovement();
        if (facingDirection != SpriteDir.None) controller.SetFacingDirection(facingDirection);
        Camera.main.SendMessage("UpdateBounds");

        if (!instantTP)
        {
            cameraFader.StartUnfading();

            yield return new WaitUntil(() => cameraFader.finishedFading);
        }

        Player.playerInstance.AllowMovement = before;

        yield return null;
    }

}
