﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTeleportPlayer : _BaseEvent {
	public Vector2 TeleportPosition;
	public SpriteDir facingDirection = SpriteDir.None;
	public bool teleportRelative = false;

    public Vector2 shibeTeleOffset;

	void OnDrawGizmosSelected ()
	{
		var telePos = TeleportPosition;
		if (teleportRelative) telePos += (Vector2)transform.position;

		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, telePos);
		Gizmos.DrawCube(telePos, Vector3.one);
	}

	public override IEnumerator TriggeredEvent (GameObject triggeredBy)
	{
		Player.playerInstance.AllowMovement = false;

		var cameraFader = Camera.main.GetComponentInChildren<CameraFader>();

        var beforeSpeed = cameraFader.fadeSpeed;
        cameraFader.fadeSpeed = (1f / .4f);
        
		cameraFader.StartFading();

		yield return new WaitUntil(() => cameraFader.finishedFading);

		var telePos = (Vector3)TeleportPosition;
		if (teleportRelative) telePos += transform.position;

		Player.playerInstance.transform.position = telePos + new Vector3 (0f, .5f, 0f);
		Player.playerInstance.StallMovement ();
		if(facingDirection != SpriteDir.None) Player.playerInstance.SetFacingDirection(facingDirection);
		Camera.main.SendMessage ("UpdateBounds");

        if(shibeTeleOffset.magnitude > 0 && Global.s.ShibeInParty > 0)
            ShibeFollowLogic.instance.TeleToPomWithOffset(shibeTeleOffset);

		cameraFader.StartUnfading();

		yield return new WaitUntil(() => cameraFader.finishedFading);

        cameraFader.fadeSpeed = beforeSpeed;

        if(Player.playerInstance.triggerOverride == 0)
		    Player.playerInstance.AllowMovement = true;
	}
}
