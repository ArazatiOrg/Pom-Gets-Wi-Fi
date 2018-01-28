using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPositioner : MonoBehaviour {
    static EventPositioner instance;

    public GameObject dustBunny;

    public SpriteRenderer stoneBlock;
    public List<Sprite> stoneBlockSprites = new List<Sprite>();

    public GameObject lineBlock;

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
        var nullPos = new Vector3(-20, 0, 0);

        if (s.SharpeiTalk.value == 3) NPCList.GetNPC(NPC.Sharpeii).transform.position = new Vector3(18.5f, -55f);
        else NPCList.GetNPC(NPC.Sharpeii).transform.position = new Vector3(21.5f, -56f);

        if (s.DustBunny == 0) dustBunny.transform.position = new Vector3(63f, 56f);
        else dustBunny.transform.position = nullPos;
        
        switch (Global.s.StoneBlockSearch)
        {
            case 0: case 3: stoneBlock.sprite = stoneBlockSprites[0]; break;
            case 4: case 5: stoneBlock.sprite = stoneBlockSprites[1]; break;
            case 6: stoneBlock.sprite = stoneBlockSprites[2]; break;
            case 7: stoneBlock.sprite = stoneBlockSprites[3]; break;
            case 8: stoneBlock.sprite = stoneBlockSprites[4]; break;
            case 9: stoneBlock.sprite = stoneBlockSprites[5]; break;
        }

        if (s.ParkFixed == 1) lineBlock.transform.position = nullPos;
        else lineBlock.transform.position = new Vector3(66, -22);
    }
}
