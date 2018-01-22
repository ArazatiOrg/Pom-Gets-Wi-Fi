using System;
using System.Collections;
using System.Collections.Generic;
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
    
    public static SaveFile s { get { return ActiveSafefile; } }
    public static SaveFile ActiveSafefile = new SaveFile();

    [Serializable]
    public class SaveFile
    {
        [SerializeField] public DateTime saveTimestamp;

        [SerializeField] public GlobalInt ActiveBGM = new GlobalInt(-1);
        [SerializeField] public GlobalFloat ActiveBGMVolume = new GlobalFloat(1f);

        [SerializeField] public GlobalFloat PlayerPosX = new GlobalFloat(22.5f); //default position of left of dave pointer, just in case things go fucky
        [SerializeField] public GlobalFloat PlayerPosY = new GlobalFloat(-23f);
        [SerializeField] public GlobalInt PlayerFacing = new GlobalInt(2); //down
        [SerializeField] public GlobalInt PlayerSprite = new GlobalInt(2); //Normal sprite

        //Gamestate Variables
        [SerializeField] public GlobalInt ShibeInParty = new GlobalInt();

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

        void CopyToGlobal()
        {
            ActiveSafefile = this;
        }

        public void Save(int slot)
        {
            var key = "PGWF_Savefile" + slot;
            if (PlayerPrefs.HasKey(key)) PlayerPrefs.DeleteKey(key);

            saveTimestamp = DateTime.Now;
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

    void ResetVariables()
    {
        ActiveSafefile = new SaveFile();
    }

    public static void LoadVariables(int saveSlot)
    {
        if (saveSlot < 0 || saveSlot >= WorldspaceUI.instance.saveSlots) saveSlot = 0;

        SaveFile.Load(saveSlot, ActiveSafefile);
        //ActiveSafefile = WorldspaceUI.instance.saveFiles[saveSlot];

        //world setup based on the new save slots
        Player.playerInstance.transform.position = new Vector3(ActiveSafefile.PlayerPosX.value, ActiveSafefile.PlayerPosY.value);
        Player.playerInstance.SetFacingDirection((SpriteDir)ActiveSafefile.PlayerFacing.value);

        Player.playerInstance.anim.spriteSetIndex = ActiveSafefile.PlayerSprite.value;

        ShibeFollowLogic.instance.transform.position = new Vector3(-44.5f, -21f); //Field, he'll teleport once the player moves

        KeepCameraInBounds.instance.objectToFollow = Player.playerInstance.anim.gameObject;
        
        Player.playerInstance.AllowMovement = true;
    }

    private void Start()
    {
        ResetVariables();

        //starter pos
        s.PlayerPosX.value = Player.playerInstance.transform.position.x;
        s.PlayerPosY.value = Player.playerInstance.transform.position.y;

        s.PlayerFacing.value = (int)Player.playerInstance.facingDir;

        Application.targetFrameRate = 60;

        var defaultFont = TextEngine.instance.text.font;

        EventPage.InitializeTranslations();

        if (EventPage.supportedLanguageInitializers[0].GetType() == typeof(tr_English)) { EventPage.supportedLanguageInitializers[0].font = defaultFont; }

        if (TextEngine.instance != null) TextEngine.instance.UpdateLanguage();
    }

    private void Update()
    {
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
    }

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
