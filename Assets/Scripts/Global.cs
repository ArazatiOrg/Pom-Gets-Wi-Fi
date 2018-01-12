using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stop that, don't shame me. I'm just porting the game. I don't intend people to -actually- make their own stuff with this in the future. :V

public class Global : MonoBehaviour {
    //TODO: set this to false for normal mode..
    public static bool devMode = true;

    private static GlobalInt _activeLanguage = new GlobalInt(0); //english is 0
    public static GlobalInt ActiveLanguage
    {
        get { return _activeLanguage; }
        set {
            var firstEnglish = EventPage.supportedLanguageInitializers[0].GetType() == typeof(tr_English);
            if (value > 0 && (value < EventPage.supportedLanguageInitializers.Count || !firstEnglish))
            {
                _activeLanguage = value;
                
                if(TextEngine.instance != null) TextEngine.instance.UpdateLanguage();

                Debug.Log("Setting language to: " + EventPage.supportedLanguageInitializers[value - (firstEnglish ? 0 : 1)].TranslationName + " (" + value + ")");
            }
        }
    }
    
    public static GlobalInt ActiveBGM = new GlobalInt(-1);
    public static GlobalFloat ActiveBGMVolume = new GlobalFloat(1f);

    public static GlobalFloat PlayerPosX = new GlobalFloat();
    public static GlobalFloat PlayerPosY = new GlobalFloat();

    //Gamestate Variables
    public static GlobalInt ShibeInParty = new GlobalInt();

    public static GlobalInt Intro = new GlobalInt();
    public static GlobalBool Intro_Facewoof = new GlobalBool();
    public static GlobalBool Intro_Reddig = new GlobalBool();
    public static GlobalBool Intro_gTail = new GlobalBool();
    public static GlobalBool Intro_Tumfur = new GlobalBool();
    public static GlobalInt Intro_LastWebsiteSelector = new GlobalInt();

    public static GlobalInt IntroGround = new GlobalInt();
    public static GlobalInt ShibeIntro = new GlobalInt();
    public static GlobalInt ShibeTalk = new GlobalInt();

    public static GlobalInt FlowerField = new GlobalInt();
    public static GlobalInt Silent_Treatment = new GlobalInt();
    public static GlobalInt Cherry_Blossoms = new GlobalInt();

    private void Start()
    {
        //starter pos
        PlayerPosX.value = Player.playerInstance.transform.position.x;
        PlayerPosY.value = Player.playerInstance.transform.position.y;

        Application.targetFrameRate = 60;

        var defaultFont = TextEngine.instance.text.font;

        EventPage.InitializeTranslations();

        if (EventPage.supportedLanguageInitializers[0].GetType() == typeof(tr_English)) { EventPage.supportedLanguageInitializers[0].font = defaultFont; }

        if (TextEngine.instance != null) TextEngine.instance.UpdateLanguage();

        //TODO: save/load stuff for globals
    }

    private void Update()
    {

        
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            _activeLanguage.value++;

            if (_activeLanguage.value == EventPage.supportedLanguageInitializers.Count)
                _activeLanguage.value = 0;

            Debug.Log("Setting language to: " + EventPage.supportedLanguageInitializers[_activeLanguage.value].TranslationName + " (" + _activeLanguage + ")");
        }
        
    }

    public class GlobalInt
    {
        public int value;

        public GlobalInt(int value = 0)
        {
            this.value = value;
        }

        public static implicit operator int(GlobalInt i)
        {
            return i.value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
    public class GlobalFloat
    {
        public float value;

        public GlobalFloat(float value = 0f)
        {
            this.value = value;
        }

        public static implicit operator float(GlobalFloat i)
        {
            return i.value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
    public class GlobalBool
    {
        public bool value;

        public GlobalBool(bool value = false)
        {
            this.value = value;
        }

        public static implicit operator bool(GlobalBool i)
        {
            return i.value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
