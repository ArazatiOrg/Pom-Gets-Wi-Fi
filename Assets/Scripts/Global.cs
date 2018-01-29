using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

//Stop that, don't shame me. I'm just porting the game. I don't intend people to -actually- make their own stuff with this in the future. :V

public class Global : MonoBehaviour {
    //TODO: set this to false for normal mode..
    public static bool devMode = true;

    private static GlobalInt _activeLanguage = new GlobalInt(); //english is 0
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
            PlayerPrefs.SetInt("ActiveLanguage", _activeLanguage.value);
            PlayerPrefs.Save();
        }
    }
    
    public static SaveFile s { get { return ActiveSavefile; } }
    public static SaveFile ActiveSavefile;

    [Serializable]
    public class SaveFile
    {
        [SerializeField] public long saveTimestamp; //UTC ticks
        [SerializeField] public string saveVersion;

        [SerializeField] public GlobalInt ActiveBGM = new GlobalInt(-1);
        [SerializeField] public GlobalFloat ActiveBGMVolume = new GlobalFloat(1f);

        [SerializeField] public GlobalFloat PlayerPosX = new GlobalFloat(22.5f); //default position of left of dave pointer, just in case things go fucky
        [SerializeField] public GlobalFloat PlayerPosY = new GlobalFloat(-23f);
        [SerializeField] public GlobalInt PlayerFacing = new GlobalInt(2); //down
        [SerializeField] public GlobalInt PlayerSprite = new GlobalInt(2); //Normal sprite

        //Gamestate Variables
        [SerializeField] public GlobalInt ShibeInParty = new GlobalInt();
        [SerializeField] public GlobalInt ShibeAbleToFollow = new GlobalInt(1);

        [SerializeField] public GlobalInt Intro = new GlobalInt();
        [SerializeField] public GlobalBool Intro_Facewoof = new GlobalBool();
        [SerializeField] public GlobalBool Intro_Reddig = new GlobalBool();
        [SerializeField] public GlobalBool Intro_gTail = new GlobalBool();
        [SerializeField] public GlobalBool Intro_Tumfur = new GlobalBool();
        [SerializeField] public GlobalInt Intro_LastWebsiteSelector = new GlobalInt();

        [SerializeField] public GlobalInt IntroGround = new GlobalInt();
        [SerializeField] public GlobalInt ShibeIntro = new GlobalInt();
        [SerializeField] public GlobalInt ShibeTalk = new GlobalInt();

        [SerializeField] public GlobalInt FlowerField = new GlobalInt();
        [SerializeField] public GlobalInt Silent_Treatment = new GlobalInt();
        [SerializeField] public GlobalInt Cherry_Blossoms = new GlobalInt();

        //Town
        [SerializeField] public GlobalInt DavePointer = new GlobalInt();
        [SerializeField] public GlobalInt CrestStalkFest = new GlobalInt();
        [SerializeField] public GlobalInt PapiTalk = new GlobalInt();

        [SerializeField] public GlobalInt HasFamicom = new GlobalInt();
        [SerializeField] public GlobalInt GoldieTalk = new GlobalInt();

        //Sharpei's House
        [SerializeField] public GlobalInt Funyarinpa = new GlobalInt();
        [SerializeField] public GlobalInt SharpeiTalk = new GlobalInt();

        [SerializeField] public GlobalInt Rocket = new GlobalInt();
        [SerializeField] public GlobalInt JunkPile = new GlobalInt();

        [SerializeField] public GlobalInt RootBeer = new GlobalInt();
        [SerializeField] public GlobalInt CorgKeys = new GlobalInt();

        [SerializeField] public GlobalInt MachineChecked = new GlobalInt();

        [SerializeField] public GlobalInt YorkTalk = new GlobalInt();

        //Park
        [SerializeField] public GlobalInt ChiTalk = new GlobalInt();
        [SerializeField] public GlobalInt StoneBlockSearch = new GlobalInt();
        [SerializeField] public GlobalInt ParkState = new GlobalInt(); //0 = none, 1 = coming back from grass, 2 = fixed
        [SerializeField] public GlobalInt ExtraParkPartyMember = new GlobalInt(); //0 = none, 1 = hus, 2 = chi
        [SerializeField] public GlobalInt LabraAlmaTalk = new GlobalInt();
        [SerializeField] public GlobalInt PuddleTalk = new GlobalInt();
        [SerializeField] public GlobalInt CrestTalk = new GlobalInt();
        [SerializeField] public GlobalInt ShermanTalk = new GlobalInt();

        [SerializeField] public GlobalInt HasDolphie = new GlobalInt();
        [SerializeField] public GlobalInt Blessing = new GlobalInt();

        //Frisbee Machine
        [SerializeField] public GlobalInt DustBunny = new GlobalInt();
        [SerializeField] public GlobalInt CityEscape = new GlobalInt();

        //Observatory
        [SerializeField] public GlobalInt Observatory = new GlobalInt();

        //Starpugs
        [SerializeField] public GlobalInt UgTalk = new GlobalInt();
        [SerializeField] public GlobalInt BernardTalk = new GlobalInt();
        [SerializeField] public GlobalInt MaltyTalk = new GlobalInt();
        [SerializeField] public GlobalInt CorgTalk = new GlobalInt();
        [SerializeField] public GlobalInt BadEnd = new GlobalInt();
        [SerializeField] public GlobalInt WittyFidoTalk = new GlobalInt();

        [SerializeField] public GlobalInt StopPom = new GlobalInt();

        public void Save(int slot)
        {
            var key = "PGWF_Savefile" + slot;
            if (PlayerPrefs.HasKey(key)) PlayerPrefs.DeleteKey(key);

            saveTimestamp = DateTime.UtcNow.Ticks;
            saveVersion = "v" + Application.version + " - Last Built: " + BuildtimeInfo.DateTimeString();

            PlayerSprite.value = Player.playerInstance.anim.spriteSetIndex;
            
            PlayerPrefs.SetString(key, JsonUtility.ToJson(this));
            PlayerPrefs.Save();
        }

        public static SaveFile Load(int slot, SaveFile overwrite)
        {
            var key = "PGWF_Savefile" + slot;
            if (PlayerPrefs.HasKey(key))
            {
                if (overwrite == null) overwrite = new SaveFile();
                JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), overwrite);
                
                return overwrite;
            }

            return null;
        }
    }

    public static bool loadedData = false;
    void ResetVariables()
    {
        if(!loadedData || ActiveSavefile == null) ActiveSavefile = new SaveFile();
    }

    public static void LoadVariables(int saveSlot)
    {
        if (saveSlot < 0 || saveSlot >= WorldspaceUI.instance.saveSlots) saveSlot = 0;

        if(!loadedData)
            SaveFile.Load(saveSlot, ActiveSavefile);
        //ActiveSafefile = WorldspaceUI.instance.saveFiles[saveSlot];

        //world setup based on the new save slots
        if(ActiveSavefile.PlayerPosX >= -23f && ActiveSavefile.PlayerPosX <= -17f && ActiveSavefile.PlayerPosY >= -3f && ActiveSavefile.PlayerPosY <= 5f) { ActiveSavefile.PlayerPosX.value = 22.5f; ActiveSavefile.PlayerPosY.value = -23f; }
        Player.playerInstance.transform.position = new Vector3(ActiveSavefile.PlayerPosX.value, ActiveSavefile.PlayerPosY.value);
        Player.playerInstance.SetFacingDirection((SpriteDir)ActiveSavefile.PlayerFacing.value);

        Player.playerInstance.anim.spriteSetIndex = ActiveSavefile.PlayerSprite.value;

        ShibeFollowLogic.instance.transform.position = new Vector3(-44.5f, -21f); //Field, he'll teleport once the player moves

        KeepCameraInBounds.instance.objectToFollow = Player.playerInstance.anim.gameObject;

        if (ActiveSavefile.ActiveBGM == -1) //none
        {
            AudioController.instance.bgmSource.Stop();
        }
        else AudioController.instance.PlayBGM(ActiveSavefile.ActiveBGM, ActiveSavefile.ActiveBGMVolume);
        
        EventPositioner.CheckPositions();

        Player.playerInstance.AllowMovement = true;

        loadedData = false;
    }

    private void Start()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            try
            {
                GameControlReady();
            }
            catch (Exception e) { Debug.Log("GameCanvas Error: " + e.Message); }
        #endif

        if (AudioController.instance.bgmSource.clip == null && !loadedData)
            AudioController.instance.PlayBGM((int)BGM.Memories, .4f);

        ResetVariables();

        if (!loadedData)
        {
            //starter pos
            s.PlayerPosX.value = Player.playerInstance.transform.position.x;
            s.PlayerPosY.value = Player.playerInstance.transform.position.y;

            s.PlayerFacing.value = (int)Player.playerInstance.facingDir;
        }

        Application.targetFrameRate = 60;

        var defaultFont = TextEngine.instance.text.font;

        EventPage.InitializeTranslations();

        if (EventPage.supportedLanguageInitializers[0].GetType() == typeof(tr_English)) { EventPage.supportedLanguageInitializers[0].font = defaultFont; }

        if (TextEngine.instance != null) TextEngine.instance.UpdateLanguage();
    }
    
    public void WebGLConsumeInput(int p_focus)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
            UnityEngine.WebGLInput.captureAllKeyboardInput = p_focus == 1;
#endif
    }

    public static bool changedVariables = false;
    private void Update()
    {
        if (InputController.JustPressed(Action.DEBUG_SaveState))
        {
            ActiveSavefile.saveTimestamp = DateTime.UtcNow.Ticks;
            ActiveSavefile.saveVersion = "v" + Application.version + " - Last Built: " + BuildtimeInfo.DateTimeString();

            var data = JsonUtility.ToJson(ActiveSavefile);

            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                DebugInfo.debugText = "Save Data: Setting text area to: " + data;


                LoadArea_SetText(data);
            }
            else
            {
                DebugInfo.debugText = "Clipboard set to Save Data: " + data;
                GUIUtility.systemCopyBuffer = data;
            }
        }

        if(changedVariables)
        {
            EventPositioner.CheckPositions();
            changedVariables = false;
        }

        //rest require devMode to be enabled
        if (!devMode) return;
        
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            var val = _activeLanguage.value + 1;

            if (val == EventPage.supportedLanguageInitializers.Count)
                val = 0;

            ActiveLanguage = new GlobalInt(val);
        }
        
        if(Input.GetKeyDown(KeyCode.F5))
        {
            ResetLevel();
        }

        if(Input.GetKeyDown(KeyCode.PageDown))
        {
            var s = Application.platform == RuntimePlatform.WebGLPlayer ? LoadArea_GetText() : GUIUtility.systemCopyBuffer;
            DebugInfo.debugText = "Attempting to load Save Data from Clipboard... ";

            loadedData = true;
            ActiveSavefile = new SaveFile();
            try
            {
                JsonUtility.FromJsonOverwrite(s, ActiveSavefile);
            }
            catch(Exception e)
            {
                DebugInfo.debugText = "Invalid Save Data.";
            }
            ResetLevel();
        }
    }

    [DllImport("__Internal")]
    private static extern void LoadArea_SetText(string str);

    [DllImport("__Internal")]
    private static extern string LoadArea_GetText();

    [DllImport("__Internal")]
    private static extern void GameControlReady();

    public void ResetLevel()
    {
        EventPage.eventPages = new Dictionary<Guid, List<EventPage>>();
        EventPage.supportedLanguageInitializers = new List<_BaseTR>();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [Serializable] public class GlobalInt
    {
        [SerializeField] public int value;

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
    [Serializable] public class GlobalFloat
    {
        [SerializeField] public float value;

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
    [Serializable] public class GlobalBool
    {
        [SerializeField] public bool value;

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
