using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMovePlayer : _BaseLogicEvent {
    private Vector2 directDir;

    public EventMovePlayer(Vector2 directDirection)
    {
        directDir = directDirection;
    }

    public static EventMovePlayer c(Vector2 directDirection)
    {
        return new EventMovePlayer(directDirection);
    }

    public override IEnumerator Execute()
    {
        var before = Player.playerInstance.AllowMovement;
        
        Player.playerInstance.AllowMovement = true;
        Player.playerInstance.ForceMove(directDir);
        Player.playerInstance.AllowMovement = false;

        yield return new WaitUntil(() =>  Player.playerInstance.stoppedOnTile);
        
        Player.playerInstance.AllowMovement = before;

        yield return null;
    }

}
