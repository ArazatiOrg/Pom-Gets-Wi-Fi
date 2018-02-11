using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EventBattleAnim : _BaseLogicEvent {
    Target target;
    Anim anim;

    AnimSheet useSheet = AnimSheet.strike;
    
    //TODO: flashes when things take damage?
    
    public static EventBattleAnim c( Target target, Anim anim )
    {
        return new EventBattleAnim() { target = target, anim = anim };
    }
    
        //always add .5f to posY to pixel align

    public override IEnumerator Execute()
    {
        switch (anim)
        {
            case Anim.PunchA:
                {
                    useSheet = AnimSheet.strike;

                    SetSprite(0, 24, -24);
                    PlaySFX(SFX.punch1);
                    //flash 31,16,00,17
                    yield return WaitFrame();

                    SetSprite(1, 24, -24);
                    yield return WaitFrame();

                    SetSprite(2, 24, -24);
                    yield return WaitFrame();

                    SetSprite(3, 24, -24);
                    yield return WaitFrame();

                    SetSprite(3, 24, -24);
                    SetSprite(0, -24, 8);
                    PlaySFX(SFX.punch1);
                    //flash 31,16,00,17
                    yield return WaitFrame();

                    SetSprite(1, -24, 8);
                    yield return WaitFrame();

                    SetSprite(2, -24, 8);
                    yield return WaitFrame();

                    SetSprite(3, -24, 8);
                    yield return WaitFrame();

                    SetSprite(3, -24, 8);
                    SetSprite(0, 24, 40);
                    PlaySFX(SFX.punch1);
                    //flash 31,16,00,17
                    yield return WaitFrame();

                    SetSprite(1, 24, 40);
                    yield return WaitFrame();

                    SetSprite(2, 24, 40);
                    yield return WaitFrame();

                    SetSprite(3, 24, 40);
                    yield return WaitFrame();
                } break;
            case Anim.PunchC:
                {
                    useSheet = AnimSheet.strike;

                    SetSprite(5);
                    PlaySFX(SFX.punch3);
                    yield return WaitFrame();

                    SetSprite(6);
                    yield return WaitFrame();

                    SetSprite(7);
                    //flash 31, 16, 00, 31
                    yield return WaitFrame();

                    SetSprite(8, scale:.8f);
                    yield return WaitFrame();

                    SetSprite(8, scale:1.5f);
                    yield return WaitFrame();

                } break;
            case Anim.IntellectDiminish:
                {
                    useSheet = AnimSheet.lightray;
                    spriteColorOverride = new Color(1f, .176f, 1f);

                    SetSprite(0, -16, 32, 1f, .75f);
                    SetSprite(1, 16, 32, 1f, .75f);
                    PlaySFX(SFX.decrease);
                    yield return WaitFrame();

                    SetSprite(0, -16, 56, 1f, .75f);
                    SetSprite(1, 16, 72, 1f, .75f);
                    SetSprite(2, 0, 8, 1f, .75f);
                    yield return WaitFrame();

                    SetSprite(0, -16, 104, 1f, .75f);
                    SetSprite(1, 16, 112, 1f, .75f);
                    SetSprite(2, 0, 48, 1f, .75f);
                    SetSprite(1, -24, 32, 1f, .75f);
                    SetSprite(0, 40, 16, 1f, .75f);
                    SetSprite(1, 8, 0, 1f, .75f);
                    //flash 15, 05, 15, 31
                    yield return WaitFrame();

                    SetSprite(0, -16, 128, 1f, .75f);
                    SetSprite(1, 16, 168, 1f, .75f);
                    SetSprite(2, 0, 80, 1f, .75f);
                    SetSprite(1, -40, 80, 1f, .75f);
                    SetSprite(0, 40, 112, 1f, .75f);
                    SetSprite(1, 8, 56, 1f, .75f);
                    SetSprite(1, -16, 16, 1f, .75f);
                    //flash 20, 20, 20, 16
                    yield return WaitFrame();

                    SetSprite(0, -16, 184, 1f, .75f);
                    SetSprite(1, -24, 136, 1f, .75f);
                    SetSprite(0, 40, 136, 1f, .75f);
                    SetSprite(2, 0, 128, 1f, .75f);
                    SetSprite(1, 8, 104, 1f, .75f);
                    SetSprite(1, -16, 80, 1f, .75f);
                    SetSprite(0, 0, 16, 1f, .75f);
                    SetSprite(2, 24, 16);
                    //flash 10, 10, 10, 16
                    yield return WaitFrame();

                    SetSprite(0, -48, 24, 1f, .75f);
                    SetSprite(0, 0, 56, 1f, .75f);
                    SetSprite(2, 0, 160, 1f, .75f);
                    SetSprite(1, -24, 152, 1f, .75f);
                    SetSprite(0, 40, 152, 1f, .75f);
                    SetSprite(1, 8, 128, 1f, .75f);
                    SetSprite(1, -16, 104, 1f, .75f);
                    SetSprite(2, 24, 56);
                    //flash 15, 05, 15, 31
                    yield return WaitFrame();

                    SetSprite(0, -48, 64, 1f, .75f);
                    SetSprite(0, 0, 88, 1f, .75f);
                    SetSprite(0, 40, 32, 1f, .75f);
                    SetSprite(2, -8, 8);
                    SetSprite(1, 8, 168, 1f, .75f);
                    SetSprite(1, -16, 136, 1f, .75f);
                    SetSprite(2, 24, 104);
                    yield return WaitFrame();

                    SetSprite(0, -48, 96, 1f, .75f);
                    SetSprite(0, 0, 120, 1f, .75f);
                    SetSprite(0, 40, 72, 1f, .75f);
                    SetSprite(2, -8, 40);
                    SetSprite(1, -32, 16, 1f, .75f);
                    SetSprite(1, 16, 16, 1f, .75f);
                    SetSprite(1, -16, 168, 1f, .75f);
                    SetSprite(2, 24, 120);
                    yield return WaitFrame();

                    SetSprite(0, -48, 120, 1f, .75f);
                    SetSprite(0, 0, 168, 1f, .75f);
                    SetSprite(0, 40, 112, 1f, .75f);
                    SetSprite(2, -8, 80);
                    SetSprite(1, -32, 40, 1f, .75f);
                    SetSprite(1, 16, 40, 1f, .75f);
                    SetSprite(0, 0, 16, 1f, .75f);
                    SetSprite(2, 24, 144);
                    //flash 13, 13, 03, 31
                    yield return WaitFrame();

                    SetSprite(0, -48, 160, 1f, .75f);
                    SetSprite(2, 32, 16);
                    SetSprite(0, 40, 144, 1f, .75f);
                    SetSprite(2, -8, 112);
                    SetSprite(1, -32, 72, 1f, .75f);
                    SetSprite(1, 16, 72, 1f, .75f);
                    SetSprite(0, 0, 48, 1f, .75f);
                    SetSprite(2, -56, 16);
                    //flash 15, 05, 15, 16
                    yield return WaitFrame();

                    SetSprite(0, -24, 24, 1f, .75f);
                    SetSprite(2, 32, 40);
                    SetSprite(1, 40, 24, 1f, .75f);
                    SetSprite(2, -8, 152);
                    SetSprite(1, 32, 120, 1f, .75f);
                    SetSprite(1, 16, 120, 1f, .75f);
                    SetSprite(0, 0, 80, 1f, .75f);
                    SetSprite(2, -56, 48);
                    //flash 00, 00, 00, 16
                    yield return WaitFrame();

                    SetSprite(0, -24, 48, 1f, .75f);
                    SetSprite(2, 32, 64);
                    SetSprite(1, 40, 40, 1f, .75f);
                    SetSprite(2, -48, 8);
                    SetSprite(1, -32, 168, 1f, .75f);
                    SetSprite(1, 16, 168, 1f, .75f);
                    SetSprite(0, 0, 112, 1f, .75f);
                    SetSprite(2, -56, 80);
                    //flash 00, 00, 00, 31
                    yield return WaitFrame();

                    SetSprite(0, -24, 112, 1f, .75f);
                    SetSprite(2, 32, 104);
                    SetSprite(1, 48, 80, 1f, .75f);
                    SetSprite(2, -48, 48);
                    SetSprite(0, 16, 16, 1f, .75f);
                    SetSprite(1, -56, 8, 1f, .75f);
                    SetSprite(0, 0, 168, 1f, .75f);
                    SetSprite(2, -56, 112);
                    //flash 00, 00, 00, 16
                    yield return WaitFrame();

                    SetSprite(0, -24, 168, 1f, .75f);
                    SetSprite(2, 32, 128);
                    SetSprite(1, 48, 104, 1f, .75f);
                    SetSprite(2, -48, 80);
                    SetSprite(0, 16, 56, 1f, .75f);
                    SetSprite(1, -56, 40, 1f, .75f);
                    SetSprite(0, 0, 16, 1f, .75f);
                    SetSprite(2, -56, 128);
                    //flash 15, 15, 15, 15
                    yield return WaitFrame();

                    SetSprite(2, 40, 16);
                    SetSprite(1, -32, 16, 1f, .75f);
                    SetSprite(1, 48, 136, 1f, .75f);
                    SetSprite(2, -48, 120);
                    SetSprite(0, 16, 96, 1f, .75f);
                    SetSprite(1, -56, 72, 1f, .75f);
                    SetSprite(0, 0, 56, 1f, .75f);
                    SetSprite(2, -56, 160);
                    //flash 15, 05, 15, 31
                    yield return WaitFrame();

                    SetSprite(2, 40, 48);
                    SetSprite(1, -32, 40, 1f, .75f);
                    SetSprite(1, 48, 168, 1f, .75f);
                    SetSprite(2, -58, 152);
                    SetSprite(0, 16, 120, 1f, .75f);
                    SetSprite(1, -56, 104, 1f, .75f);
                    SetSprite(0, 0, 104, 1f, .75f);
                    SetSprite(1, 24, 16, 1f, .75f);
                    yield return WaitFrame();

                    SetSprite(2, 40, 80);
                    SetSprite(1, -32, 72, 1f, .75f);
                    SetSprite(0, 16, 160, 1f, .75f);
                    SetSprite(1, -56, 128, 1f, .75f);
                    SetSprite(0, 0, 136, 1f, .75f);
                    SetSprite(1, 24, 48, 1f, .75f);
                    yield return WaitFrame();

                    SetSprite(2, 40, 112);
                    SetSprite(1, -32, 96, 1f, .75f);
                    SetSprite(1, -56, 152, 1f, .75f);
                    SetSprite(1, 24, 64, 1f, .75f);
                    yield return WaitFrame();

                    SetSprite(2, 40, 168);
                    SetSprite(1, -32, 152, 1f, .75f);
                    SetSprite(1, 24, 88, 1f, .75f);
                    yield return WaitFrame();

                    SetSprite(1, 24, 136, 1f, .75f);
                    yield return WaitFrame();
                    
                    spriteColorOverride = Color.white;
                } break;
            case Anim.FireMagicS2:
                {
                    useSheet = AnimSheet.fire1;

                    SetSprite(4, 0, -104);
                    PlaySFX(SFX.fire2);
                    yield return WaitFrame();

                    SetSprite(5, 0, -84);
                    yield return WaitFrame();

                    SetSprite(4, 0, -64);
                    yield return WaitFrame();

                    SetSprite(5, 0, -44);
                    yield return WaitFrame();

                    SetSprite(4, 0, -24);
                    yield return WaitFrame();

                    yield return WaitFrame();

                    yield return WaitFrame();
                    SetSprite(6, 0, -16, 1f, .5f);
                    PlaySFX(SFX.fire3);
                    yield return WaitFrame();

                    SetSprite(7, 0, -16, 1.06f, .65f);
                    yield return WaitFrame();

                    SetSprite(8, 0, -18, 1.112f, .9f);
                    yield return WaitFrame();

                    SetSprite(9, 0, -19, 1.18f);
                    yield return WaitFrame();

                    SetSprite(6, 0, -20, 1.24f);
                    //flash 31, 10, 05, 10
                    yield return WaitFrame();

                    SetSprite(7, 0, -21, 1.29f);
                    //flash 31, 10, 05, 10
                    yield return WaitFrame();

                    SetSprite(8, 0, -22, 1.35f);
                    //flash 31, 10, 05, 10
                    yield return WaitFrame();

                    SetSprite(9, 0, -23, 1.41f);
                    //flash 31, 10, 05, 10
                    yield return WaitFrame();

                    SetSprite(6, 0, -24, 1.47f);
                    //flash 31, 10, 05, 31
                    yield return WaitFrame();

                    SetSprite(7, 0, -24, 1.53f);
                    //flash 31, 10, 05, 31
                    yield return WaitFrame();

                    SetSprite(8, 0, -25, 1.59f);
                    //flash 31, 10, 05, 31
                    yield return WaitFrame();

                    SetSprite(9, 0, -26, 1.65f);
                    //flash 31, 10, 05, 31
                    yield return WaitFrame();

                    SetSprite(6, 0, -27, 1.71f);
                    //flash 31, 10, 05, 20
                    yield return WaitFrame();

                    SetSprite(7, 0, -28, 1.76f, .9f);
                    //flash 31, 10, 05, 10
                    yield return WaitFrame();

                    SetSprite(8, 0, -29, 1.82f, .8f);
                    yield return WaitFrame();

                    SetSprite(9, 0, -30, 1.88f, .7f);
                    yield return WaitFrame();

                    SetSprite(6, 0, -31, 1.94f, .6f);
                    yield return WaitFrame();

                    SetSprite(7, 0, -32, 2f, .5f);
                    yield return WaitFrame();
                } break;
            case Anim.NonElementalS1:
                {
                    useSheet = AnimSheet.explode1;

                    SetSprite(0, 0, 0);
                    yield return WaitFrame();

                    SetSprite(0, 0, 0);
                    yield return WaitFrame();

                    SetSprite(1, 0, 0);
                    yield return WaitFrame();

                    SetSprite(1, 0, 0);
                    yield return WaitFrame();

                    SetSprite(2, 0, 0);
                    yield return WaitFrame();

                    SetSprite(2, 0, 0);
                    SetSprite(3, 0, 0, 1f, .6f);
                    yield return WaitFrame();

                    SetSprite(3, 0, 0, 1f, .8f);
                    PlaySFX(SFX.explode1);
                    //flash 31, 00, 00, 18
                    yield return WaitFrame();

                    SetSprite(3, 0, -8, 1f, .9f);
                    SetSprite(0, 16, 48);
                    yield return WaitFrame();

                    SetSprite(3, 24, 8, 1f, .6f);
                    SetSprite(4, 0, -8, 1f, .9f);
                    //flash 31, 31, 00, 18
                    yield return WaitFrame();

                    SetSprite(3, 24, 8, 1f, .8f);
                    SetSprite(4, 0, -16, 1.5f, .85f);
                    yield return WaitFrame();

                    SetSprite(3, 24, 0, 1f, .8f);
                    SetSprite(5, 0, -16, 1.5f, .9f);
                    //flash 00, 31, 31, 18
                    yield return WaitFrame();

                    SetSprite(4, 20, 0, 1f, .9f);
                    SetSprite(5, 0, -24, 1.5f, .6f);
                    SetSprite(3, -24, 16, 1f, .6f);
                    yield return WaitFrame();

                    SetSprite(4, 24, -8, 1.5f, .9f);
                    SetSprite(3, -24, 16, 1f, .8f);
                    //flash 00, 31, 00, 18
                    yield return WaitFrame();

                    SetSprite(5, 24, -8, 1.5f, .9f);
                    SetSprite(3, -24, 8, 1f, .9f);
                    yield return WaitFrame();

                    SetSprite(5, 24, -16, 1.5f, .6f);
                    SetSprite(4, -24, 8, 1f, .9f);
                    //flash 00, 00, 31, 18
                    yield return WaitFrame();

                    SetSprite(4, -24, 0, 1.5f, .9f);
                    yield return WaitFrame();

                    SetSprite(5, -24, 0, 1.5f, .9f);
                    //flash 31, 00, 31, 18
                    yield return WaitFrame();

                    SetSprite(5, -24, -8, 1.5f, .6f);
                    yield return WaitFrame();
                } break;
            case Anim.StatusHealingA:
                {
                    useSheet = AnimSheet.cure1;

                    SetSprite(0, 0, -16, 1.5f);
                    PlaySFX(SFX.heal4);
                    yield return WaitFrame();

                    SetSprite(0, -8, -88, 1.5f);
                    SetSprite(3, -48, -40);
                    yield return WaitFrame();

                    SetSprite(1, -8, -136, 1.5f);
                    SetSprite(4, -48, -80);
                    yield return WaitFrame();

                    SetSprite(1, -8, -152, 1.5f);
                    SetSprite(4, -48, -104);
                    SetSprite(0, 32, -8);
                    //flash 00, 31, 18, 31
                    yield return WaitFrame();

                    SetSprite(2, -8, -176, 1.5f);
                    SetSprite(5, -18, -128);
                    SetSprite(0, 32, -72);
                    //flash 00, 31, 18, 31
                    yield return WaitFrame();

                    SetSprite(1, 32, -104);
                    SetSprite(3, -40, -8, 1.5f);
                    SetSprite(0, -56, -64);
                    yield return WaitFrame();

                    SetSprite(2, 32, -136);
                    SetSprite(1, -64, -112);
                    SetSprite(3, -40, -40, 1.25f);
                    //flash 00, 31, 18, 31
                    yield return WaitFrame();

                    SetSprite(0, 48, -8);
                    SetSprite(2, -56, -136);
                    SetSprite(4, -40, -72, 1.25f);
                    yield return WaitFrame();

                    SetSprite(5, -40, -136, 1.25f);
                    SetSprite(0, 48, -64);
                    yield return WaitFrame();

                    SetSprite(0, 48, -120);
                    yield return WaitFrame();

                    SetSprite(1, 48, -168);
                    yield return WaitFrame();

                    yield return WaitFrame();

                    SetSprite(0, 0, -16, 1.5f);
                    yield return WaitFrame();

                    SetSprite(0, -8, -88, 1.5f);
                    SetSprite(3, -48, -40);
                    yield return WaitFrame();

                    SetSprite(1, -8, -136, 1.5f);
                    SetSprite(4, -48, -80);
                    yield return WaitFrame();

                    SetSprite(1, -8, -152, 1.5f);
                    SetSprite(4, -48, -104);
                    SetSprite(0, 32, -8);
                    yield return WaitFrame();

                    SetSprite(2, -8, -176, 1.5f);
                    SetSprite(5, -18, -128);
                    SetSprite(0, 32, -72);
                    yield return WaitFrame();

                    SetSprite(1, 32, -104);
                    SetSprite(3, -40, -8, 1.25f);
                    SetSprite(0, -56, -64);
                    yield return WaitFrame();

                    SetSprite(2, 32, -136);
                    SetSprite(1, -64, -112);
                    SetSprite(3, -40, -40, 1.25f);
                    yield return WaitFrame();

                    SetSprite(0, 48, -8);
                    SetSprite(2, -56, -136);
                    SetSprite(4, -40, -72, 1.25f);
                    yield return WaitFrame();

                    SetSprite(5, -40, -136, 1.25f);
                    SetSprite(0, 48, -64);
                    yield return WaitFrame();

                    SetSprite(0, 48, -120);
                    yield return WaitFrame();

                    SetSprite(1, 48, -168);
                    yield return WaitFrame();


                } break;
        }
    }

    IEnumerator WaitFrame()
    {
        yield return new WaitForSecondsRealtime(.0166f);
        ResetSprites();
    }

    void PlaySFX(SFX sfx)
    {
        AudioController.instance.PlaySFX((int)sfx, 1f);
    }

    void SetSprite(int index, int xOffset = 0, int yOffset = 0, float scale = 1f, float opacity = 1f)
    {
        var offset = new Vector2(xOffset/16f, yOffset/16f);
        switch (anim)
        {
            case Anim.IntellectDiminish:
            case Anim.StatusHealingA:
                {
                    var curBattle = BattleController.instance.curBattle;
                    if (Global.s.ShibeInParty > 0 && BattleController.instance.shibeHP > 0)
                        SetSprite(index, offset, BattleController.instance.ShibeSprite.transform.position, scale, opacity);

                    if(curBattle == Battles.Shibe || curBattle == Battles.Hus_and_Shibe || curBattle == Battles.Shibe_final && BattleController.instance.enemy1HP > 0)
                        SetSprite(index, offset, BattleController.instance.Enemy1Sprite.transform.position, scale, opacity);
                } break;
            default:
                //all enemies, or the random ally
                {
                    if(target == Target.Ally)
                    {
                        var rng = BattleController.EventDamage.lastRand;

                        if (Global.s.ShibeInParty == 0) rng = 0;

                        SetSprite(index, offset, rng == 0 ? 
                            BattleController.instance.PomSprite.transform.position :
                            BattleController.instance.ShibeSprite.transform.position, scale, opacity);
                    }
                    else
                    {
                        if(BattleController.instance.enemy1HP > 0) SetSprite(index, offset, BattleController.instance.Enemy1Sprite.transform.position, scale, opacity);
                        if(BattleController.instance.enemy2HP > 0) SetSprite(index, offset, BattleController.instance.Enemy2Sprite.transform.position, scale, opacity);
                    }
                } break;
        }
    }

    Color spriteColorOverride = new Color(1f, 1f, 1f);
    void SetSprite(int index, Vector2 offset, Vector3 target, float scalePercentage, float opacity)
    {
        var sprite = BattleController.instance.battleAnimSlots[BattleController.instance.battleAnimIndex];

        sprite.sprite = BattleController.instance.battleAnims[(int)useSheet].sprites[index];
        sprite.transform.position = new Vector3(target.x + offset.x, target.y - offset.y, sprite.transform.position.z);
        sprite.transform.localScale = new Vector3(16f, 16f, 16f) * scalePercentage;
        sprite.color = new Color(spriteColorOverride.r, spriteColorOverride.g, spriteColorOverride.b, opacity);

        BattleController.instance.battleAnimIndex++;
    }

    void ResetSprites()
    {
        var nullPos = BattleController.instance.battleAnimNullPos;
        for (int i = BattleController.instance.battleAnimIndex - 1; i >= 0; i--)
        {
            BattleController.instance.battleAnimSlots[i].transform.position = nullPos;
        }
        BattleController.instance.battleAnimIndex = 0;
    }
}

public enum Anim
{
    PunchA,
    PunchC,
    IntellectDiminish,
    FireMagicS2,
    NonElementalS1,
    StatusHealingA
}

enum AnimSheet
{
    cure1,
    explode1,
    fire1,
    lightray,
    strike
}