using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEngine : MonoBehaviour {
    public static TextEngine instance;

    Color windowColor = new Color(255f/255f, 67f/255f, 118f/255f);

    Color[] colors = new Color[]
    {
        new Color(254f/255f, 254f/255f, 255f/255f),
        new Color( 43f/255f, 247f/255f, 255f/255f),
        new Color(255f/255f, 250f/255f, 202f/255f),
        new Color(255f/255f, 142f/255f, 173f/255f),
        //Add the rest of the colors if they're needed.. ¯\_(ツ)_/¯
    };

    public GameObject textboxElements;
    public int xOffset = 0;

    public SpriteRenderer introGraphics;
    public Image bgImage;
    public Image face;

    public float faceSlideTime = 0f;
    float faceSlideTimeSetTo = 0f;

    public Text text;

    float waitBetweenCharacters = .001f;
    float curWaitTimeBetweenCharacters = 0f;

    int textIndex;
    int cursorIndex;
    int lineIndex;

    public Image textMaskLine;
    public Image textMaskPartialLine;

    public Image cursorPos;

    public float cursorBlinkToggleRate = .33f;
    float cursorBlinkTimeLeft = 0f;
    public bool cursorEnabled = true;

    public List<Sprite> faces = new List<Sprite>();
    public Sprite emptyTextboxSprite;
    public List<Sprite> pictures = new List<Sprite>();

    public Image selectedSprite;

    public List<Sprite> selectedAnim = new List<Sprite>();

    public float selectedAnimTimeToChange = .5f;
    float selectedAnimTimeLeft = 0f;

    [HideInInspector] public int selectedChoice = 0;
    [HideInInspector] public int maxChoices = 0;
    [HideInInspector] public bool waitingForChoice = false;

    [HideInInspector] public bool waitingForInput = false;
    [HideInInspector] public bool finishedTextbox = false;
    
    float timeSinceOpened = 0f;

    // Use this for initialization
    void Start () {
        instance = this;

        bgImage.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(cursorEnabled)
        {
            cursorBlinkTimeLeft -= Time.smoothDeltaTime;

            if(cursorBlinkTimeLeft < -cursorBlinkToggleRate) cursorBlinkTimeLeft = 0f;

            if(cursorBlinkTimeLeft <= 0f)
            {
                cursorPos.enabled = !cursorPos.enabled;
                cursorBlinkTimeLeft += cursorBlinkToggleRate;
            }
        }

        if (faceSlideTime >= 0f)
        {
            faceSlideTime -= Time.smoothDeltaTime;
            var percentage = faceSlideTime / faceSlideTimeSetTo;

            var pos = Vector3.Lerp(Vector3.zero, new Vector3(xOffset, 0, 0), percentage);

            //snap to the 16 pixel grid
            textboxElements.transform.localPosition = new Vector3(((int)(pos.x * 16) / 16f), ((int)(pos.y * 16) / 16f), 0);

            if (faceSlideTime <= 0f)
            {
                curWaitTimeBetweenCharacters = waitBetweenCharacters;

                textIndex = 0;
                cursorIndex = 0;
                lineIndex = 0;
            }
        }
        else if (lineIndex < 5)
        {
            if(Global.devMode && (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.Backslash)))
            {
                ShowLines(4);

                lineIndex = 5;
                waitingForInput = true;
                UpdateCursorState();

                timeSinceOpened = Time.realtimeSinceStartup;
            }

            curWaitTimeBetweenCharacters -= Time.smoothDeltaTime;

            if (curWaitTimeBetweenCharacters < 0)
            {
                curWaitTimeBetweenCharacters += waitBetweenCharacters;

                while (true)
                {
                    if(textIndex > text.text.Length)
                    {
                        Debug.LogError("Text Length of Zero: " + text.text);
                        break;
                    }

                    var c = text.text[textIndex];
                    if (c == '\n')
                    {
                        lineIndex++;
                        cursorIndex = 0;
                        textIndex++;

                        ShowLines(lineIndex);
                    }
                    else if (c == '<')
                    {
                        do
                        {
                            textIndex++;
                        } while (textIndex < text.text.Length && text.text[textIndex] != '>');
                        textIndex++;
                    }
                    else
                    {
                        ShowCharacters(++cursorIndex);
                        textIndex++;

                        if (text.text.Length <= textIndex)
                        {
                            lineIndex = 5;
                            waitingForInput = true;
                            UpdateCursorState();

                            timeSinceOpened = Time.realtimeSinceStartup;
                        }

                        break;
                    }
                }
            }
        }
            
        if(waitingForInput && (Input.anyKeyDown || (Global.devMode && Input.GetKey(KeyCode.Backslash))) && timeSinceOpened + .05f < Time.realtimeSinceStartup)
        {
            waitingForInput = false;
            finishedTextbox = true;

            UpdateCursorState();
        }

        if(waitingForChoice)
        {
            var selectedObjectOrigin = new Vector3(-0.127f, -55.83619f); //ignore this demon
            selectedAnimTimeLeft -= Time.smoothDeltaTime;

            if(selectedAnimTimeLeft <= 0f)
            {
                selectedAnimTimeLeft += selectedAnimTimeToChange;
                
                selectedSprite.sprite = selectedAnim[selectedSprite.sprite == selectedAnim[0] ? 1 : 0];
            }

            var changeSelected = false;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                changeSelected = true;
                selectedChoice--;

                if (selectedChoice <= -1) selectedChoice = maxChoices - 1;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                changeSelected = true;
                selectedChoice++;

                if (selectedChoice >= maxChoices) selectedChoice = 0;
            }
            if (maxChoices == 0) selectedChoice = 0;

            //move selected choice around
            if (changeSelected)
            {
                selectedSprite.transform.localPosition = selectedObjectOrigin += new Vector3(0f, -16f * selectedChoice);
            }

            //TODO: Proper input for choice selection's input
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z))
            {
                waitingForChoice = false;
                selectedSprite.transform.localPosition = selectedObjectOrigin;
                selectedSprite.enabled = false;
            }
        }

        //window shake
    }

    public void Clear()
    {
        SetFace(Faces.None);
        SetFaceFlipped(false);

        bgImage.sprite = null;
        bgImage.enabled = false;

        NewText(string.Empty);
    }

    public void Hide()
    {
        textboxElements.SetActive(false);
        SetFace(Faces.None);
    }

    public void SetFace(string faceString = "")
    {
        face.enabled = true;

        if (string.IsNullOrEmpty(faceString))
        {
            face.sprite = emptyTextboxSprite;
            return;
        }

        faceString = faceString.ToLower().Trim();
        
        foreach (var f in faces)
        {
            if(f.name.ToLower().Equals(faceString))
            {
                face.sprite = f;
                break;
            }
        }
    }
    public void SetFace(Faces shownFace)
    {
        face.enabled = true;

        if (shownFace == Faces.None) face.sprite = emptyTextboxSprite;
        else face.sprite = faces[(int)shownFace];
    }
    public void SetFaceFlipped(bool flipped)
    {
        var x = Mathf.Abs(face.rectTransform.localScale.x);
        if (flipped) x = -x;
        
        face.rectTransform.localScale = new Vector3(x, face.rectTransform.localScale.y, face.rectTransform.localScale.z);
    }

    public void InitializeNew(Faces shownFace, string text, bool fromRight)
    {
        //SetFace(faceString);
        SetFace(shownFace);
        SetFaceFlipped(!fromRight);

        NewText(text);

        textboxElements.SetActive(true);
    }

    public void InitializeNewSlidein(Faces shownFace, string text, bool fromRight, float timeToSlide)
    {
        if (timeToSlide < 0f) timeToSlide = 0f;

        var curFace = (shownFace == Faces.None ? emptyTextboxSprite : faces[(int)shownFace]);

        if(timeToSlide == 0f || (curFace == face.sprite && ((fromRight && xOffset == 160) || (!fromRight && xOffset == -160))))
        {
            SetFace(shownFace);
            SetFaceFlipped(!fromRight);

            NewText(text);

            textboxElements.SetActive(true);
            
            faceSlideTime = 0f;
            faceSlideTimeSetTo = 1f;

            return;
        }
        else
        {
            InitializeNew(shownFace, text, fromRight);

            xOffset = (fromRight ? 160 : -160);

            textboxElements.transform.localPosition = new Vector3(xOffset, 0, face.rectTransform.localPosition.z);
            faceSlideTime = timeToSlide;
            faceSlideTimeSetTo = timeToSlide;
        }
    }

    public void NewText(string txt)
    {
        timeSinceOpened = Time.realtimeSinceStartup;

        //reset text masks
        ShowLines(0);
        ShowCharacters(0);

        var t = txt.Replace(@"\n", "\n");
        t = t.Replace(@"\c[1]", "<color=#" + ColorUtility.ToHtmlStringRGB(colors[1]) + ">");
        t = t.Replace(@"\C[1]", "<color=#" + ColorUtility.ToHtmlStringRGB(colors[1]) + ">");
        t = t.Replace(@"\c[0]", "</color>");
        t = t.Replace(@"\C[0]", "</color>");
        text.text = t;

        waitingForInput = false;
        finishedTextbox = false;

        cursorBlinkTimeLeft = cursorBlinkToggleRate;

        UpdateCursorState();

        Player.playerInstance.AllowMovement = false;
    }

    public void ShowLines(int lines)
    {
        if(lines >= 0)
        {
            var pos = new Vector2(7.670166f, -170.332f); //I hate that I hardcoded this but WHATEVER, IT'S A PORT
            textMaskLine.rectTransform.offsetMin = new Vector2(pos.x, pos.y - (lines * 16));
            textMaskLine.rectTransform.offsetMax = new Vector2(pos.x + 300, textMaskLine.rectTransform.offsetMin.y + (lines*16));
        }
    }

    public void ShowCharacters(int characters)
    {
        var pos = new Vector2(7.670166f, -170.332f); //Still hardcoded FUCK OFF
        textMaskPartialLine.rectTransform.offsetMin = new Vector2(pos.x, textMaskLine.rectTransform.offsetMin.y - 16);
        textMaskPartialLine.rectTransform.offsetMax = new Vector2(pos.x + (characters * 6), textMaskLine.rectTransform.offsetMin.y + 32);
    }

    public void UpdateCursorState()
    {
        cursorEnabled = waitingForInput;
        cursorPos.enabled = waitingForInput;
    }

    internal void UpdateLanguage()
    {
        text.font = EventPage.supportedLanguageInitializers[Global.ActiveLanguage.value].font;

        //No font found, default to english
        if (text.font == null) text.font = EventPage.supportedLanguageInitializers[0].font;
    }

    public void SetBG(Background background)
    {
        if(background == Background.None)
        {
            bgImage.sprite = null;
            bgImage.enabled = false;
        }
        else
        {
            var i = (int)background;

            if (i >= 4 && i <= 8)
            {
                //Don't look at my hacky code. Shoo :V
                introGraphics.sprite = pictures[i];
            }
            else
            {
                bgImage.sprite = pictures[i];
                bgImage.enabled = true;
            }
        }
    }
}

public enum Background
{
    None = -1,
    Facewoof = 0,
    gTail,
    Reddig,
    Tumfur,
    Intro,
    IntroFire1,
    IntroFire2,
    IntroFire3,
    IntroNight,
    Funyarinpa
}

public enum Faces
{
    Alma,
    Bernard,
    Bold,
    Chi,
    Chi_nervous,
    Corg,
    Crest,
    Crest_crying,
    DavePointer,
    Dog,
    Dog2,
    Glish,
    Goldie,
    Hus_angry,
    Hus,
    Labra,
    Malti,
    Papi,
    Pom,
    Pom_fire,
    Pom_no_laptop,
    Puddle,
    Puddle_angry,
    Sharpeii,
    Sherman,
    Shibe_blush,
    Shibe_uh,
    Shibe_annoyed,
    Shibe_freaking_out,
    Shibe_nervous,
    Shibe,
    Ug,
    WittyFido,
    York,
    None
}
