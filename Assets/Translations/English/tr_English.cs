using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tr_English : _BaseTR
{
	void Start () {
        TranslationName = "English";
        TranslationCredits = ""; //Your name and anyone who helped you here!

        PomName = "Pom";
        ShibeName = "Shibe";
        AlmaName = "Alma";
        BernardName = "Bernard";
        BoldName = "Bold";
        ChiName = "Chi";
        CorgName = "Corg";
        CrestName = "Crest";
        DavePointerName = "Dave Pointer";
        DogName = "Dog";
        GlishName = "Glish";
        GoldieName = "Goldie";
        HusName = "Hus";
        LabraName = "Labra";
        MaltaName = "Malta";
        PapiName = "Papi";
        PuddleName = "Puddle";
        SharpeiiName = "Sharpei";
        ShermanName = "Sherman";
        UgName = "Ug";
        WittyFidoName = "Witty Fido";
        YorkName = "York";

        //the following variables have to be configured in the Global object in the scene editor
        //Font - the font used by text in this translation

        langRegisterCode = EventPage.RegisterTranslation(this);

        //uncomment the next line out if you want to automatically test your new events when running the game
        //Global.ActiveLanguage = langRegisterCode;
    }

    public override void Initialize()
    {
        base.Initialize();
        var curLang = Global.ActiveLanguage.value;
        Global.ActiveLanguage.value = langRegisterCode;
        EventPage tempEP;
        var allowWalkEP = new EventPage(); allowWalkEP.Add(EventPlayerMoveable.c(true));

        //I'll try to keep this as well documented as I can, feel free to send me (Arazati) messages if you need any help or clarifications on anything :)

        //Some quick notes first of all;
        //-Each line can have 50 characters across, so count if you think you're using long lines, or test them ingame
        //-You can't use " inside of a string. Instead, you have to use two of ' so it's '',
        //      it gets automatically turned into a " in the textboxes so that's only one character

        #region Intro

        //This is actually the longest event chain in the game, so it's a bit more complicated than most.
        //For the most part, each event page is done in order, with 4 potential sub events on 1, 2, and 3, which lets the player choose one of 4 websites.

        NewEP("67B10BC2-FCEF-4722-B7D7-B8BCB24B3F70");
        {
            var introIs0 = new EventPage();
            var introIs1 = new EventPage();
            var introIs2 = new EventPage();
            var introIs3 = new EventPage();
            var introIs4 = new EventPage();

            e = EventPageSwitch.c(Global.s.Intro). AddEventPage(0, introIs0). AddEventPage(1, introIs1). AddEventPage(2, introIs2). AddEventPage(3, introIs3). AddEventPage(4, introIs4);
            
            ep = introIs0;
            {
                e = EventPlayerMoveable.c(false);
                e = EventBGM.c(BGM.village2, .4f);
                e = EventSFX.c(SFX.Pom_bark);
                e = EventTextbox.c(Faces.Pom_no_laptop, @"the sun is shining");
                e = EventTextboxClearText.c;
                e = EventWait.c(.3f);
                e = EventTextbox.c(Faces.Pom_no_laptop, @"the birds are singing");
                e = EventTextboxClearText.c;
                e = EventWait.c(.3f);
                e = EventTextbox.c(Faces.Pom_no_laptop, @"it looks like the perfect day...");
                e = EventTextboxClose.c;
                e = EventChangeSprite.c(PlayerSprite.PillowAndLaptop);
                e = EventFlashScreen.c(.2f);
                e = EventWait.c(1f);
                e = EventSFX.c(SFX.Pom_bark);
                e = EventTextbox.c(Faces.Pom, @"...to spend on the internet");
                e = EventTextboxClose.c;
                e = EventSetGlobal.c(Global.s.Intro, 1);
                e = EventPlayerMoveable.c(true);
            }

            #region Websites
            var facewoof = new EventPage();
            var reddig = new EventPage();
            var gTail = new EventPage();
            var tumfur = new EventPage();

            var choice = EventTextboxChoice.c.
                    AddChoice("Facewoof", facewoof, Global.s.Intro_Facewoof).
                    AddChoice("Reddig", reddig, Global.s.Intro_Reddig).
                    AddChoice("gTail", gTail, Global.s.Intro_gTail).
                    AddChoice("Tumfur", tumfur, Global.s.Intro_Tumfur);

            //Facewoof events
            ep = facewoof;
            {
                e = EventSetBackground.c(Background.Facewoof);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextbox.c(Faces.Pom, @"god
                                                stop posting pictures of ur fukkin food");
                e = EventTextbox.c(Faces.Pom, @"and showing off how much fun ur
                                                having without me");
                e = EventTextbox.c(Faces.Pom, @"no one wants to see ur pugly duck
                                                face either");
                e = EventTextbox.c(Faces.Pom, @"jfc");
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextbox.c(Faces.Pom, @"hey looks like my top pomeranians fb
                                                group has some new members");
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextbox.c(Faces.Pom, @"r u fucking kidding me");
                e = EventTextbox.c(Faces.Pom, @"these r all humans showing off
                                                their doges...");
                e = EventTextbox.c(Faces.Pom, @"plus some weird girl pretending
                                                to be a doge on the internet");
                e = EventTextbox.c(Faces.Pom, @"r u srsly telling me im the only legit
                                                pom pom doge on this website");
                e = EventTextbox.c(Faces.Pom, @"furget this");
                e = EventTextbox.c(Faces.Pom, @"i dont want to live on this planet
                                                anymore");
                e = EventTextbox.c(Faces.Pom, @"flies into the sun");
                e = EventSetBackground.c(Background.None);
                e = EventSetGlobal.c(Global.s.Intro_Facewoof, true);
            }

            //Reddig events
            ep = reddig;
            {
                e = EventSetBackground.c(Background.Reddig);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextbox.c(Faces.Pom, @"??????!!!!!!!");
                e = EventSFX.c(SFX.Pom_bark);
                e = EventTextbox.c(Faces.Pom, @"JESSUSUSUS CHSIRTS");
                e = EventTextbox.c(Faces.Pom, @"the mythbarkers r doing an AMA");
                e = EventTextbox.c(Faces.Pom, @"this is terrieriffic
                                                nows my chance to ask them all my 
                                                burning questions");
                e = EventTextbox.c(Faces.Pom, @"hhhhhhhhhhhhhhhhhhhhh");
                e = EventTextbox.c(Faces.Pom, @"all my comments will probably b
                                                buried tho");
                e = EventTextbox.c(Faces.Pom, @"lies down");
                e = EventSetBackground.c(Background.None);
                e = EventSetGlobal.c(Global.s.Intro_Reddig, true);
            }

            //gTail events
            ep = gTail;
            {
                e = EventSetBackground.c(Background.gTail);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextbox.c(Faces.Pom, @"lets see what i have here");
                e = EventTextbox.c(Faces.Pom, @"''Pom, it's not too late to apply!''
                                                ''Pom, picture yourself at Berkeley''");
                e = EventSFX.c(SFX.Pom_bark);
                e = EventTextbox.c(Faces.Pom, @"IM A FUKKIN POMERANIAN");
                e = EventTextbox.c(Faces.Pom, @"WTH DO U GUYS WANT FROM ME");
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextbox.c(Faces.Pom, @"hey its my SAT question of the day");
                e = EventTextbox.c(Faces.Pom, @"delete");
                e = EventTextbox.c(Faces.Pom, @"still not sure why i signed up for that");
                e = EventSetBackground.c(Background.None);
                e = EventSetGlobal.c(Global.s.Intro_gTail, true);
            }

            //Tumfur events
            ep = tumfur;
            {
                e = EventSetBackground.c(Background.Tumfur);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextbox.c(Faces.Pom, @"wow this fanart is amaze");
                e = EventTextbox.c(Faces.Pom, @"bless this drawing");
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextbox.c(Faces.Pom, @"wh");
                e = EventSFX.c(SFX.Pom_bark);
                e = EventTextbox.c(Faces.Pom, @"the arTIST IS FOURTEEN");
                e = EventTextbox.c(Faces.Pom, @"WHY THIS");
                e = EventTextbox.c(Faces.Pom, @"SO TALENT");
                e = EventTextbox.c(Faces.Pom, @"THIS ISNT POSSIBLE");
                e = EventTextbox.c(Faces.Pom, @"LEAPS INTO AN ACTIVE VOLCANO");
                e = EventSetBackground.c(Background.None);
                e = EventSetGlobal.c(Global.s.Intro_Tumfur, true);
            }

            #endregion
            
            ep = introIs1;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"now what should i check first");
                e = EventTextbox.c(Faces.Pom, @"first world problems");
                e = choice;
                e = EventTextboxClose.c;
                e = EventSetGlobal.c(Global.s.Intro, 2);
                e = EventPlayerMoveable.c(true);
            }
            
            ep = introIs2;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"next up is...");
                e = choice;
                e = EventSetBackground.c(Background.IntroNight);
                e = EventTextboxClose.c;
                e = EventSetGlobal.c(Global.s.Intro, 3);
                e = EventPlayerMoveable.c(true);
            }
            
            ep = introIs3;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"next...");
                e = choice;
                e = EventBGM.c(BGM.burning, .6f);
                e = EventSetBackground.c(Background.IntroFire1);
                e = EventTextboxClose.c;
                e = EventSetGlobal.c(Global.s.Intro, 4);
                e = EventPlayerMoveable.c(true);
            }

            ep = introIs4;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"finally, I need to check...");
                e = EventSFX.c(SFX.Shibe_barking);
                //  \C[1]  is a color code for blue, \C[0] is for white.
                // This is the first time a name has to show up for no face. Otherwise it's automated. :)
                e = EventTextbox.c(Faces.None, @"\C[1]Voice\C[0]
                                YEEOWCH!");
                e = EventTextbox.c(Faces.None, @"\C[1]Voice\C[0]
                                F-f-fire! Fire!!!");
                e = EventTextbox.c(Faces.None, @"\C[1]Voice\C[0]
                                Master, wake up!");
                e = EventTextbox.c(Faces.None, @"\C[1]Voice\C[0]
                                You have to get out of here!");
                e = EventSFX.c(SFX.Shibe_barking);
                e = EventTextbox.c(Faces.None, @"\C[1]Voice\C[0]
                                Come on! This way!");
                e = EventSFX.c(SFX.Pom_bark);
                e = EventTextbox.c(Faces.Pom, @"wtf!!");
                e = EventTextbox.c(Faces.Pom, @"that fukkin shiba inu is so noisy");
                e = EventSFX.c(SFX.Shibe_barking);
                e = EventTextbox.c(Faces.None, @"\C[1]Shibe\C[0]
                                Huh? Pom, you're still in here?");
                e = EventTextbox.c(Faces.None, @"\C[1]Shibe\C[0]
                                We have to go!
                                Master is already waiting
                                outside!");
                e = EventTextbox.c(Faces.Pom, @"I SWEAR TO DOG");
                e = EventTextbox.c(Faces.Pom, @"IF YOU DONT SHADDUP IMMA
                                                FUKKIN KNOCK THE WALL DOWN");
                e = EventSFX.c(SFX.Pom_bark);
                e = EventTextbox.c(Faces.Pom, @"YA HEAR ME, SHIBE??");
                e = EventSFX.c(SFX.Shibe_barking);
                e = EventSFX.c(SFX.bump1);
                e = EventSFX.c(SFX.bump1);
                e = EventTextbox.c(Faces.None, @"\C[1]Shibe\C[0]
                                Pom, listen to me! Open your
                                door and run for it!");
                e = EventSFX.c(SFX.Pom_bark);
                e = EventTextbox.c(Faces.Pom, @"GO AWAY!!!!!!!!!!!");
                e = EventTextbox.c(Faces.None, @"\C[1]Shibe\C[0]
                                No! I'm not leaving without you!");
                e = EventSetBackground.c(Background.IntroFire2);
                e = EventTextbox.c(Faces.None, @"\C[1]Shibe\C[0]
                                Hurry! Th-th-the ceiling here
                                looks like it's about to collapse!");
                e = EventTextbox.c(Faces.None, @"\C[1]Shibe\C[0]
                                AIIEEEEEE!!!");
                e = EventTextboxClose.c;
                e = EventSFX.c(SFX.fire8);
                e = EventSFX.c(SFX.earth08);
                e = EventWait.c(3.3f);
                e = EventTextbox.c(Faces.Pom, @"finally that dum shibe shut up");
                e = EventTextbox.c(Faces.Pom, @"is it just me or is it hella hot in here");
                e = EventTextbox.c(Faces.Pom, @"our owner should turn up the air 
                                                conditioning");
                e = EventSFX.c(SFX.Pom_bark);
                e = EventTextbox.c(Faces.Pom, @"HEY OWNER!!");
                e = EventTextbox.c(Faces.Pom, @"AIR CONDITIONING!!!");
                e = EventSetBackground.c(Background.IntroFire3);
                e = EventTextboxClose.c;
                e = EventWait.c(1.5f);
                e = EventTextbox.c(Faces.Pom, @"*koffing*");
                e = EventTextbox.c(Faces.Pom, @"*wheezing*");
                e = EventTextboxClose.c;
                e = EventFlashScreen.c(2.5f);
                e = EventPixelize.c;
                e = EventFlashScreen.c(0f, Color.black);
                e = EventWait.c(2f);
                e = EventBGM.c(BGM.eternal);
                e = EventSetGlobal.c(Global.s.Intro, 6);
                e = EventChangeSprite.c(PlayerSprite.Normal);
                e = EventTPPlayer.c(new Vector2(-69.5f, -21.5f)).instantTeleport;
                e = EventFlashScreen.c(0f, new Color(0f, 0f, 0f, 0f));
                e = EventUnPixelize.c;
                e = EventWait.c(2f);

                e = EventTextbox.c(Faces.Pom, @"huh");
                e = EventTextbox.c(Faces.Pom, @"this is much better");
                e = EventSetWebsiteSelector.c;
                // i'm sorry for this mess.. only one of these will trigger based on what the player -didn't- select before
                {
                    var tumfurLeft = new EventPage();
                    var reddigLeft = new EventPage();
                    var gTailLeft = new EventPage();
                    var facewoofLeft = new EventPage();

                    tumfurLeft.Add(EventTextbox.c(Faces.Pom,   @"now i can finally finish my daily
                                                                 rounds and check tumfur..."));
                    reddigLeft.Add(EventTextbox.c(Faces.Pom,   @"now i can finally finish my daily
                                                                 rounds and check reddig..."));
                    gTailLeft.Add(EventTextbox.c(Faces.Pom,    @"now i can finally finish my daily
                                                                 rounds and check gTail..."));
                    facewoofLeft.Add(EventTextbox.c(Faces.Pom, @"now i can finally finish my daily
                                                                 rounds and check facewoof..."));

                    e = EventPageSwitch.c(Global.s.Intro_LastWebsiteSelector).AddEventPage(0, facewoofLeft).AddEventPage(1, reddigLeft).AddEventPage(2, gTailLeft).AddEventPage(3, tumfurLeft);
                }

                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextbox.c(Faces.Pom, @"EH????????");
                e = EventSFX.c(SFX.Pom_bark);
                e = EventShake.c(.4f);
                e = EventTextbox.c(Faces.Pom, @"THERES NO WI-FI");
                e = EventTextbox.c(Faces.Pom, @"JUST KILL ME NOW");
                e = EventTextbox.c(Faces.Pom, @"WAT DID I EVER DO 2 DESERVE
                                                THIS");
                e = EventTextbox.c(Faces.Pom, @"I;M CRY");
                e = EventTextbox.c(Faces.Pom, @"GROSS SOBBING");
                e = EventTextbox.c(Faces.Pom, @"sniff");
                e = EventTextbox.c(Faces.Pom, @"sniff");
                e = EventTextbox.c(Faces.Pom, @"sniff");
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextbox.c(Faces.Pom, @"nows not the time 2 b wallowing
                                                in self pity");
                e = EventTextbox.c(Faces.Pom, @"i gotta get up and do something 
                                                about this!!");
                e = EventTextbox.c(Faces.Pom, @"ye a");
                e = EventTextbox.c(Faces.Pom, @"!!!");
                e = EventTextbox.c(Faces.Pom, @"inspire");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }
        #endregion
        
        #region Field

        //Talking to shibe when you first enter the field
        NewEP("5c0579a0-63db-4383-a307-188f4a0f6645");
        {
            tempEP = new EventPage(); e = EventPageSwitch.c(Global.s.ShibeIntro).AddEventPage(1, tempEP); ep = tempEP;
            e = EventPlayerMoveable.c(false);
            e = EventSetGlobal.c(Global.s.IntroGround, 1);
            e = EventSetGlobal.c(Global.s.ShibeIntro, 3);
            e = EventSetGlobal.c(Global.s.ShibeTalk, 1);
            e = EventSFX.c(SFX.Medium_Dog1);
            e = EventTextbox.c(Faces.Shibe, @"Pom!");
            e = EventTextbox.c(Faces.Pom, @"poopy head!");
            e = EventTextbox.c(Faces.Shibe, @"I'm glad you didn't get hurt in
                                              the fire!!");
            e = EventTextbox.c(Faces.Shibe, @"Do you know where we are?");
            e = EventTextbox.c(Faces.Shibe, @"I was waiting outside your room
                                              when--");
            e = EventTextbox.c(Faces.Pom, @"uh eXCUSE U???????");
            e = EventTextbox.c(Faces.Pom, @"i AM hurt");
            e = EventTextbox.c(Faces.Pom, @"in da KOKORO!!!!");
            e = EventTextbox.c(Faces.Shibe_uh, @"Huh?");
            e = EventTextbox.c(Faces.Pom, @"now help me look for wi-fi");
            e = EventTextbox.c(Faces.Shibe_uh, @"What? But...");
            e = EventTextbox.c(Faces.Shibe_uh, @"Isn't it more important that we
                                                 figure out how to get home first?");
            e = EventTextbox.c(Faces.Shibe, @"We can worry about the wi-fi
                                              later.");
            e = EventTextbox.c(Faces.Pom, @"what the fuk did u just fukkin say 2
                                            me u lil bitch");
            e = EventTextbox.c(Faces.Pom, @"ur fukkin ded kiddo");
            e = EventTextboxClose.c;
            e = EventBattle.c(Battles.Shibe);
            e = EventSetGlobal.c(Global.s.FlowerField, 1);
            e = EventTextbox.c(Faces.Pom, @"ok shibe");
            e = EventTextbox.c(Faces.Pom, @"from now on ur my manservant");
            e = EventTextbox.c(Faces.Pom, @"i can talk 2 u whenever i want by
                                            facing u and pressing da z key");
            e = EventTextbox.c(Faces.Pom, @"also ive changed ur name 2
                                            sebastian");
            e = EventTextbox.c(Faces.Shibe_annoyed, @"Why the hell am I ''Sebastian''?!");
            e = EventTextbox.c(Faces.None, @"Shibe has joined the party!").DontSlide;
            e = EventSetGlobal.c(Global.s.ShibeInParty, 1);
            e = EventTextboxClose.c;
            e = EventPlayerMoveable.c(true);
        }

        //cherry blossom trees
        NewEP("ba0b6a84-07ed-46da-b0d6-a4b541c0b52f");
        {
            var shibeInParty = new EventPage();
            var shibeNotInparty = new EventPage();
            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(1, shibeInParty).AddEventPage(1, shibeNotInparty, SwitchComparator.NotEqual);

            ep = shibeNotInparty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeInParty;
            {
                var silentTreatment = new EventPage();
                var notSilentTreatment = new EventPage();
                e = EventPageSwitch.c(Global.s.Silent_Treatment).AddEventPage(0, silentTreatment, SwitchComparator.NotEqual)
                                                              .AddEventPage(0, notSilentTreatment);

                ep = silentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"hey shibe");
                    e = EventTextbox.c(Faces.Shibe_uh, @"...");
                    e = EventTextbox.c(Faces.Pom, @"...");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = notSilentTreatment;
                {
                    var cherryBlossomsSeen = new EventPage();
                    var cherryBlossomsNotSeen = new EventPage();
                    e = EventPageSwitch.c(Global.s.Cherry_Blossoms).AddEventPage(0, cherryBlossomsNotSeen)
                                                                 .AddEventPage(0, cherryBlossomsSeen, SwitchComparator.NotEqual);

                    ep = cherryBlossomsNotSeen;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.Pom, @"perfect these r cherry blossoms");
                        e = EventTextbox.c(Faces.Pom, @"shibe stand over here");
                        e = EventTextbox.c(Faces.Shibe_uh, @"Huh?");
                        e = EventTextbox.c(Faces.Pom, @"say ''a new year a new start''");
                        e = EventTextbox.c(Faces.Pom, @"''i hope senpai notices me''");
                        e = EventTextbox.c(Faces.Shibe_uh, @"A new year, a ne-");
                        e = EventSFX.c(SFX.Pom_bark);
                        e = EventTextbox.c(Faces.Pom, @"NO ur doin it wrong");
                        e = EventTextbox.c(Faces.Pom, @"''a new year a new start''");
                        e = EventTextbox.c(Faces.Pom, @"not ''A new year, a new start.''");
                        e = EventTextbox.c(Faces.Pom, @"try 2 say it in comic sans too");
                        e = EventTextbox.c(Faces.Shibe_annoyed, @"I have no idea what you're trying to
                                                                  tell me!");
                        e = EventSetGlobal.c(Global.s.Cherry_Blossoms, 1);
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }

                    ep = cherryBlossomsSeen;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.Pom, @"what kind of shibe r u");
                        e = EventTextbox.c(Faces.Pom, @"cant even speak in comic sans");
                        e = EventTextbox.c(Faces.Shibe_annoyed, @"I still don't get what I did wrong!");
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }
                }
            }
        }


        #endregion

        #region Flower Field Town

        // Big White Rose
        NewEP("F9794751-D80A-41DA-9888-83E57059A4F1");
        {
            {
                var shibeInParty = new EventPage();
                var shibeNotInparty = new EventPage();
                e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(1, shibeInParty).AddEventPage(1, shibeNotInparty, SwitchComparator.NotEqual);

                ep = shibeNotInparty;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"...");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = shibeInParty;
                {
                    var silentTreatment = new EventPage();
                    var notSilentTreatment = new EventPage();
                    e = EventPageSwitch.c(Global.s.Silent_Treatment).AddEventPage(0, silentTreatment, SwitchComparator.NotEqual)
                                                                  .AddEventPage(0, notSilentTreatment);

                    ep = silentTreatment;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.Pom, @"hey shibe");
                        e = EventTextbox.c(Faces.Shibe_uh, @"...");
                        e = EventTextbox.c(Faces.Pom, @"...");
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }

                    ep = notSilentTreatment;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.Shibe, @"This flower is so tall");
                        e = EventTextbox.c(Faces.Pom, @"If normal roses r Kuroko then
                                            this one is Kagami");
                        e = EventTextbox.c(Faces.Shibe_uh, @"...Sometimes I really can't understand
                                                 what you're saying.");
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }
                }
            }
        }

        // Big Black/Purple Rose
        NewEP("95b58f5e-4227-4d69-97e6-f005ce41f5d4");
        {
            {
                {
                    var shibeInParty = new EventPage();
                    var shibeNotInparty = new EventPage();
                    e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(1, shibeInParty).AddEventPage(1, shibeNotInparty, SwitchComparator.NotEqual);

                    ep = shibeNotInparty;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.Pom, @"...");
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }

                    ep = shibeInParty;
                    {
                        var silentTreatment = new EventPage();
                        var notSilentTreatment = new EventPage();
                        e = EventPageSwitch.c(Global.s.Silent_Treatment).AddEventPage(0, silentTreatment, SwitchComparator.NotEqual)
                                                                      .AddEventPage(0, notSilentTreatment);

                        ep = silentTreatment;
                        {
                            e = EventPlayerMoveable.c(false);
                            e = EventTextbox.c(Faces.Pom, @"hey shibe");
                            e = EventTextbox.c(Faces.Shibe_uh, @"...");
                            e = EventTextbox.c(Faces.Pom, @"...");
                            e = EventTextboxClose.c;
                            e = EventPlayerMoveable.c(true);
                        }

                        ep = notSilentTreatment;
                        {
                            e = EventPlayerMoveable.c(false);
                            e = EventTextbox.c(Faces.Pom, @"wouldnt it have been funny if garry
                                            had to carry around a rose this big");
                            e = EventTextbox.c(Faces.Shibe_annoyed, @"Who the heck is ''Garry''?!");
                            e = EventTextboxClose.c;
                            e = EventPlayerMoveable.c(true);
                        }
                    }
                }
            }
        }

        //Crest and Puddle's House teleport door.
        NewEP("393fae68-8399-49bd-9973-37a04aff48ec");
        {
            var crestStalkFest0 = new EventPage();
            var crestStalkFest1to8 = new EventPage();
            var crestStalkFest9plus = new EventPage();
            
            e = EventPageSwitch.c(Global.s.CrestStalkFest).AddEventPage(0, crestStalkFest0).
                                                           AddEventPage(8, crestStalkFest1to8, SwitchComparator.LessOrEqual).
                                                           AddEventPage(9, crestStalkFest9plus, SwitchComparator.GreaterOrEqual);

            ep = crestStalkFest0;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTPPlayer.c(new Vector2(-10.5f, -53.5f), SpriteDir.Up);
                e = EventPlayerMoveable.c(true);
            }

            ep = crestStalkFest1to8;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe_uh, @"It's locked.");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = crestStalkFest9plus;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"it's locked");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }

        #endregion

        #region Sharpei's House

        //Funyarinpa
        NewEP("6dd2fb8b-a541-408f-be90-b2f204358c6a");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeInParty;
            {
                var silentTreatment = new EventPage();
                var notSilentTreatment = new EventPage();

                e = EventPageSwitch.c(Global.s.Silent_Treatment).AddEventPage(0, notSilentTreatment).AddEventPage(1, silentTreatment);

                ep = silentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"hey shibe");
                    e = EventTextbox.c(Faces.Shibe_uh, @"...");
                    e = EventTextbox.c(Faces.Pom, @"...");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = notSilentTreatment;
                {
                    var notSeenFunyarinpa = new EventPage();
                    var seenFunyarinpa = new EventPage();

                    e = EventPageSwitch.c(Global.s.Funyarinpa).AddEventPage(0, notSeenFunyarinpa).AddEventPage(1, seenFunyarinpa);

                    ep = notSeenFunyarinpa;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventSetBackground.c(Background.Funyarinpa);
                        e = EventWait.c(1f);
                        e = EventTextbox.c(Faces.Shibe_uh, @"What's this picture supposed to be?");
                        e = EventTextbox.c(Faces.Pom, @"looks like kawoshin fanart");
                        e = EventTextbox.c(Faces.Shibe_uh, @"Huh?");
                        e = EventTextbox.c(Faces.Pom, @"c
                                                        dis part here is shinjis butt");
                        e = EventTextbox.c(Faces.Shibe_annoyed, @"There's no way that's what this is!");
                        e = EventTextbox.c(Faces.Shibe_annoyed, @"Who on earth would hang up a picture
                                                                  of something like that?!");
                        e = EventTextbox.c(Faces.Pom, @"i would");
                        e = EventTextbox.c(Faces.Shibe_uh, @"Anyway, doesn't this look more like
                                                             a picture of a dog?");
                        e = EventTextbox.c(Faces.Shibe_uh, @"It's standing in the center.");
                        e = EventTextboxOnlyBG.c;
                        e = EventWait.c(2.5f);
                        e = EventTextbox.c(Faces.Pom, @"oh i c it now");
                        e = EventTextbox.c(Faces.Pom, @"darn");
                        e = EventTextbox.c(Faces.Sharpeii, @"You're wrong!");
                        e = EventTextbox.c(Faces.Shibe_uh, @"H-huh?");
                        e = EventTextbox.c(Faces.Sharpeii, @"This picture isn't of a mere dog.");
                        e = EventTextbox.c(Faces.Sharpeii, @"It's the funyarinpa!");
                        e = EventTextbox.c(Faces.Pom, @"what the hell is a funyarinpa");
                        e = EventSFX.c(SFX.fire8);
                        e = EventShake.c(5, 5, .2f);
                        e = EventTextbox.c(Faces.Sharpeii, @"What do you mean ''What the hell is
                                                             a funyarinpa''?!");
                        e = EventTextbox.c(Faces.Sharpeii, @"You mean...you don't know?!");
                        e = EventSFX.c(SFX.Pom_bark);
                        e = EventTextbox.c(Faces.Pom, @"how the hell would i know!?");
                        e = EventTextbox.c(Faces.Sharpeii, @"How could you not know?!
                                                             That...that's practically blasphemous.");
                        e = EventTextbox.c(Faces.Sharpeii, @"Say you're sorry!
                                                             Apologize to the funyarinpa!");
                        e = EventTextbox.c(Faces.Sharpeii, @"Goodness, you are such a rude
                                                             pomeranian.");
                        e = EventSetGlobal.c(Global.s.Funyarinpa, 1);
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }

                    ep = seenFunyarinpa;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventSetBackground.c(Background.Funyarinpa);
                        e = EventWait.c(1f);
                        e = EventTextbox.c(Faces.Shibe_uh, @"...Was he just screwing around with
                                                             us?");
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }
                }
            }
        }

        //Rocket
        NewEP("5da5b1ba-1243-4099-be86-dab1485d3af0");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeInParty;
            {
                var silentTreatment = new EventPage();
                var notSilentTreatment = new EventPage();

                e = EventPageSwitch.c(Global.s.Silent_Treatment).AddEventPage(0, notSilentTreatment).AddEventPage(1, silentTreatment);

                ep = silentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"hey shibe");
                    e = EventTextbox.c(Faces.Shibe_uh, @"...");
                    e = EventTextbox.c(Faces.Pom, @"...");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = notSilentTreatment;
                {
                    var rocket0 = new EventPage();
                    var rocket1 = new EventPage();
                    var rocket2plus = new EventPage();

                    e = EventPageSwitch.c(Global.s.Rocket).AddEventPage(0, rocket0).AddEventPage(1, rocket1).AddEventPage(2, rocket2plus, SwitchComparator.GreaterOrEqual);

                    ep = rocket0;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.Shibe, @"This looks like a model of a
                                                          rocket.");
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }

                    ep = rocket1;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.Shibe, @"This looks like a model of a
                                                          rocket.");
                        e = EventSFX.c(SFX.Pom_bark);
                        e = EventTextbox.c(Faces.Pom, @"shit
                                                        i accidentally just broke a little
                                                        piece of it off");
                        e = EventTextbox.c(Faces.Pom, @"let's blame it on that brat upstairs ok");
                        e = EventTextbox.c(Faces.Shibe_annoyed, @"Are you trying to turn these two
                                                                  against each other?!");
                        e = EventSetGlobal.c(Global.s.Rocket, 2);
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }

                    ep = rocket2plus;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.Shibe_annoyed, @"I wonder when he'll notice it...");
                        e = EventTextbox.c(Faces.Pom, @"never");
                        e = EventTextbox.c(Faces.Shibe_uh, @"How are we going to pull that off?");
                        e = EventTextbox.c(Faces.Pom, @"we kill him");
                        e = EventTextbox.c(Faces.Shibe_annoyed, @"Just to stop him from finding out that
                                                                  you broke off a piece of his model?!");
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }
                }
            }
        }

        //Floor2 - Titanic
        NewEP("f2ff3774-7659-4f3f-8498-09b1c769e7b0");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeInParty;
            {
                var silentTreatment = new EventPage();
                var notSilentTreatment = new EventPage();

                e = EventPageSwitch.c(Global.s.Silent_Treatment).AddEventPage(0, notSilentTreatment).AddEventPage(1, silentTreatment);

                ep = silentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"hey shibe");
                    e = EventTextbox.c(Faces.Shibe_uh, @"...");
                    e = EventTextbox.c(Faces.Pom, @"...");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = notSilentTreatment;
                {
                    var rocket0 = new EventPage();
                    var rocket1plus = new EventPage();

                    e = EventPageSwitch.c(Global.s.Rocket).AddEventPage(0, rocket0).AddEventPage(1, rocket1plus, SwitchComparator.GreaterOrEqual);

                    ep = rocket0;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.Shibe, @"This looks like a replica of the
                                                          Titanic.");
                        e = EventSFX.c(SFX.Pom_bark);
                        e = EventTextbox.c(Faces.Pom, @"fuk
                                                        i accidentally just broke a little
                                                        piece of it off");
                        e = EventTextbox.c(Faces.Pom, @"let's blame it on that old fart downstairs");
                        e = EventTextbox.c(Faces.Shibe_annoyed, @"I don't want to have any part in
                                                                  this!");
                        e = EventSetGlobal.c(Global.s.Rocket, 1);
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }

                    ep = rocket1plus;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.Shibe_annoyed, @"We probably shouldn't touch this
                                                                  anymore.");
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }
                }
            }
        }

        //Birdcage
        NewEP("f9cfa717-a418-42a7-a74e-d643eca28ba0");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeInParty;
            {
                var silentTreatment = new EventPage();
                var notSilentTreatment = new EventPage();

                e = EventPageSwitch.c(Global.s.Silent_Treatment).AddEventPage(0, notSilentTreatment).AddEventPage(1, silentTreatment);

                ep = silentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"hey shibe");
                    e = EventTextbox.c(Faces.Shibe_uh, @"...");
                    e = EventTextbox.c(Faces.Pom, @"...");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = notSilentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Shibe, @"It's a birdcage.");
                    e = EventTextbox.c(Faces.Shibe, @"There's nothing inside, though.");
                    e = EventTextbox.c(Faces.Pom, @"we should put u inside");
                    e = EventTextbox.c(Faces.Shibe_annoyed, @"No!");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }
            }
        }

        //Floor2 - Garbage
        NewEP("16335bfe-31c0-404a-8521-bad2b3f0e4b0");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeNotInParty;
            {
                var junkPile0 = new EventPage();
                var junkPile1 = new EventPage();
                var junkPile2 = new EventPage();

                e = EventPageSwitch.c(Global.s.JunkPile).AddEventPage(0, junkPile0).AddEventPage(1, junkPile1).AddEventPage(2, junkPile2);

                ep = junkPile0;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"...");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = junkPile1;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"huh? what's that");
                    e = EventTextbox.c(Faces.Pom, @"HEY");
                    e = EventSFX.c(SFX.Pom_bark);
                    e = EventTextbox.c(Faces.Pom, @"I FOUND THE CORG-KEYS");
                    e = EventTextbox.c(Faces.York, @"Hey! You can't just take those!");
                    e = EventTextbox.c(Faces.Pom, @"2 bad 4 u");
                    e = EventTextbox.c(Faces.Pom, @"i need them");

                    var hasRootbeer = new EventPage();
                    var noRootbeer = new EventPage();

                    e = EventPageSwitch.c(Global.s.RootBeer).AddEventPage(0, noRootbeer).AddEventPage(1, hasRootbeer);

                    ep = hasRootbeer;
                    {
                        e = EventTextbox.c(Faces.Pom, @"how about I trade this 2 u for this
                                                        root beer float from starpugs");
                        e = EventSFX.c(SFX.fire8);
                        e = EventShake.c(5, 5, .2f);
                        e = EventTextbox.c(Faces.York, "");
                        e = EventTextboxClearText.c;
                        e = EventWait.c(.2f);
                        e = EventTextbox.c(Faces.York, @"You have a root beer float?!");
                        e = EventTextbox.c(Faces.York, @"Okay, deal!");
                        e = EventTextbox.c(Faces.None, @"You gave the root beer float to York.");
                        e = EventSetGlobal.c(Global.s.RootBeer, 0);
                        e = EventTextbox.c(Faces.None, @"You received the Corg-Keys!");
                        e = EventSetGlobal.c(Global.s.CorgKeys, 1);
                        e = EventSetGlobal.c(Global.s.JunkPile, 2);
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }

                    ep = noRootbeer;
                    {
                        e = EventTextboxClose.c;
                        e = EventBattle.c(Battles.York);
                        e = EventTextbox.c(Faces.Pom, @"they're mine now");
                        e = EventTextbox.c(Faces.Pom, @"uwee hee");
                        e = EventSetGlobal.c(Global.s.CorgKeys, 1);
                        e = EventTextbox.c(Faces.None, @"You obtained the Corg-Keys!");
                        e = EventSetGlobal.c(Global.s.JunkPile, 2);
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }
                }

                ep = junkPile2;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"there's nothing else important in here");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }
            }

            ep = shibeInParty;
            {
                var silentTreatment = new EventPage();
                var notSilentTreatment = new EventPage();

                e = EventPageSwitch.c(Global.s.Silent_Treatment).AddEventPage(0, notSilentTreatment).AddEventPage(1, silentTreatment);

                ep = silentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"hey shibe");
                    e = EventTextbox.c(Faces.Shibe_uh, @"...");
                    e = EventTextbox.c(Faces.Pom, @"...");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = notSilentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Shibe_uh, @"It looks like a pile of junk.").SwitchSides;
                    e = EventTextbox.c(Faces.York, @"Oh, that's all stuff I scavenged from
                                                     trash.");
                    e = EventTextbox.c(Faces.York, @"There's some really valuable things
                                                     in there, you know.");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }
            }
        }

        #endregion

        #region Crest and Puddle's House

        //Hearts
        NewEP("14513af2-9f23-4247-b310-923777a8dcba");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"did yuo kno");
                e = EventTextbox.c(Faces.Pom, @"girls need cute things or else
                                                they'll die");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }

        //Big Bunny
        NewEP("53d67977-8932-4bf7-ab5e-67652d73b2b2");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"DOG FUKKING DAMMIT
                                                I LOVE BUNNIES");
                e = EventTextbox.c(Faces.Pom, @"PUNCH ME IN DA DICK");
                e = EventTextbox.c(Faces.Shibe_uh, @"E-excuse me?!");
                e = EventTextbox.c(Faces.Pom, @"it's just a figure of speech");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }

        //Trophy
        NewEP("3fbed45b-7cf5-4123-a01c-018b1c2ea226");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"dis is a best in show trophy");
                e = EventTextbox.c(Faces.Shibe_uh, @"Whoa! It's from a national competition.");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }

        //Oven
        NewEP("0793e0e7-c92d-4555-b0c1-eb8933df94b5");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe_uh, @"This is a really pink oven.").SwitchSides;
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }

        #endregion

        #region Observatory

        NewEP("bcd40acc-69a0-497e-b78e-99a998f9563e");
        {
            //TODO: Observatory stuff
        }

        #endregion

        #region Starpugs Exterior

        //wifi sign
        NewEP("8f83a21f-836d-46eb-b342-ff43403865d0");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeInParty;
            {
                var silentTreatment = new EventPage();
                var notSilentTreatment = new EventPage();

                e = EventPageSwitch.c(Global.s.Silent_Treatment).AddEventPage(0, notSilentTreatment).AddEventPage(1, silentTreatment);

                ep = silentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"hey shibe");
                    e = EventTextbox.c(Faces.Shibe_uh, @"...");
                    e = EventTextbox.c(Faces.Pom, @"...");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = notSilentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Shibe, @"''Free wi-fi inside.''");
                    e = EventTextbox.c(Faces.Shibe, @"This looks promising.");
                    e = EventTextbox.c(Faces.Pom, @"howl-elujah lets go");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }
            }

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }

        #endregion

        #region Starpugs Interior

        //Ug Counter
        NewEP("ae077145-261a-4d93-b723-9941794f70e0");
        {
            var ugTalk0 = new EventPage();
            var ugTalk1 = new EventPage();
            var ugTalk2plus = new EventPage();

            e = EventPageSwitch.c(Global.s.UgTalk).AddEventPage(0, ugTalk0, SwitchComparator.LessOrEqual).AddEventPage(1, ugTalk1).AddEventPage(2, ugTalk2plus, SwitchComparator.GreaterOrEqual);

            ep = ugTalk0;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Ug, @"Welcome to Starpugs!");
                e = EventTextbox.c(Faces.Ug, @"Can I take your order?");
                e = EventTextbox.c(Faces.Pom, @"we're just here 4 da wi-fi");
                e = EventSFX.c(SFX.Medium_Dog1);
                e = EventTextbox.c(Faces.Shibe_nervous, @"So honest!").SwitchSides;
                e = EventTextbox.c(Faces.Ug, @"If you want to be here, you'll have to
                                               buy something using dog treats!");
                e = EventTextbox.c(Faces.Shibe_uh, @"Oh...but we don't have any dog treats...").SwitchSides;
                e = EventTextbox.c(Faces.Ug, @"Then don't waste my time!");
                e = EventTextbox.c(Faces.Pom, @"rude");
                e = EventSetGlobal.c(Global.s.ShibeTalk, 20);
                e = EventSetGlobal.c(Global.s.BernardTalk, 1);
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = ugTalk1;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Ug, @"Welcome to Starpugs!");
                e = EventTextbox.c(Faces.Pom, @"we have da dog treats this time!");
                e = EventTextbox.c(Faces.Ug, @"What would you like to buy?");

                var mangoBoba = new EventPage();
                var vanillaMilkshake = new EventPage();
                var orangeJuice = new EventPage();
                var rootBeerFloat = new EventPage();

                e = EventTextboxChoice.c.AddChoice("Mango Boba", mangoBoba).
                                         AddChoice("Vanilla Milkshake", vanillaMilkshake).
                                         AddChoice("Orange Juice (no pulp)", orangeJuice).
                                         AddChoice("Root Beer Float", rootBeerFloat);

                ep = mangoBoba; e = EventTextbox.c(Faces.None, @"You received a mango boba.");
                ep = vanillaMilkshake; e = EventTextbox.c(Faces.None, @"You received a vanilla milkshake.");
                ep = orangeJuice; e = EventTextbox.c(Faces.None, @"You received an orange juice.");
                ep = rootBeerFloat;
                {
                    e = EventTextbox.c(Faces.None, @"You received a root beer float.");
                    e = EventSetGlobal.c(Global.s.RootBeer, 1);
                }
                
                ep = ugTalk1;

                e = EventTextboxClose.c;
                e = EventFade.c(2f);
                e = EventTPPlayer.c(new Vector2(83.5f, -51.0f)).instantTeleport;
                e = EventMovePlayer.c(Left);
                e = EventSetFacing.c(NPC.Pom, SpriteDir.Right);
                e = EventSetGlobal.c(Global.s.ShibeTalk, 25);
                e = EventSetGlobal.c(Global.s.MaltyTalk, 1);
                e = EventFade.c(-2f);
                e = EventWait.c(1f);
                e = EventTextbox.c(Faces.Pom, @"................");
                e = EventTextbox.c(Faces.Pom, @"????????????");
                e = EventTextbox.c(Faces.Pom, @"wheres da wi-fi");
                e = EventTextbox.c(Faces.Pom, @"what the hecky");
                e = EventTextbox.c(Faces.Shibe_uh, @"You're not getting any?");
                e = EventTextbox.c(Faces.None, @"\C[1]???\C[0]
                                                 Let's get this comedy show started!");
                e = EventTextbox.c(Faces.Shibe_uh, @"Huh?");
                e = EventSetFacing.c(NPC.Pom, SpriteDir.Up);
                e = EventSetFacing.c(NPC.Shibe, SpriteDir.Up);
                e = EventTextbox.c(Faces.WittyFido, @"I'm Witty Fido!");
                e = EventShake.c(5, 5, .2f).Wait;
                e = EventTextbox.c(Faces.WittyFido, @"Call me Wi-Fi for short!");
                e = EventSFX.c(SFX.Rimshot);
                e = EventTextboxClose.c;
                e = EventWait.c(1f);
                e = EventTextbox.c(Faces.Shibe_nervous, @"So when the sign said ''free Wi-Fi''...");
                e = EventSFX.c(SFX.Medium_Dog1);
                e = EventShake.c(5, 5, .2f).Wait;
                e = EventTextbox.c(Faces.Shibe_nervous, @"It meant him?!");
                e = EventTextbox.c(Faces.Pom, @"O");
                e = EventTextbox.c(Faces.Pom, @"M");
                e = EventTextbox.c(Faces.Pom, @"F");
                e = EventTextbox.c(Faces.Pom, @"G");
                e = EventShake.c(5, 5, .2f).Wait;
                e = EventSFX.c(SFX.Pom_bark);
                e = EventTextbox.c(Faces.Pom, @"U HAVE GOTTA B KEEEEEEEEDDING
                                                ME");
                e = EventTextbox.c(Faces.WittyFido, @"What's brown and sticky?");
                e = EventTextboxClose.c;
                e = EventWaitForInput.c;
                e = EventTextbox.c(Faces.WittyFido, @"A stick!");
                e = EventSFX.c(SFX.Rimshot);
                e = EventTextbox.c(Faces.Pom, @"DOG WHAT A WASTE OF TIME");
                e = EventTextbox.c(Faces.Pom, @"SHIBE WE'RE LEAVING");
                e = EventSetGlobal.c(Global.s.CorgTalk, 1);
                e = EventSetGlobal.c(Global.s.UgTalk, 2);

                var badEnd = new EventPage(); e = EventPageSwitch.c(Global.s.BadEnd).AddEventPage(1, badEnd);
                ep = badEnd; { e = EventSetGlobal.c(Global.s.CorgTalk, 3); }

                ep = ugTalk1;

                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = ugTalk2plus;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Ug, @"Welcome to Starpugs!");
                e = EventTextbox.c(Faces.Ug, @"Can I take your order?");
                e = EventTextbox.c(Faces.Pom, @"no");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }

        //Desserts
        NewEP("094765c6-c2c9-4e01-8650-acf09a9e63d9");
        {
            var shibeInParty = new EventPage();
            var shibeNotInparty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInparty).AddEventPage(1, shibeInParty);

            ep = shibeNotInparty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeInParty;
            {
                var silentTreatment = new EventPage();
                var notSilentTreatment = new EventPage();

                e = EventPageSwitch.c(Global.s.Silent_Treatment).AddEventPage(0, notSilentTreatment).AddEventPage(1, silentTreatment);

                ep = notSilentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"hey shibe");
                    e = EventTextbox.c(Faces.Shibe_uh, @"...");
                    e = EventTextbox.c(Faces.Pom, @"...");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = silentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Shibe, @"There's tons of pastries and desserts
                                                      in here.");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }
            }
        }

        //Yell Boundary
        NewEP("8d9849cb-9e59-417e-9d62-6373a7728a58");
        {
            var notWatchedShow = new EventPage();

            e = EventPageSwitch.c(Global.s.UgTalk).AddEventPage(1, notWatchedShow, SwitchComparator.LessOrEqual);

            ep = notWatchedShow;
            {
                //TODO: Should this event be solid? So you can't get to the left side of the shop?
                e = EventPlayerMoveable.c(false);
                e = EventSFX.c(SFX.fire8);
                e = EventShake.c(5, 5, .2f).Wait;
                e = EventTextbox.c(Faces.Ug, @"If you're not buying something, leave!");
                e = EventSFX.c(SFX.Pom_bark);
                e = EventTextbox.c(Faces.Pom, @"RUDE");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }
        
        #endregion




        #region NPCs

        //Shibe
        NewEP("f125b5c1-a3e4-4128-8dbc-f2e06d2091bc");
        {
            var shibeTalkIs1 = new EventPage();
            var shibeTalkIs3 = new EventPage();
            var shibeTalkIs4 = new EventPage();
            var shibeTalkIs5 = new EventPage();
            var shibeTalkIs6 = new EventPage();
            var shibeTalkIs7 = new EventPage();
            var shibeTalkIs8 = new EventPage();
            var shibeTalkIs9 = new EventPage();
            var shibeTalkIs10 = new EventPage();
            var shibeTalkIs11 = new EventPage();
            var shibeTalkIs12 = new EventPage();
            var shibeTalkIs13 = new EventPage();
            var shibeTalkIs14 = new EventPage();
            var shibeTalkIs15 = new EventPage();
            var shibeTalkIs16 = new EventPage();
            var shibeTalkIs17 = new EventPage();
            var shibeTalkIs18 = new EventPage();
            var shibeTalkIs19 = new EventPage();
            var shibeTalkIs20 = new EventPage();
            var shibeTalkIs21 = new EventPage();
            var shibeTalkIs22 = new EventPage();
            var shibeTalkIs23 = new EventPage();
            var shibeTalkIs24 = new EventPage();
            var shibeTalkIs25 = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeTalk).AddEventPage(1, shibeTalkIs1).AddEventPage(3, shibeTalkIs3).AddEventPage(4, shibeTalkIs4)
                                                   .AddEventPage(5, shibeTalkIs5).AddEventPage(6, shibeTalkIs6).AddEventPage(7, shibeTalkIs7)
                                                   .AddEventPage(8, shibeTalkIs8).AddEventPage(9, shibeTalkIs9).AddEventPage(10, shibeTalkIs10)
                                                   .AddEventPage(11, shibeTalkIs11).AddEventPage(12, shibeTalkIs12).AddEventPage(13, shibeTalkIs13)
                                                   .AddEventPage(14, shibeTalkIs14).AddEventPage(15, shibeTalkIs15).AddEventPage(16, shibeTalkIs16)
                                                   .AddEventPage(17, shibeTalkIs17).AddEventPage(18, shibeTalkIs18).AddEventPage(19, shibeTalkIs19)
                                                   .AddEventPage(20, shibeTalkIs20).AddEventPage(21, shibeTalkIs21).AddEventPage(22, shibeTalkIs22)
                                                   .AddEventPage(23, shibeTalkIs23).AddEventPage(24, shibeTalkIs24).AddEventPage(25, shibeTalkIs25);

            ep = shibeTalkIs1;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe, @"Why do you have laptop with you,
                                                  always?");
                e = EventTextbox.c(Faces.Pom, @"i am a lapdog after all");
                e = EventTextbox.c(Faces.Shibe_uh, @"I'm pretty sure that's not what the
                                                     term means.");
                e = EventSetGlobal.c(Global.s.ShibeTalk, 3);
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs3;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"if i dont check my facebark soon
                                                im going 2 die");
                e = EventTextbox.c(Faces.Pom, @"come on sebastian
                                                lets get going");
                e = EventTextbox.c(Faces.Shibe_annoyed, @"My name's not Sebastian!");
                e = EventTextbox.c(Faces.Pom, @"mush");
                e = EventTextbox.c(Faces.Shibe_uh, @"Alright, alright! I get it!");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs4;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe_uh, @"I can't believe we're really dead...");
                e = EventTextbox.c(Faces.Shibe_uh, @"I thought it was strange when I
                                                     suddenly woke up here, but
                                                     still!");
                e = EventTextbox.c(Faces.Pom, @"i thought it was strange when
                                                my wi-fi was gone");
                e = EventTextbox.c(Faces.Shibe_uh, @"So, what should we do now?");
                e = EventTextbox.c(Faces.Pom, @"keep asking around about wi-fi");
                e = EventTextbox.c(Faces.Shibe_uh, @"Not a lot of dogs would know what it
                                                     is, though.");
                e = EventTextbox.c(Faces.Shibe_uh, @"If I didn't live with you, I wouldn't
                                                     have known what it was either.");
                e = EventTextbox.c(Faces.Pom, @"got any better ideas");
                e = EventTextbox.c(Faces.Shibe_uh, @"Not really...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs5;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"lets go!! 2 da cafe");
                e = EventTextbox.c(Faces.Shibe, @"Alright! All we have to do is keep
                                                  going east.");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs6;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"we'll have 2 do something about this
                                                line if we wanna pass");
                e = EventTextbox.c(Faces.Pom, @"why is life so suck");
                e = EventTextbox.c(Faces.Shibe_uh, @"Maybe if we could get into the park,
                                                     we could figure out why they're not
                                                     lettign anyone in.");
                e = EventTextbox.c(Faces.Shibe_uh, @"Sherman is blocking the entrance,
                                                     though");
                e = EventTextbox.c(Faces.Pom, @"lets kill him");
                e = EventTextbox.c(Faces.Shibe_annoyed, @"That's not the answer!");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs7;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe, @"We need to gather things to pile
                                                  onto that stone in front of the park");
                e = EventTextbox.c(Faces.Shibe, @"Seeing how those two rude ladies in
                                                  line happened to have stuff on them...");
                e = EventTextbox.c(Faces.Pom, @"...makes u wonder if the other doges
                                                have stuff we could use too");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs8;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"we should find papi and beat da dog
                                                treats outta her");
                e = EventTextbox.c(Faces.Shibe_annoyed, @"Don't be so eager to resort to
                                                          violent measures!");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs9;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"whats goldie going 2 think of this tho");
                e = EventTextbox.c(Faces.Shibe_uh, @"There's nothing we can do but tell her
                                                     what happened.");
                e = EventTextbox.c(Faces.Shibe, @"Honesty is the best policy!").SwitchSides;
                e = EventTextbox.c(Faces.Pom, @"when u say things like that it makes
                                                me want to throw up");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs10;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe_annoyed, @"I think we should help Crest...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs11;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe, @"We have enough stuff to scale the
                                                  fence now!").SwitchSides;
                e = EventTextbox.c(Faces.Shibe, @"Let's go!").SwitchSides;
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs12;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe, @"Let's go see what's wrong.").SwitchSides;
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs13;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe, @"Looks like we found the problem.
                                                  The frisbee throwing machine's gone
                                                  berserk!").SwitchSides;
                e = EventTextbox.c(Faces.Pom, @"there must b some way 2 fix it");
                e = EventTextbox.c(Faces.Pom, @"lets try 2 dodge all da frisbees and c
                                                what's on the other side");
                e = EventTextbox.c(Faces.Shibe, @"Be careful!
                                                  It would be bad if we both got knocked
                                                  out by those frisbees at once.");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs14;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"how did u even get in here hus");
                e = EventTextbox.c(Faces.Hus, @"Through the entrance.
                                                Sherman let me in.");
                e = EventTextbox.c(Faces.Shibe_uh, @"...So you're not a ghost..?").SwitchSides;
                e = EventTextbox.c(Faces.Hus, @"Is that what you were thinking all
                                                this time?!");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs15;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe, @"For a place that's supposed to be heaven,
                                                  there sure is a lot wrong with it.").SwitchSides;
                e = EventTextbox.c(Faces.Hus, @"Seriously. I wonder what Dog is up to
                                                these days.");
                e = EventTextbox.c(Faces.Shibe_uh, @"Dog?").SwitchSides;
                e = EventTextbox.c(Faces.Hus, @"He's something like the head honcho
                                                around here.");
                e = EventTextbox.c(Faces.Hus, @"I've never met him, but I hear that
                                                he's invincible.");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs16;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe, @"I don't recall ever joining a gang.");
                e = EventTextbox.c(Faces.Pom, @"we homies 4 life");
                e = EventTextbox.c(Faces.Pom, @"we ride together we die together");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs17;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"our theme song should b a screamo
                                                cover of love story by taylor swift");
                e = EventTextbox.c(Faces.Pom, @"then we should get black hoodies and
                                                paint skulls on them with white-out");
                e = EventTextbox.c(Faces.Hus, @"Not hardcore enough!");
                e = EventTextbox.c(Faces.Hus, @"We need temporary tattoos.");
                e = EventTextbox.c(Faces.Hus, @"Dibs on the kitty one!");
                e = EventTextbox.c(Faces.Shibe_uh, @"Aren't you two getting awfully
                                                     excited about this?").SwitchSides;
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs18;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Chi, @"I forgot to ask, but...
                                                What did you need me for?");
                e = EventTextbox.c(Faces.Pom, @"gang activities");
                e = EventTextbox.c(Faces.Pom, @"we're burying a dead body");
                e = EventTextbox.c(Faces.Pom, @"in fact that dead body is gONNA B U");
                e = EventTextbox.c(Faces.Chi_nervous, @"Oh...oh, no!
                                                        Please reconsider!");
                e = EventTextbox.c(Faces.Shibe_annoyed, @"Pom, stop that!
                                                          You're scaring him!");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs19;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"da path 2 da cafe is finally clear");
                e = EventTextbox.c(Faces.Pom, @"googogogogogog og og");
                e = EventTextbox.c(Faces.Pom, @"gotta gio fatus");
                e = EventTextbox.c(Faces.Pom, @"gottas go fatser faster
                                                fastre fatsre fgaster fatre fatsre");
                e = EventTextbox.c(Faces.Shibe_annoyed, @"I can't understand a single word
                                                          you're saying!");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs20;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe_uh, @"I guess I should have known better
                                                     than to expect it to be simple.");
                e = EventTextbox.c(Faces.Shibe_uh, @"We'll have to obtain some dog treats
                                                     so we can buy a drink...");
                e = EventTextbox.c(Faces.Shibe_uh, @"So that we can sit inside StarPugs...");
                e = EventTextbox.c(Faces.Shibe_uh, @"So that you can use their wi-fi.");
                e = EventTextbox.c(Faces.Pom, @"time to look for dogs to shake down
                                                for dog treats");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs21;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe_annoyed, @"Why did you accept?!");
                e = EventTextbox.c(Faces.Pom, @"we need da treats dont we");
                e = EventTextbox.c(Faces.Shibe_annoyed, @"No matter how you look at it, this
                                                          isn't right!");
                e = EventTextbox.c(Faces.Shibe_annoyed, @"I'm not talking to you!");
                e = EventTextbox.c(Faces.Pom, @"lol we'll c how long that lasts");
                e = EventTextbox.c(Faces.Pom, @"poopy head");
                e = EventTextbox.c(Faces.Shibe_blush, @"..................................");
                e = EventTextbox.c(Faces.Pom, @"ur tail looks like poop too");
                e = EventTextbox.c(Faces.Shibe_blush, @"..............................................................");
                e = EventSetGlobal.c(Global.s.Silent_Treatment, 1);
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs22;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"hey shibe");
                e = EventTextbox.c(Faces.Shibe_annoyed, @"......................");
                e = EventTextbox.c(Faces.Pom, @"fine b that way");
                e = EventTextbox.c(Faces.Pom, @"c if i care");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs23;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe_annoyed, @"I can't believe I messed up and talked
                                                          yo you...");
                e = EventTextbox.c(Faces.Pom, @"u do this every single time u try 2
                                                give me the silent treatment");
                e = EventTextbox.c(Faces.Pom, @"it's never going 2 work");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs24;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Shibe_uh, @"Come on! Let's hurry to the cafe!");
                e = EventTextbox.c(Faces.Pom, @"whats this??");
                e = EventTextbox.c(Faces.Pom, @"shibe have u at last realized how
                                                vital wi-fi is 2 ur well being");
                e = EventTextbox.c(Faces.Shibe_uh, @"No, that's not it.");
                e = EventTextbox.c(Faces.Shibe_uh, @"Since this is heaven I'm not hungry or
                                                     anything, but it's still really difficult
                                                     to restrain myself from eating these
                                                     treats while holding them.");
                e = EventTextbox.c(Faces.Shibe_uh, @"I can see why they're used as currency.
                                                     They're a measure of the holder's
                                                     self-control.");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeTalkIs25;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"i still cant fukkin believe this
                                                happened");
                e = EventTextbox.c(Faces.Shibe_uh, @"I feel really bad for you, after your
                                                     hopes got all raised like that.");
                e = EventTextbox.c(Faces.Pom, @"but i wont be broken");
                e = EventTextbox.c(Faces.Pom, @"ill persevere like a tru hero");
                e = EventTextbox.c(Faces.Shibe_uh, @"I don't know if ''hero'' is really
                                                     the right word to describe you...");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }

        //Dave Pointer in Flower Field Town
        NewEP("2c6cfa07-9274-4894-8a77-faf92b4d6b47");
        {
            var davePointer0 = new EventPage();
            var davePointer1 = new EventPage();
            var davePointer2 = new EventPage();

            e = EventPageSwitch.c(Global.s.DavePointer).AddEventPage(0, davePointer0).AddEventPage(1, davePointer1).AddEventPage(2, davePointer2);

            ep = davePointer0;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.DavePointer, "Save?");
                e = EventTextbox.c(Faces.Shibe, "...").SwitchSides;
                e = EventTextbox.c(Faces.Shibe_uh, "......?").SwitchSides;
                e = EventTextbox.c(Faces.Shibe_uh, "Save what?").SwitchSides;
                e = EventTextbox.c(Faces.Shibe_uh, "The rainforest? The manatees?").SwitchSides;
                e = EventTextbox.c(Faces.Pom, "ive been waiting for this!");
                e = EventSetGlobal.c(Global.s.DavePointer, 1);
                e = EventSaveScreen.c; //temp, just automatically saves to slot 0
                e = EventTextbox.c(Faces.None, @"Automatically saved to slot 0.");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = davePointer1;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.DavePointer, "Save?");
                e = EventSaveScreen.c; //temp, just automatically saves to slot 0
                e = EventTextbox.c(Faces.None, @"Automatically saved to slot 0.");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = davePointer2;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.DavePointer, "Say V?");
                e = EventSaveScreen.c; //temp, just automatically saves to slot 0
                e = EventTextbox.c(Faces.None, @"Automatically saved to slot 0.");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }

        //Papi
        NewEP("d9b54a6e-a4a1-4ad8-b021-7206e17d01d3");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeInParty;
            {
                var papiTalk0 = new EventPage();
                var papiTalk1 = new EventPage();
                var papiTalk2 = new EventPage();
                var papiTalk3 = new EventPage();
                var papiTalk4 = new EventPage();

                e = EventPageSwitch.c(Global.s.PapiTalk).AddEventPage(0, papiTalk0).AddEventPage(1, papiTalk1).AddEventPage(2, papiTalk2).AddEventPage(3, papiTalk3).AddEventPage(4, papiTalk4);

                ep = papiTalk0;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Papi, @"Hi hi hi!");
                    e = EventTextbox.c(Faces.Papi, @"Welcome to doggy heaven!");
                    e = EventTextbox.c(Faces.Shibe, @"Thanks!").SwitchSides;
                    e = EventTextbox.c(Faces.Shibe_uh, @"...wait, what?").SwitchSides;
                    e = EventShake.c(5, 5, .2f);
                    e = EventSFX.c(SFX.Medium_Dog1);
                    e = EventTextbox.c(Faces.Shibe_nervous, @"D-d-d-doggy heaven?!").SwitchSides;
                    e = EventTextbox.c(Faces.Shibe_nervous, @"Then, that means...!").SwitchSides;
                    e = EventTextbox.c(Faces.Papi, @"You got it!");
                    e = EventShake.c(5, 5, .2f);
                    e = EventSFX.c(SFX.fire8);
                    e = EventTextbox.c(Faces.Papi, @"You're dead!");
                    e = EventTextbox.c(Faces.Shibe_nervous, @"Augh!!").SwitchSides;
                    e = EventTextbox.c(Faces.Pom, @"if this is heaven then where da wi-fi");
                    e = EventTextbox.c(Faces.Pom, @"in heaven shouldn't there b ultra
                                                    hi speed wi-fi everywhere");
                    e = EventTextbox.c(Faces.Papi, @"''Wi-fi''? What's that?");
                    e = EventTextbox.c(Faces.Pom, @"omfg");
                    e = EventTextbox.c(Faces.Papi, @"Is that a new technology?");
                    e = EventTextbox.c(Faces.Papi, @"I've been up here in heaven for a while
                                                     now, so if that's the case then I wouldn't
                                                     know anything about it!");
                    e = EventTextbox.c(Faces.Papi, @"Sorry!");
                    e = EventTextbox.c(Faces.Pom, @"u better b sorry");
                    e = EventTextbox.c(Faces.Shibe_uh, @"Don't feel too bad! It's not
                                                         exactly common knowledge for
                                                         a dog to have.").SwitchSides;
                    e = EventSetGlobal.c(Global.s.PapiTalk, 1);
                    e = EventSetGlobal.c(Global.s.ShibeTalk, 4);
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = papiTalk1;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Papi, @"I, I was a pretty tech-savvy pup
                                                     while I was still living, you know!");
                    e = EventTextbox.c(Faces.Papi, @"I was the first one on the block
                                                     to own a Famicom!!");
                    e = EventTextbox.c(Faces.Shibe_uh, @"She seems a little miffed...").SwitchSides;
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = papiTalk2;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Pom, @"hand over da dog treats");
                    e = EventTextbox.c(Faces.Papi, @"A daylight robbery?!");
                    e = EventTextbox.c(Faces.Shibe_uh, @"No, no! We're here on Goldie's behalf.").SwitchSides;
                    e = EventTextbox.c(Faces.Shibe_uh, @"She sent us here to retrieve the dog
                                                         treats you owe her.").SwitchSides;
                    e = EventTextbox.c(Faces.Papi, @"Oh...about that...");
                    e = EventTextbox.c(Faces.Papi, @"I already ate them.");
                    e = EventSFX.c(SFX.Pom_bark);
                    e = EventShake.c(5, 5, .2f);
                    e = EventTextbox.c(Faces.Pom, @"PERIOD BLOOD MICROWAVE");
                    e = EventTextbox.c(Faces.Pom, @"WHAT DO WE DO NOW");
                    e = EventTextbox.c(Faces.Papi, @"How about you give her this instead!");
                    e = EventTextbox.c(Faces.None, @"You received a Famicom.");
                    e = EventTextbox.c(Faces.Shibe_uh, @"I guess we'll have to take this back
                                                         to Goldie and explain what happened.").SwitchSides;
                    e = EventSetGlobal.c(Global.s.Famicom, 1);
                    e = EventSetGlobal.c(Global.s.PapiTalk, 3);
                    e = EventSetGlobal.c(Global.s.ShibeTalk, 9);
                    e = EventSetGlobal.c(Global.s.GoldieTalk, 4);
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = papiTalk3;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Shibe_uh, @"................").SwitchSides;
                    e = EventTextbox.c(Faces.Papi, @"Why are you looking at me like that?!");
                    e = EventTextbox.c(Faces.Papi, @"It's really hard not to eat those treats,
                                                     you know!");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = papiTalk4;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventSFX.c(SFX.crunching1);
                    e = EventTextbox.c(Faces.Papi, @"Crest bakes the best dog treats!");
                    e = EventTextbox.c(Faces.Pom, @"i want one");
                    e = EventTextbox.c(Faces.Pom, @"too bad im spying on her so i cant
                                                    ask her for one");
                    e = EventTextbox.c(Faces.Papi, @"What do you mean by that?");
                    e = EventTextbox.c(Faces.Pom, @"nothing");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }
            }

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Papi, "Where's shibe?");
                e = EventTextbox.c(Faces.Papi, "It's almost like you two had a fight!");
                e = EventTextbox.c(Faces.Pom, "can u not");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }

        //Sharpei
        NewEP("cbb2d128-bdf5-408b-a517-c963c42e0b74");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Sharpeii, @"I don't think Crest likes me very
                                                     much.");
                e = EventTextbox.c(Faces.Sharpeii, @"Normally I couldn't care less, but it
                                                     sucks not to get dog treats from her.");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeInParty;
            {
                var sharpeiTalk0 = new EventPage();
                var sharpeiTalk1 = new EventPage();
                var sharpeiTalk2 = new EventPage();
                var sharpeiTalk3 = new EventPage();

                e = EventPageSwitch.c(Global.s.SharpeiTalk).AddEventPage(0, sharpeiTalk0).AddEventPage(1, sharpeiTalk1).AddEventPage(2, sharpeiTalk2).AddEventPage(3, sharpeiTalk3);

                ep = sharpeiTalk0;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Shibe, @"Uh, excuse me, sir!").SwitchSides;
                    e = EventTextbox.c(Faces.Shibe, @"Would you happen to know where we
                                                      might be able to findwi-fi?").SwitchSides;
                    e = EventTextbox.c(Faces.Sharpeii, @"''Why Phi?''
                                                         What the heck are you talking about?");
                    e = EventTextbox.c(Faces.Pom, @"stares into the distance");
                    e = EventTextbox.c(Faces.Shibe_uh, @"Never mind, then...").SwitchSides;
                    e = EventSetGlobal.c(Global.s.SharpeiTalk, 1);
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = sharpeiTalk1;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Sharpeii, @"Gimme a ''P''!");
                    e = EventTextbox.c(Faces.Shibe, @"Gimme an ''I''!").SwitchSides;
                    e = EventTextbox.c(Faces.Pom, @"gimme an ''s'' and an ''s''");
                    e = EventTextbox.c(Faces.Pom, @"wat does that spell??
                                                    PISS");
                    e = EventTextbox.c(Faces.Sharpeii, @"That's not what we were trying to
                                                         spell!");
                    e = EventTextbox.c(Faces.Pom, @"what am i, psychic?");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = sharpeiTalk2;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Shibe, @"Do you have anything we might be
                                                      able to borrow?").SwitchSides;
                    e = EventTextbox.c(Faces.Sharpeii, @"That you can borrow, huh?");
                    e = EventTextbox.c(Faces.Sharpeii, @"...");
                    e = EventTextbox.c(Faces.Sharpeii, @"......");
                    e = EventTextbox.c(Faces.Sharpeii, @"...........");
                    e = EventTextbox.c(Faces.Sharpeii, @"Nope, sorry.");
                    e = EventTextbox.c(Faces.Pom, @"what was wiTH THAT
                                                    UNNECESSARILY LONG PAUSE");
                    e = EventTextbox.c(Faces.Pom, @"U MADE US WAIT FOR NOTHING");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = sharpeiTalk3;
                {
                    var toyBroken = new EventPage();
                    var toyNotBroken = sharpeiTalk1;

                    e = EventPageSwitch.c(Global.s.Rocket).AddEventPage(2, toyBroken, SwitchComparator.GreaterOrEqual).AddEventPage(1, toyNotBroken, SwitchComparator.LessOrEqual);

                    ep = toyNotBroken;
                    {
                        //This is already set above in sharpeiTalk1.
                        //If you need it to say something different for whatever reason, replace 
                        //      var toyNotBroken = sharpeiTalk1;
                        //with
                        //      var toyNotBroken = new EventPage();
                        //and then copy the events here and replace what you need to.
                    }

                    ep = toyBroken;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.Sharpeii, @"Somebody broke my rocket model!");
                        e = EventTextbox.c(Faces.Shibe_nervous, @"W-w-we definitely don't know
                                                                  anything about that!").SwitchSides;
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }
                }
            }
        }

        //York
        NewEP("489e668c-6d95-4a0c-a927-acffa10e0f00");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.York, @"I wouldn't believe what some
                                                 people throw away.");
                e = EventTextbox.c(Faces.Pom, @"believe it");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeInParty;
            {
                var machineChecked = new EventPage();
                var machineNotChecked = new EventPage();

                e = EventPageSwitch.c(Global.s.MachineChecked).AddEventPage(0, machineNotChecked).AddEventPage(1, machineChecked);

                ep = machineChecked;
                {
                    var brokeStuff = new EventPage();
                    var notBrokeStuff = new EventPage();

                    e = EventPageSwitch.c(Global.s.Rocket).AddEventPage(1, brokeStuff, SwitchComparator.GreaterOrEqual).AddEventPage(0, notBrokeStuff, SwitchComparator.LessOrEqual);

                    ep = brokeStuff;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.York, @"");
                        e = EventTextbox.c(Faces.Pom, @"");
                        e = EventTextbox.c(Faces.York, @"");
                        e = EventTextbox.c(Faces.Shibe_nervous, @"").SwitchSides;
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }

                    ep = notBrokeStuff;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.York, @"I love here with Grandpa.");
                        e = EventTextbox.c(Faces.Pom, @"that cranky old fart downstairs?");
                        e = EventTextbox.c(Faces.Shibe_annoyed, @"Pom, don't be rude!").SwitchSides;
                        e = EventTextbox.c(Faces.York, @"He may be cranky at times, but he's
                                                         good on the inside!");
                        e = EventTextbox.c(Faces.York, @"He got me a root beer float once.");
                        e = EventTextbox.c(Faces.Shibe_uh, @"Just because someone got you a root
                                                             beer float doesn't prove that they're a
                                                             good person...").SwitchSides;
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }
                }

                ep = machineNotChecked;
                {
                    var talk0 = new EventPage();
                    var talk1 = new EventPage();
                    var talk2 = new EventPage();

                    e = EventPageSwitch.c(Global.s.YorkTalk).AddEventPage(0, talk0).AddEventPage(1, talk1).AddEventPage(2, talk2);

                    ep = talk0;
                    {
                        var silentTreatment = new EventPage();
                        var notSilentTreatment = new EventPage();

                        e = EventPageSwitch.c(Global.s.Silent_Treatment).AddEventPage(0, notSilentTreatment).AddEventPage(1, silentTreatment);

                        ep = silentTreatment;
                        {
                            e = EventPlayerMoveable.c(false);
                            e = EventTextbox.c(Faces.York, @"I'm really craving a root beer float
                                                             right now.");
                            e = EventTextbox.c(Faces.York, @"Too bad I don't have the treats to buy
                                                             one.");
                            e = EventTextbox.c(Faces.Pom, @"so crest doesnt like u either, huh");
                            e = EventTextboxClose.c;
                            e = EventPlayerMoveable.c(true);
                        }

                        ep = notSilentTreatment;
                        {
                            e = EventPlayerMoveable.c(false);
                            e = EventTextbox.c(Faces.Shibe, @"Do you know where we can find
                                                              wi-fi?").SwitchSides;
                            e = EventTextbox.c(Faces.York, @"''Wi-fi''...?
                                                             That sounds pretty familiar.");
                            e = EventTextbox.c(Faces.York, @"I think the cafe has it.");
                            e = EventTextbox.c(Faces.York, @"If you keep heading east, you'll see it
                                                             for sure.");
                            e = EventSFX.c(SFX.Pom_bark);
                            e = EventTextbox.c(Faces.Pom, @"ARIGATOU YOUNG DOGE");
                            e = EventTextbox.c(Faces.Pom, @"i owe u my life");
                            e = EventTextbox.c(Faces.Pom, @"i love y");
                            e = EventTextbox.c(Faces.Pom, @"ugioh");
                            e = EventSetGlobal.c(Global.s.ShibeTalk, 5);
                            e = EventSetGlobal.c(Global.s.YorkTalk, 1);
                            e = EventTextboxClose.c;
                            e = EventPlayerMoveable.c(true);
                        }
                    }

                    ep = talk1;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.York, @"I love here with Grandpa.");
                        e = EventTextbox.c(Faces.Pom, @"that cranky old fart downstairs?");
                        e = EventTextbox.c(Faces.Shibe_annoyed, @"Pom, don't be rude!").SwitchSides;
                        e = EventTextbox.c(Faces.York, @"He may be cranky at times, but he's
                                                         good on the inside!");
                        e = EventTextbox.c(Faces.York, @"He got me a root beer float once.");
                        e = EventTextbox.c(Faces.Shibe_uh, @"Just because someone got you a root
                                                             beer float doesn't prove that they're a
                                                             good person...").SwitchSides;
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }

                    ep = talk2;
                    {
                        e = EventPlayerMoveable.c(false);
                        e = EventTextbox.c(Faces.Shibe, @"Do you have anything we can borrow?").SwitchSides;
                        e = EventTextbox.c(Faces.York, @"Sorry, I can't lend any of that pile
                                                         over there.");
                        e = EventTextbox.c(Faces.York, @"That stuff is important.");
                        e = EventTextbox.c(Faces.Pom, @"IMPORTANT MY ASS");
                        e = EventTextbox.c(Faces.Pom, @"I SEE SODA CANS IN THERE");
                        e = EventTextboxClose.c;
                        e = EventPlayerMoveable.c(true);
                    }
                }
            }
        }

        //Glish
        NewEP("2047de3b-6bcc-459d-823c-ee017d3a2ba8");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Glish, @"I wonder where York gets all his
                                                  trash.");
                e = EventTextbox.c(Faces.Glish, @"I can smell that junk heap in his room
                                                  from all the way over here.");
                e = EventTextbox.c(Faces.Pom, @"trash, huh");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeInParty;
            {
                var silentTreatment = new EventPage();
                var notSilentTreatment = new EventPage();

                e = EventPageSwitch.c(Global.s.Silent_Treatment).AddEventPage(0, notSilentTreatment).AddEventPage(1, silentTreatment);

                ep = notSilentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Glish, @"This is the observatory.");
                    e = EventTextbox.c(Faces.Glish, @"If you look down through the glass,
                                                      you watch over your loved ones
                                                      going about their lives!");
                    e = EventTextbox.c(Faces.Shibe, @"That's amazing!").SwitchSides;
                    e = EventTextbox.c(Faces.Shibe_uh, @"Can you really see with the fur
                                                         over your eyes like that, though?").SwitchSides;
                    e = EventTextbox.c(Faces.Glish, @"Of course!");
                    e = EventTextbox.c(Faces.Glish, @"The fur does keep poking me in
                                                      the eyes, though.");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }

                ep = silentTreatment;
                {
                    e = EventPlayerMoveable.c(false);
                    e = EventTextbox.c(Faces.Glish, @"I smell dog treats in the distance!");
                    e = EventTextboxClose.c;
                    e = EventPlayerMoveable.c(true);
                }
            }
        }

        //Ug
        NewEP("61e36259-6e72-4182-a7a2-f9f1ee8fb8df");
        {
            e = EventPlayerMoveable.c(false);
            e = EventTextbox.c(Faces.Ug, @"You're not supposed to be back here!");
            e = EventTextboxClose.c;
            e = EventPlayerMoveable.c(true);
        }

        //Bold
        NewEP("3a207469-bbbd-445c-a4b8-09a81d5ecfcb");
        {
            var shibeInParty = new EventPage();
            var shibeNotInParty = new EventPage();

            e = EventPageSwitch.c(Global.s.ShibeInParty).AddEventPage(0, shibeNotInParty).AddEventPage(1, shibeInParty);

            ep = shibeNotInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Bold, @"I wonder what the world would be
                                                 like if I were dog.");
                e = EventTextbox.c(Faces.Pom, @"hell");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = shibeInParty;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Bold, @"Don't you think it'd be great if you
                                                 turned on the tap and orange juice 
                                                 came out?");
                e = EventSFX.c(SFX.Medium_Dog1);
                e = EventShake.c(5, 5, .2f).Wait;
                e = EventTextbox.c(Faces.Shibe_nervous, @"He just suddenly said something
                                                          really stupid!").SwitchSides;
                e = EventTextbox.c(Faces.Pom, @"ikr");
                e = EventTextbox.c(Faces.Pom, @"he didnt specify with or without pulp");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }

        //Witty Fido
        NewEP("9fef999e-0bcd-486d-bc24-391fe51b3848");
        {
            var wittyFidoTalk0 = new EventPage();
            var wittyFidoTalk1 = new EventPage();
            var wittyFidoTalk2 = new EventPage();
            var wittyFidoTalk3 = new EventPage();

            e = EventPageSwitch.c(Global.s.WittyFidoTalk).AddEventPage(0, wittyFidoTalk0).AddEventPage(1, wittyFidoTalk1).AddEventPage(2, wittyFidoTalk2).AddEventPage(3, wittyFidoTalk3);

            ep = wittyFidoTalk0;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.WittyFido, @"What kind of dog will laugh at any
                                                      joke?");
                e = EventTextboxClose.c;
                e = EventWaitForInput.c;
                e = EventTextbox.c(Faces.WittyFido, @"A Chi-ha-ha!");
                e = EventSFX.c(SFX.Rimshot);
                e = EventSetGlobal.c(Global.s.WittyFidoTalk, 1);
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = wittyFidoTalk1;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.WittyFido, @"Why are Dalmatians no good at
                                                      ''Hide and Seek''?");
                e = EventTextboxClose.c;
                e = EventWaitForInput.c;
                e = EventTextbox.c(Faces.WittyFido, @"They're always spotted!");
                e = EventSFX.c(SFX.Rimshot);
                e = EventSetGlobal.c(Global.s.WittyFidoTalk, 2);
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = wittyFidoTalk2;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.WittyFido, @"Why did the man bring his dog to the
                                                      railroad station?");
                e = EventTextboxClose.c;
                e = EventWaitForInput.c;
                e = EventTextbox.c(Faces.WittyFido, @"Because he wanted to ''train'' him!");
                e = EventSFX.c(SFX.Rimshot);
                e = EventSetGlobal.c(Global.s.WittyFidoTalk, 3);
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }

            ep = wittyFidoTalk3;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.WittyFido, @"That's all I have for today.");
                e = EventTextbox.c(Faces.WittyFido, @"Come back tomorrow for more jokes!");
                e = EventTextboxClose.c;
                e = EventPlayerMoveable.c(true);
            }
        }

        #endregion


        //.. You're done! That's it. The rest of the events are all the pure logic event pages. No more translations that need to be done. :)















        #region Logic Only EventPages

        #region Field - Walk-to-Shibe Line

        NewEP("74bb2385-60e2-4347-a5e8-f2bba5a6d98c"); //top
        {
            tempEP = new EventPage(); e = EventPageSwitch.c(Global.s.IntroGround).AddEventPage(0, tempEP); ep = tempEP;
            e = EventPlayerMoveable.c(false);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(DownRight);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(DownRight);
            e = EventWait.c(.33f);
            e = EventSetGlobal.c(Global.s.ShibeIntro, 1);
            e = EventMovePlayer.c(Right);
        }

        NewEP("330be885-184e-4c81-bb03-58032f0797e9"); //above mid
        {
            tempEP = new EventPage(); e = EventPageSwitch.c(Global.s.IntroGround).AddEventPage(0, tempEP); ep = tempEP;
            e = EventPlayerMoveable.c(false);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(DownRight);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventSetGlobal.c(Global.s.ShibeIntro, 1);
            e = EventMovePlayer.c(Right);
        }

        NewEP("a20c7976-0f55-464a-bc63-d598ca23e448"); //mid
        {
            tempEP = new EventPage(); e = EventPageSwitch.c(Global.s.IntroGround).AddEventPage(0, tempEP); ep = tempEP;
            e = EventPlayerMoveable.c(false);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventSetGlobal.c(Global.s.ShibeIntro, 1);
            e = EventMovePlayer.c(Right);
        }

        NewEP("647c580b-b0f2-41f8-b551-2d55ba4ee830"); //below mid
        {
            tempEP = new EventPage(); e = EventPageSwitch.c(Global.s.IntroGround).AddEventPage(0, tempEP); ep = tempEP;
            e = EventPlayerMoveable.c(false);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(UpRight);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventSetGlobal.c(Global.s.ShibeIntro, 1);
            e = EventMovePlayer.c(Right);
        }

        NewEP("a5e1dea9-1a38-4bac-9e46-7b6d28575087"); //bottom
        {
            tempEP = new EventPage(); e = EventPageSwitch.c(Global.s.IntroGround).AddEventPage(0, tempEP); ep = tempEP;
            e = EventPlayerMoveable.c(false);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(UpRight);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(UpRight);
            e = EventWait.c(.33f);
            e = EventSetGlobal.c(Global.s.ShibeIntro, 1);
            e = EventMovePlayer.c(Right);
        }

        #endregion

        #endregion
        
        Global.ActiveLanguage.value = curLang;
    }
}







