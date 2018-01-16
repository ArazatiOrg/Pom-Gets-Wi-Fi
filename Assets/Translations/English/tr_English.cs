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
        SharpeiiName = "Sharpeii";
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

            e = EventPageSwitch.c(Global.Intro). AddEventPage(0, introIs0). AddEventPage(1, introIs1). AddEventPage(2, introIs2). AddEventPage(3, introIs3). AddEventPage(4, introIs4);
            
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
                e = EventSetGlobal.c(Global.Intro, 1);
                e = EventPlayerMoveable.c(true);
            }

            #region Websites
            var facewoof = new EventPage();
            var reddig = new EventPage();
            var gTail = new EventPage();
            var tumfur = new EventPage();

            var choice = EventTextboxChoice.c.
                    AddChoice("Facewoof", facewoof, Global.Intro_Facewoof).
                    AddChoice("Reddig", reddig, Global.Intro_Reddig).
                    AddChoice("gTail", gTail, Global.Intro_gTail).
                    AddChoice("Tumfur", tumfur, Global.Intro_Tumfur);

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
                e = EventSetGlobal.c(Global.Intro_Facewoof, true);
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
                e = EventSetGlobal.c(Global.Intro_Reddig, true);
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
                e = EventSetGlobal.c(Global.Intro_gTail, true);
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
                e = EventSetGlobal.c(Global.Intro_Tumfur, true);
            }

            #endregion
            
            ep = introIs1;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"now what should i check first");
                e = EventTextbox.c(Faces.Pom, @"first world problems");
                e = choice;
                e = EventTextboxClose.c;
                e = EventSetGlobal.c(Global.Intro, 2);
                e = EventPlayerMoveable.c(true);
            }
            
            ep = introIs2;
            {
                e = EventPlayerMoveable.c(false);
                e = EventTextbox.c(Faces.Pom, @"next up is...");
                e = choice;
                e = EventSetBackground.c(Background.IntroNight);
                e = EventTextboxClose.c;
                e = EventSetGlobal.c(Global.Intro, 3);
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
                e = EventSetGlobal.c(Global.Intro, 4);
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
                e = EventSetGlobal.c(Global.Intro, 6);
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

                    e = EventPageSwitch.c(Global.Intro_LastWebsiteSelector).AddEventPage(0, facewoofLeft).AddEventPage(1, reddigLeft).AddEventPage(2, gTailLeft).AddEventPage(3, tumfurLeft);
                }

                e = EventTextbox.c(Faces.Pom, @"...");
                e = EventTextbox.c(Faces.Pom, @"EH????????");
                e = EventSFX.c(SFX.Pom_bark);
                e = EventShake.c;
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
            tempEP = new EventPage(); e = EventPageSwitch.c(Global.ShibeIntro).AddEventPage(1, tempEP); ep = tempEP;
            e = EventPlayerMoveable.c(false);
            e = EventSetGlobal.c(Global.IntroGround, 1);
            e = EventSetGlobal.c(Global.ShibeIntro, 3);
            e = EventSetGlobal.c(Global.ShibeTalk, 1);
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
            e = EventSetGlobal.c(Global.FlowerField, 1);
            e = EventTextbox.c(Faces.Pom, @"ok shibe");
            e = EventTextbox.c(Faces.Pom, @"from now on ur my manservant");
            e = EventTextbox.c(Faces.Pom, @"i can talk 2 u whenever i want by
                                            facing u and pressing da z key");
            e = EventTextbox.c(Faces.Pom, @"also ive changed ur name 2
                                            sebastian");
            e = EventTextbox.c(Faces.Shibe_annoyed, @"Why the hell am I ''Sebastian''?!");
            e = EventTextbox.c(Faces.None, @"Shibe has joined the party!").DontSlide;
            e = EventSetGlobal.c(Global.ShibeInParty, 1);
            e = EventTextboxClose.c;
            e = EventPlayerMoveable.c(true);
        }

        //cherry blossom trees
        NewEP("ba0b6a84-07ed-46da-b0d6-a4b541c0b52f");
        {
            var shibeInParty = new EventPage();
            var shibeNotInparty = new EventPage();
            e = EventPageSwitch.c(Global.ShibeInParty).AddEventPage(1, shibeInParty).AddEventPage(1, shibeNotInparty, SwitchComparator.NotEqual);

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
                e = EventPageSwitch.c(Global.Silent_Treatment).AddEventPage(0, silentTreatment, SwitchComparator.NotEqual)
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
                    e = EventPageSwitch.c(Global.Cherry_Blossoms).AddEventPage(0, cherryBlossomsNotSeen)
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
                        e = EventSetGlobal.c(Global.Cherry_Blossoms, 1);
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
                e = EventPageSwitch.c(Global.ShibeInParty).AddEventPage(1, shibeInParty).AddEventPage(1, shibeNotInparty, SwitchComparator.NotEqual);

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
                    e = EventPageSwitch.c(Global.Silent_Treatment).AddEventPage(0, silentTreatment, SwitchComparator.NotEqual)
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
                    e = EventPageSwitch.c(Global.ShibeInParty).AddEventPage(1, shibeInParty).AddEventPage(1, shibeNotInparty, SwitchComparator.NotEqual);

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
                        e = EventPageSwitch.c(Global.Silent_Treatment).AddEventPage(0, silentTreatment, SwitchComparator.NotEqual)
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

            e = EventPageSwitch.c(Global.ShibeTalk).AddEventPage(1, shibeTalkIs1).AddEventPage(3, shibeTalkIs3).AddEventPage(4, shibeTalkIs4)
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
                e = EventSetGlobal.c(Global.ShibeTalk, 3);
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
                e = EventSetGlobal.c(Global.Silent_Treatment, 1);
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



        #endregion


        //.. You're done! That's it. The rest of the events are all the pure logic event pages. No more translations that need to be done. :)















        #region Logic Only EventPages

        #region Field - Walk-to-Shibe Line

        NewEP("74bb2385-60e2-4347-a5e8-f2bba5a6d98c"); //top
        {
            tempEP = new EventPage(); e = EventPageSwitch.c(Global.IntroGround).AddEventPage(0, tempEP); ep = tempEP;
            e = EventPlayerMoveable.c(false);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(DownRight);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(DownRight);
            e = EventWait.c(.33f);
            e = EventSetGlobal.c(Global.ShibeIntro, 1);
            e = EventMovePlayer.c(Right);
        }

        NewEP("330be885-184e-4c81-bb03-58032f0797e9"); //above mid
        {
            tempEP = new EventPage(); e = EventPageSwitch.c(Global.IntroGround).AddEventPage(0, tempEP); ep = tempEP;
            e = EventPlayerMoveable.c(false);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(DownRight);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventSetGlobal.c(Global.ShibeIntro, 1);
            e = EventMovePlayer.c(Right);
        }

        NewEP("a20c7976-0f55-464a-bc63-d598ca23e448"); //mid
        {
            tempEP = new EventPage(); e = EventPageSwitch.c(Global.IntroGround).AddEventPage(0, tempEP); ep = tempEP;
            e = EventPlayerMoveable.c(false);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventSetGlobal.c(Global.ShibeIntro, 1);
            e = EventMovePlayer.c(Right);
        }

        NewEP("647c580b-b0f2-41f8-b551-2d55ba4ee830"); //below mid
        {
            tempEP = new EventPage(); e = EventPageSwitch.c(Global.IntroGround).AddEventPage(0, tempEP); ep = tempEP;
            e = EventPlayerMoveable.c(false);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(UpRight);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventSetGlobal.c(Global.ShibeIntro, 1);
            e = EventMovePlayer.c(Right);
        }

        NewEP("a5e1dea9-1a38-4bac-9e46-7b6d28575087"); //bottom
        {
            tempEP = new EventPage(); e = EventPageSwitch.c(Global.IntroGround).AddEventPage(0, tempEP); ep = tempEP;
            e = EventPlayerMoveable.c(false);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(Right);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(UpRight);
            e = EventWait.c(.33f);
            e = EventMovePlayer.c(UpRight);
            e = EventWait.c(.33f);
            e = EventSetGlobal.c(Global.ShibeIntro, 1);
            e = EventMovePlayer.c(Right);
        }

        #endregion

        #endregion
    }
}







