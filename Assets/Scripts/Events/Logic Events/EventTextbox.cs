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
    public EventTextbox SwitchSides { get { fromRight = false; return this; } }

    public static EventTextbox c(Faces shownFace, string text)
    {
        return new EventTextbox(shownFace, text);
    }

    public EventTextbox(Faces shownFace, string text)
    {
        this.shownFace = shownFace;

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

            if(text[i] == '\'' && text[i+1] == '\'')
            {
                i++;
                stringBuilder.Append("\"");
                continue;
            }

            if(i < text.Length)
                stringBuilder.Append(text[i]);
        }

        this.text = stringBuilder.ToString();
    }

    public override IEnumerator Execute()
    {
        if ((shownFace == Faces.Pom || shownFace == Faces.Pom_no_laptop || shownFace == Faces.Pom_fire))
            fromRight = !fromRight;

        var before = Player.playerInstance.AllowMovement;
        
        TextEngine.instance.InitializeNewSlidein(shownFace, text, fromRight, timeToSlide);

        yield return new WaitUntil(() =>  TextEngine.instance.finishedTextbox);

        Player.playerInstance.AllowMovement = before;
    }

}
