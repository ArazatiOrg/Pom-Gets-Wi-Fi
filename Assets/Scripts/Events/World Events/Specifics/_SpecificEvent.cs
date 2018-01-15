using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _SpecificEvent : _BaseEvent
{
    List<EventPage> eventPages;
    Guid guid;

    public string Guid;

    public override IEnumerator TriggeredEvent(GameObject triggeredBy)
    {
        if (transform.parent != null)
        {
            transform.parent.SendMessage("LookAt", triggeredBy, SendMessageOptions.DontRequireReceiver);
        }

        if (eventPages == null)
        {
            guid = new Guid(Guid);
            if (EventPage.eventPages.ContainsKey(guid)) eventPages = EventPage.eventPages[guid];
        }

        if (eventPages != null)
        {
            var eventPage = eventPages[Global.ActiveLanguage.value];

            if (eventPage == null)
            {
                Debug.LogError("Object does not have an event page for active language " + Global.ActiveLanguage + "!", gameObject);
            }
            else
            {
                for (int i = 0; i < eventPage.events.Count; i++)
                {
                    yield return eventPage.events[i].Execute();
                }
            }
        }
        else
        {
            Debug.LogError("Object's events never registered.", gameObject);
        }
    }
    
    override public void Update()
    {
        base.Update();

        if (Application.isEditor && !Application.isPlaying)
        {
            if (string.IsNullOrEmpty(Guid))
            {
                guid = System.Guid.NewGuid();
                Guid = guid.ToString();
                Debug.Log("Setting GUID for new event- " + name + " - " + Guid);
            }

            return;
        }
    }
}