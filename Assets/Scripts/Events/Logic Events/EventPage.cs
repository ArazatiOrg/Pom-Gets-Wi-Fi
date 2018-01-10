using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EventPage
{
    #region Static
    public static Dictionary<Guid, List<EventPage>> eventPages;
    public static List<_BaseTR> supportedLanguageInitializers = new List<_BaseTR>();

    static EventPage()
    {
        eventPages = new Dictionary<Guid, List<EventPage>>();
    }
    
    public static int RegisterTranslation(_BaseTR behaviour)
    {
        if(behaviour is tr_English)
        {
            if (!supportedLanguageInitializers.Contains(behaviour)) supportedLanguageInitializers.Insert(0, behaviour);

            return 0;
        }
        else
        {
            if (!supportedLanguageInitializers.Contains(behaviour)) supportedLanguageInitializers.Add(behaviour);

            if (supportedLanguageInitializers[0].GetType() == typeof(tr_English)) return supportedLanguageInitializers.Count - 1;
            else return supportedLanguageInitializers.Count;
        }
    }

    public static void InitializeTranslations()
    {
        foreach (var lang in supportedLanguageInitializers)
        {
            lang.Initialize();
        }
    }

    public static EventPage GetEventPage(int langRegisterCode, string uniqueIdentifier)
    {
        var guid = new Guid(uniqueIdentifier);

        if(!eventPages.ContainsKey(guid))
        {
            if(langRegisterCode == 0)
            {
                //this is english, unless someone fucked up hard

                eventPages.Add(guid, new List<EventPage>());
            }
            else
            {
                Debug.LogError("GUID " + guid + " - Not an existing event. Did you mess up the GUID?");
                return new EventPage();
            }
        }

        var pages = eventPages[guid];

        if (pages.Count <= langRegisterCode)
            pages.Add(new EventPage());
        
        return pages[langRegisterCode];
    }
    #endregion

    public List<_BaseLogicEvent> events = new List<_BaseLogicEvent>();

    public void Add(_BaseLogicEvent ev)
    {
        events.Add(ev);
    }
}
