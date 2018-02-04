using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EventTextbox : _BaseLogicEvent {
    //string faceString;
    Faces shownFace;
    string text;
    bool fromRight = true;
    float timeToSlide = .1f;

    //modifiers
    public EventTextbox DontSlide { get { this.timeToSlide = 0f; return this; } }
    public EventTextbox SwitchSides { get { fromRight = !fromRight; return this; } }

    public static EventTextbox c(Faces shownFace, string text)
    {
        return new EventTextbox(shownFace, text);
    }

    public EventTextbox(Faces shownFace, string text)
    {
        this.shownFace = shownFace;

        if (shownFace == Faces.Pom || shownFace == Faces.Pom_no_laptop || shownFace == Faces.Pom_fire)
            fromRight = !fromRight;

        var stringBuilder = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            if(text[i] == '\n')
            {
                stringBuilder.Append(text[i]);

                while(i+1 < text.Length && text[i+1] == ' ')
                {
                    i++;
                }

                //extra space, oops
                i++;
            }
            
            if(text[i] == '\'' && i+1 < text.Length && text[i+1] == '\'')
            {
                i++;
                stringBuilder.Append("\"");
                continue;
            }

            if(i < text.Length)
                stringBuilder.Append(text[i]);
        }

        var curLanguage = EventPage.supportedLanguageInitializers[Global.ActiveLanguage];
        var namePrefix = "";
        if(shownFace != Faces.None)
        {
            switch(shownFace)
            {
                case Faces.Alma:
                    namePrefix = @"\C[1]" + curLanguage.AlmaName + "\\C[0]\n"; break;
                case Faces.Bernard:
                    namePrefix = @"\C[1]" + curLanguage.BernardName + "\\C[0]\n"; break;
                case Faces.Bold:
                    namePrefix = @"\C[1]" + curLanguage.BoldName + "\\C[0]\n"; break;
                case Faces.Chi:
                case Faces.Chi_nervous:
                    namePrefix = @"\C[1]" + curLanguage.ChiName + "\\C[0]\n"; break;
                case Faces.Corg:
                    namePrefix = @"\C[1]" + curLanguage.CorgName + "\\C[0]\n"; break;
                case Faces.Crest:
                case Faces.Crest_crying:
                    namePrefix = @"\C[1]" + curLanguage.CrestName + "\\C[0]\n"; break;
                case Faces.DavePointer:
                    namePrefix = @"\C[1]" + curLanguage.DavePointerName + "\\C[0]\n"; break;
                case Faces.Dog:
                case Faces.Dog2:
                    namePrefix = @"\C[1]" + curLanguage.DogName + "\\C[0]\n"; break;
                case Faces.Glish:
                    namePrefix = @"\C[1]" + curLanguage.GlishName + "\\C[0]\n"; break;
                case Faces.Goldie:
                    namePrefix = @"\C[1]" + curLanguage.GoldieName + "\\C[0]\n"; break;
                case Faces.Hus:
                case Faces.Hus_angry:
                    namePrefix = @"\C[1]" + curLanguage.HusName + "\\C[0]\n"; break;
                case Faces.Labra:
                    namePrefix = @"\C[1]" + curLanguage.LabraName + "\\C[0]\n"; break;
                case Faces.Malty:
                    namePrefix = @"\C[1]" + curLanguage.Malty + "\\C[0]\n"; break;
                case Faces.Papi:
                    namePrefix = @"\C[1]" + curLanguage.PapiName + "\\C[0]\n"; break;
                case Faces.Pom:
                case Faces.Pom_fire:
                case Faces.Pom_no_laptop:
                    namePrefix = @"\C[1]" + curLanguage.PomName + "\\C[0]\n"; break;
                case Faces.Puddle:
                case Faces.Puddle_angry:
                    namePrefix = @"\C[1]" + curLanguage.PuddleName + "\\C[0]\n"; break;
                case Faces.Sharpeii:
                    namePrefix = @"\C[1]" + curLanguage.SharpeiName + "\\C[0]\n"; break;
                case Faces.Sherman:
                    namePrefix = @"\C[1]" + curLanguage.ShermanName + "\\C[0]\n"; break;
                case Faces.Shibe:
                case Faces.Shibe_annoyed:
                case Faces.Shibe_blush:
                case Faces.Shibe_freaking_out:
                case Faces.Shibe_nervous:
                case Faces.Shibe_uh:
                    namePrefix = @"\C[1]" + curLanguage.ShibeName + "\\C[0]\n"; break;
                case Faces.Ug:
                    namePrefix = @"\C[1]" + curLanguage.UgName + "\\C[0]\n"; break;
                case Faces.WittyFido:
                    namePrefix = @"\C[1]" + curLanguage.WittyFidoName + "\\C[0]\n"; break;
                case Faces.York:
                    namePrefix = @"\C[1]" + curLanguage.YorkName + "\\C[0]\n"; break;
                default:
                    namePrefix = @"\C[1]" + "Names broke, yo" + "\\C[0]\n"; break;
            }
        }

        this.text = namePrefix + stringBuilder.ToString();
    }

    public override IEnumerator Execute()
    {
        var before = Player.playerInstance.AllowMovement;

        var face = shownFace;
        if (face == Faces.Pom && Global.s.PlayerSprite == (int)PlayerSprite.OnFire) face = Faces.Pom_fire;
        TextEngine.instance.InitializeNewSlidein(face, text, fromRight, timeToSlide);

        yield return new WaitUntil(() =>  TextEngine.instance.finishedTextbox);

        Player.playerInstance.AllowMovement = before;
    }

}
