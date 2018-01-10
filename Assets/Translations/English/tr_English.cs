using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tr_English : _BaseTR
{
	void Start () {
        TranslationName = "English";
        TranslationCredits = ""; //Your name and anyone who helped you here!

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

        //I'll try to keep this as well documented as I can, feel free to send me (Arazati) messages if you need any help or clarifications on anything :)

        //Some quick notes first of all;
        //-Each line can have 50 characters across, so count if you think you're using long lines, or test them ingame
        //-You can't use " inside of a string. Instead, you have to use two of ' so it's '',
        //      it gets automatically turned into a " in the textboxes so that's only one character

        #region Intro

        //This is actually the longest event chain in the game, so it's a bit more complicated than most.
        //For the most part, each event page is done in order, with 4 potential sub events on 1, 2, and 3, which lets the player choose one of 4 websites.

        NewEP("67B10BC2-FCEF-4722-B7D7-B8BCB24B3F70");
        var introIs0 = new EventPage();
        var introIs1 = new EventPage();
        var introIs2 = new EventPage();
        var introIs3 = new EventPage();
        var introIs4 = new EventPage();

        e = EventPlayerMoveable.c(false);
        e =
        EventPageSwitch.c(Global.Intro).
            AddEventPage(0, introIs0).
            AddEventPage(1, introIs1).
            AddEventPage(2, introIs2).
            AddEventPage(3, introIs3).
            AddEventPage(4, introIs4);

        #region Intro is set to 0
        ep = introIs0;
        e = EventBGM.c(BGM.village2, .4f);
        e = EventSFX.c(SFX.Pom_bark);
        e = EventTextbox.c(Faces.Pom_no_laptop, @"\C[1]Pom\C[0]
                                the sun is shining");
        e = EventTextboxClearText.c;
        e = EventWait.c(.3f);
        e = EventTextbox.c(Faces.Pom_no_laptop, @"\C[1]Pom\C[0]
                                the birds are singing");
        e = EventTextboxClearText.c;
        e = EventWait.c(.3f);
        e = EventTextbox.c(Faces.Pom_no_laptop, @"\C[1]Pom\C[0]
                                it looks like the perfect day...");
        e = EventTextboxClose.c;
        e = EventChangeSprite.c(PlayerSprite.PillowAndLaptop);
        e = EventFlashScreen.c(.2f);
        e = EventWait.c(1f);
        e = EventSFX.c(SFX.Pom_bark);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ...to spend on the internet");
        e = EventTextboxClose.c;
        e = EventSetGlobal.c(Global.Intro, 1);
        e = EventPlayerMoveable.c(true);
        #endregion

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
        e = EventSetBackground.c(Background.Facewoof);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ...");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                god
                                stop posting pictures of ur fukkin food");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                and showing off how much fun ur
                                having without me");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                no one wants to see ur pugly duck
                                face either");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                jfc");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ...");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                hey looks like my top pomeranians fb
                                group has some new members");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ...");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                r u fucking kidding me");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                these r all humans showing off
                                their doges...");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                plus some weird girl pretending
                                to be a doge on the internet");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                r u srsly telling me im the only legit
                                pom pom doge on this website");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                furget this");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                i dont want to live on this planet
                                anymore");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                flies into the sun");
        e = EventSetBackground.c(Background.None);
        e = EventSetGlobal.c(Global.Intro_Facewoof, true);

        //Reddig events
        ep = reddig;
        e = EventSetBackground.c(Background.Reddig);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ...");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ...");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ??????!!!!!!!");
        e = EventSFX.c(SFX.Pom_bark);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                JESSUSUSUS CHSIRTS");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                the mythbarkers r doing an AMA");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                this is terrieriffic
                                nows my chance to ask them all my 
                                burning questions");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                hhhhhhhhhhhhhhhhhhhhh");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                all my comments will probably b
                                buried tho");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                lies down");
        e = EventSetBackground.c(Background.None);
        e = EventSetGlobal.c(Global.Intro_Reddig, true);

        //gTail events
        ep = gTail;
        e = EventSetBackground.c(Background.gTail);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ...");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                lets see what i have here");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ''Pom, it's not too late to apply!''
                                ''Pom, picture yourself at Berkeley''");
        e = EventSFX.c(SFX.Pom_bark);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                IM A FUKKIN POMERANIAN");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                WTH DO U GUYS WANT FROM ME");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ...");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                hey its my SAT question of the day");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                delete");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                still not sure why i signed up for that");
        e = EventSetBackground.c(Background.None);
        e = EventSetGlobal.c(Global.Intro_gTail, true);

        //Tumfur events
        ep = tumfur;
        e = EventSetBackground.c(Background.Tumfur);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ...");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                wow this fanart is amaze");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                bless this drawing");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ...");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                wh");
        e = EventSFX.c(SFX.Pom_bark);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                the arTIST IS FOURTEEN");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                WHY THIS");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                SO TALENT");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                THIS ISNT POSSIBLE");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                LEAPS INTO AN ACTIVE VOLCANO");
        e = EventSetBackground.c(Background.None);
        e = EventSetGlobal.c(Global.Intro_Tumfur, true);

        #endregion

        #region Intro is set to 1
        ep = introIs1;
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                now what should i check first");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                first world problems");
        e = choice;
        e = EventTextboxClose.c;
        e = EventSetGlobal.c(Global.Intro, 2);
        e = EventPlayerMoveable.c(true);
        #endregion

        #region Intro is set to 2
        ep = introIs2;
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                next up is...");
        e = choice;
        e = EventSetBackground.c(Background.IntroNight);
        e = EventTextboxClose.c;
        e = EventSetGlobal.c(Global.Intro, 3);
        e = EventPlayerMoveable.c(true);
        #endregion

        #region Intro is set to 3
        ep = introIs3;
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                next...");
        e = choice;
        e = EventBGM.c(BGM.burning, .6f);
        e = EventSetBackground.c(Background.IntroFire1);
        e = EventTextboxClose.c;
        e = EventSetGlobal.c(Global.Intro, 4);
        e = EventPlayerMoveable.c(true);
        #endregion

        #region Intro is set to 4
        ep = introIs4;
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                finally, I need to check...");
        e = EventSFX.c(SFX.Shibe_barking);
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
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                wtf!!");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                that fukkin shiba inu is so noisy");
        e = EventSFX.c(SFX.Shibe_barking);
        e = EventTextbox.c(Faces.None, @"\C[1]Shibe\C[0]
                                Huh? Pom, you're still in here?");
        e = EventTextbox.c(Faces.None, @"\C[1]Shibe\C[0]
                                We have to go!
                                Master is already waiting
                                outside!");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                I SWEAR TO DOG");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                IF YOU DONT SHADDUP IMMA
                                FUKKIN KNOCK THE WALL DOWN");
        e = EventSFX.c(SFX.Pom_bark);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                YA HEAR ME, SHIBE??");
        e = EventSFX.c(SFX.Shibe_barking);
        e = EventSFX.c(SFX.bump1);
        e = EventSFX.c(SFX.bump1);
        e = EventTextbox.c(Faces.None, @"\C[1]Shibe\C[0]
                                Pom, listen to me! Open your
                                door and run for it!");
        e = EventSFX.c(SFX.Pom_bark);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                GO AWAY!!!!!!!!!!!");
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
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                finally that dum shibe shut up");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                is it just me or is it hella hot in here");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                our owner should turn up the air 
                                conditioning");
        e = EventSFX.c(SFX.Pom_bark);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                HEY OWNER!!");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                AIR CONDITIONING!!!");
        e = EventSetBackground.c(Background.IntroFire3);
        e = EventTextboxClose.c;
        e = EventWait.c(1.5f);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                *koffing*");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                *wheezing*");
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
        
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                huh");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                this is much better");
        e = EventSetWebsiteSelector.c;

        // i'm sorry for this mess.. only one of these will trigger based on what the player -didn't- select before
        {
            var tumfurLeft = new EventPage();
            var reddigLeft = new EventPage();
            var gTailLeft = new EventPage();
            var facewoofLeft = new EventPage();

            tumfurLeft.Add(EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                now i can finally finish my daily
                                rounds and check tumfur..."));
            reddigLeft.Add(EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                now i can finally finish my daily
                                rounds and check reddig..."));
            gTailLeft.Add(EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                now i can finally finish my daily
                                rounds and check gTail..."));
            facewoofLeft.Add(EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                now i can finally finish my daily
                                rounds and check facewoof..."));

            e = EventPageSwitch.c(Global.Intro_LastWebsiteSelector).AddEventPage(0, facewoofLeft).AddEventPage(1, reddigLeft).AddEventPage(2, gTailLeft).AddEventPage(3, tumfurLeft);
        }

        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ...");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                EH????????");
        e = EventSFX.c(SFX.Pom_bark);
        e = EventShake.c;
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                THERES NO WI-FI");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                JUST KILL ME NOW");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                WAT DID I EVER DO 2 DESERVE
                                THIS");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                I;M CRY");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                GROSS SOBBING");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                sniff");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                sniff");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                sniff");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ...");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                nows not the time 2 b wallowing
                                in self pity");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                i gotta get up and do something 
                                about this!!");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ye a");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                !!!");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                inspire");
        e = EventTextboxClose.c;
        e = EventPlayerMoveable.c(true);
        #endregion

        #endregion

        #region Field

        //Talking to shibe when you first enter the field
        NewEP("5c0579a0-63db-4383-a307-188f4a0f6645");
        tempEP = new EventPage(); e = EventPageSwitch.c(Global.ShibeIntro).AddEventPage(1, tempEP); ep = tempEP;
        e = EventPlayerMoveable.c(false);
        e = EventSetGlobal.c(Global.IntroGround, 1);
        e = EventSetGlobal.c(Global.ShibeIntro, 3);
        e = EventSetGlobal.c(Global.ShibeTalk, 1);
        e = EventSFX.c(SFX.Medium_Dog1);
        e = EventTextbox.c(Faces.Shibe, @"\C[1]Shibe\C[0]
                                Pom!");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                poopy head!");
        e = EventTextbox.c(Faces.Shibe, @"\C[1]Shibe\C[0]
                                I'm glad you didn't get hurt in
                                the fire!!");
        e = EventTextbox.c(Faces.Shibe, @"\C[1]Shibe\C[0]
                                Do you know where we are?");
        e = EventTextbox.c(Faces.Shibe, @"\C[1]Shibe\C[0]
                                I was waiting outside your room
                                when--");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                uh eXCUSE U???????");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                i AM hurt");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                in da KOKORO!!!!");
        e = EventTextbox.c(Faces.Shibe_uh, @"\C[1]Shibe\C[0]
                                Huh?");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                now help me look for wi-fi");
        e = EventTextbox.c(Faces.Shibe_uh, @"\C[1]Shibe\C[0]
                                What? But...");
        e = EventTextbox.c(Faces.Shibe_uh, @"\C[1]Shibe\C[0]
                                Isn't it more important that we
                                figure out how to get home first?");
        e = EventTextbox.c(Faces.Shibe, @"\C[1]Shibe\C[0]
                                We can worry about the wi-fi
                                later.");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                what the fuk did u just fukkin say 2
                                me u lil bitch");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ur fukkin ded kiddo");
        e = EventTextboxClose.c;
        {
            //TODO: event sequence stuff here with shibe
            e = EventFlashScreen.c(.2f);
            e = EventTextbox.c(Faces.None, "TODO: Battle scenes ( ᐛ )");
        }
        e = EventSetGlobal.c(Global.FlowerField, 1);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                ok shibe");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                from now on ur my manservant");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                i can talk 2 u whenever i want by
                                facing u and pressing da z key");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                also ive changed ur name 2
                                sebastian");
        e = EventTextbox.c(Faces.Shibe_annoyed, @"\C[1]Shibe\C[0]
                                Why the hell am I ''Sebastian''?!");
        e = EventTextbox.c(Faces.None, @"Shibe has joined the party!").DontSlide;
        e = EventTextboxClose.c;
        e = EventSetGlobal.c(Global.ShibeIntro, 3);
        e = EventSetGlobal.c(Global.ShibeTalk, 1);
        e = EventPlayerMoveable.c(true);

        //sakura trees


        #endregion

        #region Flower Field Town

        // Big White Rose
        NewEP("F9794751-D80A-41DA-9888-83E57059A4F1");
        e = EventPlayerMoveable.c(false);
        e = EventTextbox.c(Faces.Shibe, @"\C[1]Shibe\C[0]
                                    This flower is so tall");
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                    If normal roses r Kuroko then
                                    this one is Kagami");
        e = EventTextbox.c(Faces.Shibe_uh, @"\C[1]Shibe\C[0]
                                    ...Sometimes I really can't understand
                                    what you're saying.");
        e = EventTextboxClose.c;
        e = EventPlayerMoveable.c(true);

        // Big Black/Purple Rose
        NewEP("95b58f5e-4227-4d69-97e6-f005ce41f5d4");
        e = EventPlayerMoveable.c(false);
        e = EventTextbox.c(Faces.Pom, @"\C[1]Pom\C[0]
                                    wouldnt it have been funny if garry
                                    had to carry around a rose this big");
        e = EventTextbox.c(Faces.Shibe_annoyed, @"\C[1]Shibe\C[0]
                                    Who the heck is ''Garry''?!");
        e = EventTextboxClose.c;
        e = EventPlayerMoveable.c(true);

        #endregion





        //.. You're done! That's it. The rest of the events are all the pure logic event pages. No more translations that need to be done. :)















        #region Logic Only EventPages

        var allowWalkEP = new EventPage(); allowWalkEP.Add(EventPlayerMoveable.c(true));

        #region Field - Walk-to-Shibe Line

        NewEP("74bb2385-60e2-4347-a5e8-f2bba5a6d98c"); //top
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

        NewEP("330be885-184e-4c81-bb03-58032f0797e9"); //above mid
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

        NewEP("a20c7976-0f55-464a-bc63-d598ca23e448"); //mid
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

        NewEP("647c580b-b0f2-41f8-b551-2d55ba4ee830"); //below mid
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

        NewEP("a5e1dea9-1a38-4bac-9e46-7b6d28575087"); //bottom
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

        #endregion

        #endregion
    }
}







