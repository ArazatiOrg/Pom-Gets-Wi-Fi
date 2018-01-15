using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibeFollowLogic : MonoBehaviour {
    public static ShibeFollowLogic instance;

    NPCController controller;

	// Use this for initialization
	void Start () {
        controller = this.GetComponent<NPCController>();
        instance = this;
	}

    Vector3 lastPomPos = Vector3.zero;
    SpriteDir lastPomFacing = SpriteDir.Down;
    bool lastStandingStill = false;

	void Update () {
		if(Global.ShibeInParty > 0 && controller.standingStill)
        {
            var distance = Vector2.Distance(transform.position, Player.playerInstance.transform.position);

            if(distance < 5)
            {
                //if (distance > 1f)
                {
                    var dir = controller.DirFromVector(lastPomPos - transform.position);
                    controller.TryMove(dir, false);
                }
            }
            else
            {
                //distance is >= 5 tiles, teleport
                if(!Player.playerInstance.standingStill)
                {
                    controller.SetFacingDirection(lastPomFacing);
                    transform.position = lastPomPos;
                }
            }
        }

        if(Global.ShibeInParty > 0 && (!Player.playerInstance.standingStill || !lastStandingStill))
        {
            var movePercentage = Player.playerInstance.movePercentage;

            if (Player.playerInstance.standingStill) movePercentage = 1f;

            if (movePercentage < 1f)
            {
                var pos = Vector3.Lerp(transform.position, controller.boxCollider.transform.position, movePercentage);

                //snap to the 16 pixel grid
                controller.anim.transform.position = new Vector3(((int)(pos.x * 16) / 16f), ((int)(pos.y * 16) / 16f), controller.anim.transform.position.z);
            }
            else
            {
                movePercentage = 1f;
                transform.position = controller.boxCollider.transform.position;
                controller.boxCollider.transform.localPosition = Vector3.zero;
                controller.anim.transform.localPosition = Vector3.zero;
                controller.standingStill = true;
                controller.stoppedOnTile = true;
            }
        }

        lastPomPos = Player.playerInstance.transform.position;
        lastPomFacing = Player.playerInstance.facingDir;
        lastStandingStill = Player.playerInstance.standingStill;
	}

    public void TeleToPomWithOffset(Vector3 vec)
    {
        controller.ResetMovement();

        controller.transform.position = Player.playerInstance.transform.position + vec;
        controller.SetFacingDirection(Player.playerInstance.facingDir);

        lastPomPos = Player.playerInstance.transform.position;
        lastPomFacing = Player.playerInstance.facingDir;
        lastStandingStill = Player.playerInstance.standingStill;
    }
}
