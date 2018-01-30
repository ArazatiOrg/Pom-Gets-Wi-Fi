using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPositioner : MonoBehaviour {
    static EventPositioner instance;

    //park
    public GameObject dustBunny;

    public SpriteRenderer stoneBlock;
    public List<Sprite> stoneBlockSprites = new List<Sprite>();
    
    public GameObject lineBlock;
    public GameObject shermanBlock;
    public GameObject closeToSherman;
    public GameObject exitParkTrigger;
    public GameObject parkFinishedTrigger;

    public GameObject noLeaveParkTown;
    public GameObject noLeaveParkObservatory;

    public List<GameObject> crestHouseExits = new List<GameObject>();
    public GameObject crestHouseExitBlocker;

    public NPCController chiController;
    public GameObject spider;

    public GameObject FastFrisbees;
    public GameObject SlowFrisbees;
    public GameObject SuperFrisbee;

    public GameObject FrisbeeTrap;
    public GameObject FrisbeeTrapTrigger;
    public GameObject MachineCheckedTrigger;

    int oldCrestTalk = -1;
    int oldPuddleTalk = -1;
    int oldParkState = -1;
    int oldFrisbeeTrap = -1;

    int oldExtraParty = -1;

    public static Vector3 nullPos = new Vector3(-20, 0, 0);

    void Start () {
        instance = this;
	}

    public static void CheckPositions()
    {
        instance.check();
    }

    void check()
    {
        var s = Global.ActiveSavefile;
        var up = (Vector3)Vector2.up;
        var right = (Vector3)Vector2.right;
        var down = (Vector3)Vector2.down;
        var left = (Vector3)Vector2.left;

        if (s.SharpeiTalk.value == 3) NPCList.GetNPC(NPC.Sharpeii).transform.position = new Vector3(18.5f, -55f);
        else NPCList.GetNPC(NPC.Sharpeii).transform.position = new Vector3(21.5f, -56f);

        if (s.DustBunny == 0) dustBunny.transform.position = new Vector3(63.5f, 56.5f);
        else dustBunny.transform.position = nullPos;
        
        switch (Global.s.StoneBlockSearch)
        {
            case 0: case 1: case 2: case 3: stoneBlock.sprite = stoneBlockSprites[0]; break;
            case 4: case 5: stoneBlock.sprite = stoneBlockSprites[1]; break;
            case 6: stoneBlock.sprite = stoneBlockSprites[2]; break;
            case 7: stoneBlock.sprite = stoneBlockSprites[3]; break;
            case 8: stoneBlock.sprite = stoneBlockSprites[4]; break;
            case 9: stoneBlock.sprite = stoneBlockSprites[5]; break;
        }

        if (s.ParkState == 0) shermanBlock.transform.position = new Vector3(64f, -17.5f);
        else shermanBlock.transform.position = nullPos;

        if (s.ParkState == 0) closeToSherman.transform.position = new Vector3(64f, -16.5f);
        else closeToSherman.transform.position = nullPos;

        if (s.ParkState == 1) exitParkTrigger.transform.position = new Vector3(64f, -17.5f);
        else exitParkTrigger.transform.position = nullPos;

        if (s.ParkState == 1) noLeaveParkTown.transform.position = new Vector3(34.5f, -20f);
        else noLeaveParkTown.transform.position = nullPos;

        if (s.ParkState == 1) noLeaveParkObservatory.transform.position = new Vector3(51f, -25.5f);
        else noLeaveParkObservatory.transform.position = nullPos;

        if (s.ParkState == 2) parkFinishedTrigger.transform.position = new Vector3(64.5f, -17.5f);
        else parkFinishedTrigger.transform.position = nullPos;

        if (s.ParkState == 2) lineBlock.transform.position = nullPos;
        else lineBlock.transform.position = new Vector3(66.5f, -21.5f);

        if (s.ParkState > 0) chiController.ConstantlyWalk = false;
        else chiController.ConstantlyWalk = true;

        if (s.StoneBlockSearch == 3) s.ShibeTalk.value = 6;

        if(s.CrestTalk == 4) { crestHouseExitBlocker.SetActive(true); foreach (var exit in crestHouseExits) { exit.SetActive(false); } }
        else { crestHouseExitBlocker.SetActive(false); foreach (var exit in crestHouseExits) { exit.SetActive(true); } }

        if (s.CrestTalk >= 2 && s.CrestTalk <= 4) spider.SetActive(true);
        if (s.CrestTalk == 5) spider.transform.position = nullPos;
        else if (s.PuddleTalk == 3) spider.SetActive(false);

        var crest = NPCList.GetNPC(NPC.Crest);
        var puddle = NPCList.GetNPC(NPC.Puddle);
        if (s.CrestTalk == 2)
        {
            crest.transform.position = new Vector3(2.5f, -50f);
            puddle.transform.position = nullPos;
        }

        if(oldCrestTalk != s.CrestTalk)
        {
            var defaultPos = new Vector3(-0.5f, -50f);

            switch (s.CrestTalk)
            {
                case 2: crest.transform.position = defaultPos + (right * 3); break;
                case 7: crest.transform.position = defaultPos + (left * 6); break;
                case 8: crest.transform.position = defaultPos + (left * 6) + (up * 2); break;
                case 9: crest.transform.position = defaultPos + (left * 10) + (up * 9); break;
            }

            oldCrestTalk = s.CrestTalk;
        }

        if (oldPuddleTalk != s.PuddleTalk)
        {
            var defaultPos = new Vector3(-10.5f, -41f);

            switch (s.PuddleTalk)
            {
                case 0: case 4: puddle.transform.position = defaultPos; break;
                case 2: puddle.transform.position = defaultPos + (down * 12) + (left * 1); puddle.SetFacingDirection(SpriteDir.Up); break;
                case 3: puddle.transform.position = defaultPos + (down * 11) + (left * 1); break;
                case 5: puddle.transform.position = new Vector3(-0.5f, -50f); break;
            }

            oldPuddleTalk = s.PuddleTalk;
        }

        if(oldParkState != s.ParkState)
        {
            FastFrisbees.SetActive(s.ParkState == 0 || s.ParkState == 1);
            SlowFrisbees.SetActive(s.ParkState == 2);

            if (oldParkState != 2 && s.ParkState == 2)
            {
                NPCList.GetNPC(NPC.Goldie).transform.position = nullPos;
                NPCList.GetNPC(NPC.Labra).transform.position = nullPos;
                NPCList.GetNPC(NPC.Sherman).transform.position = nullPos;
                NPCList.GetNPC(NPC.Chi).transform.position = nullPos;
                NPCList.GetNPC(NPC.Alma).transform.position = new Vector2(44.5f, -4.5f);
            }

            oldParkState = s.ParkState;
        }

        if(oldFrisbeeTrap != s.FrisbeeTrap)
        {
            SuperFrisbee.SetActive(s.FrisbeeTrap == 1);
            FrisbeeTrap.SetActive(s.FrisbeeTrap == 1);
            FrisbeeTrapTrigger.SetActive(s.FrisbeeTrap <= 1);

            oldFrisbeeTrap = s.FrisbeeTrap;
        }

        MachineCheckedTrigger.SetActive(Global.s.MachineChecked < 1 && Global.s.ParkState == 1);

        if(oldExtraParty != 2 && s.ExtraParkPartyMember == 2)
        {
            oldExtraParty = 2;

            var hus = NPCList.GetNPC(NPC.Hus);
            var chi = NPCList.GetNPC(NPC.Chi);

            var oldHusPos = hus.transform.position;
            var oldHusLook = hus.facingDir;

            hus.transform.position = chi.transform.position;
            hus.SetFacingDirection(SpriteDir.Up);

            chi.transform.position = oldHusPos;
            chi.SetFacingDirection(oldHusLook);
        }
    }
}
