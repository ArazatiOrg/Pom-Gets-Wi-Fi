﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;

public class EventTextboxChoice : _BaseLogicEvent {
    List<ChoiceSet> sets = new List<ChoiceSet>();

    public static EventTextboxChoice c
    {
        get
        {
            return new EventTextboxChoice();
        }
    }
    
    public EventTextboxChoice AddText(string text)
    {
        sets.Add(new ChoiceSet() { text = text });
        return this;
    }

    public EventTextboxChoice AddChoice(string text, EventPage tiedEvent, Global.GlobalBool variableShown = null)
    {
        sets.Add(new ChoiceSet() { text = text, eventPage = tiedEvent, willShow = variableShown });

        return this;
    }

    public override IEnumerator Execute()
    {
        TextEngine.instance.text.text = "";
        TextEngine.instance.choiceHasText = false;

        var usedItems = new List<ChoiceSet>();

        foreach (var item in sets)
        {
            if (item.willShow == null || !item.willShow.value)
            {
                if (item.eventPage == null)
                {
                    TextEngine.instance.text.text += item.text + "\n";
                    TextEngine.instance.choiceHasText = true;
                }
                else
                {
                    TextEngine.instance.text.text += "  " + item.text + "\n";
                    usedItems.Add(item);
                }
            }
        }
        
        TextEngine.instance.ShowLines(4);
        TextEngine.instance.selectedChoice = 0;
        TextEngine.instance.maxChoices = usedItems.Count;
        TextEngine.instance.selectedSprite.enabled = true;
        TextEngine.instance.waitingForChoice = true;
        TextEngine.instance.waitingForInput = false;
        TextEngine.instance.finishedTextbox = false;
        TextEngine.instance.textboxElements.SetActive(true);
        TextEngine.instance.UpdateCursorState();

        yield return new WaitUntil(() => !TextEngine.instance.waitingForChoice);

        var ep = usedItems[TextEngine.instance.selectedChoice].eventPage.events;
        if (ep != null)
        {
            for (int i = 0; i < ep.Count; i++)
            {
                yield return ep[i].Execute();
            }
        }
        
        yield return null;
    }

    class ChoiceSet
    {
        public string text;
        public EventPage eventPage;
        public Global.GlobalBool willShow;
    }
}
