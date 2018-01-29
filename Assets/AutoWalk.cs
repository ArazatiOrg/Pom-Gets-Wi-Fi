using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWalk : MonoBehaviour {
    NPCController controller;

    int index = 0;
    public List<MovePattern> movements = new List<MovePattern>();

    public void ResetIndex() { index = 0; }
    public NPC curNPC = NPC.NONE;

	// Use this for initialization
	void Start () {
        controller = GetComponent<NPCController>();
	}

    List<MovePattern> empty = new List<MovePattern>();
    List<MovePattern> crestPanic = new List<MovePattern>() { MovePattern.MoveLeft, MovePattern.MoveRight };
    List<MovePattern> crestUpstairs = new List<MovePattern>() { MovePattern.MoveRight, MovePattern.MoveUp, MovePattern.NONE, MovePattern.MoveDown, MovePattern.MoveLeft };

    List<MovePattern> puddle0 = new List<MovePattern>() { MovePattern.MoveLeft, MovePattern.LookUp, MovePattern.LookDown, MovePattern.MoveRight };
    List<MovePattern> puddle3 = new List<MovePattern>() { MovePattern.RandomMoveOrLook };
    List<MovePattern> puddle4 = new List<MovePattern>() { MovePattern.MoveRight, MovePattern.NONE, MovePattern.MoveLeft };

    List<MovePattern> spider = new List<MovePattern>() { MovePattern.MoveLeft, MovePattern.MoveRight };

    // Update is called once per frame
    bool doMoveTimeout = true;
    void Update () {
		if(controller.AllowMovement && controller.standingStill && controller.moveTimeout <= 0f && Player.playerInstance.AllowMovement)
        {
            CheckPatterns();

            if (movements.Count == 0) { index = 0; return; }
            if (index >= movements.Count) index = 0;

            var movePattern = movements[index];
            if (movePattern == MovePattern.RandomMoveOrLook) movePattern = (Random.Range(0, 10) < 9 ? MovePattern.RandomMove : MovePattern.RandomLook);

            switch (movePattern)
            {
                case MovePattern.NONE: controller.moveTimeout = 1f / controller.moveSpeed; break;

                case MovePattern.MoveUp:
                case MovePattern.MoveRight:
                case MovePattern.MoveDown:
                case MovePattern.MoveLeft:
                    controller.TryMove((SpriteDir)movements[index], false);
                    if(doMoveTimeout) controller.moveTimeout = 2f / (controller.moveSpeed);
                    break;
                case MovePattern.RandomMove:
                    controller.TryMove((SpriteDir)Random.Range(0, 4), false);
                    if (doMoveTimeout) controller.moveTimeout = 2f / (controller.moveSpeed);
                    break;
                case MovePattern.LookUp:
                case MovePattern.LookRight:
                case MovePattern.LookDown:
                case MovePattern.LookLeft:
                    controller.SetFacingDirection((SpriteDir)(movePattern - 4));
                    controller.moveTimeout = 1f / controller.moveSpeed;
                    index++;
                    break;
                case MovePattern.RandomLook:
                    controller.SetFacingDirection((SpriteDir)Random.Range(0, 4));
                    controller.moveTimeout = 1f / controller.moveSpeed;
                    index++;
                    break;
                case MovePattern.SpeedOneEighthNormal: controller.moveSpeed = 1f; index++; break;
                case MovePattern.SpeedOneFourthNormal: controller.moveSpeed = 2f; index++; break;
                case MovePattern.SpeedHalfNormal: controller.moveSpeed = 4f; index++; break;
                case MovePattern.SpeedNormal: controller.moveSpeed = 8f; index++; break;
                case MovePattern.SpeedTwiceNormal: controller.moveSpeed = 16f; index++; break;
                case MovePattern.SpeedFourTimesNormal: controller.moveSpeed = 64f; index++; break;
            }
            
            if (!controller.standingStill)
            {
                index++;
            }
        }
	}

    void CheckPatterns()
    {
        switch (curNPC)
        {
            case NPC.Crest:
                {
                    var s = Global.s.CrestTalk.value;

                    switch (s)
                    {
                        case 0: case 1: case 2: case 6: case 7: case 8: movements = empty; break;
                        case 3: case 4: case 5: movements = crestPanic; break;
                        case 9: movements = crestUpstairs; break;
                    }
                }
                break;
            case NPC.Puddle:
                {
                    var s = Global.s.PuddleTalk.value;

                    if (s == 0) movements = puddle0;
                    else if (s == 3) movements = puddle3;
                    else if (s == 4) movements = puddle4;
                    else movements = empty;
                }
                break;
            case NPC.Spider:
                {
                    var s = Global.s.CrestTalk.value;

                    if (s == 4) movements = spider;
                    else movements = empty;
                }
                break;
        }
    }

    public enum MovePattern
    {
        NONE = -1,
        MoveUp = 0,
        MoveRight = 1,
        MoveDown = 2,
        MoveLeft = 3,
        LookUp,
        LookRight,
        LookDown,
        LookLeft,
        RandomMove,
        RandomLook,
        RandomMoveOrLook,
        SpeedOneEighthNormal,
        SpeedOneFourthNormal,
        SpeedHalfNormal,
        SpeedNormal,
        SpeedTwiceNormal,
        SpeedFourTimesNormal
    }
}
