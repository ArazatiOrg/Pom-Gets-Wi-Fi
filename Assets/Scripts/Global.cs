using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Stop that, don't shame me. I'm just porting the game. I don't intend people to -actually- make their own stuff with this in the future. :V

public class Global : MonoBehaviour {
    //TODO: set this to false for normal mode..
    public static bool devMode = true;

    private static GlobalInt _activeLanguage; //english is 0
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
    
    public static GlobalInt ActiveBGM;
    public static GlobalFloat ActiveBGMVolume;

    public static GlobalFloat PlayerPosX;
    public static GlobalFloat PlayerPosY;

    //Gamestate Variables
    public static GlobalInt ShibeInParty;

    public static GlobalInt Intro;
    public static GlobalBool Intro_Facewoof;
    public static GlobalBool Intro_Reddig;
    public static GlobalBool Intro_gTail;
    public static GlobalBool Intro_Tumfur;
    public static GlobalInt Intro_LastWebsiteSelector;

    public static GlobalInt IntroGround;
    public static GlobalInt ShibeIntro;
    public static GlobalInt ShibeTalk;

    public static GlobalInt FlowerField;
    public static GlobalInt Silent_Treatment;
    public static GlobalInt Cherry_Blossoms;

    void ResetVariables()
    {
        _activeLanguage = new GlobalInt(0);

        ActiveBGM = new GlobalInt(-1);
        ActiveBGMVolume = new GlobalFloat(1f);

        PlayerPosX = new GlobalFloat();
        PlayerPosY = new GlobalFloat();

        ShibeInParty = new GlobalInt() { name = "ShibeInParty" };

        Intro = new GlobalInt() { name = "Intro" };
        Intro_Facewoof = new GlobalBool() { name = "Intro_FaceWoof" };
        Intro_Reddig = new GlobalBool() { name = "Intro_Reddig" };
        Intro_gTail = new GlobalBool() { name = "Intro_gTail" };
        Intro_Tumfur = new GlobalBool() { name = "Intro_Tumfur" };
        Intro_LastWebsiteSelector = new GlobalInt() { name = "Intro_LastWebsiteSelector" };

        IntroGround = new GlobalInt() { name = "IntroGround" };
        ShibeIntro = new GlobalInt() { name = "ShibeIntro" };
        ShibeTalk = new GlobalInt() { name = "ShibeTalk" };

        FlowerField = new GlobalInt() { name = "FlowerField" };
        Silent_Treatment = new GlobalInt() { name = "Silent_Treatment" };
        Cherry_Blossoms = new GlobalInt() { name = "Cherry_Blossoms" };
}

    private void Start()
    {
        ResetVariables();

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
        if (!devMode) return;
        
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            _activeLanguage.value++;

            if (_activeLanguage.value == EventPage.supportedLanguageInitializers.Count)
                _activeLanguage.value = 0;

            Debug.Log("Setting language to: " + EventPage.supportedLanguageInitializers[_activeLanguage.value].TranslationName + " (" + _activeLanguage + ")");
        }
        
        if(Input.GetKeyDown(KeyCode.F5))
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        EventPage.eventPages = new Dictionary<System.Guid, List<EventPage>>();
        EventPage.supportedLanguageInitializers = new List<_BaseTR>();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public class GlobalInt
    {
        public int value;
        public string name = "Unknown GlobalInt";

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

        public string Name
        {
            get { return name; }
        }
    }
    public class GlobalFloat
    {
        public float value;
        public string name = "Unknown GlobalFloat";

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

        public string Name
        {
            get { return name; }
        }
    }
    public class GlobalBool
    {
        public bool value;
        public string name = "Unknown GlobalBool";

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

        public string Name
        {
            get { return name; }
        }
    }
}
