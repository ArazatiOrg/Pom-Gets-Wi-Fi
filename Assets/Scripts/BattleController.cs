using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {
    public static BattleController instance;

    public Image bgImage;

    public GameObject bottomPanel;
        public Image pomSelected;
        public Image pomFillBar; //25 max, so  width = (percentage * 25f)
        public Text pomHPText;
        public Text pomStatusText;
        public Text pomAttacksText;
        public GameObject shibePanel;
            public Image shibeSelected;
            public Image shibeFillBar; //25 max, so  width = (percentage * 25f)
            public Text shibeHPText;
            public Text shibeStatusText;
            public Text shibeAttacksText;

    public Image attackSelected;

    public GameObject damageCollection;
    public GameObject damageNumPrefab;

    public Image PomSprite;
    public Image ShibeSprite;
    public Image Enemy1Sprite;
    public Image Enemy2Sprite;

    public Sprite fillingBarSprite;
    public Sprite fullBarSprite;

    public List<Sprite> enemySprites = new List<Sprite>();
    enum EnemySprites
    {
        Bernard,
        Dog,
        Hus,
        Papi,
        Puddle,
        CryingShibe,
        Shibe,
        York
    }

    public List<Sprite> heroSprites = new List<Sprite>();

    //List<string> shibeAttacks;
    
    //miss sfx plays at the same time as the start of an attack
    //attack number bounces up slightly before falling back down and dissapearing (more research)
    //attack numbers have 2 text elements. Red behind and offset by 1,1 downright
    //attack happens at same time as attack start

    //bars stop progressing when choosing an attack
    //but the bars keep going if it's just waiting for the player to start attacking

    public Battles curBattle = Battles.None;

    public List<Sprite> battleImages = new List<Sprite>();
    enum BattleBGs
    {
        sky,
        sharpeisHouse,
        Final
    }

    int pomHP = 100;
    int pomMaxHP = 100;

    int shibeHP = 0;
    int enemy1HP = 0;
    int enemy2HP = 0;

    float pomCharge = 0f;
    float shibeCharge = 0f;
    float enemy1Charge = 0f;
    float enemy2Charge = 0f;

    float animTimer = 0f;
    float animSpeed = 5f;

    bool enemiesDiedYet = false;

	void Start () {
        instance = this;
	}

    GameObject oldFocus;
    Guid guid;

    public void InitBattle(Battles battle)
    {
        enemiesDiedYet = false;

        chargingUp.value = 0;
        battleTrigger.value = (int)BattleStates.StartBattle;
        pomTurn.value = 0;
        animTimer = 0f;
        
        Taunt.value = 0;
        YoMamaJoke.value = 0;
        //shibeAttack.value = 0;
        enemy1Turn.value = -1;
        enemy2Turn.value = -1;

        hidInitTextbox = false;
        curBattle = battle;

        pomCharge = 0f;
        shibeCharge = 0f;
        enemy1Charge = 0f;
        enemy2Charge = -.5f;

        pomMaxHP = 100;
        shibeHP = 0;
        enemy2HP = 0;

        oldFocus = KeepCameraInBounds.instance.objectToFollow;
        KeepCameraInBounds.instance.objectToFollow = bgImage.gameObject;

        enemy1HP = 100;
        pomHP = Global.s.PlayerSprite.value == (int)PlayerSprite.OnFire ? 999 : 100;
        if (Global.s.ShibeInParty == 1) shibeHP = 100;

        var song = BGM.field4;

        switch (battle)
        {
            case Battles.Shibe:
                enemy1HP = 80;
                bgImage.sprite = battleImages[(int)BattleBGs.sky];
                Enemy1Sprite.sprite = enemySprites[(int)EnemySprites.Shibe];
                guid = new Guid("2d22a536-343a-4910-a780-bf24656916c7");
                break;
            case Battles.Puddle:
                bgImage.sprite = battleImages[(int)BattleBGs.sky];
                Enemy1Sprite.sprite = enemySprites[(int)EnemySprites.Puddle];
                guid = new Guid("2f18fef2-3ba5-4a18-b384-f096754bc8ce");
                break;
            case Battles.Bernard:
                enemy1HP = 90;
                bgImage.sprite = battleImages[(int)BattleBGs.sky];
                Enemy1Sprite.sprite = enemySprites[(int)EnemySprites.Bernard];
                guid = new Guid("b1ecd61a-be10-4c29-b597-af72660aec37");
                break;
            case Battles.Hus_and_Shibe:
                enemy1HP = 80; //shibe
                enemy2HP = 100; //hus
                bgImage.sprite = battleImages[(int)BattleBGs.sky];
                Enemy1Sprite.sprite = enemySprites[(int)EnemySprites.Hus];
                guid = new Guid("20244fa8-22c7-409f-ae4a-f13e8a315c9a");
                break;
            case Battles.York:
                enemy1HP = 15; //poor weak bab :(
                bgImage.sprite = battleImages[(int)BattleBGs.sharpeisHouse];
                Enemy1Sprite.sprite = enemySprites[(int)EnemySprites.York];
                guid = new Guid("afc7f890-5609-42c9-815e-e6d083816532");
                break;
            case Battles.Dog:
                song = BGM.mystery3;
                enemy1HP = 4995;
                pomMaxHP = 999;
                bgImage.sprite = battleImages[(int)BattleBGs.Final];
                Enemy1Sprite.sprite = enemySprites[(int)EnemySprites.Dog];
                guid = new Guid("f3f9bf44-4dab-42ac-99f2-abeeb497dceb");
                break;
            case Battles.Shibe_final:
                song = BGM.EricSkiff_UnderStars;
                pomMaxHP = 999;
                bgImage.sprite = battleImages[(int)BattleBGs.Final];
                Enemy1Sprite.sprite = enemySprites[(int)EnemySprites.CryingShibe];
                guid = new Guid("5d814f08-7eaa-4c77-9ef6-e28e0e523108");
                break;
            default:
                Debug.LogError("UNKNOWN BATTLE - " + battle);
                battle = Battles.None;
                guid = Guid.Empty;
                break;
        }

        pomHP = pomMaxHP;

        //I moved this into the actual translation files, to line up the timing better
        //AudioController.instance.PlayBGM((int)song, .4f);

        if (EventPage.eventPages.ContainsKey(guid)) eventPages = EventPage.eventPages[guid];

        if(eventPages == null)
        {
            Debug.LogError("Object's events never registered.", gameObject);
        }

        UpdateVisuals(true);
        bottomPanel.SetActive(false);
    }

    public void StartBattle()
    {
        SetTextPosition(TextPos.Top);
        //TextEngine.instance.InitializeNewSlidein(Faces.None, "Battle WIP", true, 0f);
        battleTrigger.value = (int)BattleStates.StartBattle;

        StartCoroutine(StartBattleCoroutine());
    }

    public void FinishedBattle()
    {
        SetTextPosition(TextPos.Default);
        KeepCameraInBounds.instance.objectToFollow = oldFocus;
    }

    string lowHP = "<color=#F7E76B>"; //25% or less
    string zeroHP = "<color=#E27A8B>";
    string endCol = "</color>";
    void UpdateVisuals(bool init = false)
    {
        var shibeInParty = Global.ActiveSavefile.ShibeInParty.value == 1;

        if (init)
        {
            shibeAttacksText.text = "";

            shibePanel.SetActive(shibeInParty);

            pomStatusText.text = "Normal";
            shibeStatusText.text = "Normal";

            pomHPText.text = pomHP.ToString();
            shibeHPText.text = shibeHP.ToString();

            pomFillBar.sprite = fillingBarSprite;
            shibeFillBar.sprite = fillingBarSprite;
            
            attackSelected.enabled = false;
            pomSelected.enabled = false;
            shibeSelected.enabled = false;

            ShibeSprite.enabled = shibeInParty;
            Enemy2Sprite.enabled = (enemy2HP > 0);

            pomFillBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pomCharge * 25f);
            shibeFillBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, shibeCharge * 25f);
        }
        
        PomHPChangedCheck();
        ShibeHPChangedCheck();

        animTimer += Time.smoothDeltaTime * animSpeed;

        if(animTimer >= 1f)
        {
            animTimer -= 1f;
            animStateUp = !animStateUp;
            
            if (pomDmgTimer <= 0f)
            {
                var fireModifier = (Global.ActiveSavefile.PlayerSprite.value == (int)PlayerSprite.OnFire ? 0 : 4);

                if (pomHP > 0)
                {
                    PomSprite.sprite = heroSprites[(animStateUp ? 1 : 0) + fireModifier];
                }
                else
                {
                    PomSprite.sprite = heroSprites[(animStateUp ? 1 : 0) + fireModifier + 2];
                }
            }
            else
            {
                PomSprite.sprite = heroSprites[2];
                pomDmgTimer -= Time.smoothDeltaTime;
            }

            if (shibeDmgTimer <= 0f)
            {
                if (shibeHP > 0)
                {
                    ShibeSprite.sprite = heroSprites[(animStateUp ? 1 : 0) + 8];
                }
                else
                {
                    ShibeSprite.sprite = heroSprites[11];
                }
            }
            else
            {
                shibeDmgTimer -= Time.smoothDeltaTime;
                ShibeSprite.sprite = heroSprites[10];
            }
        }
    }

    float pomDmgTimer = 0f;
    float shibeDmgTimer = 0f;
    bool animStateUp = true;

    int pomOldHP = -1;
    int shibeOldHP = -1;
    void PomHPChangedCheck()
    {
        if(pomOldHP == pomHP) return;

        pomOldHP = pomHP;

        if (pomHP <= 0)
        {
            pomStatusText.text = zeroHP + "Death" + endCol;
            pomHPText.text = zeroHP + "0" + endCol;
        }
        else if ((pomHP / (float)pomMaxHP) <= .25f) { pomHPText.text = lowHP + pomHP + endCol; }
        else { pomHPText.text = pomHP.ToString(); }
    }

    void ShibeHPChangedCheck()
    {
        if (shibeOldHP == shibeHP) return;

        shibeOldHP = shibeHP;

        if (shibeHP <= 0)
        {
            shibeStatusText.text = zeroHP + "Death" + endCol;
            shibeHPText.text = zeroHP + "0" + endCol;
        }
        else if ((shibeHP / 100f) <= .25f) { shibeHPText.text = lowHP + shibeHP + endCol; }
        else { shibeHPText.text = shibeHP.ToString(); }
    }

    enum TextPos
    {
        Default = 0,
        Top = 161,
        VeryTop = 209
    }
    void SetTextPosition(TextPos pos)
    {
        var localPos = TextEngine.instance.transform.parent.localPosition;
        TextEngine.instance.transform.parent.localPosition = new Vector3(localPos.x, ((int)pos)/16f, localPos.z);
    }

    bool hidInitTextbox = false;

    public static Global.GlobalInt chargingUp = new Global.GlobalInt(1);
    public static Global.GlobalInt battleTrigger = new Global.GlobalInt(0);
    public static Global.GlobalInt pomTurn = new Global.GlobalInt(0);

    public static Global.GlobalInt Taunt = new Global.GlobalInt(0);
    public static Global.GlobalInt YoMamaJoke = new Global.GlobalInt(0);
    public static Global.GlobalInt enemy1Turn = new Global.GlobalInt(-1);
    public static Global.GlobalInt enemy2Turn = new Global.GlobalInt(-1);

    IEnumerator StartBattleCoroutine()
    {
        chargingUp.value = 0;
        
        yield return TriggeredEvent();

        bottomPanel.SetActive(true);
        chargingUp.value = 1;
    }

    public void Damage(Attacker target, int damage)
    {
        //TODO: damage fx and stuff and things
        Debug.Log("Dealing " + damage + " damage to " + target + ".");

        Vector3 pos = Vector2.zero;
        switch (target)
        {
            case Attacker.Pom:
                pomHP -= damage;
                pos = PomSprite.transform.position;
                break;
            case Attacker.Shibe:
                shibeHP -= damage;
                pos = ShibeSprite.transform.position;
                break;
            case Attacker.Enemy1:
                enemy1HP -= damage;
                pos = Enemy1Sprite.transform.position;
                break;
            case Attacker.Enemy2:
                enemy2HP -= damage;
                pos = Enemy2Sprite.transform.position;
                break;
        }

        var shiftAmount = 4/16f;
        pos += new Vector3(UnityEngine.Random.Range(-shiftAmount, shiftAmount), UnityEngine.Random.Range(-shiftAmount, shiftAmount));

        var obj = Instantiate(damageNumPrefab, pos, Quaternion.identity, damageCollection.transform).GetComponent<FallingNumber>();
        obj.InitText(damage > 0 ? damage.ToString() : "lmao");
    }

    void Trigger(BattleStates state)
    {
        battleTrigger.value = (int)state;
        StartCoroutine(TriggeredEvent());
    }
    List<EventPage> eventPages;
    public IEnumerator TriggeredEvent()
    {
        if (eventPages != null)
        {
            chargingUp.value = 0;
            var eventPage = eventPages[Global.ActiveLanguage.value];

            if (eventPage == null)
            {
                Debug.LogError("Object does not have an event page for active language " + Global.ActiveLanguage + "!", gameObject);
            }
            else
            {
                for (int i = 0; i < eventPage.events.Count; i++)
                {
                    yield return eventPage.events[i].Execute();
                }
            }
            
            chargingUp.value = 1;
        }
        else
        {
            Debug.LogError("Object's events never registered.", gameObject);
        }
    }

    float pomChargeSpeed = 1f / 2f; //2 seconds to charge
    float shibeChargeSpeed = 1f / 17f; //17 seconds to charge
    float enemyChargeSpeed = 1f / 7f; //7 seconds to charge
    List<Attacker> attackers = new List<Attacker>();
    void Update () {
        if (curBattle == Battles.None) return;
        
        if(chargingUp.value == 0)
        {
            UpdateVisuals();
            return;
        }
        
        if (pomCharge < 1f && pomHP > 0)
        {
            if (pomCharge == 0f) pomFillBar.sprite = fillingBarSprite;

            pomCharge += Time.smoothDeltaTime * pomChargeSpeed;

            pomFillBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pomCharge * 25f);

            if (pomCharge >= 1f)
            {
                pomFillBar.sprite = fullBarSprite;
                pomCharge = 1f;

                attackers.Add(Attacker.Pom);

                if(attackers.Count == 1)
                {
                    Taunt.value = UnityEngine.Random.Range(0, curBattle == Battles.Puddle ? 5 : 8);
                    YoMamaJoke.value = UnityEngine.Random.Range(0, 13);

                    attackSelected.enabled = true;
                    pomSelected.enabled = true;
                }
            }
        }
        if (shibeCharge < 1f && Global.s.ShibeInParty == 1 && shibeHP > 0)
        {
            if (pomCharge == 0f) shibeFillBar.sprite = fillingBarSprite;

            shibeCharge += Time.smoothDeltaTime * shibeChargeSpeed;

            shibeFillBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, shibeCharge * 25f);

            if (shibeCharge >= 1f)
            {
                shibeFillBar.sprite = fullBarSprite;
                shibeCharge = 1f;

                attackers.Add(Attacker.Shibe);

                if (attackers.Count == 1)
                {
                    attackSelected.enabled = true;
                    shibeSelected.enabled = true;
                }
            }
        }
        if (enemy1Charge < 1f && enemy1HP > 0)
        {
            enemy1Charge += Time.smoothDeltaTime * enemyChargeSpeed;

            if(enemy1Charge >= 1f)
            {
                enemy1Charge -= 1f;
                enemy1Turn.value++;
                Trigger(BattleStates.Enemy1Attack);
            }
        }
        if (enemy2Charge < 1f && enemy2HP > 0)
        {
            enemy2Charge += Time.smoothDeltaTime * enemyChargeSpeed;

            if (enemy2Charge >= 1f)
            {
                enemy2Charge -= 1f;
                enemy2Turn.value++;
                Trigger(BattleStates.Enemy2Attack);
            }
        }
        
        if(attackers.Count > 0)
        {
            var attacker = attackers[0];
            
            if (InputController.JustPressed(Action.Confirm))
            {
                AudioController.instance.PlaySFX((int)SFX.Choice, 1f);

                chargingUp.value = 0;
                attackSelected.enabled = false;
                pomSelected.enabled = false;
                shibeSelected.enabled = false;

                if(attacker == Attacker.Pom)
                {
                    pomCharge -= 1f;
                    pomTurn.value++;
                    Trigger(BattleStates.PomAttack);
                }
                else
                {
                    shibeCharge -= 1f;
                    Trigger(BattleStates.ShibeAttack);
                }

                attackers.RemoveAt(0);

                if(attackers.Count > 0)
                {
                    if(attackers[0] == Attacker.Pom)
                    {
                        attackSelected.enabled = true;
                        pomSelected.enabled = true;
                    }
                    else
                    {
                        attackSelected.enabled = true;
                        shibeSelected.enabled = true;
                    }
                }
            }
        }

        if(enemy1HP <= 0 && enemy2HP <= 0)
        {
            if(!enemiesDiedYet)
            {
                enemiesDiedYet = true;

                Trigger(BattleStates.EnemyAboutToDie);

                if (chargingUp.value == 1)
                    curBattle = Battles.None;
            }
            else
            {
                curBattle = Battles.None;
            }
        }

        UpdateVisuals();
    }

    public class EventEndBattle : _BaseLogicEvent
    {
        public static EventEndBattle c
        {
            get { return new EventEndBattle(); }
        }

        public override IEnumerator Execute()
        {
            instance.curBattle = Battles.None;
            yield return null;
        }
    }

    public class EventDamage : _BaseLogicEvent
    {
        Target target;
        DamageType damageType;
        float damage;

        public static EventDamage c(Target target, int damage)
        {
            return new EventDamage() { target = target, damageType = DamageType.Normal, damage = damage };
        }

        public static EventDamage c(Target target, float damagePercentage)
        {
            return new EventDamage() { target = target, damageType = DamageType.Percentage, damage = damagePercentage };
        }

        public override IEnumerator Execute()
        {
            if(damageType == DamageType.Percentage)
            {
                if (target == Target.Ally)
                {
                    if (instance.pomHP > 0) instance.Damage(Attacker.Pom, (int)(instance.pomHP * damage));
                    if (instance.shibeHP > 0) instance.Damage(Attacker.Shibe, (int)(instance.shibeHP * damage));
                }
                else
                {
                    if (instance.enemy1HP > 0) instance.Damage(Attacker.Enemy1, (int)(instance.enemy1HP * damage));
                    if (instance.enemy2HP > 0) instance.Damage(Attacker.Enemy2, (int)(instance.enemy2HP * damage));
                }
            }
            else
            {
                if(target == Target.Ally)
                {
                    if (instance.pomHP > 0) instance.Damage(Attacker.Pom, (int)damage);
                    if (instance.shibeHP > 0) instance.Damage(Attacker.Shibe, (int)damage);
                }
                else
                {
                    if (instance.enemy1HP > 0) instance.Damage(Attacker.Enemy1, (int)damage);
                    if (instance.enemy2HP > 0) instance.Damage(Attacker.Enemy2, (int)damage);
                }
            }

            yield return null;
        }
    }
}

public enum Target
{
    Ally,
    Enemy
}

public enum DamageType
{
    Normal,
    Percentage
}

public enum BattleStates
{
    StartBattle,
    PomAttack,
    ShibeAttack,
    Enemy1Attack,
    Enemy2Attack,
    EnemyAboutToDie,
    NONE
}
public enum Attacker
{
    Pom,
    Shibe,
    Enemy1,
    Enemy2
}

/* Monster Group - Shibe
    Shibe Status: Not in party .. obviously..
    
    Trigger - Start Battle
	    Shibe: Wh-what's this?
	    Shibe: Pom, you're kind of scaring me...

    Trigger - [Pom] has taken [1] turns
	    Shibe: You're hurting me!
	
    Trigger - [Pom] has taken [3] turns
	    Shibe: There's no need to get violent!
	
    Trigger - [Pom] has taken [5] turns
	    Shibe: Fighting is bad!

    Trigger - [Pom] uses the [Attack] command
	    Show Choices: Taunt/Tell a "yo mama" joke
		    [Taunt] Handler
		    {
			    Global [Taunt] set Rnd 1-8
			
			    if 1 - Pom: no one likes u
	            if 2 - Pom: senpai will never notice u		   //this is originally 6, but puddle doesn't have a weiner so changing it to 2 makes me not have to change anything around 
			    if 3 - Pom: a rock has more of a life
						    than u do
			    if 4 - Pom: ur so ugly that hello kitty said
						    goodbye 2 u
			    if 5 - Pom: everyone who ever loved u was
						    wrong
			    if 6 - Pom: ur wiener is so small that the vet
						    couldnt tell whether u were neutered
						    or not
			    if 7 - Pom: no one will ever want 2 go out
						    with u
			    if 8 - Pom: is ur ass jealous of the amount of
						    shit that just came out of ur mouth
						
			    ShowBattleAnim - Punch A, All Enemies
			    Change Monster HP: remove 20% of remaining health
			    end event processing
		    }
		    [Tell a "yo mama" joke] Handler
		    {
			    Global [Yo Mama] set Rnd 1-13
			
			    if 01 - Pom: yo mama so fat
						    -when she went to the beach
						    -all da whales came up and sang
						     "we r family"
			    if 02 - Pom: yo mama so fat
						    -even dora couldnt explore her
			    if 03 - Pom: yo mama so ugly
						    -her pillow cries at night
			    if 04 - Pom: yo mama so ugly
						    -when she went 2 da haunted house
						     she came out with a job application
			    if 05 - Pom: yo mama so ugly
						    -if she were a scarecrow
						     the corn would run away
			    if 06 - Pom: yo mama's teeth so yellow
						    -i can't believe it's not butter!
			    if 07 - Pom: yo mama so fat
						    -when she jumped in the air
						     she got stuck
			    if 08 - Pom: yo mama so fat
						    -when she wears yellow clothes
						     people yell "taxi"
			    if 09 - Pom: yo mama so fat
						    -when she sat on an iphone
						     it turned into an ipad
			    if 10 - Pom: yo mama so fat
						    -the shadow of her butt weighs
						     100 pounds
			    if 11 - Pom: yo mama so stupid
						    -she threw a rock at the ground
						     and missed
			    if 12 - Pom: yo mama so stupid
						    -she climbed over a glass wall
						     to see what was on the other
						     side
			    if 13 - Pom: yo mama so stupid
						    -she stole free bread
			
			    ShowBattleAnim - Punch A, All Enemies
			    Change Monster HP: remove 10 hp
			    end event processing
		    }
*/

/* Monster Group - Puddle
    Shibe Status: In Party
    
    Attacks: (50%) Charge Up / (50%) Attack

    Trigger - Start Battle
        N/A

    Trigger - [Pom] uses the [Attack] command
	    Show Choices: Taunt/Tell a "yo mama" joke
		    [Taunt] Handler
		    {
			    Global [Taunt] set Rnd 1-5 instead of 1-8
                Same as Shibe otherwise.
		    }
		    [Tell a "yo mama" joke] Handler
		    {
                same as shibe
            }

    Trigger - [Shibe] uses the [Apologize] command
        Message: Shibe apologized profusely!
        ShowBattleAnim - Healing A, Puddle (Waiting Event)
        Message: Puddle looks more fired up than ever!
    
    Trigger - [Shibe] uses the [Puppy Eyes] command
        Message: Shibe used Puppy Dog Eyes!
        Message: It had no effect on Puddle...

    Trigger - [Shibe] uses the [Play Dead] command
        Message: Shibe played dead!
        Message: It had no effect on Puddle...
*/

/* Monster Group - Bernard
Shibe Status: In Party

Attacks: Attack

Trigger - Start Battle
    N/A

Trigger - [Pom] uses the [Attack] command
    Show Choices: Taunt/Tell a "yo mama" joke
        [Taunt] Handler
        {
            same as shibe
        }
        [Tell a "yo mama" joke] Handler
        {
            same as shibe
        }

Trigger - [Shibe] uses the [Sit] command
    Message: It had no effect on Bernard...

Trigger - [Shibe] uses the [Stay] command
    Message: Shibe stayed!
    Message: It had no effect on Bernard...

Trigger - [Shibe] uses the [Roll Over] command
    Message: Shibe rolled over!
    ShowBattleAnim - Intellect Diminish, Shibe Ally (Waiting Event)
    Message: Shibe became more vulnerable to the
             enemy!

Trigger - [Shibe] uses the [Dig] command
    Message: Shibe dug an important hole!
    Message: Not just any hole!

Trigger - [Bernard]'s HP <= 0
    Bernard: Guh! You're a monster!
    SFX - Pom Bark
    Pom: take back what u said
    Pom: shibe doesnt have a thing 4 crest
    Bernard: Okay, okay! He doesn't!
    SFX - Pom Bark
    Pom: now say "i ship hus/shibe"
    SFX - Medium Dog 1
    Shibe: Wha?!
    SFX - Pom Bark
    Pom: say it
    Bernard: I...ship Hus/Shibe!
    Bernard: Are you happy now?
    Message: Bernard ran away while sobbing!
    Global [BernardTalk] set 5
    END BATTLE
*/

/* Monster Group - Hus and Shibe
Shibe Status: Again, nope, obviously.

Attacks: Attack (Only Hus)

Trigger - Start Battle
    Global [Stop Pom] set 2
    SFX - Medium Dog 1
    Shibe: Wait, you two!
    Shibe: Don't fight!
    SFX - Pom Bark
    Pom: no fukkin way
    Pom: u 2 r going down
    SFX - Medium Dog 1
    Hus: Sorry, Shibe.
    Hus: Looks like I have no choice.

Trigger - [Pom] uses the [Attack] command
    Global [Stop Pom] set 2

    Show Choices: Taunt/Tell a "yo mama" joke
        [Taunt] Handler
        {
            same as shibe
        }
        [Tell a "yo mama" joke] Handler
        {
            same as shibe
        }
        
Trigger - [Shibe] Turns Elapsed [1]
    Message: Shibe dug an important hole!
    Message: Not just any hole!

Trigger - [Shibe] Turns Elapsed [3]
    Message: Shibe used Puppy Dog Eyes!
    Message: It had no effect on Pom...
    Hus: ...
    SFX - Medium Dog 1
    Hus: Shibe, stop that!
    SFX - Medium Dog 1
    Shibe: H-huh?
    SFX - Medium Dog 1
    Hus: It's distracting!
    SFX - Medium Dog 1
    Shibe: O-okay!

Trigger - [Shibe] Turns Elapsed [4]
    Message: Shibe rolled over!
    ShowBattleAnim - Intellect Diminish, Shibe Ally (Waiting Event)
    Message: Shibe became more vulnerable to the
             enemy!
*/

/* Monster Group - York
Shibe Status: Nope

Trigger - [Pom] uses the [Attack] command
    Pom: suck
    Pom: on
    Pom: my
    Pom: misSILE PUNCH!!!
    ShowBattleAnim - Non-elemental S 1, All Enemies (Wait)
    ChangeMonsterHP: -100
    York: Gnnrk...!
    END BATTLE
*/

/* Monster Group - Dog
Shibe Status: Nope

Trigger - [Pom] uses the [Attack] command
    switch([Incinerate])
        0: Pom: im in da zone
           Pom: autozone
        1: Pom: kawoshin? no. more like kawobunga.
           Pom: surf's up shinji kun
        2: Pom: [weird edgeworth noises]
        3: Pom: I fukkin cant believe the 12th doctor
                is mitt romney
        4: Pom: sorry but i think we should break up
           Pom: it's not you it's-a-me mario
    
    ShowBattleAnim - Fire Magic S 2, All Enemies (Wait)
    ChangeMonsterHP: -999
    Global [Incinerate] += 1

Trigger - [Dog] Turns Elapsed [All]
    Message: You cannot grasp the true form of Dog's attack!
    FlashScreen (31,31,31,31) .5f (Wait)
    SFX - Flash1
    ShowBattleAnim - Punch C, Pom
    ChangePlayerHP: -100
*/

/* Monster Group - Shibe Final
Shibe Status: Nope

Trigger - Start Battle
     Global [ShibeTurns] set 0
     Shibe: Pom, listen to me!
     SFX - Medium Dog 1
     Shibe: There's got to be a better way than this!

Trigger - [Pom] uses the [Attack] command
    Pom: goodbye shibe
    Global [Bad End] set 1
    ShowBattleAnim - Fire Magic S 2, All Enemies (Wait)
    ChangeMonsterHP: -9999

Trigger - [Shibe] Turns Elapsed [All]
    Global [ShibeTurns] += 1;
    switch([ShibeTurns])
         1: SFX - Medium Dog 1
            Shibe: I know wi-fi is important to you!
            Shibe: But it doesn't have to be this way!
         2: Pom: u dont understand
            Pom: i need wi-fi like i need air
         3: Pom: i dont need anything else
            Pom: the internet is the essence of my
                 entire existance
         4: Shibe: You don't have to be like this!
         5: SFX - Medium Dog 1
            Shibe: You're Dog!
            Shibe: You have the power to do anything right now!
            Shibe: Literally anything!
         6: Shibe: There are so many things that only you can do!
         7: Shibe: Just think about it!
            Shibe: You can make the frisbee machine so
                   that it never breaks!
            Shibe: You can erase every spider in the
                   world!
            Shibe: You can eliminate violence and
                   fighting!
            Shibe: You can make it so that dogs like
                   Bernard can't creep on others!
         8: Shibe: You can fix so many things that are
                   wrong here...
            Shibe: If you'll just get up and actually make
                   an effort to change them!
            Shibe: If you don't do it, no one will!
            Shibe: No one else can!
            Shibe: ...
         9: Shibe: Please don't just sit here surfing the
                   web while the world falls apart around
                   you...
        10: Pom: but thats all i know how 2 do
            Pom: all i know how 2 do is sit in front of
                 a computer
        11: Pom: it's 2 late
            Pom: i've never done anything useful in my
                 entire life
        12: Shibe: It's never too late to start!
            SFX - Medium Dog 1
            Shibe: Not for this, not for anything!
        13: Shibe: You can't change your past, but you can change your future!
        14: Shibe: And if we keep looking, I'm sure we'll
                   find another way to get wi-fi!
            Shibe: We'll figure something out!
        15: Shibe: So please...
            Shibe: Don't give everything up!
            Shibe: You need to save the world right now!
        16: Shibe: I believe in you, Pom!
            Shibe: You can do it!
            Shibe: You don't need to be afraid of
                   anything!
        17: Shibe: I know it's hard, and but...please...
            Shibe: Do something...
            Message: Shibe is cryign really hard.
            Pom: .............
            WAIT 2s
            Switch([Bad End])
                -do attack automatically
            
            Fade out BGM 5s
            END BATTLE
*/

//Anims Used: Punch A, Healing A, Intellect Diminish, Non-elemental S 1, Fire Magic S 2, Punch C