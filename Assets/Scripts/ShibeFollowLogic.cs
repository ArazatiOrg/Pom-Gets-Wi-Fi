using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibeFollowLogic : MonoBehaviour {
    public static ShibeFollowLogic instance;
    public NPC Character = NPC.Shibe;

    NPCController controller;

	// Use this for initialization
	void Start () {
        controller = this.GetComponent<NPCController>();
        instance = this;
	}

    Vector3 lastTargetPos = Vector3.zero;
    SpriteDir lastTargetFacing = SpriteDir.Down;
    bool lastStandingStill = false;

    void Update () {
        NPCController follower = null;
        if (Global.s.ExtraParkPartyMember == 1) follower = NPCList.GetNPC(NPC.Hus);
        else if (Global.s.ExtraParkPartyMember == 2) follower = NPCList.GetNPC(NPC.Chi);

        var distance = Vector2.Distance(transform.position, Player.playerInstance.transform.position);
        if (Global.s.ShibeInParty > 0 && Global.s.ShibeAbleToFollow > 0 && controller.standingStill)
        {
            if(distance < 5)
            {
                var beforeFacing = controller.facingDir;
                var dir = controller.DirFromVector(lastTargetPos - transform.position);
                controller.TryMove(dir, false);

                if (controller.standingStill || Player.playerInstance.standingStill) controller.SetFacingDirection(beforeFacing);
                else if (follower != null && !controller.standingStill)
                {
                    var followerDir = transform.position - follower.transform.position;

                    if (followerDir.magnitude < 5)
                    {
                        follower.SetFacingDirection(follower.DirFromVector(followerDir));
                        follower.ForceMove(followerDir);
                    }
                    else
                    {
                        follower.transform.position = transform.position;
                    }
                }
            }
            else
            {
                //distance is >= 5 tiles, teleport
                if(!Player.playerInstance.standingStill)
                {
                    controller.SetFacingDirection(lastTargetFacing);
                    transform.position = lastTargetPos;
                    if (follower != null) follower.transform.position = transform.position;
                }
            }
        }

        if(Global.s.ShibeInParty > 0 && Global.s.ShibeAbleToFollow > 0 && (!Player.playerInstance.standingStill || !lastStandingStill) && distance <= 2.1f)
        {
            var movePercentage = Player.playerInstance.movePercentage;
            
            if (movePercentage < 1f)
            {
                var pos = Vector3.Lerp(transform.position, controller.boxCollider.transform.position, movePercentage);

                //snap to the 16 pixel grid
                controller.anim.transform.position = new Vector3(((int)(pos.x * 16) / 16f), ((int)(pos.y * 16) / 16f), controller.anim.transform.position.z);

                if (follower != null)
                {
                    var followerPos = Vector3.Lerp(follower.transform.position, follower.boxCollider.transform.position, movePercentage);
                    follower.anim.transform.position = new Vector3(((int)(followerPos.x * 16) / 16f), ((int)(followerPos.y * 16) / 16f), follower.anim.transform.position.z);
                }
            }
            else
            {
                movePercentage = 1f;
                transform.position = controller.boxCollider.transform.position;
                controller.boxCollider.transform.localPosition = Vector3.zero;
                controller.anim.transform.localPosition = Vector3.zero;
                controller.standingStill = true;
                controller.stoppedOnTile = true;

                if (follower != null)
                {
                    movePercentage = 1f;
                    follower.transform.position = follower.boxCollider.transform.position;
                    follower.boxCollider.transform.localPosition = Vector3.zero;
                    follower.anim.transform.localPosition = Vector3.zero;
                    follower.standingStill = true;
                    follower.stoppedOnTile = true;
                }
            }
        }

        Debug.DrawLine(lastTargetPos, lastTargetPos + Vector3.up + Vector3.right);
        lastTargetPos = Player.playerInstance.transform.position;
        lastTargetFacing = Player.playerInstance.facingDir;
        lastStandingStill = Player.playerInstance.standingStill;
	}

    public void TeleToPomWithOffset(Vector3 vec)
    {
        controller.ResetMovement();

        controller.transform.position = Player.playerInstance.transform.position + vec;
        controller.SetFacingDirection(Player.playerInstance.facingDir);

        lastTargetPos = Player.playerInstance.transform.position;
        lastTargetFacing = Player.playerInstance.facingDir;
        lastStandingStill = Player.playerInstance.standingStill;
    }
}
